using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using geekStore.Models;

namespace geekStore.Controller
{
    internal class ConProduto
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public List<ModProduto> ListaProdutos()
        {
            List<ModProduto> li = new List<ModProduto>();

            string sql = "SELECT p.Id, p.nome, p.preco, p.quantidade, p.foto, t.nome AS tipo FROM Produtos p JOIN Tipos t ON p.idTipo = t.Id;";

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

        public void Atualizar(int Id, string nome, string preco, int quantidade, string foto, int idTipo)
        {
            try
            {
                decimal precoFinal = Convert.ToDecimal(preco);

                string sql = $"UPDATE Produtos SET nome = '{nome}', preco = @preco, quantidade = '{quantidade}', foto = '{foto}', idTipo = '{idTipo}')";

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

        public void Excluir(int Id)
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
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Localizar(int Id = -1, string nomeProd = null)
        {
            try
            {
                // Busca por Id
                if (Id > -1 && nomeProd == null)
                {
                    string sql = $"SELECT * FROM Produtos WHERE Id = '{Id}'";

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        
                    }
                    dr.Close();
                    con.Close();
                }
                // Busca por nome
                else if (Id == -1 && nomeProd != null)
                {

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
