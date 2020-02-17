using Ruihit.Controls;
using Ruihit.Ffmpeg;
using SuperVideo.common;
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
    public partial class frmConvert : RStyleBaseForm
    {
        private VideoConvert convert;
        private bool IsRunning = false;

        public frmConvert()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            Invalidate();
            convert = new VideoConvert();
            convert.OnStart += convert_OnStart;
            convert.OnProgress += convert_OnProgress;
            convert.OnError += convert_OnError;
            convert.OnMessage += convert_OnMessage;
            convert.OnFinished += convert_OnFinished;
            convert.OnCancel += convert_OnCancel;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MP4 文件 (*.mp4)|*.mp4|视频剪辑 (*.avi)|*.avi|MKV 文件 (*.mkv)|*.mkv" +
                         "|Rmvb 文件 (*.rmvb)|*.rmvb|WMV 文件 (*.wmv)|*.wmv|FLV 文件 (*.flv)|*.flv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
                long len = new FileInfo(ofd.FileName).Length;
                string formatSize = FileUtility.GetFileSize(len);
                labInput.Text = string.Format("输入文件({0})", formatSize);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            btnConvert.Enabled = false;
            panel1.Enabled = false;
            btnCancle.Enabled = true;
            IsRunning = true;

            convert.InputFile = txtFileName.Text;
            convert.OutputFile = txtOutFile.Text;
            convert.Start();
        }

        private void convert_OnCancel(object sender, Ruihit.Ffmpeg.ConvertEventArgs e)
        {
            Logger.Warn(e.Message);
        }

        private void convert_OnMessage(object sender, Ruihit.Ffmpeg.ConvertEventArgs e)
        {
            Logger.Debug(e.Message);
        }

        private void convert_OnFinished(object sender, Ruihit.Ffmpeg.ConvertEventArgs e)
        {
            Logger.Info("转码完成");
            Invoke(new Action(() =>
            {
                btnConvert.Enabled = true;
                panel1.Enabled = true;
                btnCancle.Enabled = false;

                PopWindow.Information("视频转码完成！", "系统提示", this);
                IsRunning = false;
            }));
        }

        private void convert_OnError(object sender, Ruihit.Ffmpeg.ConvertEventArgs e)
        {
            Logger.Error("转码错误： {0}", e.Message);
        }

        private void convert_OnProgress(object sender, Ruihit.Ffmpeg.ConvertEventArgs e)
        {
            if (e.Progress % 10 == 0)
            {
                Logger.Info("文件转码进度：{0}", e.Progress);
            }
            Invoke(new Action(() =>
            {
                labPro.Text = string.Format("{0}%", e.Progress);
                progressBar1.Value = e.Progress;
            }));
        }

        private void convert_OnStart(object sender, Ruihit.Ffmpeg.ConvertEventArgs e)
        {
            Logger.Info("开始转码");
            Logger.Info("输入文件：{0}", txtFileName.Text);
            Logger.Info("输出文件：{0}", txtOutFile.Text);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (PopWindow.Question("你确定要取消转码吗？") == DialogResult.Yes)
            {
                btnCancle.Enabled = false;
                convert.Stop();
            }
        }

        private void btnOutFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "MP4 文件 (*.mp4)|*.mp4|视频剪辑 (*.avi)|*.avi|MKV 文件 (*.mkv)|*.mkv" +
                         "|Rmvb 文件 (*.rmvb)|*.rmvb|WMV 文件 (*.wmv)|*.wmv|FLV 文件 (*.flv)|*.flv";
            if (txtFileName.TextLength > 0)
            {
                sfd.FileName = Path.GetFileNameWithoutExtension(txtFileName.Text);
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtOutFile.Text = sfd.FileName;
            }
        }

        private void frmConvert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsRunning)
            {
                e.Cancel = true;
                PopWindow.Warnning("正在转码，请稍后 。。。");
            }
        }
    }
}
