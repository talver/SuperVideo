using SuperVideo.entity;
using SuperVideo.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo.common
{
    public sealed class Logger
    {
        private Logger() { }

        private static void Log(LogLevel level, string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format))
            {
                SystemLog log = new SystemLog(level, string.Format(format, args));
                LogManager.Instance.Enqueue(log);
            }
        }

        public static void Info(string format, params object[] args)
        {
            Log(LogLevel.Information, format, args);
        }

        public static void Debug(string format, params object[] args)
        {
            Log(LogLevel.Debug, format, args);
        }

        public static void Warn(string format, params object[] args)
        {
            Log(LogLevel.Warnning, format, args);
        }

        public static void Error(string format, params object[] args)
        {
            Log(LogLevel.Error, format, args);
        }
    }
}
