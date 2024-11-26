using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            cbxProduto.Focus();

            cldDemonstrativo.MaxDate = DateTime.Now.Date;
            string sql = "SELECT MIN(dataVenda) FROM Vendas";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object minDate = cmd.ExecuteScalar();
            if (minDate != DBNull.Value && minDate != null)
            {
                DateTime minDateTime = Convert.ToDateTime(minDate);
                cldDemonstrativo.MinDate = minDateTime;
            }
            else
            {
                MessageBox.Show("Não há registros de vendas ou a tabela está vazia.", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cldDemonstrativo.MinDate = DateTime.Today;
            }


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

    }
}
