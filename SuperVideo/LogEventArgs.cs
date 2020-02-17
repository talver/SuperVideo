using SuperVideo.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo
{
    public class LogEventArgs : EventArgs
    {
        public SystemLog Log { get; private set; }

        public LogEventArgs(SystemLog Log)
        {
            this.Log = Log;
        }
    }
}
