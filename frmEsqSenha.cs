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
    public partial class frmEsqSenha : Form
    {
        public frmEsqSenha()
        {
            InitializeComponent();

            txtCpf.Mask = "000.000.000-00";
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

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text != string.Empty)
            {
                btnPesquisar.Enabled = true;
            }
            else
            {
                btnPesquisar.Enabled = false;
            }
        }

        private void txtCpf_Click(object sender, EventArgs e)
        {
            txtCpf.SelectionStart = 0;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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

                txtSenha.Text = conCliente.senha.ToString();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
