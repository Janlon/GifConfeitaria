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
            // Dock = DockStyle.Fill; // Preenche todo o espaço disponível

            // Definir o modo de exibição da grade
            dg.AutoGenerateColumns = false;

            // Adicionar colunas à grade
            DataGridViewTextBoxColumn colunaID = new DataGridViewTextBoxColumn();
            colunaID.DataPropertyName = "ID"; // Nome da propriedade no seu objeto de dados
            colunaID.HeaderText = "ID";
            dg.Columns.Add(colunaID);
            dg.Columns[0].Visible = false;

            DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
            colunaNome.DataPropertyName = "Nome"; // Nome da propriedade no seu objeto de dados
            colunaNome.HeaderText = "Nome";
            dg.Columns.Add(colunaNome);
            dg.Columns[1].Width = 300;

            DataGridViewTextBoxColumn colunaData = new DataGridViewTextBoxColumn();
            colunaData.DataPropertyName = "DataNascimento"; // Nome da propriedade no seu objeto de dados
            colunaData.HeaderText = "Data de Nascimento";
            colunaData.DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato da data
            dg.Columns.Add(colunaData);
            dg.Columns[2].Width = 300;

            // Configurar o estilo escuro
            dg.BackgroundColor = Color.FromArgb(45, 45, 48);
            dg.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dg.DefaultCellStyle.ForeColor = Color.White;
            dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dg.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dg.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            //// Configurar o alinhamento das células
            //dg.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dg.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dg.Columns["DataNascimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //// Preencher a grade com dados fictícios para teste
            dg.Rows.Add(1, "João", new DateTime(1990, 5, 15));
            dg.Rows.Add(2, "Maria", new DateTime(1985, 10, 22));
            dg.Rows.Add(3, "Carlos", new DateTime(1995, 3, 8));
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

            Gravar(id, nome, medida, quantidade, preco);
        }

        private void FrmPrecos_Load(object sender, EventArgs e)
        {
            // Listar();
        }

    }
}
