using SuperVideo.tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVideo.controls
{
    internal class FlowLayoutPanelEx : FlowLayoutPanel
    {
        private bool isLoading = false;
        private int total = 0;
        private Stopwatch sw;

        const int RECT_SIZE = 120;

        public FlowLayoutPanelEx()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FlowLayoutPanelEx
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanelEx_Paint);
            this.ResumeLayout(false);

        }

        private void FlowLayoutPanelEx_Paint(object sender, PaintEventArgs e)
        {
            if (isLoading)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                Rectangle rect = new Rectangle((Width - RECT_SIZE) / 2,
                    (this.Height - RECT_SIZE) / 2, RECT_SIZE, RECT_SIZE);
                e.Graphics.DrawArc(new System.Drawing.Pen(Color.LightGray, 10), rect, 0, 360);

                if (total >= 360) total = -360;

                e.Graphics.DrawArc(new System.Drawing.Pen(Color.Orange, 10), rect, 0, total);
                total += 10;

                TimeSpan ts = new TimeSpan(0, 0, 0, (int)(sw.ElapsedMilliseconds / 1000));
                string text = ts.ToString("c");// "加载中 ...";

                Font font = FontUtility.LoadDigitFont(18);
                SizeF sizef = e.Graphics.MeasureString(text, font);
                Rectangle r = new Rectangle((Width - 96) / 2, (Height - 30) / 2, 96, 30);
                GraphicsPath myPath = GetPath(r, 3);
                e.Graphics.FillPath(new SolidBrush(Color.LightGray), myPath);
                e.Graphics.DrawPath(new Pen(Color.FromArgb(80, Color.Gray)), myPath);

                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(text, font, new SolidBrush(Color.DarkGreen), rect, format);
                new Thread(() => { Thread.Sleep(50); Invoke(new Action(() => { Invalidate(); })); }).Start();
            }
        }

        public void Loading()
        {
            sw = new Stopwatch();
            sw.Start();
            total = 0;
            isLoading = true;
            Invalidate();
        }

        public void Finished()
        {
            isLoading = false;
            Invalidate();
            if (sw != null)
            {
                sw.Stop();
                sw = null;
            }
        }

        private GraphicsPath GetPath(Rectangle rec, int cRadius = 1)
        {
            Rectangle rect = new Rectangle(rec.Left, rec.Top, rec.Width - cRadius, rec.Height - cRadius);
            GraphicsPath myPath = new GraphicsPath();
            myPath.StartFigure();
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 180, 90);
            myPath.AddLine(new Point(rect.X + cRadius, rect.Y), new Point(rect.Right - cRadius, rect.Y));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
            myPath.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Bottom - cRadius));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 0, 90);
            myPath.AddLine(new Point(rect.Right - cRadius, rect.Bottom), new Point(rect.X + cRadius, rect.Bottom));
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 90, 90);
            myPath.AddLine(new Point(rect.X, rect.Bottom - cRadius), new Point(rect.X, rect.Y + cRadius));
            myPath.CloseFigure();
            return myPath;
        }

        public void Clear()
        {
            try
            {
                while (Controls.Count > 0)
                {
                    Controls[0].Dispose();
                    Controls.RemoveAt(0);
                }
            }
            catch { }
        }
    }
}
