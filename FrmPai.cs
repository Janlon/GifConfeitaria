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
            PainelPai.Visible = false; // Oculta o Panel

            FrmPrecos frm = new();
            frm.MdiParent = this;
            frm.FormClosed += (sender, e) => PainelPai.Visible = true; // Mostra o Panel quando o formulário filho for fechado
            frm.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            PainelPai.Visible = false; // Oculta o Panel

            FrmProdutos frm = new();
            frm.MdiParent = this;
            frm.FormClosed += (sender, e) => PainelPai.Visible = true; // Mostra o Panel quando o formulário filho for fechado
            frm.Show();
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            PainelPai.Visible = false; // Oculta o Panel

            FrmOrcamentos frm = new();
            frm.MdiParent = this;
            frm.FormClosed += (sender, e) => PainelPai.Visible = true; // Mostra o Panel quando o formulário filho for fechado
            frm.Show();
        }
    }
}
