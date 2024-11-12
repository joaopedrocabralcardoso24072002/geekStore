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
        public frmMenu(bool showSplash = true)
        {
            InitializeComponent();

            if (showSplash)
            {
                frmSplash splash = new frmSplash();
                splash.Show();
                Application.DoEvents();
                Thread.Sleep(/*3000*/1000);
                splash.Close();
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
    }
}
