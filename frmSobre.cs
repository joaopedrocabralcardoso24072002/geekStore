using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geekStore
{
    public partial class frmSobre : Form
    {
        public frmSobre()
        {
            InitializeComponent();

            btnVoltar.BringToFront();

            GradientLabel gradientLabel = new GradientLabel
            {
                Text = "Geek Store",
                Font = new Font("Segoe Print", 24, FontStyle.Bold | FontStyle.Italic),
                GradientStart = Color.FromArgb(29, 108, 255),
                GradientEnd = Color.FromArgb(180, 40, 255),
                Size = new Size(200, 50),
                Location = new Point(21, 21)
            };
            this.Controls.Add(gradientLabel);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(linkLabel1.Text);

            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(800, "Cópia Realizada", "E-mail copiado para a área de transferência.", ToolTipIcon.Info);
        }
    }
}
