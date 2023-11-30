using System.Data;
using System.Data.SqlClient;
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

            // Configurar o DataGridView
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
            dg.Columns.Add(colunaID);
            dg.Columns[0].Width = 100;

            DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
            colunaNome.DataPropertyName = "Nome"; // Nome da propriedade no seu objeto de dados
            colunaNome.HeaderText = "Nome";
            dg.Columns.Add(colunaNome);
            dg.Columns[1].Width = 300;

            DataGridViewTextBoxColumn colunaMedida = new DataGridViewTextBoxColumn();
            colunaMedida.DataPropertyName = "Medida"; // Nome da propriedade no seu objeto de dados
            colunaMedida.HeaderText = "Medida";
           // colunaMedida.DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato da data
            dg.Columns.Add(colunaMedida);
            dg.Columns[2].Width = 100;

            DataGridViewTextBoxColumn colunaQuantidade = new DataGridViewTextBoxColumn();
            colunaQuantidade.DataPropertyName = "Quantidade"; // Nome da propriedade no seu objeto de dados
            colunaQuantidade.HeaderText = "Qtd";
            dg.Columns.Add(colunaQuantidade);
            dg.Columns[3].Width = 100;

            DataGridViewTextBoxColumn colunaPreco = new DataGridViewTextBoxColumn();
            colunaPreco.DataPropertyName = "Preco"; // Nome da propriedade no seu objeto de dados
            colunaPreco.HeaderText = "Preco";
            colunaPreco.DefaultCellStyle.Format = "00.00"; // Formato da data
            dg.Columns.Add(colunaPreco);
            dg.Columns[4].Width = 160;

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
                    string query = "SELECT [Id],[Nome],[Medida],[Quantidade],[Preco] FROM [confeitaria].[dbo].[Precos]";
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

        private void Gravar(int id, string? nome, string medida, int quantidade, double preco)
        {
            try
            {
                if (nome == null) return;

                if (id > 0)
                {
                    Alterar(id, nome, medida, quantidade, preco);
                }
                else
                {
                    Incluir(nome, medida, quantidade, preco);
                }
                Listar();
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

            var medida = dg.CurrentRow.Cells[2].Value;
            if (medida == null) 
            {
                medida = "KG";
            }

            var valorQuantidade = dg.CurrentRow.Cells[3].Value;
            int quantidade = 0;
            if(valorQuantidade == null)
            {
                valorQuantidade = string.Empty;
            }
            if (valorQuantidade != string.Empty)
            {
                quantidade = Convert.ToInt32(valorQuantidade);
            }

            var valorpreco = dg.CurrentRow.Cells[4].Value.ToString();
            double preco = 0;
            if (valorpreco != string.Empty)
            {
                preco = Convert.ToDouble(valorpreco);
            }

            Gravar(id, nome.ToString().Trim().ToUpper(), medida.ToString().Trim().ToUpper(), quantidade, preco);
        }

        private void FrmPrecos_Load(object sender, EventArgs e)
        {
            Listar();
        }

    }
}
