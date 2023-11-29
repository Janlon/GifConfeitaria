using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;

namespace GifConfeitaria
{
    public partial class FrmPrecos : Form
    {
        private readonly BindingSource bindingSource1 = [];
        private SqlDataAdapter dataAdapter = new();
        readonly string connectionString = "Data Source=.; Initial Catalog=confeitaria; User Id=sa; Password=Senha@123;";

        public FrmPrecos()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                dg.DataSource = bindingSource1;

                string query = "SELECT [Id],[Nome],[Medida],[Quantidade],[Preco] FROM [confeitaria].[dbo].[Precos]";

                dataAdapter = new SqlDataAdapter(query, connectionString);

                SqlCommandBuilder commandBuilder = new(dataAdapter);

                DataTable table = new()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                dg.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Gravar(int id, string? nome, string medida, int quantidade, double preco)
        {
            try
            {
                if (nome == null) return;

                dg.DataSource = bindingSource1;

                if (id > 0)
                {
                    Alterar(id, nome, medida, quantidade, preco);
                }
                else
                {
                    Incluir(nome, medida, quantidade, preco);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void Incluir(string nome, string medida, int quantidade, double preco)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "INSERT INTO [dbo].[Precos] ([Nome],[Medida],[Quantidade],[Preco]) VALUES (@Nome, @Medida, @Quantidade, @Preco)";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Medida", medida);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Preco", preco);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void Excluir(int id)
        {

        }

        private void Alterar(int id, string nome, string medida, int quantidade, double preco)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "UPDATE [dbo].[Precos] SET [Nome] = @Nome, [Medida] = @Medida, [Quantidade] = @Quantidade, [Preco] = @Preco WHERE Id = @Id";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Medida", medida);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Preco", preco);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
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

            var medida = dg.CurrentRow.Cells["Medida"].Value.ToString();
            
            var valorQuantidade = dg.CurrentRow.Cells["Quantidade"].Value.ToString();
            int quantidade = 0;
            if (valorQuantidade != string.Empty)
            {
                quantidade = Convert.ToInt32(valorQuantidade);
            }

            var valorpreco = dg.CurrentRow.Cells["Preco"].Value.ToString();
            double preco = 0;
            if (valorpreco != string.Empty)
            {
                preco = Convert.ToDouble(valorpreco);
            }

            Gravar(id, nome, medida, quantidade,  preco);
        }

        private void FrmPrecos_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
