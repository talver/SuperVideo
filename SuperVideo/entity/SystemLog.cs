using SuperVideo.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo.entity
{
    public sealed class SystemLog
    {
        public LogLevel Level { get; set; }
        public string Content { get; set; }

        public SystemLog() { this.Level = LogLevel.Information; }

        public SystemLog(string content)
        {
            this.Level = LogLevel.Information;
            this.Content = content;
        }

        public SystemLog(LogLevel level, string content)
        {
            this.Level = level;
            this.Content = content;
        }
    }
}
