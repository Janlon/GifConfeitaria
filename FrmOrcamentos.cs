using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            colunaID.HeaderText = "Id";
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
            colunaNome.HeaderText = "Produto, Recursos e Mão de Obra";
            colunaNome.ValueMember = "Nome";
            colunaNome.DataSource = CarregarListaPrecos();
            dg.Columns.Add(colunaNome);
            dg.Columns[2].Width = 500;
            dg.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dg_EditingControlShowing);

            DataGridViewTextBoxColumn colunaPreco = new();
            colunaPreco.DataPropertyName = "Preco";
            colunaPreco.HeaderText = "Preço";
            colunaPreco.DefaultCellStyle.Format = "00.00";
            dg.Columns.Add(colunaPreco);
            dg.Columns[3].ReadOnly = true;
            dg.Columns[3].DefaultCellStyle.BackColor = Color.Gray;
            dg.Columns[3].Width = 100;

            DataGridViewComboBoxColumn colunaMedida = new();
            colunaMedida.DataPropertyName = "Medida";
            colunaMedida.HeaderText = "Medida";
            colunaMedida.Items.Add("HR");
            colunaMedida.Items.Add("GR");
            colunaMedida.Items.Add("ML");
            colunaMedida.Items.Add("UN");
            dg.Columns.Add(colunaMedida);
            dg.Columns[4].ReadOnly = true;
            dg.Columns[4].DefaultCellStyle.BackColor = Color.Gray;
            dg.Columns[4].Width = 100;

            DataGridViewTextBoxColumn colunaQuantidade = new();
            colunaQuantidade.DataPropertyName = "Quantidade";
            colunaQuantidade.HeaderText = "Quantidade";
            dg.Columns.Add(colunaQuantidade);
            dg.Columns[5].ReadOnly = true;
            dg.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
            dg.Columns[5].Width = 110;

            DataGridViewTextBoxColumn colunaFracionada = new();
            colunaFracionada.DataPropertyName = "Fracionada";
            colunaFracionada.HeaderText = "Fracionada";
            dg.Columns.Add(colunaFracionada);
            dg.Columns[6].Width = 100;
           
            DataGridViewTextBoxColumn colunaFracao = new();
            colunaFracao.DataPropertyName = "Fracao";
            colunaFracao.HeaderText = "Fração";
            colunaFracao.DefaultCellStyle.Format = "00.00";
            dg.Columns.Add(colunaFracao);
            dg.Columns[7].Width = 130;
            dg.Columns[7].DefaultCellStyle.BackColor = Color.Gray;
            dg.Columns[7].ReadOnly = true;

            // Configurar o estilo escuro
            dg.BackgroundColor = Color.FromArgb(45, 45, 48);
            dg.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dg.DefaultCellStyle.ForeColor = Color.White;
            dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dg.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dg.RowHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void dg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox combo)
            {
                combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.Text != string.Empty)
            {
                int precoId = PesquisarIdPrecoPeloNome(cb.Text);
                if(precoId > 0)
                {
                    dg.Rows[dg.CurrentRow.Index].Cells[1].Value = precoId;
                    dg.Rows[dg.CurrentRow.Index].Cells[3].Value = PesquisarValorPrecoPeloId(Convert.ToInt32(precoId));
                    dg.Rows[dg.CurrentRow.Index].Cells[4].Value = PesquisarMedidaPrecoPeloId(precoId);
                    dg.Rows[dg.CurrentRow.Index].Cells[5].Value = PesquisarQuantidadePrecoPeloId(precoId);
                }
            }
        }

        private string PesquisarMedidaPrecoPeloId(int Id)
        {
            string medidaPreco = string.Empty;
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [Medida] FROM [confeitaria].[dbo].[Precos] WHERE Id = @Id";
                    connection.Open();
                    SqlCommand cmd = new(query, connection);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    medidaPreco = Convert.ToString(cmd.ExecuteScalar());
                    connection.Close();

                    return medidaPreco;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return medidaPreco;
        }

        private void Listar()
        {
            try
            {

                if (lblProdutoId.Text == string.Empty) return;

                int id = Convert.ToInt32(lblProdutoId.Text);

                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [confeitaria].[dbo].[Orcamentos].[Id], [confeitaria].[dbo].[Precos].[Id] AS IdPreco, [confeitaria].[dbo].[Precos].[Nome],[confeitaria].[dbo].[Precos].[Preco],[confeitaria].[dbo].[Precos].[Quantidade] as [Quantidade],[confeitaria].[dbo].[Orcamentos].[Medida],[confeitaria].[dbo].[Orcamentos].[Quantidade] as Fracionada,[confeitaria].[dbo].[Orcamentos].[Preco] AS Fracao FROM [confeitaria].[dbo].[Orcamentos] INNER JOIN [confeitaria].[dbo].Precos ON [PrecoId] = [confeitaria].[dbo].Precos.[Id] WHERE [ProdutoId] = " + id;
                    connection.Open();

                    using (SqlCommand command = new(query, connection))
                    {
                        using (SqlDataAdapter adapter = new(command))
                        {
                            DataTable dataTable = new();
                            adapter.Fill(dataTable);

                            dg.DataSource = dataTable;
                            

                            decimal fracao = 0;

                            foreach (DataRow row in dataTable.Rows)
                            {
                                fracao += Convert.ToDecimal(row.ItemArray[7]);
                            }

                            dg.CurrentCell = dg[2, dataTable.Rows.Count];

                            lblTotal.Text = "R$ " + fracao.ToString("00.00");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Gravar(int id, int idPreco, int idProduto, string medida, int quantidade, decimal preco)
        {
            try
            {
                if (quantidade == 0) return;

                if (id > 0)
                {
                    Alterar(id, idPreco, idProduto, medida, quantidade, preco);
                }
                else
                {
                    Incluir(idPreco, idProduto, medida, quantidade, preco);
                }

                BeginInvoke(new MethodInvoker(Listar));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Incluir(int precoId, int produtoId, string medida, int quantidade, decimal preco)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "INSERT INTO [dbo].[Orcamentos] ([PrecoId],[ProdutoId],[Medida],[Quantidade],[Preco]) VALUES (@PrecoId, @ProdutoId, @Medida, @Quantidade, @Preco)";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@PrecoId", precoId);
                cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                cmd.Parameters.AddWithValue("@Medida", medida);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Preco", preco);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void Alterar(int id, int precoId, int produtoId, string medida, int quantidade, decimal preco)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string query = "UPDATE [dbo].[Orcamentos] SET [PrecoId] = @PrecoId, [ProdutoId] = @ProdutoId, [Medida] = @Medida, [Quantidade] = @Quantidade, [Preco] = @Preco WHERE Id = @Id";
                connection.Open();
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@PrecoId", precoId);
                cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                cmd.Parameters.AddWithValue("@Medida", medida);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Preco", preco);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private int PesquisarQuantidadePrecoPeloId(int id)
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

        private decimal PesquisarValorPrecoPeloId(int id)
        {
            decimal valorPreco = 0;
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [Preco] FROM [confeitaria].[dbo].[Precos] WHERE Id = @Id";
                    connection.Open();
                    SqlCommand cmd = new(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);
                    valorPreco = Convert.ToDecimal(cmd.ExecuteScalar());
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

        private int PesquisarIdPrecoPeloNome(string item)
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    string query = "SELECT [Id] FROM [confeitaria].[dbo].[Precos] WHERE Nome = @Nome";
                    connection.Open();
                    SqlCommand cmd = new(query, connection);
                    cmd.Parameters.AddWithValue("@Nome", item);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    return id;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return id;
        }

        private void FrmOrcamentos_Load(object sender, EventArgs e)
        {
            dg.Enabled = false;
            dg.Visible = false;
            lblProdutoId.Visible = false;
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
                        using (SqlDataAdapter adapter = new(command))
                        {
                            DataTable dataTable = new();
                            adapter.Fill(dataTable);

                            dataTable.Rows.Add(new object[] { 0, "SELECIONE" });

                            cboProdutos.DataSource = dataTable;
                            cboProdutos.DisplayMember = "Nome";
                            cboProdutos.ValueMember = "Id";
                            cboProdutos.SelectedValue = 0;
                            cboProdutos.Refresh();
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
                lblProdutoId.Text = selectedValue.ToString();
                if (selectedValue > 0)
                {
                    dg.Enabled = true;
                    dg.Visible = true;
                    Listar();
                }
            }
        }

        private void dg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
                if (dg.CurrentRow == null) return;

            //Id
            var valorId = dg.CurrentRow.Cells[0].Value;
            int id = 0;
            if (valorId != null && valorId.ToString() != "")
            {
                id = Convert.ToInt32(valorId);
            }

               //Medida
            var medida = dg.CurrentRow.Cells[4].Value;

            //Quantidade
            var valorQuantidade = dg.CurrentRow.Cells[6].Value;
            int quantidadeFracionada = 0;
            valorQuantidade ??= 0;
            if (valorQuantidade != null && valorQuantidade.ToString() != "")
            {
                quantidadeFracionada = Convert.ToInt32(valorQuantidade);
            }

            //Fração do preco
            var idPreco = dg.CurrentRow.Cells[1].Value;
            if (idPreco == null || idPreco.ToString() == "")
            {
                return;
            }
            decimal preco = 0;
            if (idPreco is int)
            {
                var quantidade = dg.CurrentRow.Cells[6].Value;
                if (quantidade != null && quantidade.ToString() != "")
                {
                    decimal precoProduto = PesquisarValorPrecoPeloId(Convert.ToInt32(idPreco));
                    int quantidadeProduto = PesquisarQuantidadePrecoPeloId(Convert.ToInt32(idPreco));
                    if (precoProduto > 0)
                    {
                        preco = precoProduto / quantidadeProduto * Convert.ToInt32(quantidade);
                        dg.CurrentRow.Cells[7].Value = preco;
                    }
                }

            }

            int idproduto = Convert.ToInt32(lblProdutoId.Text);

            Gravar(id, Convert.ToInt32(idPreco), idproduto, medida.ToString(), quantidadeFracionada, preco);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

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

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("DELETE FROM ORCAMENTOS WHERE ID = @ID", connection))
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
    }
}
