namespace SuperVideo.view
{
    partial class frmEncrypt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEncrypt));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labLen = new System.Windows.Forms.Label();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.btnOpen = new System.Windows.Forms.Button();
            this.labTime = new System.Windows.Forms.Label();
            this.picThumb = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.labSize = new System.Windows.Forms.Label();
            this.PanelBody.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBody
            // 
            this.PanelBody.Controls.Add(this.panel1);
            this.PanelBody.Controls.Add(this.progressBar1);
            this.PanelBody.Controls.Add(this.btnCancle);
            this.PanelBody.Controls.Add(this.btnEncrypt);
            this.PanelBody.Location = new System.Drawing.Point(1, 1);
            this.PanelBody.Size = new System.Drawing.Size(597, 447);
            this.PanelBody.Controls.SetChildIndex(this.TitleBar, 0);
            this.PanelBody.Controls.SetChildIndex(this.btnEncrypt, 0);
            this.PanelBody.Controls.SetChildIndex(this.btnCancle, 0);
            this.PanelBody.Controls.SetChildIndex(this.progressBar1, 0);
            this.PanelBody.Controls.SetChildIndex(this.panel1, 0);
            // 
            // TitleBar
            // 
            this.TitleBar.Size = new System.Drawing.Size(597, 35);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labSize);
            this.panel1.Controls.Add(this.labLen);
            this.panel1.Controls.Add(this.chkDelete);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.trackBar);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.labTime);
            this.panel1.Controls.Add(this.picThumb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Location = new System.Drawing.Point(18, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 304);
            this.panel1.TabIndex = 16;
            // 
            // labLen
            // 
            this.labLen.AutoSize = true;
            this.labLen.Location = new System.Drawing.Point(405, 184);
            this.labLen.Name = "labLen";
            this.labLen.Size = new System.Drawing.Size(17, 12);
            this.labLen.TabIndex = 16;
            this.labLen.Text = "16";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(207, 137);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(216, 16);
            this.chkDelete.TabIndex = 15;
            this.chkDelete.Text = "加密完成后弹出询问是否删除源文件";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(205, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "*请牢记密码，忘记后将无法找回！！！";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(207, 181);
            this.txtPassword.MaxLength = 16;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(192, 21);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "播放密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "截图时间点";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            this.txtFileName.Location = new System.Drawing.Point(5, 19);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(521, 21);
            this.txtFileName.TabIndex = 4;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(205, 253);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(350, 45);
            this.trackBar.TabIndex = 10;
            this.trackBar.Value = 1;
            this.trackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_MouseUp);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::SuperVideo.Properties.Resources.folder;
            this.btnOpen.Location = new System.Drawing.Point(531, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(203, 113);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(41, 12);
            this.labTime.TabIndex = 9;
            this.labTime.Text = "时长：";
            // 
            // picThumb
            // 
            this.picThumb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picThumb.Location = new System.Drawing.Point(5, 58);
            this.picThumb.Name = "picThumb";
            this.picThumb.Size = new System.Drawing.Size(180, 240);
            this.picThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picThumb.TabIndex = 6;
            this.picThumb.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "分类";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(238, 58);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(135, 20);
            this.cmbCategory.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 362);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(550, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // btnCancle
            // 
            this.btnCancle.Enabled = false;
            this.btnCancle.Image = global::SuperVideo.Properties.Resources.action_delete;
            this.btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancle.Location = new System.Drawing.Point(493, 408);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(80, 24);
            this.btnCancle.TabIndex = 14;
            this.btnCancle.Text = "取消 (&C)";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Image = global::SuperVideo.Properties.Resources.b_primary;
            this.btnEncrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncrypt.Location = new System.Drawing.Point(386, 408);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(80, 24);
            this.btnEncrypt.TabIndex = 13;
            this.btnEncrypt.Text = "加密 (&E)";
            this.btnEncrypt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // labSize
            // 
            this.labSize.AutoSize = true;
            this.labSize.Location = new System.Drawing.Point(203, 90);
            this.labSize.Name = "labSize";
            this.labSize.Size = new System.Drawing.Size(41, 12);
            this.labSize.TabIndex = 17;
            this.labSize.Text = "大小：";
            // 
            // frmEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 449);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEncrypt";
            this.ShowInTaskbar = false;
            this.Text = "视频加密";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEncrypt_FormClosing);
            this.Load += new System.EventHandler(this.frmEncrypt_Load);
            this.PanelBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labLen;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.PictureBox picThumb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label labSize;
    }
}