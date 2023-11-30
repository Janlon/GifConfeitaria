using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace GifConfeitaria
{
    public partial class FrmOrcamentos : Form
    {
        private readonly BindingSource bindingSource1 = [];
        private SqlDataAdapter dataAdapter = new();
        readonly string connectionString = "Data Source=.; Initial Catalog=confeitaria; User Id=sa; Password=Senha@123;";

        public FrmOrcamentos()
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
            dg.Columns.Add(colunaID);
            dg.Columns[0].Width = 100;

            DataGridViewComboBoxColumn colunaNome = new DataGridViewComboBoxColumn();
            colunaNome.DataPropertyName = "Nome"; // Nome da propriedade no seu objeto de dados
            colunaNome.HeaderText = "Produto";
            dg.Columns.Add(colunaNome);
            dg.Columns[1].Width = 300;

            DataGridViewTextBoxColumn colunaMedida = new DataGridViewTextBoxColumn();
            colunaMedida.DataPropertyName = "Medida"; // Nome da propriedade no seu objeto de dados
            colunaMedida.HeaderText = "Medida";
            dg.Columns.Add(colunaMedida);
            dg.Columns[2].Width = 100;

            DataGridViewTextBoxColumn colunaQuantidade = new DataGridViewTextBoxColumn();
            colunaQuantidade.DataPropertyName = "Quantidade"; // Nome da propriedade no seu objeto de dados
            colunaQuantidade.HeaderText = "Qtd";
            dg.Columns.Add(colunaQuantidade);
            dg.Columns[3].Width = 100;

            DataGridViewTextBoxColumn colunaPreco = new DataGridViewTextBoxColumn();
            colunaPreco.DataPropertyName = "Preco"; // Nome da propriedade no seu objeto de dados
            colunaPreco.HeaderText = "Preço";
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

        private void Listar(int id)
        {
            try
            {

                dg.Rows.Clear();

                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [confeitaria].[dbo].[Orcamentos].[Id],[confeitaria].[dbo].Precos.Nome,[confeitaria].[dbo].[Orcamentos].[Medida],[confeitaria].[dbo].[Orcamentos].[Quantidade],[confeitaria].[dbo].[Orcamentos].[Preco] FROM [confeitaria].[dbo].[Orcamentos] INNER JOIN [confeitaria].[dbo].Precos ON [PrecoId] = [confeitaria].[dbo].Precos.[Id] WHERE [ProdutoId] = " + id;
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

                                    if(i == 4)
                                    {
                                        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dg.Rows[index].Cells[i];
                                        cb.DataSource = CarregarListaPrecos;
                                        cb.ValueMember = "Id";
                                        cb.DisplayMember = "Nome";
                                    }

    
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

        private void Gravar(int id, int idPreco, int idProduto, string medida, int quantidade, double preco, double total)
        {
            try
            {
                if (quantidade == 0) return;

                if (id > 0)
                {
                    Alterar(id, idPreco, idProduto, medida, quantidade, preco, total);
                }
                else
                {
                    Incluir(idPreco, idProduto, medida, quantidade, preco, total);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void Incluir(int precoId, int produtoId, string medida, int quantidade, double preco, double total)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "INSERT INTO [dbo].[Orcamentos] ([PrecoId],[ProdutoId],[Medida],[Quantidade],[Preco],[Total]) VALUES (@PrecoId, @ProdutoId, @Medida, @Quantidade, @Preco, @Total)";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@PrecoId", precoId);
                cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                cmd.Parameters.AddWithValue("@Medida", medida);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Preco", preco);
                cmd.Parameters.AddWithValue("@Total", total);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void Excluir()
        {

        }

        private void Alterar(int id, int precoId, int produtoId, string medida, int quantidade, double preco, double total)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "UPDATE [dbo].[Orcamentos] SET [PrecoId] = @PrecoId, [ProdutoId] = @ProdutoId, [Medida] = @Medida, [Quantidade] = @Quantidade, [Preco] = @Preco, [Total] = @Total WHERE Id = @Id";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@PrecoId", precoId);
                cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                cmd.Parameters.AddWithValue("@Medida", medida);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Preco", preco);
                cmd.Parameters.AddWithValue("@Total", total);

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

            var medida = dg.CurrentRow.Cells["Medida"].Value.ToString();

            var valorProdutoId = dg.CurrentRow.Cells["ProdutoId"].Value.ToString();
            int idproduto = 0;
            if (valorProdutoId != string.Empty)
            {
                idproduto = Convert.ToInt32(valorProdutoId);
            }

            var valorQuantidade = dg.CurrentRow.Cells["Quantidade"].Value.ToString();
            int quantidade = 0;
            if (valorQuantidade != string.Empty)
            {
                quantidade = Convert.ToInt32(valorQuantidade);
            }

            var valorPrecoId = dg.CurrentRow.Cells["PrecoId"].Value.ToString();
            int idpreco = 0;
            double preco = 0;
            if (valorPrecoId != string.Empty)
            {
                idpreco = Convert.ToInt32(valorPrecoId);
                double precoProduto = PesquisarPreco(idpreco);
                int quantidadeProduto = PesquisarQuantidade(idpreco);
                if (precoProduto > 0)
                {
                    preco = (precoProduto / quantidadeProduto) * quantidade;
                }
            }

            var valortotal = dg.CurrentRow.Cells["Total"].Value.ToString();
            double total = 0;
            if (valortotal != string.Empty)
            {
                total = Convert.ToDouble(valortotal);
            }

            Gravar(id, idpreco, idproduto, medida, quantidade, preco, total);
        }

        private int PesquisarQuantidade(int id)
        {
            int qtdPreco = 0;
            try
            {

                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [Quantidade] FROM [confeitaria].[dbo].[Precos] WHERE Id = @Id";
                    connection.Open();
                    SqlCommand cmd = new(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);

                    qtdPreco = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    return qtdPreco;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return qtdPreco;
        }

        private double PesquisarPreco(int id)
        {
            double valorPreco = 0;
            try
            {

                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [Preco] FROM [confeitaria].[dbo].[Precos] WHERE Id = @Id";
                    connection.Open();
                    SqlCommand cmd = new(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);
                    valorPreco = Convert.ToDouble(cmd.ExecuteScalar());
                    connection.Close();

                    return valorPreco;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return valorPreco;
        }

        private void FrmOrcamentos_Load(object sender, EventArgs e)
        {
            CarregarComboBoxProdutos();
        }

        private void CarregarComboBoxProdutos()
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

                            comboBox1.DataSource = dataTable;
                            comboBox1.DisplayMember = "Nome";
                            comboBox1.ValueMember = "Id";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable CarregarListaPrecos()
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [Id],[Nome] FROM [confeitaria].[dbo].[Precos]";
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

                            return dataTable;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                //var id = ((System.Data.DataRowView)comboBox1.SelectedValue).Row.ItemArray[0];
                //if(id != null)
                //{
                //    Listar(Convert.ToInt32(id));
                //}
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                int selectedValue = (int)cmb.SelectedValue;
                Listar(selectedValue);
            }
            catch (Exception)
            {

            }

        }
    }
}
