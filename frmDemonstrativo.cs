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
        private string Data;

        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public frmDemonstrativo()
        {
            InitializeComponent();
        }

        private void frmDemonstrativo_Load(object sender, EventArgs e)
        {
            CarregaCbxMes();
            cbxMes.Text = string.Empty;
            cbxMes.Focus();
        }

        private void frmDemonstrativo_Shown(object sender, EventArgs e)
        {
            dgvDemonstrativo.Columns.Add("Nome", "Nome");
            dgvDemonstrativo.Columns.Add("Quantidade", "Quantidade");
            dgvDemonstrativo.Columns.Add("Preco", "Preço");
            dgvDemonstrativo.Columns.Add("Total", "Total");
        }

        private void CarregaCbxMes()
        {
            try
            {
                string sql = "SELECT CONCAT(MONTH(dataVenda), '/', YEAR(dataVenda)) AS Data FROM Vendas GROUP BY YEAR(dataVenda), MONTH(dataVenda)";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataSet ds = new DataSet();

                da.Fill(ds, "Vendas");

                cbxMes.DisplayMember = "Data";
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
            string ano = string.Empty;
            string mes = string.Empty;
            string[] partes = cbxMes.Text.Split('/');
            if (partes.Length == 2)
            {
                Data = $"{partes[1]}/{partes[0]}";
                mes = partes[0];
                ano = partes[1];
            }
            else
            {
                MessageBox.Show("Formato de data inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string sql = "SELECT v.dataVenda, p.nome AS Nome, pv.quantidade AS Quantidade, pv.valorUnitário AS Preco, pv.quantidade * pv.valorUnitário AS Total FROM Vendas AS v JOIN ProdutosVendas AS pv ON v.Id = pv.idVenda JOIN Produtos AS p ON pv.idProduto = p.Id WHERE YEAR(v.dataVenda) = @ano AND MONTH(v.dataVenda) = @mes ORDER BY v.dataVenda, p.nome";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ano", ano);
            cmd.Parameters.AddWithValue("@mes", mes);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvDemonstrativo);
                row.Cells[0].Value = dr[1].ToString();
                row.Cells[1].Value = dr[2].ToString();
                row.Cells[2].Value = dr[3].ToString();
                row.Cells[3].Value = dr[4].ToString();
                dgvDemonstrativo.Rows.Add(row);
            }
            dr.Close();

            con.Close();

            decimal soma = 0;
            foreach (DataGridViewRow dgvr in dgvDemonstrativo.Rows)
            {
                soma += Convert.ToDecimal(dgvr.Cells[3].Value);
            }
            txtTotal.Text = soma.ToString();
        }
    }
}
