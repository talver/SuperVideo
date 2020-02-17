using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo.tools
{
  public  class FontUtility
    {
        public FontUtility() { 
        
        }

        public static Font LoadDigitFont(float size = 12, FontStyle style = FontStyle.Regular)
        {
            try
            {
                PrivateFontCollection prc = new PrivateFontCollection();
                prc.AddFontFile(AppDomain.CurrentDomain.BaseDirectory + "fonts\\DS-DIGIT.TTF");
                Font f = new Font(prc.Families[0], size, style);
                return f;
            }
            catch { }
            return null;
        }

    }
}
