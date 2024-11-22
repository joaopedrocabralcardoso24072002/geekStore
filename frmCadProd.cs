using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using geekStore.Controller;
using geekStore.Models;

namespace geekStore
{
    public partial class frmCadProd : Form
    {
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public frmCadProd()
        {
            InitializeComponent();
        }

        private void frmCadProd_Load(object sender, EventArgs e)
        {
            btnImagem.BringToFront();
            pbxImagem.SendToBack();
        }

        private void frmCadProd_Shown(object sender, EventArgs e)
        {

            CarregaCbxTipo();

            ConProduto conProduto = new ConProduto();
            List<ModProduto> modProdutos = conProduto.ListaProdutos();
            dgvProduto.DataSource = modProdutos;
            if (dgvProduto.Columns.Contains("foto"))
            {
                dgvProduto.Columns["foto"].Visible = false;
            }

            btnPesquisar.Enabled = false;
            btnLimparCampos.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            txtNome.Focus();
        }

        private void LimpaCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            cbxTipo.Text = string.Empty;
            pbxImagem.Image = null;
            pbxImagem.Update();

            VerificaCampos();
        }

        private void VerificaCampos()
        {
            if (txtId.Text == string.Empty && txtNome.Text == string.Empty && txtPreco.Text == string.Empty && txtQuantidade.Text == string.Empty && cbxTipo.Text == string.Empty)
            {
                btnLimparCampos.Enabled = false;
            }
            else
            {
                btnLimparCampos.Enabled = true;
            }
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

            cbxTipo.ValueMember = "Id";
            cbxTipo.DisplayMember = "nome";

            cbxTipo.DataSource = ds.Tables["Tipos"];

            con.Close();

            cbxTipo.Text = string.Empty;
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProduto.Rows[e.RowIndex];
                row.Selected = true;

                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtPreco.Text = row.Cells[2].Value.ToString();
                txtQuantidade.Text = row.Cells[3].Value.ToString();
                cbxTipo.Text = row.Cells[5].Value.ToString();

                string imagem = row.Cells[4].Value.ToString();
                pbxImagem.Image = Image.FromFile($@"C:\Programas\geekStore\Produtos\{imagem}.jpg");

                btnInserir.Enabled = false;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnLimparCampos.Enabled = true;
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty && txtNome.Text == string.Empty && txtPreco.Text == string.Empty && txtQuantidade.Text == string.Empty && cbxTipo.Text == string.Empty)
            {
                btnPesquisar.Enabled = true;
            }
            else
            {
                btnPesquisar.Enabled = false;
            }

            VerificaCampos();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            VerificaCampos();
        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            VerificaCampos();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            VerificaCampos();
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificaCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecionar imagem...";
            dialog.Filter = "Todos os arquivos de imagem|*.bmp;*.jpg;*.jpeg;*.png;*.gif | " + 
                            "Bitmap (*.bmp;)|*.bmp | " +
                            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg | " +
                            "GIF (*.gif)|*.gif | " +
                            "PNG (*.png)|*.png | " +
                            "Todos os Arquivos|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imagem = dialog.FileName;
                pbxImagem.ImageLocation = imagem;
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text == string.Empty || txtPreco.Text == string.Empty || txtQuantidade.Text == string.Empty)
                {
                    MessageBox.Show($"Por favor, preencha todos os campos!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    ConProduto conProduto = new ConProduto();
                    int idTipo = cbxTipo.SelectedIndex;
                    if (conProduto.RegistroRepetido(txtNome.Text, idTipo))
                    {
                        MessageBox.Show($"\"{txtNome.Text}\" já existe em nossa base de dados!", "Produto Repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Focus();
                        txtNome.SelectAll();
                        return;
                    }
                    else
                    {
                        string imagem = txtNome.Text.Replace(" ", "");
                        pbxImagem.Image.Save($@"C:\Programas\geekStore\Produtos\{imagem}.jpg");

                        int quantidade = Convert.ToInt32(txtQuantidade.Text);

                        conProduto.Inserir(txtNome.Text, txtPreco.Text, quantidade, imagem, idTipo);

                        MessageBox.Show("Produto inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        List<ModProduto> modProdutos = conProduto.ListaProdutos();

                        dgvProduto.DataSource = modProdutos;

                        LimpaCampos();

                        txtNome.Focus();
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());

                ConProduto conProduto = new ConProduto();
                conProduto.Localizar(id);

                txtNome.Text = conProduto.nome.ToString();
                txtPreco.Text = conProduto.preco.ToString();
                txtQuantidade.Text = conProduto.quantidade.ToString();
                cbxTipo.Text = conProduto.tipo.ToString();
                string imagem = txtNome.Text.Replace(" ", "");
                pbxImagem.Image = Image.FromFile($@"C:\Programas\geekStore\Produtos\{imagem}.jpg");

                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());

                string imagem = txtNome.Text.Replace(" ", "");
                if (pbxImagem.Image != null)
                {
                    pbxImagem.Image.Dispose();
                    pbxImagem.Image = null;
                }

                int idTipo = cbxTipo.SelectedIndex;

                ConProduto conProduto = new ConProduto();
                int quantidade = Convert.ToInt32(txtQuantidade.Text);
                conProduto.Atualizar(id, txtNome.Text, txtPreco.Text, quantidade, imagem, idTipo);

                List<ModProduto> modProduto = conProduto.ListaProdutos();
                dgvProduto.DataSource = modProduto;

                LimpaCampos();

                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;

                txtNome.Focus();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Um Erro ocorreu: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (pbxImagem.Image != null)
                {
                    pbxImagem.Image.Dispose();
                    pbxImagem.Image = null;
                }

                int id = Convert.ToInt32(txtId.Text.Trim());

                ConProduto conProduto = new ConProduto();
                conProduto.Localizar(id);

                string nome = conProduto.nome;
                string imagem = conProduto.foto;

                System.IO.FileInfo fi = new System.IO.FileInfo($@"C:\Programas\geekStore\Produtos\{imagem}.jpg");
                fi.Delete();

                conProduto.Excluir(id);

                MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                List<ModProduto> modProdutos = conProduto.ListaProdutos();
                dgvProduto.DataSource = modProdutos;

                LimpaCampos();

                txtNome.Focus();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Um erro ocorreu: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}