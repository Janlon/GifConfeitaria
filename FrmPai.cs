using System.Speech.AudioFormat;
using System.Speech.Synthesis;

namespace GifConfeitaria
{
    public partial class FrmPai : Form
    {
        public FrmPai()
        {
            InitializeComponent();

            //Abertura();
        }

        private void Abertura()
        {
            using (SpeechSynthesizer synth = new())
            {
                synth.SetOutputToDefaultAudioDevice();
                synth.Rate = 3;
                synth.Speak("Olá Giovanna!");
            }
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
