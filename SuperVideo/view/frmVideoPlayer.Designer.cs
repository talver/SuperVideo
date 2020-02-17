namespace SuperVideo.view
{
    partial class frmVideoPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVideoPlayer));
            this.Player = new Vlc.DotNet.Forms.VlcControl();
            this.PanelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBody
            // 
            this.PanelBody.Controls.Add(this.Player);
            this.PanelBody.Location = new System.Drawing.Point(1, 1);
            this.PanelBody.Size = new System.Drawing.Size(745, 527);
            this.PanelBody.Controls.SetChildIndex(this.Player, 0);
            this.PanelBody.Controls.SetChildIndex(this.TitleBar, 0);
            // 
            // TitleBar
            // 
            this.TitleBar.Size = new System.Drawing.Size(745, 35);
            // 
            // Player
            // 
            this.Player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player.BackColor = System.Drawing.Color.Black;
            this.Player.Location = new System.Drawing.Point(0, 35);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(747, 492);
            this.Player.TabIndex = 3;
            this.Player.Text = "vlcControl1";
            this.Player.VlcLibDirectory = null;
            this.Player.Buffering += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerBufferingEventArgs>(this.Player_Buffering);
            this.Player.EncounteredError += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerEncounteredErrorEventArgs>(this.Player_EncounteredError);
            this.Player.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.Player_VlcLibDirectoryNeeded);
            // 
            // frmVideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 529);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVideoPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVideoPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVideoPlayer_FormClosing);
            this.Load += new System.EventHandler(this.frmVideoPlayer_Load);
            this.PanelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl Player;

    }
}