using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVideo.controls
{
    public sealed class PictureBoxEx : PictureBox
    {
        private bool _selected = false;
        private bool mouseEnter = false;

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                if (_selected)
                {
                    UnSelectOther();
                }
                Invalidate();
            }
        }

        private void UnSelectOther()
        {
            foreach (Control c in Parent.Controls.OfType<PictureBoxEx>())
            {
                if (c == this) continue;
                PictureBoxEx pic = c as PictureBoxEx;
                pic.Selected = false;
                pic.Invalidate();
            }
        }

        public PictureBoxEx()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxEx
            // 
            this.Click += new System.EventHandler(this.PictureBoxEx_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxEx_Paint);
            this.MouseEnter += new System.EventHandler(this.PictureBoxEx_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.PictureBoxEx_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void PictureBoxEx_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            Invalidate();
        }

        private void PictureBoxEx_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            Invalidate();
        }

        private void PictureBoxEx_Paint(object sender, PaintEventArgs e)
        {
            RectangleF selc = new RectangleF(0, 0, Width, Height);

            if (Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.Cyan)), selc);
            }

            if (mouseEnter)
            {
                Rectangle rectStrike = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Cyan)), selc);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, Color.Cyan)), rectStrike);
            }

            int offset = 5;
            int titleHeight = 25;
            PictureBoxEx pic = sender as PictureBoxEx;
            pic.Margin = new Padding(5);
            RectangleF rect = new RectangleF(0, pic.Height - titleHeight, pic.Width, titleHeight);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, 255, 255, 255)), rect);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center; //居中
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            RectangleF rectTitle = new RectangleF(offset, pic.Height - titleHeight + offset, pic.Width - offset * 2, titleHeight - offset * 2);

            string name = Path.GetFileNameWithoutExtension(Tag.ToString());
            e.Graphics.DrawString(name, new Font(Font.FontFamily, 10),
                new SolidBrush(Color.White), rectTitle, format);
        }

        private void PictureBoxEx_Click(object sender, EventArgs e)
        {
            Selected = true;
        }
    }
}
