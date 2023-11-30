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
            DataGridViewTextBoxColumn colunaID = new DataGridViewTextBoxColumn();
            colunaID.DataPropertyName = "Id"; // Nome da propriedade no seu objeto de dados
            colunaID.HeaderText = "Registro";
            colunaID.SortMode = DataGridViewColumnSortMode.Automatic;
            dg.Columns.Add(colunaID);
            dg.Columns[0].Width = 100;

            DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
            colunaNome.DataPropertyName = "Nome"; // Nome da propriedade no seu objeto de dados
            colunaNome.HeaderText = "Nome";
            colunaNome.SortMode = DataGridViewColumnSortMode.Automatic;
            dg.Columns.Add(colunaNome);
            dg.Columns[1].Width = 650;

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
  
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Crie um adaptador de dados
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Crie um DataTable para armazenar os dados
                            DataTable dataTable = new DataTable();

                            // Preencha o DataTable com os dados do banco de dados
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                // Adicione uma nova linha ao DataGridView
                                int index = dg.Rows.Add();

                                // Itere pelas colunas e popule as células do DataGridView
                                for (int i = 0; i < dataTable.Columns.Count; i++)
                                {
                                    dg.Rows[index].Cells[i].Value = row[i];
                                }
                            }
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
                string query = "INSERT INTO PRODUTOS (Nome) VALUES (@Nome)";
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
            try
            {
                if (dg.CurrentRow == null) return;

                var valorId = dg.CurrentRow.Cells[0].Value;
                int id = 0;
                if (valorId != null)
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
    }
}
