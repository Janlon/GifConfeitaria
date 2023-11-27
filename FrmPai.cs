using Microsoft.VisualBasic;

namespace GifConfeitaria
{
    public partial class FrmPai : Form
    {
        public FrmPai()
        {
            InitializeComponent();
        }

        private void btnPrecos_Click(object sender, EventArgs e)
        {
            FrmPrecos frm = new();
            frm.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos frm = new();
            frm.ShowDialog();
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            FrmOrcamentos frm = new();
            frm.ShowDialog();
        }
    }
}
