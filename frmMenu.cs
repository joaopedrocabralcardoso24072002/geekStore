using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace geekStore
{
    public partial class frmMenu : Form
    {
        private int IdTipo;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbGeekStore"].ConnectionString);

        public frmMenu()
        {
            InitializeComponent();
            strMenu.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
        }

        private void frmMenu_Shown(object sender, EventArgs e)
        {
            CarregaCbxTipo();
        }

        private void frmMenu_Activated(object sender, EventArgs e)
        {
            if (chtMenu.Series["Nome"].Points.Count > 0)
            {
                chtMenu.Series["Nome"].Points.Clear();
            }
            CarregaGrafico();
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
            da.Fill(ds, "Tipos");

            DataTable tiposTable = ds.Tables["Tipos"];
            int proximoId = 1;
            if (tiposTable.Rows.Count > 0)
            {
                proximoId = tiposTable.AsEnumerable().Max(row => row.Field<int>("Id")) + 1;
            }
            DataRow novaLinha = tiposTable.NewRow();
            novaLinha["Id"] = proximoId;
            novaLinha["nome"] = "Todos";
            tiposTable.Rows.Add(novaLinha);

            cbxTipo.ValueMember = "Id";
            cbxTipo.DisplayMember = "nome";

            cbxTipo.DataSource = ds.Tables["Tipos"];

            con.Close();

            cbxTipo.SelectedValue = proximoId;
            IdTipo = proximoId;
        }

        private void CarregaGrafico()
        {
            try
            {
                string sql = "SELECT t.nome AS 'Nome', COUNT(p.idTipo) AS 'Total' FROM Produtos p JOIN Tipos t ON p.idTipo = t.Id GROUP BY t.nome ";

                SqlCommand cmd = new SqlCommand(sql, con);

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int total = dr.GetInt32(dr.GetOrdinal("Total"));
                    string nome = dr.GetString(dr.GetOrdinal("Nome"));

                    var point = chtMenu.Series["Nome"].Points.AddXY(nome, total);

                    var addedPoint = chtMenu.Series["Nome"].Points.Last(); 
                    addedPoint.Label = total.ToString();
                    addedPoint.LabelForeColor = Color.FromArgb(29, 108, 255);
                    addedPoint.Font = new Font("Segoe Print", 14, FontStyle.Bold);
                }                
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltroGrafico(int id)
        {
            if (chtMenu.Series["Nome"].Points.Count > 0)
            {
                chtMenu.Series["Nome"].Points.Clear();
            }

            try
            {
                if (id == IdTipo)
                {
                    CarregaGrafico();
                }
                else
                {
                    string sql = "SELECT TOP 7 p.nome AS 'Nome', SUM(pv.quantidade) AS 'Quantidade' FROM Produtos p JOIN ProdutosVendas pv ON p.Id = pv.idProduto JOIN Tipos t ON p.idTipo = t.Id WHERE p.idTipo = @idTipo GROUP BY p.nome ORDER BY SUM(pv.quantidade) DESC";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@idTipo", id);

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int quantidade = dr.GetInt32(dr.GetOrdinal("Quantidade"));
                        string nome = dr.GetString(dr.GetOrdinal("Nome"));

                        var point = chtMenu.Series["Nome"].Points.AddXY(nome, quantidade);

                        var addedPoint = chtMenu.Series["Nome"].Points.Last();
                        addedPoint.Label = quantidade.ToString();
                        addedPoint.LabelForeColor = Color.FromArgb(29, 108, 255);
                        addedPoint.Font = new Font("Segoe Print", 14, FontStyle.Bold);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ocorreu um erro: {er.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCli cadCli = new frmCadCli("menu");
            this.Hide();
            cadCli.ShowDialog();
            this.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadProd cadProd = new frmCadProd();
            this.Hide();
            cadProd.ShowDialog();
            this.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendas vendas = new frmVendas();
            this.Hide();
            vendas.ShowDialog();
            this.Show();
        }

        private void demonstrativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDemonstrativo demonstrativo = new frmDemonstrativo();
            this.Hide();
            demonstrativo.ShowDialog();
            this.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            this.Hide();
            sobre.ShowDialog();
            this.Show();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja mesmo sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int idTipo = cbxTipo.SelectedIndex + 1;
            FiltroGrafico(idTipo);
        }
    }
}
