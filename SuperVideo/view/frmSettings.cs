using Ruihit.Controls;
using SuperVideo.common;
using SuperVideo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVideo.view
{
    public partial class frmSettings : Form
    {
        private ApplicationConfig config;

        public frmSettings()
        {
            InitializeComponent();
            config = ApplicationConfig.Load<ApplicationConfig>();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            cmnLogLevel.Items.AddRange(Enum.GetNames(typeof(LogLevel)));

            maxLog.Value = config.MaxLogs;
            txtVideoDir.Text = config.VideoDir;
            if (txtVideoDir.TextLength == 0 || !Directory.Exists(txtVideoDir.Text))
            {
                txtVideoDir.Text = AppDomain.CurrentDomain.BaseDirectory;
            }

            chkSaveLog.Checked = config.AutoSaveLog;
            txtLogFile.Text = config.LogFile;

            cmnLogLevel.SelectedIndex = (int)config.LogLevel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            config.MaxLogs = (int)maxLog.Value;
            config.VideoDir = txtVideoDir.Text;

            config.AutoSaveLog = chkSaveLog.Checked;
            config.LogFile = txtLogFile.Text;
            config.LogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), cmnLogLevel.Text);

            config.Save();

            PopWindow.Information("设置完成，部分设置需重启程序后生效！");
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtVideoDir.Text = fbd.SelectedPath;
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtLogFile.Text = fbd.SelectedPath;
            }
        }

        private void chkSaveLog_CheckedChanged(object sender, EventArgs e)
        {
            panelLog.Enabled = chkSaveLog.Checked;
        }
    }
}
