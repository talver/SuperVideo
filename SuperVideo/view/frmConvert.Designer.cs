namespace SuperVideo.view
{
    partial class frmConvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvert));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutFile = new System.Windows.Forms.TextBox();
            this.btnOutFile = new System.Windows.Forms.Button();
            this.labInput = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.labPro = new System.Windows.Forms.Label();
            this.PanelBody.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelBody
            // 
            this.PanelBody.Controls.Add(this.labPro);
            this.PanelBody.Controls.Add(this.panel1);
            this.PanelBody.Controls.Add(this.progressBar1);
            this.PanelBody.Controls.Add(this.btnCancle);
            this.PanelBody.Controls.Add(this.btnConvert);
            this.PanelBody.Location = new System.Drawing.Point(1, 1);
            this.PanelBody.Size = new System.Drawing.Size(586, 290);
            this.PanelBody.Controls.SetChildIndex(this.btnConvert, 0);
            this.PanelBody.Controls.SetChildIndex(this.btnCancle, 0);
            this.PanelBody.Controls.SetChildIndex(this.progressBar1, 0);
            this.PanelBody.Controls.SetChildIndex(this.panel1, 0);
            this.PanelBody.Controls.SetChildIndex(this.TitleBar, 0);
            this.PanelBody.Controls.SetChildIndex(this.labPro, 0);
            // 
            // TitleBar
            // 
            this.TitleBar.Size = new System.Drawing.Size(586, 35);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOutFile);
            this.panel1.Controls.Add(this.btnOutFile);
            this.panel1.Controls.Add(this.labInput);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Location = new System.Drawing.Point(13, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 112);
            this.panel1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "输出文件";
            // 
            // txtOutFile
            // 
            this.txtOutFile.BackColor = System.Drawing.Color.White;
            this.txtOutFile.Location = new System.Drawing.Point(5, 79);
            this.txtOutFile.Name = "txtOutFile";
            this.txtOutFile.ReadOnly = true;
            this.txtOutFile.Size = new System.Drawing.Size(521, 21);
            this.txtOutFile.TabIndex = 7;
            // 
            // btnOutFile
            // 
            this.btnOutFile.Image = global::SuperVideo.Properties.Resources.folder;
            this.btnOutFile.Location = new System.Drawing.Point(531, 78);
            this.btnOutFile.Name = "btnOutFile";
            this.btnOutFile.Size = new System.Drawing.Size(23, 23);
            this.btnOutFile.TabIndex = 8;
            this.btnOutFile.UseVisualStyleBackColor = true;
            this.btnOutFile.Click += new System.EventHandler(this.btnOutFile_Click);
            // 
            // labInput
            // 
            this.labInput.AutoSize = true;
            this.labInput.Location = new System.Drawing.Point(3, 10);
            this.labInput.Name = "labInput";
            this.labInput.Size = new System.Drawing.Size(53, 12);
            this.labInput.TabIndex = 2;
            this.labInput.Text = "输入文件";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            this.txtFileName.Location = new System.Drawing.Point(5, 25);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(521, 21);
            this.txtFileName.TabIndex = 4;
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::SuperVideo.Properties.Resources.folder;
            this.btnOpen.Location = new System.Drawing.Point(531, 24);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 184);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(549, 23);
            this.progressBar1.TabIndex = 19;
            // 
            // btnCancle
            // 
            this.btnCancle.Enabled = false;
            this.btnCancle.Image = global::SuperVideo.Properties.Resources.action_delete;
            this.btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancle.Location = new System.Drawing.Point(487, 241);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(80, 24);
            this.btnCancle.TabIndex = 18;
            this.btnCancle.Text = "取消 (&C)";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Image = global::SuperVideo.Properties.Resources.reverse;
            this.btnConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvert.Location = new System.Drawing.Point(380, 241);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(80, 24);
            this.btnConvert.TabIndex = 17;
            this.btnConvert.Text = "转换 (&T)";
            this.btnConvert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // labPro
            // 
            this.labPro.AutoSize = true;
            this.labPro.Location = new System.Drawing.Point(16, 167);
            this.labPro.Name = "labPro";
            this.labPro.Size = new System.Drawing.Size(17, 12);
            this.labPro.TabIndex = 21;
            this.labPro.Text = "0%";
            // 
            // frmConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 292);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConvert";
            this.ShowInTaskbar = false;
            this.Text = "视频转码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConvert_FormClosing);
            this.PanelBody.ResumeLayout(false);
            this.PanelBody.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labInput;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutFile;
        private System.Windows.Forms.Button btnOutFile;
        private System.Windows.Forms.Label labPro;
    }
}