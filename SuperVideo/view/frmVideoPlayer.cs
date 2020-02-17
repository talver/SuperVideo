using Ruihit.Controls;
using SuperVideo.common;
using SuperVideo.entity;
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
using Vlc.DotNet.Core;

namespace SuperVideo.view
{
    public partial class frmVideoPlayer : RStyleBaseForm
    {
        public string Url { get; set; }
        public string FileName { get; set; }

        public frmVideoPlayer()
        {
            CanResize = true;
            InitializeComponent();
        }

        private void frmVideoPlayer_Load(object sender, EventArgs e)
        {
            ReloadVideo();
        }

        private void frmVideoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player.Stop();
        }

        public void ReloadVideo()
        {
            Player.Stop();
            Text = FileName;

            string[] options = {  "--width=10","--fullscreen"
            };
            Uri r = new Uri(Url);

            Player.Play(r, null);
            //Player.Video.Logo.File = @"D:\Locker\locker256.png";
            //Player.Video.Logo.Opacity = 255;
            //Player.Video.Logo.Position = 1;
            //Player.Video.Logo.Enabled = true;
        }

        private void Player_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Application.StartupPath);
        }

        private void Player_Buffering(object sender, Vlc.DotNet.Core.VlcMediaPlayerBufferingEventArgs e)
        {
            // 缓冲
        }

        private void Player_EncounteredError(object sender, Vlc.DotNet.Core.VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            Logger.Error("播放失败:{0}", FileName);
        }
    }
}
