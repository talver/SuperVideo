using Ruihit.Controls.picture;
using SuperVideo.controls;
namespace SuperVideo
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.thumbPanel = new Ruihit.Controls.picture.PictureListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mDecrypt = new System.Windows.Forms.ToolStripMenuItem();
            this.mDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelStatusBar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.tsStatus = new System.Windows.Forms.Label();
            this.tbEncrypt = new Ruihit.Controls.ToolBarButton();
            this.tbExit = new Ruihit.Controls.ToolBarButton();
            this.tbConvert = new Ruihit.Controls.ToolBarButton();
            this.tbSettings = new Ruihit.Controls.ToolBarButton();
            this.tbHome = new Ruihit.Controls.ToolBarButton();
            this.tbLogs = new Ruihit.Controls.ToolBarButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new Ruihit.Controls.ImageButton();
            this.PanelBody.SuspendLayout();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBody
            // 
            this.PanelBody.Controls.Add(this.panelContainer);
            this.PanelBody.Controls.Add(this.panelStatusBar);
            this.PanelBody.Location = new System.Drawing.Point(1, 1);
            this.PanelBody.Size = new System.Drawing.Size(892, 579);
            this.PanelBody.Controls.SetChildIndex(this.panelStatusBar, 0);
            this.PanelBody.Controls.SetChildIndex(this.TitleBar, 0);
            this.PanelBody.Controls.SetChildIndex(this.panelContainer, 0);
            // 
            // TitleBar
            // 
            this.TitleBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TitleBar.Controls.Add(this.btnSearch);
            this.TitleBar.Controls.Add(this.txtSearch);
            this.TitleBar.Controls.Add(this.tbSettings);
            this.TitleBar.Controls.Add(this.tbLogs);
            this.TitleBar.Controls.Add(this.tbHome);
            this.TitleBar.Controls.Add(this.tbConvert);
            this.TitleBar.Controls.Add(this.tbExit);
            this.TitleBar.Controls.Add(this.tbEncrypt);
            this.TitleBar.Size = new System.Drawing.Size(892, 130);
            this.TitleBar.Controls.SetChildIndex(this.tbEncrypt, 0);
            this.TitleBar.Controls.SetChildIndex(this.tbExit, 0);
            this.TitleBar.Controls.SetChildIndex(this.tbConvert, 0);
            this.TitleBar.Controls.SetChildIndex(this.tbHome, 0);
            this.TitleBar.Controls.SetChildIndex(this.tbLogs, 0);
            this.TitleBar.Controls.SetChildIndex(this.tbSettings, 0);
            this.TitleBar.Controls.SetChildIndex(this.txtSearch, 0);
            this.TitleBar.Controls.SetChildIndex(this.btnSearch, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(888, 415);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 3;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.imageList1;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 1;
            this.tv.Size = new System.Drawing.Size(206, 415);
            this.tv.TabIndex = 0;
            this.tv.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_BeforeSelect);
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_closed_16x16.gif");
            this.imageList1.Images.SetKeyName(1, "folder_open_16x16.gif");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.thumbPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 415);
            this.panel1.TabIndex = 1;
            // 
            // thumbPanel
            // 
            this.thumbPanel.AutoScroll = true;
            this.thumbPanel.AutoScrollMinSize = new System.Drawing.Size(658, 0);
            this.thumbPanel.BackColor = System.Drawing.Color.White;
            this.thumbPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.thumbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbPanel.Location = new System.Drawing.Point(0, 0);
            this.thumbPanel.Name = "thumbPanel";
            this.thumbPanel.Size = new System.Drawing.Size(676, 413);
            this.thumbPanel.TabIndex = 0;
            this.thumbPanel.OnItemDoubleClick += new System.EventHandler(this.thumbPanel_OnItemDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDecrypt,
            this.mDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mDecrypt
            // 
            this.mDecrypt.Image = global::SuperVideo.Properties.Resources.access__delete__16x16;
            this.mDecrypt.Name = "mDecrypt";
            this.mDecrypt.Size = new System.Drawing.Size(124, 22);
            this.mDecrypt.Text = "视频解密";
            this.mDecrypt.Click += new System.EventHandler(this.mDecrypt_Click);
            // 
            // mDelete
            // 
            this.mDelete.Image = global::SuperVideo.Properties.Resources.action_delete__2_;
            this.mDelete.Name = "mDelete";
            this.mDelete.Size = new System.Drawing.Size(124, 22);
            this.mDelete.Text = "删除视频";
            this.mDelete.Click += new System.EventHandler(this.mDelete_Click);
            // 
            // panelStatusBar
            // 
            this.panelStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.panelStatusBar.Controls.Add(this.pictureBox2);
            this.panelStatusBar.Controls.Add(this.labelVersion);
            this.panelStatusBar.Controls.Add(this.tsStatus);
            this.panelStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusBar.Location = new System.Drawing.Point(0, 549);
            this.panelStatusBar.Name = "panelStatusBar";
            this.panelStatusBar.Size = new System.Drawing.Size(892, 30);
            this.panelStatusBar.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SuperVideo.Properties.Resources.seprator;
            this.pictureBox2.Location = new System.Drawing.Point(143, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(2, 9);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(137, 12);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "视频加密系统 V 2.6.2.0";
            // 
            // tsStatus
            // 
            this.tsStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsStatus.ForeColor = System.Drawing.Color.White;
            this.tsStatus.Location = new System.Drawing.Point(153, 9);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(726, 12);
            this.tsStatus.TabIndex = 0;
            // 
            // tbEncrypt
            // 
            this.tbEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.tbEncrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbEncrypt.DisableSelected = true;
            this.tbEncrypt.ForeColor = System.Drawing.Color.White;
            this.tbEncrypt.Icon = global::SuperVideo.Properties.Resources.key;
            this.tbEncrypt.IconMargionTop = 10;
            this.tbEncrypt.Location = new System.Drawing.Point(89, 35);
            this.tbEncrypt.Name = "tbEncrypt";
            this.tbEncrypt.Selected = false;
            this.tbEncrypt.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.tbEncrypt.Size = new System.Drawing.Size(78, 90);
            this.tbEncrypt.TabIndex = 7;
            this.tbEncrypt.Title = "加密";
            this.tbEncrypt.ToolTip = null;
            this.tbEncrypt.Click += new System.EventHandler(this.tbEncrypt_Click);
            // 
            // tbExit
            // 
            this.tbExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.tbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbExit.DisableSelected = true;
            this.tbExit.ForeColor = System.Drawing.Color.White;
            this.tbExit.Icon = global::SuperVideo.Properties.Resources.exit;
            this.tbExit.IconMargionTop = 10;
            this.tbExit.Location = new System.Drawing.Point(401, 35);
            this.tbExit.Name = "tbExit";
            this.tbExit.Selected = false;
            this.tbExit.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.tbExit.Size = new System.Drawing.Size(78, 90);
            this.tbExit.TabIndex = 8;
            this.tbExit.Title = "退出";
            this.tbExit.ToolTip = null;
            this.tbExit.Click += new System.EventHandler(this.tbExit_Click);
            // 
            // tbConvert
            // 
            this.tbConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.tbConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbConvert.DisableSelected = true;
            this.tbConvert.ForeColor = System.Drawing.Color.White;
            this.tbConvert.Icon = global::SuperVideo.Properties.Resources.change;
            this.tbConvert.IconMargionTop = 10;
            this.tbConvert.Location = new System.Drawing.Point(167, 35);
            this.tbConvert.Name = "tbConvert";
            this.tbConvert.Selected = false;
            this.tbConvert.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.tbConvert.Size = new System.Drawing.Size(78, 90);
            this.tbConvert.TabIndex = 9;
            this.tbConvert.Title = "转码";
            this.tbConvert.ToolTip = null;
            this.tbConvert.Click += new System.EventHandler(this.tbConvert_Click);
            // 
            // tbSettings
            // 
            this.tbSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.tbSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbSettings.DisableSelected = false;
            this.tbSettings.ForeColor = System.Drawing.Color.White;
            this.tbSettings.Icon = global::SuperVideo.Properties.Resources.settings;
            this.tbSettings.IconMargionTop = 10;
            this.tbSettings.Location = new System.Drawing.Point(323, 35);
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Selected = false;
            this.tbSettings.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.tbSettings.Size = new System.Drawing.Size(78, 90);
            this.tbSettings.TabIndex = 9;
            this.tbSettings.Title = "设置";
            this.tbSettings.ToolTip = null;
            this.tbSettings.Click += new System.EventHandler(this.tbSettings_Click);
            // 
            // tbHome
            // 
            this.tbHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.tbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbHome.DisableSelected = false;
            this.tbHome.ForeColor = System.Drawing.Color.White;
            this.tbHome.Icon = global::SuperVideo.Properties.Resources.home;
            this.tbHome.IconMargionTop = 10;
            this.tbHome.Location = new System.Drawing.Point(11, 35);
            this.tbHome.Name = "tbHome";
            this.tbHome.Selected = false;
            this.tbHome.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.tbHome.Size = new System.Drawing.Size(78, 90);
            this.tbHome.TabIndex = 10;
            this.tbHome.Title = "首页";
            this.tbHome.ToolTip = "";
            this.tbHome.Click += new System.EventHandler(this.tbHome_Click);
            // 
            // tbLogs
            // 
            this.tbLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.tbLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbLogs.DisableSelected = false;
            this.tbLogs.ForeColor = System.Drawing.Color.White;
            this.tbLogs.Icon = global::SuperVideo.Properties.Resources.log;
            this.tbLogs.IconMargionTop = 10;
            this.tbLogs.Location = new System.Drawing.Point(245, 35);
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.Selected = false;
            this.tbLogs.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.tbLogs.Size = new System.Drawing.Size(78, 90);
            this.tbLogs.TabIndex = 9;
            this.tbLogs.Title = "日志";
            this.tbLogs.ToolTip = null;
            this.tbLogs.Click += new System.EventHandler(this.tbLogs_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.splitContainer1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 130);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(2);
            this.panelContainer.Size = new System.Drawing.Size(892, 419);
            this.panelContainer.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearch.Location = new System.Drawing.Point(483, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(188, 26);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FaceColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::SuperVideo.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(646, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 24);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSearch.TabIndex = 12;
            this.btnSearch.TabStop = false;
            this.btnSearch.ToolTip = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 581);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视频加密系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Controls.SetChildIndex(this.PanelBody, 0);
            this.PanelBody.ResumeLayout(false);
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelStatusBar.ResumeLayout(false);
            this.panelStatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private PictureListView thumbPanel;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mDelete;
        private System.Windows.Forms.ToolStripMenuItem mDecrypt;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelStatusBar;
        private System.Windows.Forms.Label tsStatus;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Ruihit.Controls.ToolBarButton tbEncrypt;
        private Ruihit.Controls.ToolBarButton tbExit;
        private Ruihit.Controls.ToolBarButton tbConvert;
        private Ruihit.Controls.ToolBarButton tbSettings;
        private Ruihit.Controls.ToolBarButton tbHome;
        private Ruihit.Controls.ToolBarButton tbLogs;
        private System.Windows.Forms.Panel panelContainer;
        private Ruihit.Controls.ImageButton btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;


    }
}

