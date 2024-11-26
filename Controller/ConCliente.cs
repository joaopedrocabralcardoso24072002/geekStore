using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using geekStore.Models;

namespace geekStore.Controller
{
    internal class ConCliente
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataRegistro { get; set; }
        public string senha { get; set; }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public void Inserir(string nome, string cpf, string email, string telefone, string senha)
        {
            try
            {
                DateTime data = DateTime.Now.Date;
                string dataRegistro = data.ToString("MM/dd/yyyy");

                string sql = $"INSERT INTO Clientes (nome, cpf, email, telefone, dataRegistro, senha) VALUES ('{nome}', '{cpf}', '{email}', '{telefone}', '{dataRegistro}', '{senha}')";

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void Atualizar(int id, string nome, string cpf, string email, string telefone, string senha)
        {
            try
            {
                string sql = $"UPDATE Clientes SET nome = '{nome}', cpf = '{cpf}', email = '{email}', telefone = '{telefone}', senha = '{senha}' WHERE Id = '{id}'";

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                string sql = $"DELETE FROM Clientes WHERE Id = '{id}'";

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool LocalizarEmail(string oEmail)
        {
            try
            {
                string sql = $"SELECT * FROM Clientes WHERE email = '{oEmail}'";

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        nome = dr["nome"].ToString();
                        cpf = dr["cpf"].ToString();
                        email = dr["email"].ToString();
                        telefone = dr["telefone"].ToString();
                        senha = dr["senha"].ToString();
                    }
                    dr.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    dr.Close();
                    con.Close();
                    return false;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool LocalizarCpf(string oCpf)
        {
            try
            {
                string sql = $"SELECT * FROM Clientes WHERE cpf = '{oCpf}'";

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Id = (int)dr["Id"];
                        nome = dr["nome"].ToString();
                        cpf = dr["cpf"].ToString();
                        email = dr["email"].ToString();
                        telefone = dr["telefone"].ToString();
                        senha = dr["senha"].ToString();
                    }
                    dr.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    dr.Close();
                    con.Close();
                    return false;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool RegistroRepetido(string cpf, string email)
        {
            string sql = $"SELECT * FROM Clientes WHERE cpf = '{cpf}' OR email = '{email}'";

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                con.Close();
                return true;
            }

            con.Close();
            return false;
        }
    }
}
