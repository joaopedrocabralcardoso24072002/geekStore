using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geekStore
{
    public partial class frmDemonstrativo : Form
    {
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public frmDemonstrativo()
        {
            InitializeComponent();
        }

        private void frmDemonstrativo_Load(object sender, EventArgs e)
        {
            CarregaCbxProduto();
            CarregaCbxMes();
            cbxProduto.Focus();
        }

        private void CarregaCbxProduto()
        {
            try
            {
                string sql = "SELECT Id, nome FROM Produtos ORDER BY nome";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataSet ds = new DataSet();

                da.Fill(ds, "Produtos");

                cbxProduto.ValueMember = "Id";
                cbxProduto.DisplayMember = "nome";
                cbxProduto.DataSource = ds.Tables["Produtos"];

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaCbxMes()
        {
            try
            {
                string sql = "SELECT dataVenda FROM Vendas ORDER BY dataVenda ASC";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataSet ds = new DataSet();

                da.Fill(ds, "Vendas");

                cbxMes.ValueMember = "Id";
                cbxMes.DisplayMember = "dataVenda";
                cbxMes.DataSource = ds.Tables["Vendas"];
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT YEAR(dataVenda) AS Ano, MONTH(dataVenda) AS Mes, COUNT(*) AS TotalVendas FROM Vendas GROUP BY YEAR(dataVenda), MONTH(dataVenda) ORDER BY Ano, Mes;";
        }
    }
}
