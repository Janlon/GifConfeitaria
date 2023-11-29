using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GifConfeitaria
{
    public partial class FrmProdutos : Form
    {
        private readonly BindingSource bindingSource1 = [];
        private SqlDataAdapter dataAdapter = new();
        readonly string connectionString = "Data Source=.; Initial Catalog=confeitaria; User Id=sa; Password=Senha@123;";

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                string query = "SELECT [Id],[Nome] FROM [confeitaria].[dbo].[Produtos]";

                dataAdapter = new SqlDataAdapter(query, connectionString);

                SqlCommandBuilder commandBuilder = new(dataAdapter);

                DataTable table = new()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);

                dg.DataSource = bindingSource1;
                bindingSource1.DataSource = table;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Gravar(int id, string? nome)
        {
            try
            {

                if (nome == null) return;

                if (id > 0)
                {
                    Alterar(id, nome.Trim().ToUpper());
                }
                else
                {
                    Incluir(nome.Trim().ToUpper());
                }
                //MessageBox.Show("Dados gravados com sucesso.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void Incluir(string nome)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "INSERT INTO PRODUTOS(Nome) VALUES (@Nome)";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@Nome", nome.Trim().ToUpper());

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void Excluir()
        {

        }

        private void Alterar(int id, string nome)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "UPDATE PRODUTOS SET Nome = @Nome WHERE Id = @Id";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nome", nome.Trim().ToUpper());

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dg.CurrentRow == null) return;

            var valorId = dg.CurrentRow.Cells["Id"].Value.ToString();
            int id = 0;
            if (valorId != string.Empty)
            {
                id = Convert.ToInt32(valorId);
            }

            var nome = dg.CurrentRow.Cells["Nome"].Value.ToString();
            if (nome == string.Empty)
            {
                return;
            }

            Gravar(id, nome.Trim().ToUpper());
        }
    }
}
