using Ruihit.Controls;
using Ruihit.Controls.picture;
using Ruihit.Ffmpeg;
using SuperVideo.common;
using SuperVideo.controls;
using SuperVideo.entity;
using SuperVideo.Properties;
using SuperVideo.tools;
using SuperVideo.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVideo
{
    //-----------------------------------------------------------------------------------------------------
    /// <summary>
    /// talver@126.com
    /// </summary>
    public partial class frmMain : RStyleBaseForm
    {
        public static string VideoDir;
        public static string VideoTmp;

        public const string DEFAULT_CATEGORY = "未分类";
        public const string VIDEO_TEMP = "tmp";

        public string Token { get; set; }
        private PictureBox selectPic;
        private TreeNode SelectedNode;

        HttpServer server;

        private frmLogs frmLog;
        private frmSettings frmSettings;

        private ImageButton btnAddVideo;
        private ApplicationConfig config;

        private FlowLayoutPanelEx loading = new FlowLayoutPanelEx();
        private Thread loadThread;
        private bool isLoading = false;

        //-----------------------------------------------------------------------------------------------------
        public frmMain()
        {
            ToggleButton = true;
            ShowAnimate = false;
            CanResize = true;
            Token = Guid.NewGuid().ToString();
            InitializeComponent();
            splitContainer1.Panel2.Controls.Add(loading); // 显示进度
            loading.BorderStyle = BorderStyle.FixedSingle;
            loading.Dock = DockStyle.Fill;
            loading.SendToBack();
            config = ApplicationConfig.Load<ApplicationConfig>();
            LogManager.Instance.SetAutoSave(config.AutoSaveLog).SetFileName(config.LogFile).Init();
            LogManager.Instance.LogLevel = config.LogLevel;
            LogoLotion = LogoLotion.Right;
            LogoImage = Resources.titlebar_right;

            InitDir();

            InitVideoButton();
        }

        //-----------------------------------------------------------------------------------------------------
        private void InitVideoButton()
        {
            btnAddVideo = new ImageButton();
            btnAddVideo.FaceColor = Color.LightGray;
            btnAddVideo.ToolTip = "添加视频";
            btnAddVideo.Width = 120;
            btnAddVideo.Height = 120;
            btnAddVideo.Image = Resources.add_video;
            btnAddVideo.Margin = new Padding(10);
            btnAddVideo.Click += btnAddVideo_Click;
        }

        //-----------------------------------------------------------------------------------------------------
        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            tbEncrypt_Click(sender, e);
        }

        //-----------------------------------------------------------------------------------------------------
        private void InitDir()
        {
            if (!string.IsNullOrEmpty(config.VideoDir) &&
            Directory.Exists(config.VideoDir))
            {
                VideoDir = config.VideoDir + "\\video\\";
                VideoTmp = config.VideoDir + "\\video\\tmp\\";
            }
            else
            {
                VideoDir = AppDomain.CurrentDomain.BaseDirectory + "\\video\\";
                VideoTmp = AppDomain.CurrentDomain.BaseDirectory + "\\video\\tmp\\";
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e)
        {
            Logger.Info("视频加密系统 V {0}",
            Assembly.GetExecutingAssembly().GetName().Version.ToString());
            if (!Directory.Exists(VideoTmp)) Directory.CreateDirectory(VideoTmp);
            LoadForms();
            StartServer();
            LoadVideo();
            tbHome.Selected = true;
            Invalidate();
        }

        //-----------------------------------------------------------------------------------------------------
        private void ShowLog(SystemLog log)
        {
            Logger.Info(log.Content);
        }

        //-----------------------------------------------------------------------------------------------------
        private void LoadForms()
        {
            frmLog = new frmLogs();
            LoadForm(frmLog);

            frmSettings = new frmSettings();
            LoadForm(frmSettings);
        }

        //-----------------------------------------------------------------------------------------------------
        private void LoadForm(Form frm)
        {
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panelContainer.Controls.Add(frm);
            frm.Show();
            frm.SendToBack();
        }

        //-----------------------------------------------------------------------------------------------------
        private void StartServer()
        {
            if (server != null && server.IsRunning) return;
            server = new HttpServer();
            server.Token = Token;
            server.Start();
        }

        //-----------------------------------------------------------------------------------------------------
        private void StopServer()
        {
            server.Stop();
        }

        //-----------------------------------------------------------------------------------------------------
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PopWindow.Question("你确定要退出程序吗？") == DialogResult.Yes)
            {
                if (frmLog != null) frmLog.Close();
                LogManager.Instance.Close();
                StopServer();
            }
            else
            {
                e.Cancel = true;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void frmEncrypt_OnNewVideo(string source, string target)
        {
            LoadVideo();
            string categort = GetCategoty(target);
            if (SelectedNode != null && SelectedNode.Tag != null && categort.Equals(SelectedNode.Tag.ToString()))
            {
                LoadVideoThumb(categort);
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void LoadVideo()
        {
            ShowLog(new SystemLog("加载视频目录"));

            tv.Nodes.Clear();

            TreeNode root = new TreeNode("我的视频");
            tv.Nodes.Add(root);

            string dir = VideoDir + DEFAULT_CATEGORY;
            if (Directory.Exists(dir))
            {
                TreeNode defaultNode = new TreeNode(string.Format("{0}({1})", DEFAULT_CATEGORY, Directory.GetFiles(dir).Length));
                defaultNode.Tag = DEFAULT_CATEGORY;
                root.Nodes.Add(defaultNode);
            }

            string[] files = Directory.GetDirectories(VideoDir);
            foreach (string file in files)
            {
                string category = file.Substring(file.LastIndexOf("\\") + 1);
                if (category.Equals(DEFAULT_CATEGORY) || category.ToLower().Equals(VIDEO_TEMP)) continue;
                string text = string.Format("{0}({1})", category, Directory.GetFiles(file).Length);
                TreeNode cat = new TreeNode(text);
                cat.Tag = category;
                root.Nodes.Add(cat);
            }
            tv.ExpandAll();

            if (SelectedNode != null)
            {
                string cat = SelectedNode.Text.Split('(')[0];
                foreach (TreeNode node in tv.Nodes[0].Nodes)
                {
                    if (node.Text.StartsWith(cat))
                    {
                        tv.SelectedNode = node;
                        break;
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void PlayVideo(string category, string filename, string Password)
        {
            server.Key = Password;
            bool opened = false;
            frmVideoPlayer frm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmVideoPlayer)
                {
                    opened = true;
                    frm = f as frmVideoPlayer;
                    break;
                }
            }
            if (frm == null)
            {
                frm = new frmVideoPlayer();
            }
            frm.FileName = Path.GetFileName(filename);
            frm.Url = string.Format("http://localhost:18888/?file={0}&token={1}&category={2}", filename, Token, category);
            if (!opened) frm.Show();
            else
            {
                frm.ReloadVideo();
                frm.Activate();
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void LoadVideoThumb(string p)
        {
            if (isLoading) return;
            isLoading = true;
            loadThread = new Thread(new ParameterizedThreadStart(LoadThread));
            loadThread.IsBackground = true;
            loadThread.Start(p);
        }

        //-----------------------------------------------------------------------------------------------------
        private void LoadThread(object obj)
        {
            string p = obj.ToString();
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    loading.BringToFront();
                    loading.Loading();

                    thumbPanel.SuspendLayout();
                    thumbPanel.Items.Clear();
                    thumbPanel.Controls.Clear();

                    string[] files = Directory.GetFiles(VideoDir + p);
                    foreach (string file in files)
                    {
                        if (IsHandleCreated)
                        {
                            string thumb = Path.GetDirectoryName(file) + "\\thumb\\" + Path.GetFileNameWithoutExtension(file) + ".jpg";
                            PictureListItem item = new PictureListItem();
                            item.Tag = file;
                            if (File.Exists(thumb))
                            {
                                item.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(thumb)));
                            }
                            item.Title = Path.GetFileNameWithoutExtension(thumb);
                            thumbPanel.Items.Add(item);
                        }
                        Application.DoEvents();
                    }
                    loading.Finished();
                    loading.SendToBack();
                    thumbPanel.ResumeLayout(false);
                    isLoading = false;
                }));
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private PictureBoxEx CreateThumb(string file)
        {
            PictureBoxEx pic = new PictureBoxEx();
            pic.ContextMenuStrip = contextMenuStrip1;
            toolTip1.SetToolTip(pic, Path.GetFileName(file));
            pic.Cursor = Cursors.Hand;
            pic.BackColor = Color.Black;
            pic.Width = 120;
            pic.Height = 160;
            pic.SizeMode = PictureBoxSizeMode.Zoom;

            string thumb = Path.GetDirectoryName(file) + "\\thumb\\" + Path.GetFileNameWithoutExtension(file) + ".jpg";
            if (File.Exists(thumb))
            {
                pic.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(thumb)));
            }
            pic.Tag = file;
            return pic;
        }

        //-----------------------------------------------------------------------------------------------------
        private void pic_Click(object sender, EventArgs e)
        {
            PictureBoxEx pic = sender as PictureBoxEx;
            ShowStatus("当前选择：{0}", Path.GetFileName(pic.Tag.ToString()));
        }

        //-----------------------------------------------------------------------------------------------------
        private void Video_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            string file = pic.Tag.ToString();
            if (!File.Exists(file)) return;
            string dir = Path.GetDirectoryName(file);
            string category = dir.Substring(dir.LastIndexOf("\\") + 1);

            frmPassword frm = new frmPassword(category, file);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.IsPasswordValid)
                {
                    PlayVideo(category, Path.GetFileName(file), frm.Password);
                }
                else
                {
                    PopWindow.Warnning("密码不正确，请重新输入！");
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void mDelete_Click(object sender, EventArgs e)
        {
            if (thumbPanel.SelectedItem != null)
            {
                string file = thumbPanel.SelectedItem.Tag.ToString();
                string msg = string.Format("你确定要删除【{0}】吗？", Path.GetFileName(file));
                if (PopWindow.Question(msg) == DialogResult.Yes)
                {
                    thumbPanel.Items.Remove(thumbPanel.SelectedItem);
                    try
                    {
                        File.Delete(file);
                        File.Delete(GetThunbPath(file));
                    }
                    catch { }
                    LoadVideo();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //selectPic = (PictureBox)(sender as ContextMenuStrip).SourceControl;
        }

        //-----------------------------------------------------------------------------------------------------
        private string GetThunbPath(string file)
        {
            string dir = Path.GetDirectoryName(file) + "\\thumb\\" + Path.GetFileNameWithoutExtension(file) + ".jpg";
            return dir;
        }

        //-----------------------------------------------------------------------------------------------------
        private string GetCategoty(string filename)
        {
            try
            {
                string file = Path.GetDirectoryName(filename);
                return file.Substring(file.LastIndexOf("\\") + 1);
            }
            catch { }
            return null;
        }

        //-----------------------------------------------------------------------------------------------------
        private void mDecrypt_Click(object sender, EventArgs e)
        {
            if (selectPic == null) return;
            string file = selectPic.Tag.ToString();
            if (!File.Exists(file)) return;
            string dir = Path.GetDirectoryName(file);
            string category = dir.Substring(dir.LastIndexOf("\\") + 1);

            frmPassword frm = new frmPassword(category, file);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.IsPasswordValid)
                {
                    // 视频解密
                }
                else
                {
                    PopWindow.Warnning("密码不正确，请重新输入！");
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                thumbPanel.Items.Clear();
                thumbPanel.Controls.Clear();
                thumbPanel.Controls.Add(btnAddVideo);
            }
            else
            {
                SelectedNode = e.Node;
                ShowStatus(e.Node.Tag.ToString());
                LoadVideoThumb(e.Node.Tag.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void mExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //-----------------------------------------------------------------------------------------------------
        private void ShowStatus(string format, params object[] args)
        {
            string status = string.Format(format, args);
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    tsStatus.Text = status;
                }));
            }
            else
            {
                tsStatus.Text = status;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void tbEncrypt_Click(object sender, EventArgs e)
        {
            tbEncrypt.Selected = false;
            frmEncrypt frm = new frmEncrypt();
            if (SelectedNode != null)
            {
                frm.Category = SelectedNode.Tag.ToString();
            }
            frm.OnNewVideo += frmEncrypt_OnNewVideo;
            frm.ShowDialog();
        }

        //-----------------------------------------------------------------------------------------------------
        private void tbExit_Click(object sender, EventArgs e)
        {
            tbExit.Selected = false;
            Close();
        }

        //-----------------------------------------------------------------------------------------------------
        private void tbConvert_Click(object sender, EventArgs e)
        {
            tbConvert.Selected = false;
            new frmConvert().ShowDialog();
        }

        //-----------------------------------------------------------------------------------------------------
        private void tbSettings_Click(object sender, EventArgs e)
        {
            frmSettings.BringToFront();
        }

        //-----------------------------------------------------------------------------------------------------
        private void tbLogs_Click(object sender, EventArgs e)
        {
            frmLog.BringToFront();
        }

        //-----------------------------------------------------------------------------------------------------
        private void tbHome_Click(object sender, EventArgs e)
        {
            splitContainer1.BringToFront();
        }

        //-----------------------------------------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.TextLength > 0)
            {
                PictureListItem item = thumbPanel.SearchItem(txtSearch.Text);
                if (item != null)
                {
                    thumbPanel.ScrollTo(item);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                btnSearch_Click(null, null);
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void tv_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (isLoading) e.Cancel = true;
        }

        //-----------------------------------------------------------------------------------------------------
        private void thumbPanel_OnItemDoubleClick(object sender, EventArgs e)
        {
            PictureListItem item = (PictureListItem)sender;
            string file = item.Tag.ToString();
            if (!File.Exists(file)) return;
            string dir = Path.GetDirectoryName(file);
            string category = dir.Substring(dir.LastIndexOf("\\") + 1);

            frmPassword frm = new frmPassword(category, file);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.IsPasswordValid)
                {
                    PlayVideo(category, Path.GetFileName(file), frm.Password);
                }
                else
                {
                    PopWindow.Warnning("密码不正确，请重新输入！");
                }
            }
        }
    }
}


