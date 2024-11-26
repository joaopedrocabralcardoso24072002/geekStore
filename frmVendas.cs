using geekStore.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geekStore
{
    public partial class frmVendas : Form
    {
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public frmVendas()
        {
            InitializeComponent();
        }

        private void frmVendas_Shown(object sender, EventArgs e)
        {
            CarregaCbxProduto();

            cbxNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtPreco.Enabled = false;
            txtQuantidade.Text = string.Empty;
            txtQuantidade.Enabled = false;
            txtTotal.Text = string.Empty;
            txtTotal.Enabled = false;

            btnInserir.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimparCampos.Enabled = false;
            btnVenda.Enabled = false;


            dgvVenda.Columns.Add("Id", "Id");
            dgvVenda.Columns.Add("Nome", "Nome");
            dgvVenda.Columns.Add("Preco", "Preço");
            dgvVenda.Columns.Add("Quantidade", "Quantidade");
            dgvVenda.Columns.Add("Total", "Total");
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

                cbxNome.ValueMember = "Id";
                cbxNome.DisplayMember = "nome";
                cbxNome.DataSource = ds.Tables["Produtos"];

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Produtos WHERE Id = @id";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", cbxNome.SelectedValue);
                
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtQuantidade.Enabled = true;
                    btnInserir.Enabled = true;
                    btnEditar.Enabled = true;
                    // btnExcluir.Enabled = true;
                    btnLimparCampos.Enabled = true;

                    txtPreco.Text = dr["preco"].ToString();
                    txtQuantidade.Focus();
                }
                dr.Close();

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvVenda.Rows[e.RowIndex];
            cbxNome.Text = row.Cells[1].Value.ToString();
            txtPreco.Text = row.Cells[2].Value.ToString();
            txtQuantidade.Text = row.Cells[3].Value.ToString();
            txtQuantidade.SelectAll();
            txtQuantidade.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            cbxNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text == string.Empty)
            {
                MessageBox.Show("Digite a quantidade do produto!", "Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantidade.Focus();
                return;
            }
            else if (txtQuantidade.Text == "0")
            {
                DialogResult res = MessageBox.Show("A quantidade foi definida como '0'. Deseja continuar?", "Quantidade", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res != DialogResult.Yes)
                {
                    txtQuantidade.Focus();
                    txtQuantidade.SelectAll();
                    return;
                }
            }

            try
            {
                string sql = "SELECT * FROM Produtos WHERE Id = @id";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", cbxNome.SelectedValue);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToInt32(txtQuantidade.Text.Trim()) > Convert.ToInt32(dr[3]))
                    {
                        MessageBox.Show("Quantidade indisponível em estoque! \nDigite um valor menor.", "Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQuantidade.Focus();
                        txtQuantidade.SelectAll();
                        return;
                    }
                }
                dr.Close();

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (DataGridViewRow row in dgvVenda.Rows)
            {
                if (Convert.ToString(cbxNome.SelectedValue) == row.Cells[0].Value.ToString())
                {
                    MessageBox.Show("Produto já cadastrado!", "Produto Repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataGridViewRow item = new DataGridViewRow();
            item.CreateCells(dgvVenda);
            item.Cells[0].Value = cbxNome.SelectedValue;
            item.Cells[1].Value = cbxNome.Text;
            item.Cells[2].Value = txtPreco.Text;
            item.Cells[3].Value = txtQuantidade.Text;
            item.Cells[4].Value = Convert.ToDecimal(txtQuantidade.Text) * Convert.ToDecimal(txtPreco.Text);
            dgvVenda.Rows.Add(item);

            cbxNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;

            btnVenda.Enabled = true;

            decimal soma = 0;
            foreach (DataGridViewRow dr in dgvVenda.Rows)
            {
                soma += Convert.ToDecimal(dr.Cells[4].Value);
            }
            txtTotal.Text = soma.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Produtos WHERE Id = @id";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Id", cbxNome.SelectedValue);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (Convert.ToInt32(txtQuantidade.Text.Trim()) > Convert.ToInt32(dr[2]))
                {
                    MessageBox.Show("Quantidade indisponível em estoque! \nDigite um valor menor.", "Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantidade.Focus();
                    txtQuantidade.SelectAll();
                    return;
                }
                else if (txtQuantidade.Text == "0")
                {
                    DialogResult res = MessageBox.Show("A quantidade foi definida como '0'. Deseja continuar?", "Quantidade", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res != DialogResult.Yes)
                    {
                        txtQuantidade.Focus();
                        txtQuantidade.SelectAll();
                        return;
                    }
                }
            }
            dr.Close();

            con.Close();

            int row = dgvVenda.CurrentRow.Index;
            dgvVenda.Rows[row].Cells[0].Value = cbxNome.SelectedValue;
            dgvVenda.Rows[row].Cells[1].Value = cbxNome.Text;
            dgvVenda.Rows[row].Cells[2].Value = txtPreco.Text;
            dgvVenda.Rows[row].Cells[3].Value = txtQuantidade.Text;
            dgvVenda.Rows[row].Cells[4].Value = Convert.ToDecimal(txtQuantidade.Text.Trim()) * Convert.ToDecimal(txtPreco.Text.Trim());

            cbxNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;

            decimal soma = 0;
            foreach (DataGridViewRow dgvr in dgvVenda.Rows)
            {
                soma += Convert.ToDecimal(dgvr.Cells[4].Value);
            }
            txtTotal.Text = soma.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int row = dgvVenda.CurrentRow.Index;
            dgvVenda.Rows.RemoveAt(row);

            cbxNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimparCampos.Enabled = false;

            decimal soma = 0;
            foreach (DataGridViewRow dataGridViewRow in dgvVenda.Rows)
            {
                soma += Convert.ToDecimal(dataGridViewRow.Cells[4].Value);
            }
            txtTotal.Text = soma.ToString();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            
        }
    }
}
