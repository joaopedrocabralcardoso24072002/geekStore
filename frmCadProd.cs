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

        private void limpaCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            cbxTipo.Text = string.Empty;
            pbxImagem.Image = null;
            pbxImagem.Update();
        }

        private void frmCadProd_Load(object sender, EventArgs e)
        {
            btnImagem.BringToFront();
            pbxImagem.SendToBack();
        }

        private void frmCadProd_Shown(object sender, EventArgs e)
        {

            CarregaCbxTipo();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        public void CarregaCbxTipo()
        {
            string sql = "SELECT * FROM Tipos";

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

                /* Para fins de depuração */
                txtNome.Text = imagem;
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

                        limpaCampos();

                        txtNome.Focus();
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}