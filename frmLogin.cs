using geekStore.Controller;
using geekStore.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geekStore
{
    public partial class frmLogin : Form
    {
        public frmLogin(bool showSplash = true)
        {
            InitializeComponent();

            if (showSplash)
            {
                frmSplash splash = new frmSplash();
                splash.Show();
                Application.DoEvents();
                Thread.Sleep(3000);
                splash.Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
        }

        private void pbxOlho_Click(object sender, EventArgs e)
        {
            if (pbxOlho.Tag?.ToString() != "eye_open")
            {
                pbxOlho.Image = Properties.Resources.eye_open_30;
                pbxOlho.Tag = "eye_open";
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                pbxOlho.Image = Properties.Resources.eye_closed_30;
                pbxOlho.Tag = "eye_closed";
                txtSenha.PasswordChar = '*';
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadCli cadCli = new frmCadCli("login");
            this.Hide();
            cadCli.ShowDialog();
            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty || txtSenha.Text == string.Empty)
            {
                MessageBox.Show("E-mail ou senha incorretos!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
                return;
            }

            ConCliente conCliente = new ConCliente();
            if (conCliente.LocalizarEmail(txtUsuario.Text))
            {
                string senha = conCliente.senha.ToString();
                if (txtSenha.Text != senha)
                {
                    MessageBox.Show("Senha incorreta!", "Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Focus();
                    txtSenha.SelectAll();
                    return;
                }
                else
                {
                    frmVendas.idCliente = conCliente.Id;

                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Usuário não cadastrado!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Text = string.Empty;
                txtUsuario.SelectAll();
                txtUsuario.Focus();
                return;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void lnkEsqSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEsqSenha esqSenha = new frmEsqSenha();
            this.Hide();
            esqSenha.ShowDialog();
            this.Show();
        }
    }
}
