using System.Data;
using System.Data.SqlClient;

namespace GifConfeitaria
{
    public partial class FrmPrecos : Form
    {
        private readonly BindingSource bindingSource1 = [];
        private readonly SqlDataAdapter dataAdapter = new();
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
            DataGridViewTextBoxColumn colunaID = new();
            colunaID.DataPropertyName = "Id"; // Nome da propriedade no seu objeto de dados
            colunaID.HeaderText = "Registro";
            dg.Columns.Add(colunaID);
            dg.Columns[0].Width = 100;
            dg.Columns[0].Visible = false;

            DataGridViewTextBoxColumn colunaNome = new();
            colunaNome.DataPropertyName = "Nome"; // Nome da propriedade no seu objeto de dados
            colunaNome.HeaderText = "Nome";
            colunaNome.SortMode = DataGridViewColumnSortMode.Automatic;
            dg.Columns.Add(colunaNome);
            dg.Columns[1].Width = 350;

            DataGridViewComboBoxColumn colunaMedida = new();
            colunaMedida.DataPropertyName = "Medida";
            colunaMedida.HeaderText = "Medida";
            colunaMedida.Items.Add("HR");
            colunaMedida.Items.Add("GR");
            colunaMedida.Items.Add("ML");
            colunaMedida.Items.Add("UN");
            dg.Columns.Add(colunaMedida);
            dg.Columns[2].Width = 100;

            DataGridViewTextBoxColumn colunaQuantidade = new();
            colunaQuantidade.DataPropertyName = "Quantidade";
            colunaQuantidade.HeaderText = "Qtd";
            colunaQuantidade.SortMode = DataGridViewColumnSortMode.Automatic;
            dg.Columns.Add(colunaQuantidade);
            dg.Columns[3].Width = 100;

            DataGridViewTextBoxColumn colunaPreco = new();
            colunaPreco.DataPropertyName = "Preco";
            colunaPreco.HeaderText = "Preco";
            colunaPreco.DefaultCellStyle.Format = "00.00";
            colunaPreco.SortMode = DataGridViewColumnSortMode.Automatic;
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

        private void Gravar(int id, string? nome, string medida, int quantidade, decimal preco)
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

                BeginInvoke(new MethodInvoker(Listar));
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Violação da restrição UNIQUE KEY"))
                {
                    return;
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void Incluir(string nome, string medida, int quantidade, decimal preco)
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

        private void Alterar(int id, string nome, string medida, int quantidade, decimal preco)
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

            //id
            var valorId = dg.CurrentRow.Cells[0].Value;
            int id = 0;
            if (valorId is int)
            {
                id = Convert.ToInt32(valorId);
            }

            //nome
            var nome = dg.CurrentRow.Cells[1].Value;
            if (nome == null)
            {
                return;
            }

            //medida
            var medida = dg.CurrentRow.Cells[2].Value.ToString();

            //Quantidade
            var valorQuantidade = dg.CurrentRow.Cells[3].Value;
            int quantidade = 0;
            if (valorQuantidade is int)
            {
                quantidade = Convert.ToInt32(valorQuantidade);
            }

            //Fração do preco
            var valorPreco = dg.CurrentRow.Cells[4].Value;
            decimal preco = 0;
            if (valorPreco is decimal)
            {
                preco = Convert.ToDecimal(valorPreco);
            }

            Gravar(id, nome.ToString().Trim().ToUpper(), medida.ToString().Trim().ToUpper(), quantidade, preco);
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

                    // Exclua o registro do banco de dados (substitua "SuaTabela" pelo nome da sua tabela e "ID" pelo nome da sua coluna de chave primária)
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("DELETE FROM PRECOS WHERE ID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ID", id);
                            command.ExecuteNonQuery();
                        }
                    }

                    BeginInvoke(new MethodInvoker(Listar));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmPrecos_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
