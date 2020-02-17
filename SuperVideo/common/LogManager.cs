using SuperVideo.entity;
using SuperVideo.view;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperVideo.common
{
    public sealed class LogManager
    {
        private static readonly LogManager instance = new LogManager();
        private static readonly object Locker = new object();
        private static Queue<SystemLog> LogQueue = new Queue<SystemLog>();
        private static Queue<SystemLog> WriteQueue;

        private Thread thread;
        private FileStream fs;
        private bool autoSave = false;
        private string filename;

        public LogLevel LogLevel { get; set; }
        public bool Stopped { get; private set; }
        public long MaxFileLength { get; set; }

        private LogManager()
        {
            MaxFileLength = 50 * 1024 * 1024;
            LogLevel = LogLevel.Information;
        }

        public static LogManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void Enqueue(SystemLog log)
        {
            lock (Locker)
            {
                if (!Stopped)
                {
                    try
                    {
                        LogQueue.Enqueue(log);
                    }
                    catch (OutOfMemoryException ex)
                    {
                        Console.WriteLine("内存溢出：{0}", ex.Message);
                        LogQueue.Clear();
                    }
                    if (autoSave) WriteQueue.Enqueue(log);
                }
            }
        }

        public SystemLog Dequeue()
        {
            lock (Locker)
            {
                if (LogQueue != null && LogQueue.Count > 0)
                {
                    return LogQueue.Dequeue();
                }
                else
                {
                    return null;
                }
            }
        }

        private void Save()
        {
            while (!Stopped)
            {
                long len = new FileInfo(filename).Length;

                lock (Locker)
                {
                    if (len > MaxFileLength)
                    {
                        CreatNewFile();
                    }

                    if (WriteQueue != null && WriteQueue.Count > 0)
                    {
                        try
                        {
                            SystemLog log = WriteQueue.Dequeue();
                            if (log.Level >= LogLevel)
                            {
                                string cont = string.Format("[{0}] {1} {2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                    log.Level, log.Content);
                                byte[] buffer = Encoding.UTF8.GetBytes(cont);
                                fs.Write(buffer, 0, buffer.Length);
                                fs.Flush();
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        public LogManager SetAutoSave(bool auto)
        {
            autoSave = auto;
            return instance;
        }

        public void Init()
        {
            if (autoSave)
            {
                WriteQueue = new Queue<SystemLog>();
                thread = new Thread(new ThreadStart(Save));
                thread.Start();

                if (string.IsNullOrEmpty(filename))
                {
                    filename = AppDomain.CurrentDomain + "logs";
                }

                string dir = Path.GetDirectoryName(filename);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    this.filename = dir + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                }
                InitStream();
            }
            else
            {
                Close();
            }
        }

        private void InitStream()
        {
            if (fs == null) fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
        }

        public LogManager SetFileName(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                if (!filename.EndsWith("\\")) filename += "\\";
                this.filename = filename + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            }
            return instance;
        }

        public void Close()
        {
            Stopped = true;

            lock (Locker)
            {
                LogQueue.Clear();
                WriteQueue.Clear();
                LogQueue = null;
                WriteQueue = null;
            }

            TryToCloseStream();
        }

        private void TryToCloseStream()
        {
            if (fs != null)
            {
                try
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                catch { }
            }
        }

        private void CreatNewFile()
        {
            lock (Locker)
            {
                TryToCloseStream();
                MakeNewLogFile();
                InitStream();
            }
        }

        private void MakeNewLogFile()
        {
            string dir = Path.GetDirectoryName(filename);
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            int index = 10000;
            for (int i = 1; i <= index; i++)
            {
                string file = string.Format("{0}_{1}.log", date, i);
                string tmpname = Path.Combine(dir, file);
                if (!File.Exists(tmpname))
                {
                    this.filename = tmpname;
                    break;
                }
            }
        }
    }
}
