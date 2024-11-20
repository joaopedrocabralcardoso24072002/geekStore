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
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja mesmo sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCli cadCli = new frmCadCli();
            this.Hide();
            cadCli.ShowDialog();
            this.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadProd cadProd = new frmCadProd();
            this.Hide();
            cadProd.ShowDialog();
            this.Show();
        }
    }
}
