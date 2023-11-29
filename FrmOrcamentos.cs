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
        }

        private void Listar()
        {
            try
            {
                dg.DataSource = bindingSource1;
                string query = "SELECT * FROM [dbo].[Orcamentos]";
                dataAdapter = new SqlDataAdapter(query, connectionString);
                SqlCommandBuilder commandBuilder = new(dataAdapter);
                DataTable table = new()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                dg.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Gravar(int id,int idPreco, int idProduto, string medida, int quantidade, double preco, double total)
        {
            try
            {

                if (quantidade == 0) return;

                dg.DataSource = bindingSource1;
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

                Listar();
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
                Listar();
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
            Listar();
        }
    }
}
