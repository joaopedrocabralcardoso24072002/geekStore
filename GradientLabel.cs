using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace geekStore
{
    internal class GradientLabel : Label
    {
        public Color GradientStart { get; set; } = Color.FromArgb(29, 108, 255); // Cor inicial
        public Color GradientEnd { get; set; } = Color.FromArgb(180, 40, 255);  // Cor final

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, GradientStart, GradientEnd, LinearGradientMode.Horizontal))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(this.Text, this.Font, brush, new PointF(0, 0));
            }
        }
    }
}
