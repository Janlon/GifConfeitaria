
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
            pictureBox1 = new PictureBox();
            btnOrcamentos = new Button();
            btnProdutos = new Button();
            btnPrecos = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.papel_de_parede;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(914, 600);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnOrcamentos
            // 
            btnOrcamentos.BackColor = Color.PaleGreen;
            btnOrcamentos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrcamentos.Location = new Point(578, 247);
            btnOrcamentos.Margin = new Padding(3, 4, 3, 4);
            btnOrcamentos.Name = "btnOrcamentos";
            btnOrcamentos.Size = new Size(227, 107);
            btnOrcamentos.TabIndex = 9;
            btnOrcamentos.Text = "Meus &Gastos";
            btnOrcamentos.UseVisualStyleBackColor = false;
            btnOrcamentos.Click += btnOrcamentos_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.BackColor = Color.BurlyWood;
            btnProdutos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProdutos.Location = new Point(344, 247);
            btnProdutos.Margin = new Padding(3, 4, 3, 4);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(227, 107);
            btnProdutos.TabIndex = 8;
            btnProdutos.Text = "&Meus Produtos";
            btnProdutos.UseVisualStyleBackColor = false;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnPrecos
            // 
            btnPrecos.BackColor = Color.DeepPink;
            btnPrecos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrecos.Location = new Point(109, 247);
            btnPrecos.Margin = new Padding(3, 4, 3, 4);
            btnPrecos.Name = "btnPrecos";
            btnPrecos.Size = new Size(227, 107);
            btnPrecos.TabIndex = 7;
            btnPrecos.Text = "Lista de &Preços";
            btnPrecos.UseVisualStyleBackColor = false;
            btnPrecos.Click += btnPrecos_Click;
            // 
            // FrmPai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(914, 600);
            Controls.Add(btnOrcamentos);
            Controls.Add(btnProdutos);
            Controls.Add(btnPrecos);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmPai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = ":: GIF CONFEITARIA ::";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnOrcamentos;
        private Button btnProdutos;
        private Button btnPrecos;
    }
}
