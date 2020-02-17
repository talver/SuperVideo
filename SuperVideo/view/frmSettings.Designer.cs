namespace SuperVideo.view
{
    partial class frmSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.maxLog = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVideoDir = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.chkSaveLog = new System.Windows.Forms.CheckBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.panelLog = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmnLogLevel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.maxLog)).BeginInit();
            this.panelLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "显示日志最大行数";
            // 
            // maxLog
            // 
            this.maxLog.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxLog.Location = new System.Drawing.Point(140, 24);
            this.maxLog.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.maxLog.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.maxLog.Name = "maxLog";
            this.maxLog.Size = new System.Drawing.Size(120, 21);
            this.maxLog.TabIndex = 1;
            this.maxLog.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::SuperVideo.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(417, 334);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存 (&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "视频存储目录";
            // 
            // txtVideoDir
            // 
            this.txtVideoDir.BackColor = System.Drawing.Color.White;
            this.txtVideoDir.Location = new System.Drawing.Point(26, 87);
            this.txtVideoDir.Name = "txtVideoDir";
            this.txtVideoDir.ReadOnly = true;
            this.txtVideoDir.Size = new System.Drawing.Size(447, 21);
            this.txtVideoDir.TabIndex = 4;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(479, 86);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(23, 23);
            this.btnBrowser.TabIndex = 5;
            this.btnBrowser.Text = "*";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // chkSaveLog
            // 
            this.chkSaveLog.AutoSize = true;
            this.chkSaveLog.Location = new System.Drawing.Point(26, 137);
            this.chkSaveLog.Name = "chkSaveLog";
            this.chkSaveLog.Size = new System.Drawing.Size(144, 16);
            this.chkSaveLog.TabIndex = 6;
            this.chkSaveLog.Text = "是否将日志保存到文件";
            this.chkSaveLog.UseVisualStyleBackColor = true;
            this.chkSaveLog.CheckedChanged += new System.EventHandler(this.chkSaveLog_CheckedChanged);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(453, 0);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(23, 23);
            this.btnLog.TabIndex = 8;
            this.btnLog.Text = "*";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // txtLogFile
            // 
            this.txtLogFile.BackColor = System.Drawing.Color.White;
            this.txtLogFile.Location = new System.Drawing.Point(0, 0);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.ReadOnly = true;
            this.txtLogFile.Size = new System.Drawing.Size(447, 21);
            this.txtLogFile.TabIndex = 7;
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.btnLog);
            this.panelLog.Controls.Add(this.txtLogFile);
            this.panelLog.Enabled = false;
            this.panelLog.Location = new System.Drawing.Point(26, 159);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(477, 24);
            this.panelLog.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "日志级别";
            // 
            // cmnLogLevel
            // 
            this.cmnLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmnLogLevel.FormattingEnabled = true;
            this.cmnLogLevel.Location = new System.Drawing.Point(352, 23);
            this.cmnLogLevel.Name = "cmnLogLevel";
            this.cmnLogLevel.Size = new System.Drawing.Size(121, 20);
            this.cmnLogLevel.TabIndex = 11;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 378);
            this.Controls.Add(this.cmnLogLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.chkSaveLog);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.txtVideoDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.maxLog);
            this.Controls.Add(this.label1);
            this.Name = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxLog)).EndInit();
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxLog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVideoDir;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.CheckBox chkSaveLog;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmnLogLevel;
    }
}