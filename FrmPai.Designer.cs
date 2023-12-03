
namespace GifConfeitaria
{
    partial class FrmPai
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPai));
            PainelPai = new Panel();
            btnOrcamentos = new Button();
            btnProdutos = new Button();
            btnPrecos = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            PainelPai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PainelPai
            // 
            PainelPai.Controls.Add(btnOrcamentos);
            PainelPai.Controls.Add(btnProdutos);
            PainelPai.Controls.Add(btnPrecos);
            PainelPai.Controls.Add(label1);
            PainelPai.Controls.Add(pictureBox1);
            PainelPai.Dock = DockStyle.Fill;
            PainelPai.Location = new Point(0, 0);
            PainelPai.Margin = new Padding(3, 4, 3, 4);
            PainelPai.Name = "PainelPai";
            PainelPai.Size = new Size(1396, 762);
            PainelPai.TabIndex = 11;
            // 
            // btnOrcamentos
            // 
            btnOrcamentos.BackColor = Color.PaleGreen;
            btnOrcamentos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrcamentos.ForeColor = Color.FromArgb(192, 0, 192);
            btnOrcamentos.Image = Properties.Resources._2138186_baker_bakery_cupcake_dessert_food_icon;
            btnOrcamentos.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrcamentos.Location = new Point(811, 323);
            btnOrcamentos.Margin = new Padding(3, 4, 3, 4);
            btnOrcamentos.Name = "btnOrcamentos";
            btnOrcamentos.Size = new Size(227, 107);
            btnOrcamentos.TabIndex = 16;
            btnOrcamentos.Text = "Meus &Gastos";
            btnOrcamentos.TextAlign = ContentAlignment.MiddleRight;
            btnOrcamentos.UseVisualStyleBackColor = false;
            btnOrcamentos.Click += btnOrcamentos_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.BackColor = Color.BurlyWood;
            btnProdutos.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProdutos.ForeColor = Color.Green;
            btnProdutos.Image = Properties.Resources._2138186_baker_bakery_cupcake_dessert_food_icon;
            btnProdutos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProdutos.Location = new Point(577, 323);
            btnProdutos.Margin = new Padding(3, 4, 3, 4);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(227, 107);
            btnProdutos.TabIndex = 15;
            btnProdutos.Text = "&Meus Produtos";
            btnProdutos.TextAlign = ContentAlignment.MiddleRight;
            btnProdutos.UseVisualStyleBackColor = false;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnPrecos
            // 
            btnPrecos.BackColor = Color.DeepPink;
            btnPrecos.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrecos.ForeColor = Color.White;
            btnPrecos.Image = Properties.Resources._2138186_baker_bakery_cupcake_dessert_food_icon;
            btnPrecos.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrecos.Location = new Point(344, 323);
            btnPrecos.Margin = new Padding(3, 4, 3, 4);
            btnPrecos.Name = "btnPrecos";
            btnPrecos.Size = new Size(227, 107);
            btnPrecos.TabIndex = 14;
            btnPrecos.Text = "Lista de &Preços";
            btnPrecos.TextAlign = ContentAlignment.MiddleRight;
            btnPrecos.UseVisualStyleBackColor = false;
            btnPrecos.Click += btnPrecos_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Info;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepPink;
            label1.Location = new Point(328, 189);
            label1.Name = "label1";
            label1.Size = new Size(724, 294);
            label1.TabIndex = 13;
            label1.Text = "GIF CONFEITARIA";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.papel_de_parede;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1396, 762);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // FrmPai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1396, 762);
            Controls.Add(PainelPai);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmPai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = ":: GIF CONFEITARIA ::";
            PainelPai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PainelPai;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnOrcamentos;
        private Button btnProdutos;
        private Button btnPrecos;
    }
}
