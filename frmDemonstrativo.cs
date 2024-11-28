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
            cbxMes.Focus();
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
            string[] partes = cbxMes.Text.Split('/');
            if (partes.Length == 2)
            {
                Data = $"{partes[1]}/{partes[0]}";
            }
            else
            {
                MessageBox.Show("Formato de data inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*SELECT v.dataVenda, p.nome AS Produto, pv.quantidade AS Quantidade, pv.valorUnitario AS ValorUnitario, pv.quantidade * pv.valorUnitario AS TotalProduto FROM Venda AS v JOIN ProdutoVenda AS pv ON v.Id = pv.Venda_Id JOIN Produto AS p ON pv.Produto_Id = p.Id WHERE MONTH(v.dataVenda) = @Data -- Replace ? with the desired month GROUP BY v.dataVenda, p.nome, pv.quantidade, pv.valorUnitario ORDER BY v.dataVenda, p.nome;*/

            string sql = "SELECT COUNT(*) AS TotalVendas FROM Vendas WHERE FORMAT(dataVenda, 'yyyy/MM') = @Data GROUP BY YEAR(dataVenda), MONTH(dataVenda) ORDER BY YEAR(dataVenda), MONTH(dataVenda)";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Data", Data);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

            }
        }
    }
}
