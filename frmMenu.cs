using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public frmMenu()
        {
            InitializeComponent();
            strMenu.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
        }

        private void frmMenu_Shown(object sender, EventArgs e)
        {
            CarregaCbxTipo();
        }

        private void CarregaCbxTipo()
        {
            string sql = "SELECT * FROM Tipos ORDER BY Id";

            SqlCommand cmd = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tipos"); // Vai para o banco e preenche o dataSet

            DataTable tiposTable = ds.Tables["Tipos"];
            int proximoId = tiposTable.Rows.Count > 0
                ? tiposTable.AsEnumerable().Max(row => row.Field<int>("Id")) + 1
                : 1; // Caso não existam registros, começa com 1.

            // Criar uma nova linha para o DataTable
            DataRow novaLinha = tiposTable.NewRow();
            novaLinha["Id"] = proximoId; // Próximo Id
            novaLinha["nome"] = "Todos"; // Nome exibido
            tiposTable.Rows.Add(novaLinha); // Adiciona no final (ou use InsertAt para inserir no início)


            cbxTipo.ValueMember = "Id";
            cbxTipo.DisplayMember = "nome";

            cbxTipo.DataSource = ds.Tables["Tipos"];

            con.Close();

            cbxTipo.Text = string.Empty;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCli cadCli = new frmCadCli("menu");
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

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendas vendas = new frmVendas();
            this.Hide();
            vendas.ShowDialog();
            this.Show();
        }

        private void demonstrativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDemonstrativo demonstrativo = new frmDemonstrativo();
            this.Hide();
            demonstrativo.ShowDialog();
            this.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            this.Hide();
            sobre.ShowDialog();
            this.Show();
        }

        private void pbxClientes_Click(object sender, EventArgs e)
        {
            frmCadCli cadCli = new frmCadCli("menu");
            this.Hide();
            cadCli.ShowDialog();
            this.Show();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            frmCadCli cadCli = new frmCadCli("menu");
            this.Hide();
            cadCli.ShowDialog();
            this.Show();
        }

        private void pbxProdutos_Click(object sender, EventArgs e)
        {
            frmCadProd cadProd = new frmCadProd();
            this.Hide();
            cadProd.ShowDialog();
            this.Show();
        }

        private void lblProdutos_Click(object sender, EventArgs e)
        {
            frmCadProd cadProd = new frmCadProd();
            this.Hide();
            cadProd.ShowDialog();
            this.Show();
        }

        private void pbxVendas_Click(object sender, EventArgs e)
        {
            frmVendas vendas = new frmVendas();
            this.Hide();
            vendas.ShowDialog();
            this.Show();
        }

        private void lblVendas_Click(object sender, EventArgs e)
        {
            frmVendas vendas = new frmVendas();
            this.Hide();
            vendas.ShowDialog();
            this.Show();
        }

        private void pbxDemonstrativo_Click(object sender, EventArgs e)
        {
            frmDemonstrativo demonstrativo = new frmDemonstrativo();
            this.Hide();
            demonstrativo.ShowDialog();
            this.Show();
        }

        private void lblDemonstrativo_Click(object sender, EventArgs e)
        {
            frmDemonstrativo demonstrativo = new frmDemonstrativo();
            this.Hide();
            demonstrativo.ShowDialog();
            this.Show();
        }

        private void pbxSobre_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            this.Hide();
            sobre.ShowDialog();
            this.Show();
        }

        private void lblSobre_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            this.Hide();
            sobre.ShowDialog();
            this.Show();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja mesmo sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int idTipo = cbxTipo.SelectedIndex + 1;
            string sql = $"SELECT * FROM Produtos AS p JOIN Tipos AS t ON p.idTipo = t.Id WHERE p.idTipo = '{idTipo}'";
        }
    }
}
