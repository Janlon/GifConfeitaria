using System.Data;
using System.Data.SqlClient;

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
            ConfigurarGrade();
        }

        private void ConfigurarGrade()
        {
            WindowState = FormWindowState.Maximized; // Maximiza o formulário ao abrir

            // Definir o modo de exibição da grade
            dg.AutoGenerateColumns = false;

            // Adicionar colunas à grade
            DataGridViewTextBoxColumn colunaID = new();
            colunaID.DataPropertyName = "Id"; // Nome da propriedade no seu objeto de dados
            colunaID.HeaderText = "Registro";
            dg.Columns.Add(colunaID);
            dg.Columns[0].Visible = false;

            DataGridViewTextBoxColumn colunaNome = new ();
            colunaNome.DataPropertyName = "Nome"; // Nome da propriedade no seu objeto de dados
            colunaNome.HeaderText = "Nome";
            colunaNome.SortMode = DataGridViewColumnSortMode.Automatic;
            dg.Columns.Add(colunaNome);
            dg.Columns[1].Width = 700;

            // Configurar o estilo escuro
            dg.BackgroundColor = Color.FromArgb(45, 45, 48);
            dg.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dg.DefaultCellStyle.ForeColor = Color.White;
            dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dg.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dg.RowHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void Listar()
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [Id],[Nome] FROM [confeitaria].[dbo].[Produtos]";
                    connection.Open();

                    using (SqlCommand command = new(query, connection))
                    {
                        using (SqlDataAdapter adapter = new(command))
                        {
                            DataTable dataTable = new();
                            adapter.Fill(dataTable);

                             dg.DataSource = dataTable;
                        }
                    }
                }
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

               // BeginInvoke(new MethodInvoker(Listar));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Incluir(string nome)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "INSERT INTO PRODUTOS (Nome) VALUES (@Nome)";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@Nome", nome.Trim().ToUpper());

                cmd.ExecuteNonQuery();
                connection.Close();
            }
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
            try
            {
                if (dg.CurrentRow == null) return;

                var valorId = dg.CurrentRow.Cells[0].Value;
                int id = 0;
                if (valorId is int)
                {
                    id = Convert.ToInt32(valorId);
                }

                var nome = dg.CurrentRow.Cells[1].Value;
                if (nome == null)
                {
                    return;
                }

                Gravar(id, nome.ToString().Trim().ToUpper());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dg_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dg.CurrentRow == null) return;

                    int rowIndex = dg.CurrentRow.Index;
                    int id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
                    DataTable dt = (DataTable)dg.DataSource;
                    dt.Rows.RemoveAt(rowIndex);
                    dg.DataSource = dt;

                    using (SqlConnection connection = new(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new("DELETE FROM PRODUTOS WHERE ID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ID", id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
