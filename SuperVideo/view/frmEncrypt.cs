using Ruihit.Controls;
using Ruihit.Ffmpeg;
using SuperVideo.common;
using SuperVideo.entity;
using SuperVideo.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVideo.view
{
    public partial class frmEncrypt : RStyleBaseForm
    {
        public event OnStart OnStart;
        public event OnProgress OnProgress;
        public event OnError OnError;
        public event OnFinished OnFinished;
        public event OnNewVideo OnNewVideo;

        private bool IsStopped = false;
        private bool IsRunning = false;

        public string Category { get; set; }
        private string TargetFile = "";
        private string password = "";

        public frmEncrypt()
        {
            InitializeComponent();
            MinimizeBox = false;
            this.OnStart += frmEncrypt_OnStart;
            this.OnFinished += frmEncrypt_OnFinished;
            this.OnProgress += frmEncrypt_OnProgress;
            this.OnError += frmEncrypt_OnError;
        }

        private void frmEncrypt_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnOpen, "打开文件");
            toolTip1.SetToolTip(trackBar, "拖拽滑块截取视频缩略图");
            toolTip1.SetToolTip(picThumb, "视频缩略图");

            string[] categories = { frmMain.DEFAULT_CATEGORY, 
                                      "剧情片", "喜剧片", "家庭片", 
                                      "爱情片", "动作片", "战争片", 
                                      "悬疑片", "惊悚片", "恐怖片", 
                                      "武侠片", "古装片", "历史片",
                                      "科幻片", "传记片", "体育片",
                                      "文艺片", "动画片", "动漫片",
                                      "纪录片", "伦理片", "收藏片" };
            cmbCategory.Items.AddRange(categories);
            int index = cmbCategory.FindString(Category);
            if (index == -1) index = 0;
            cmbCategory.SelectedIndex = index;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cmbCategory.Invalidate();
        }

        private void frmEncrypt_OnStart(long length)
        {
            Invoke(new Action(() =>
            {
                progressBar1.Maximum = 100;
                progressBar1.Minimum = 0;
            }));
        }

        private void frmEncrypt_OnError(string error)
        {
            Logger.Error("加密错误:{0}", error);
        }

        private void frmEncrypt_OnProgress(int progress)
        {
            if (progress % 10 == 0)
            {
                Logger.Info("文件加密进度：{0}", progress);
            }
            Invoke(new Action(() => { progressBar1.Value = progress; }));
        }

        private void frmEncrypt_OnFinished()
        {
            Logger.Info("--加密完成--");
            Invoke(new Action(() =>
            {
                btnEncrypt.Enabled = true;
                btnCancle.Enabled = false;
                panel1.Enabled = true;

                PopWindow.Information("视频加密完成！", "系统提示", this);

                if (chkDelete.Checked)
                {
                    string msg = string.Format("是否要删除【{0}】？", Path.GetFileName(txtFileName.Text));
                    if (PopWindow.Question(msg, "系统提示", this) == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(txtFileName.Text);
                        }
                        catch { }
                    }
                }

                if (OnNewVideo != null) OnNewVideo(txtFileName.Text, TargetFile);
            }));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MP4 文件 (*.mp4)|*.mp4|视频剪辑 (*.avi)|*.avi|MKV 文件 (*.mkv)|*.mkv" +
                         "|Rmvb 文件 (*.rmvb)|*.rmvb|WMV 文件 (*.wmv)|*.wmv|FLV 文件 (*.flv)|*.flv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
                picThumb.Image = null;

                long size = new FileInfo(ofd.FileName).Length;
                string formatSize = FileUtility.GetFileSize(size);
                labSize.Text = string.Format("大小：{0}", formatSize);

                string d = FFmpegUtility.GetDuration(ofd.FileName);
                labTime.Text = string.Format("时长：{0}", d);

                trackBar.Minimum = 1;
                trackBar.Maximum = GetDurationInt(d);
                trackBar.Value = 1;
                password = "";
                int len = trackBar.Maximum > 10 ? 10 : 1;
                picThumb.Image = FFmpegUtility.GetVideoThumbnail(ofd.FileName, len);
            }
        }

        private int GetDurationInt(string duration)
        {
            TimeSpan ts = TimeSpan.Parse(duration);
            int sec = (int)(ts.Ticks / 10000000L);
            //if (sec > 600) sec = 600;
            return sec;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtFileName.TextLength == 0)
            {
                txtFileName.Focus();
                return;
            }

            if (txtPassword.TextLength == 0)
            {
                if (PopWindow.Question("你没有设置视频查看密码，是否继续？") == DialogResult.No)
                {
                    return;
                }
            }

            if (!File.Exists(txtFileName.Text))
            {
                PopWindow.Warnning("文件不存在！");
                return;
            }

            password = new PasswordManegment(txtPassword.Text).Password;
            Category = cmbCategory.Text;
            btnEncrypt.Enabled = false;
            panel1.Enabled = false;
            btnCancle.Enabled = true;
            string filename = txtFileName.Text;
            TargetFile = frmMain.VideoDir + cmbCategory.Text + "\\" + Path.GetFileName(filename);
            if (!Directory.Exists(frmMain.VideoDir + cmbCategory.Text))
            {
                Directory.CreateDirectory(frmMain.VideoDir + cmbCategory.Text);
            }
            Logger.Info("--开始加密--");
            Logger.Info("{0}->{1}", txtFileName.Text, TargetFile);
            Encrypt(password, filename, TargetFile);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (PopWindow.Question("你确定要取消加密吗？") == DialogResult.Yes)
            {
                btnCancle.Enabled = false;
                IsStopped = true;
            }
        }

        private void Encrypt(string key, string filename, string outfile)
        {
            new Thread(() =>
            {
                IsRunning = true;

                int tmp = 0, pro = 0;
                long total = 0;
                long finished = 0;
                try
                {
                    SaveThumbnail(filename);

                    FileStream fsr = new FileStream(filename, FileMode.Open);
                    FileStream fout = new FileStream(outfile, FileMode.OpenOrCreate);

                    total = fsr.Length;
                    if (OnStart != null) OnStart(total);

                    byte[] readBytes = new byte[HttpServer.BufferSize];
                    int len = 0;
                    while ((len = fsr.Read(readBytes, 0, readBytes.Length)) != 0)
                    {
                        finished += len;

                        if (IsStopped)
                        {
                            Logger.Warn("用户取消加密进程");
                            break;
                        }
                        if (len < HttpServer.BufferSize)
                        {
                            byte[] rest = new byte[len];
                            Array.Copy(readBytes, rest, len);
                            byte[] en = SecurityUtils.AesEncrypt(key, rest);
                            fout.Write(en, 0, en.Length);
                        }
                        else
                        {
                            byte[] en = SecurityUtils.AesEncrypt(key, readBytes);
                            fout.Write(en, 0, en.Length);
                        }

                        //
                        tmp = (int)(finished * 100 / total);
                        if (pro < tmp)
                        {
                            pro = tmp;
                            if (OnProgress != null) OnProgress(pro);
                        }
                    }
                    fsr.Close();
                    fout.Close();
                }
                catch (Exception ex)
                {
                    if (OnError != null) OnError(ex.Message);
                }
                IsRunning = false;
                if (OnFinished != null) OnFinished();
            }).Start();
        }

        private void SaveThumbnail(string filename)
        {
            if (picThumb.Image != null)
            {
                string thunbFile = Path.Combine(frmMain.VideoDir + Category + "\\thumb\\",
                    Path.GetFileNameWithoutExtension(filename) + ".jpg");
                if (!Directory.Exists(frmMain.VideoDir + Category + "\\thumb\\"))
                {
                    Directory.CreateDirectory(frmMain.VideoDir + Category + "\\thumb\\");
                }
                picThumb.Image.Save(thunbFile);
            }
        }

        private void frmEncrypt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsRunning)
            {
                e.Cancel = true;
                PopWindow.Warnning("正在加密，请稍后 。。。");
            }
        }

        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            picThumb.Image = null;
            picThumb.Image = FFmpegUtility.GetVideoThumbnail(txtFileName.Text, trackBar.Value);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)0x4e00) && (e.KeyChar <= (char)0x9fa5))
            {
                e.Handled = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            labLen.Text = (16 - txtPassword.TextLength).ToString();
        }
    }
}
