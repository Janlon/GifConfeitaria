using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace GifConfeitaria
{
    public partial class FrmProdutos : Form
    {
        private readonly BindingSource bindingSource1 = [];
        private SqlDataAdapter dataAdapter = new();

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void ObterProdutos()
        {
            try
            {
                string connectionString = "Data Source=.; Initial Catalog=confeitaria; User Id=sa; Password=Senha@123;";
                string query = "SELECT [Id],[Nome],[Modificacao] FROM [confeitaria].[dbo].[Produtos]";

                using (SqlConnection connection = new(connectionString)) 
                {
                    connection.Open();
                    using SqlCommand command = new(query);
                    command.ExecuteReader();
                }
                     
                dataAdapter = new SqlDataAdapter(query, connectionString);

                SqlCommandBuilder commandBuilder = new(dataAdapter);

                DataTable table = new()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            ObterProdutos();
        }
    }
}
