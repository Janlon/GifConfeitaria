using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GifConfeitaria
{
    public partial class FrmOrcamentos : Form
    {
        private readonly BindingSource bindingSource1 = [];
        private readonly SqlDataAdapter dataAdapter = new();
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
            DataGridViewTextBoxColumn colunaID = new();
            colunaID.DataPropertyName = "Id";
            colunaID.HeaderText = "Registro";
            dg.Columns.Add(colunaID);
            dg.Columns[0].Width = 100;
            dg.Columns[0].Visible = false;

            // Adicionar colunas à grade
            DataGridViewTextBoxColumn colunaIDPreco = new();
            colunaIDPreco.DataPropertyName = "IdPreco";
            colunaIDPreco.HeaderText = "IdPreco";
            dg.Columns.Add(colunaIDPreco);
            dg.Columns[1].Width = 100;
            dg.Columns[1].Visible = false;

            DataGridViewComboBoxColumn colunaNome = new();
            colunaNome.DataPropertyName = "Nome";
            colunaNome.HeaderText = "Produto";
            colunaNome.ValueMember = "Nome";
            colunaNome.DataSource = CarregarListaPrecos();
            dg.Columns.Add(colunaNome);
            dg.Columns[2].Width = 200;

            DataGridViewTextBoxColumn colunaPreco = new();
            colunaPreco.DataPropertyName = "Preco";
            colunaPreco.HeaderText = "Preço";
            colunaPreco.DefaultCellStyle.Format = "00.00";
            dg.Columns.Add(colunaPreco);
            dg.Columns[3].Width = 100;

            DataGridViewComboBoxColumn colunaMedida = new();
            colunaMedida.DataPropertyName = "Medida";
            colunaMedida.HeaderText = "Medida";
            // Adicione os itens ao ComboBox
            colunaMedida.Items.Add("KG");
            colunaMedida.Items.Add("GR");
            colunaMedida.Items.Add("LT");
            colunaMedida.Items.Add("CX");
            colunaMedida.Items.Add("UN");
            dg.Columns.Add(colunaMedida);
            dg.Columns[4].Width = 100;

            DataGridViewTextBoxColumn colunaQuantidade = new();
            colunaQuantidade.DataPropertyName = "Quantidade";
            colunaQuantidade.HeaderText = "Qtd";
            dg.Columns.Add(colunaQuantidade);
            dg.Columns[5].Width = 100;

            DataGridViewTextBoxColumn colunaFracao = new();
            colunaFracao.DataPropertyName = "Fracao";
            colunaFracao.HeaderText = "Fração";
            colunaFracao.DefaultCellStyle.Format = "00.00";
            dg.Columns.Add(colunaFracao);
            dg.Columns[6].Width = 130;

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
                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [confeitaria].[dbo].[Orcamentos].[Id], [confeitaria].[dbo].[Precos].[Id] AS IdPreco, [confeitaria].[dbo].[Precos].[Nome],[confeitaria].[dbo].[Precos].[Preco],[confeitaria].[dbo].[Orcamentos].[Medida],[confeitaria].[dbo].[Orcamentos].[Quantidade],[confeitaria].[dbo].[Orcamentos].[Preco] AS Fracao FROM [confeitaria].[dbo].[Orcamentos] INNER JOIN [confeitaria].[dbo].Precos ON [PrecoId] = [confeitaria].[dbo].Precos.[Id] WHERE [ProdutoId] = " + id;
                    connection.Open();

                    using (SqlCommand command = new(query, connection))
                    {
                        using (SqlDataAdapter adapter = new(command))
                        {
                            DataTable dataTable = new();
                            adapter.Fill(dataTable);
                            double total = 0;

                            foreach (DataRow row in dataTable.Rows)
                            {
                                int index = dg.Rows.Add();

                                double precoProduto = PesquisarPreco(Convert.ToInt32(row.ItemArray[1]));
                                int quantidadeProduto = PesquisarQuantidade(Convert.ToInt32(row.ItemArray[1]));
                                total += precoProduto / quantidadeProduto * Convert.ToInt32(row.ItemArray[5]);

                                for (int i = 0; i < dataTable.Columns.Count; i++)
                                {
                                    if(i == 6)
                                    {
                                        dg.Rows[index].Cells[i].Value = precoProduto / quantidadeProduto * Convert.ToInt32(row.ItemArray[5]);
                                    }
                                    //else if (i == 2)
                                    //{
                                    //    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dg.Rows[index].Cells[i];
                                    //    cb.DataSource = CarregarListaPrecos();
                                    //    cb.ValueMember = "Id";
                                    //    cb.DisplayMember = "Nome";
                                    //}
                                    else
                                    {
                                        dg.Rows[index].Cells[i].Value = row[i];
                                    }
                                }

                            }

                            lblTotal.Text = total.ToString("0.00");

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

                //BeginInvoke(new MethodInvoker(Listar));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            try
            {
                if (dg.CurrentRow == null) return;

                //Id
                var valorId = dg.CurrentRow.Cells[0].Value;
                int id = 0;
                if (valorId != null)
                {
                    id = Convert.ToInt32(valorId);
                }

                //Tabela Precos (Nome)
                var valorPrecoId = dg.CurrentRow.Cells[1].Value;
                int idpreco = 0;
                if (valorPrecoId != null)
                {
                    idpreco = Convert.ToInt32(valorPrecoId);
                }
                else
                {
                    return;
                }

                //Medida
                var medida = dg.CurrentRow.Cells[2].Value;
                medida ??= "KG";

                //Quantidade
                var valorQuantidade = dg.CurrentRow.Cells[3].Value;
                int quantidade = 0;
                valorQuantidade ??= 0;
                if (valorQuantidade != null)
                {
                    quantidade = Convert.ToInt32(valorQuantidade);
                }

                //Fração do preco
                var valorPreco = dg.CurrentRow.Cells[4].Value;
                double preco = 0;
                if (valorPreco != null)
                {
                    double precoProduto = PesquisarPreco(idpreco);
                    int quantidadeProduto = PesquisarQuantidade(idpreco);
                    if (precoProduto > 0)
                    {
                        preco = (precoProduto / quantidadeProduto) * quantidade;
                    }
                }

                int idproduto = Convert.ToInt32(lblIdProduto.Text);

                Gravar(id, idpreco, idproduto, medida.ToString(), quantidade, preco, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
   
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
            lblIdProduto.Visible = false;
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

                    using (SqlCommand command = new(query, connection))
                    {
                        using (SqlDataAdapter adapter = new (command))
                        {
                            DataTable dataTable = new ();

                            adapter.Fill(dataTable);

                            cboProdutos.DataSource = dataTable;
                            cboProdutos.DisplayMember = "Nome";
                            cboProdutos.ValueMember = "Id";
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

                    using (SqlCommand command = new(query, connection))
                    {
                        using (SqlDataAdapter adapter = new(command))
                        {
                            DataTable dataTable = new();
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

            return new DataTable();
        }

        private void cboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedValue is int selectedValue)
            {
                lblIdProduto.Text = selectedValue.ToString();
               // Listar(selectedValue);
            }
        }

    }
}
