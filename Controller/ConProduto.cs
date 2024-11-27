using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using geekStore.Models;
using static System.Net.Mime.MediaTypeNames;

namespace geekStore.Controller
{
    internal class ConProduto
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public int Id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int quantidade { get; set; }
        public string foto { get; set; }
        public string tipo { get; set; }

        public List<ModProduto> ListaProdutos()
        {
            List<ModProduto> li = new List<ModProduto>();

            string sql = "SELECT p.Id, p.nome, p.preco, p.quantidade, p.foto, t.nome AS tipo FROM Produtos p JOIN Tipos t ON p.idTipo = t.Id";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ModProduto modProduto = new ModProduto();
                modProduto.Id = (int)dr["Id"];
                modProduto.nome = dr["nome"].ToString();
                modProduto.preco = (decimal)dr["preco"];
                modProduto.quantidade = (int)dr["quantidade"];
                modProduto.foto = dr["foto"].ToString();
                modProduto.tipo = dr["tipo"].ToString();
                li.Add(modProduto);
            }
            dr.Close();

            con.Close();

            return li;
        }

        public void Inserir(string nome, string preco, int quantidade, string foto, int idTipo)
        {
            try
            {
                decimal precoFinal = Convert.ToDecimal(preco);

                string sql = $"INSERT INTO Produtos (nome, preco, quantidade, foto, idTipo) VALUES ('{nome}', @preco, '{quantidade}', '{foto}', '{idTipo}')";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@preco", SqlDbType.Decimal).Value = precoFinal;
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Atualizar(int Id, string nome, string preco, int quantidade, string foto, int idTipo, string imagem)
        {
            try
            {
                decimal precoFinal = Convert.ToDecimal(preco);

                string sql = $"UPDATE Produtos SET nome = '{nome}', preco = @preco, quantidade = '{quantidade}', foto = '{foto}', idTipo = '{idTipo}' WHERE Id = {Id}";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@preco", SqlDbType.Decimal).Value = precoFinal;
                cmd.ExecuteNonQuery();

                con.Close();

                string imgUrl = Path.Combine(Config.ProdutosFolderPath, $"{imagem}.jpg");
                File.Delete(imgUrl);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir(int Id, string nome)
        {
            try
            {
                string sql = $"DELETE FROM Produtos WHERE Id = '{Id}'";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();

                string imagem = nome.Replace(" ", "");
                string imgUrl = Path.Combine(Config.ProdutosFolderPath, $"{imagem}.jpg");
                File.Delete(imgUrl);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Localizar(int id)
        {
            try
            {
                string sql = $"SELECT p.Id, p.nome, p.preco, p.quantidade, p.foto, t.nome AS tipo FROM Produtos p JOIN Tipos t ON p.idTipo = t.Id WHERE p.Id = {id}";

                if (con.State == ConnectionState.Open)
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
                        Id = (int)(dr["Id"]);
                        nome = dr["nome"].ToString();
                        preco = (decimal)dr["preco"];
                        quantidade = (int)dr["quantidade"];
                        foto = dr["foto"].ToString();
                        tipo = dr["tipo"].ToString();
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

        public bool RegistroRepetido(string nome, int idTipo)
        {
            string sql = $"SELECT * FROM Produtos WHERE nome = '{nome}' AND idTipo = '{idTipo}'";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = new SqlCommand(sql ,con);

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

        public void AtualizarEstoque(int Id, int quantidade)
        {
            try
            {
                decimal precoFinal = Convert.ToDecimal(preco);

                string sql = $"UPDATE Produtos SET quantidade = '{quantidade}' WHERE Id = {Id}";

                if (con.State == ConnectionState.Open)
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
    }
}
