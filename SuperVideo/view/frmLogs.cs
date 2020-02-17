using SuperVideo.common;
using SuperVideo.entity;
using SuperVideo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVideo.view
{
    public enum LogLevel : int
    {
        Debug = 0, Information = 1, Warnning = 2, Error = 3
    }

    public partial class frmLogs : Form
    {
        private int maxLog = 0;
        private Thread thread;
        private bool stopped = false;
        ApplicationConfig config;
        public frmLogs()
        {
            InitializeComponent();
            config = ApplicationConfig.Load<ApplicationConfig>();
            maxLog = config.MaxLogs;
        }

        public void OnLog(object sender, LogEventArgs e)
        {
            LogManager.Instance.Enqueue(e.Log);
        }

        private void InitLogThread()
        {
            thread = new Thread(new ThreadStart(ShowLog));
            thread.IsBackground = true;
            thread.Start();
        }

        private void ShowLog()
        {
            while (true)
            {
                if (stopped) break;
                SystemLog log = LogManager.Instance.Dequeue();
                if (log != null && log.Level >= LogManager.Instance.LogLevel) ShowLog(log);
                Thread.Sleep(1);
            }
        }

        private void ShowLog(SystemLog log)
        {
            if (log == null) return;

            if (IsHandleCreated)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        Color lc = Color.FromArgb(0, 192, 0);
                        if (log.Level == LogLevel.Debug)
                        {
                            lc = Color.Blue;
                        }
                        else if (log.Level == LogLevel.Warnning)
                        {
                            lc = Color.Orange;
                        }
                        else if (log.Level == LogLevel.Error)
                        {
                            lc = Color.Red;
                        }

                        string text = string.Format("[{0}] {1}\r\n", DateTime.Now.ToString("HH:mm:ss.fff"), log.Content);
                        txtLog.SelectionStart = txtLog.TextLength;
                        txtLog.SelectionColor = lc;
                        txtLog.AppendText(text);
                        txtLog.SelectionStart = txtLog.TextLength;
                        txtLog.ScrollToCaret();

                        ClearLogs();
                    }));
                }
                catch { }
            }
        }

        private void ClearLogs()
        {
            int lineNum = txtLog.Lines.GetUpperBound(0);
            if (lineNum >= maxLog)
            {
                txtLog.Clear();
                Logger.Info("视频加密系统 V {0}\r\n日志达到设定值【{1}】，已自动清空！",
                    Assembly.GetExecutingAssembly().GetName().Version.ToString(), maxLog);
            }
        }

        private void frmLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopped = true;
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            InitLogThread();
        }

        /// <summary>
        /// 保存日志到文件（以后扩展）
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        private bool SaveLog(SystemLog log)
        {
            return false;
        }
    }
}
