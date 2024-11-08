using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geekStore
{
    public partial class frmMenu : Form
    {
        public frmMenu(/*bool showSplash = true*/)
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(gradientBg);

            /*if (showSplash)
            {
                frmSplash splash = new frmSplash();
                splash.Show();
                Application.DoEvents();
                Thread.Sleep(3000);
                splash.Close();
            }*/
        }

        public void gradientBg(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rec = this.ClientRectangle;
            Color start = ColorTranslator.FromHtml("#B326FF");
            Color end = ColorTranslator.FromHtml("#30C1FD");
            using (LinearGradientBrush brush = new LinearGradientBrush(rec, start, end, 180F)) 
            { 
                g.FillRectangle(brush, rec); 
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja mesmo sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja mesmo sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
