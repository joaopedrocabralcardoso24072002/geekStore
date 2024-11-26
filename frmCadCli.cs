using geekStore.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geekStore
{
    public partial class frmCadCli : Form
    {
        private string Lugar;
        public frmCadCli(string lugar)
        {
            InitializeComponent();

            Lugar = lugar;
        }

        private void frmCadCli_Load(object sender, EventArgs e)
        {
            txtCpf.Mask = "000.000.000-00";
            txtTelefone.Mask = "(00) 0 0000-0000";

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = false;
            btnLimparCampos.Enabled = false;

            txtNome.Focus();
        }

        private void LimpaCampos()
        {
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtSenha.Enabled = true;
            txtConfSenha.Text = string.Empty;
            txtConfSenha.Enabled = true;

            btnCadastrar.Enabled = true;

            VerificaCampos();
        }

        private void VerificaCampos()
        {
            if (txtNome.Text == string.Empty && txtEmail.Text == string.Empty && txtSenha.Text == string.Empty && txtConfSenha.Text == string.Empty)
            {
                txtSenha.Enabled = true;
                txtConfSenha.Enabled = true;
                btnLimparCampos.Enabled = false;
            }
            else
            {
                btnLimparCampos.Enabled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= (char)65 && e.KeyChar <= (char)90) || (e.KeyChar >= (char)97 && e.KeyChar <= (char)122) || e.KeyChar == (char)32 || e.KeyChar == (char)13 || e.KeyChar == (char)8))
            {
                e.Handled = true;
                MessageBox.Show("Apenas letras permitidas!", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            VerificaCampos();
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty && txtEmail.Text == string.Empty && txtSenha.Text == string.Empty && txtConfSenha.Text == string.Empty)
            {
                btnPesquisar.Enabled = true;
            }
            else
            {
                btnPesquisar.Enabled = false;
            }

            VerificaCampos();
        }

        private void txtCpf_Click(object sender, EventArgs e)
        {
            txtCpf.SelectionStart = 0;
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            VerificaCampos();
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.SelectionStart = 0;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(txtEmail.Text, email) && txtEmail.Text != string.Empty)
            {
                MessageBox.Show("Por favor, verifique o e-mail.", "E-mail inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.SelectAll();
                txtEmail.Focus();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            VerificaCampos();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.Text == string.Empty)
            {
                pbxOlho.Visible = false;
            }
            else
            {
                pbxOlho.Visible = true;
            }
            VerificaCampos();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)32)
            {
                e.Handled = true;
                MessageBox.Show("Espaços não são permitidos!", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtConfSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtConfSenha.Text == string.Empty)
            {
                pbxOlho2.Visible = false;
            }
            else
            {
                pbxOlho2.Visible = true;
            }

            if (txtConfSenha.Text != txtSenha.Text && txtConfSenha.Text != string.Empty)
            {
                txtConfSenha.BackColor = Color.Red;
                pbxOlho2.BackColor = Color.Red;
                btnCadastrar.Enabled = false;
            }
            else
            {
                txtConfSenha.BackColor = Color.FromArgb(11, 11, 33);
                pbxOlho2.BackColor = Color.FromArgb(11, 11, 33);
                btnCadastrar.Enabled = true;
            }

            VerificaCampos();
        }

        private void txtConfSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)32)
            {
                e.Handled = true;
                MessageBox.Show("Espaços não são permitidos!", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pbxOlho_Click(object sender, EventArgs e)
        {
            if (pbxOlho.Tag?.ToString() != "eye_open")
            {
                pbxOlho.Image = Properties.Resources.open_eye_24;
                pbxOlho.Tag = "eye_open";
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                pbxOlho.Image = Properties.Resources.closed_eye_24;
                pbxOlho.Tag = "eye_closed";
                txtSenha.PasswordChar = '*';
            }
            txtSenha.Focus();
        }

        private void pbxOlho2_Click(object sender, EventArgs e)
        {
            if (pbxOlho2.Tag?.ToString() != "eye_open")
            {
                pbxOlho2.Image = Properties.Resources.open_eye_24;
                pbxOlho2.Tag = "eye_open";
                txtConfSenha.PasswordChar = '\0';
            }
            else
            {
                pbxOlho2.Image = Properties.Resources.closed_eye_24;
                pbxOlho2.Tag = "eye_closed";
                txtConfSenha.PasswordChar = '*';
            }
            txtConfSenha.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text == string.Empty || txtCpf.Text == string.Empty || txtTelefone.Text == string.Empty || txtEmail.Text == string.Empty || txtSenha.Text == string.Empty || txtConfSenha.Text == string.Empty)
                {
                    MessageBox.Show($"Por favor, preencha todos os campos!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    ConCliente conCliente = new ConCliente();
                    string cpf = txtCpf.Text.Replace(",", "").Replace("-", "");
                    if (conCliente.RegistroRepetido(cpf, txtEmail.Text))
                    {
                        MessageBox.Show($"\"{txtNome.Text}\" já existe em nossa base de dados!", "Registro repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Focus();
                        txtNome.SelectAll();
                        return;
                    }
                    else
                    {

                        string telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                        conCliente.Inserir(txtNome.Text, cpf, txtEmail.Text, telefone, txtSenha.Text);

                        MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Lugar != "menu")
                        {
                            frmMenu menu = new frmMenu();
                            this.Hide();
                            menu.ShowDialog();
                        }

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtConfSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("Confirmar senha!", "Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfSenha.Focus();
                return;
            }
            try
            {
                ConCliente conCliente = new ConCliente();

                string cpf = txtCpf.Text.Replace(",", "").Replace("-", "");
                if (conCliente.LocalizarCpf(cpf))
                {
                    int id = conCliente.Id;

                    string telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                    conCliente.Atualizar(id, txtNome.Text, cpf, txtEmail.Text, telefone, txtSenha.Text);

                    MessageBox.Show("Cliente editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpaCampos();

                    btnCadastrar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnExcluir.Enabled = false;

                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Cliente não cadastrado!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string cpf = txtCpf.Text.Replace(",", "").Replace("-", "");

                ConCliente conCliente = new ConCliente();
                bool find = conCliente.LocalizarCpf(cpf);
                if (!find)
                {
                    MessageBox.Show("Registro não encontrado!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpf.Focus();
                    txtCpf.SelectAll();
                    return;
                }

                txtNome.Text = conCliente.nome.ToString();
                txtCpf.Text = conCliente.cpf.ToString();
                txtTelefone.Text = conCliente.telefone.ToString();
                txtEmail.Text = conCliente.email.ToString();

                if (Lugar != "login")
                {

                    txtSenha.Text = conCliente.senha.ToString();
                    btnEditar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
                else
                {
                    txtSenha.Enabled = false;
                    txtConfSenha.Enabled = false;
                    btnEditar.Enabled = false;
                    btnExcluir.Enabled = false;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtConfSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("Confirmar senha!", "Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfSenha.Focus();
                return;
            }

            ConCliente conCliente = new ConCliente();

            string cpf = txtCpf.Text.Replace(",", "").Replace("-", "");
            if (conCliente.LocalizarCpf(cpf))
            {
                int id = conCliente.Id;

                DialogResult res = MessageBox.Show("Realmente deseja excluir este registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    conCliente.Excluir(id);

                    MessageBox.Show("Registro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpaCampos();
                    btnCadastrar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnExcluir.Enabled = false;

                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("Cliente não cadastrado!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
