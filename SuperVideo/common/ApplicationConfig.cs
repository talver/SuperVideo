using Ruihit.Settings.Core;
using SuperVideo.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo.common
{
    [Serializable]
    public class ApplicationConfig : BaseSettings
    {
        public string VideoDir { get; set; }
        public int MaxLogs { get; set; }

        public string LogFile { get; set; }
        public bool AutoSaveLog { get; set; }
        public LogLevel LogLevel { get; set; }

        public ApplicationConfig()
        {
            MaxLogs = 5000;
        }
    }
}
