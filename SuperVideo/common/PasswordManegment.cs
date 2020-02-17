using SuperVideo.tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo.common
{
    internal sealed class PasswordManegment
    {
        public string Password { get; private set; }

        public PasswordManegment(string Password)
        {
            this.Password = GetPassword(Password);
        }

        private string GetPassword(string Password)
        {
            if (string.IsNullOrEmpty(Password)) return "".PadRight(16, '0');

            if (Password.Length > 16)
            {
                Password = Password.Substring(0, 16);
            }

            if (Password.Length < 16)
            {
                Password = Password.PadRight(16, '0');
            }

            return Password;
        }

        internal bool IsPasswordValid(string FileName)
        {
            try
            {
                FileStream fsr = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                byte[] readBytes = new byte[HttpServer.BufferSize + 16];
                int len = fsr.Read(readBytes, 0, readBytes.Length);
                byte[] en = SecurityUtils.AesDecrypt(Password, readBytes);
                fsr.Close();

                return en == null ? false : true;
            }
            catch { }
            return false;
        }
    }
}
