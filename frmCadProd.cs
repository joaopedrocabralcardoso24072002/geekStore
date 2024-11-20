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
            CarregaCbxTipo();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private readonly ToolTip tt = new ToolTip();
        private void pbxImagem_MouseHover(object sender, EventArgs e)
        {
            Point p = pbxImagem.PointToClient(System.Windows.Forms.Cursor.Position);
            if (p.X >= 279 && p.X <= 459 && p.Y >= 29 && p.Y <= 209)
            {
                tt.SetToolTip(this.pbxImagem, "Novo Produto");
            }
            else
            {
                tt.Hide(this.pbxImagem);
            }
        }
    }
}