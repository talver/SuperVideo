using SuperVideo.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo
{
    public delegate void OnStart(long length);
    public delegate void OnProgress(int progress);
    public delegate void OnError(string error);
    public delegate void OnFinished();

    public delegate void OnNewVideo(string source, string target);

}
