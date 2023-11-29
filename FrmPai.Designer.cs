
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
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 450);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnOrcamentos
            // 
            btnOrcamentos.BackColor = Color.PaleGreen;
            btnOrcamentos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrcamentos.Image = Properties.Resources._2138186_baker_bakery_cupcake_dessert_food_icon;
            btnOrcamentos.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrcamentos.Location = new Point(506, 185);
            btnOrcamentos.Name = "btnOrcamentos";
            btnOrcamentos.Size = new Size(199, 80);
            btnOrcamentos.TabIndex = 9;
            btnOrcamentos.Text = "Meus &Gastos";
            btnOrcamentos.TextAlign = ContentAlignment.MiddleRight;
            btnOrcamentos.UseVisualStyleBackColor = false;
            btnOrcamentos.Click += btnOrcamentos_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.BackColor = Color.BurlyWood;
            btnProdutos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProdutos.Image = Properties.Resources._2138186_baker_bakery_cupcake_dessert_food_icon;
            btnProdutos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProdutos.Location = new Point(301, 185);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(199, 80);
            btnProdutos.TabIndex = 8;
            btnProdutos.Text = "&Meus Produtos";
            btnProdutos.TextAlign = ContentAlignment.MiddleRight;
            btnProdutos.UseVisualStyleBackColor = false;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnPrecos
            // 
            btnPrecos.BackColor = Color.DeepPink;
            btnPrecos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrecos.ForeColor = Color.White;
            btnPrecos.Image = Properties.Resources._2138186_baker_bakery_cupcake_dessert_food_icon;
            btnPrecos.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrecos.Location = new Point(95, 185);
            btnPrecos.Name = "btnPrecos";
            btnPrecos.Size = new Size(199, 80);
            btnPrecos.TabIndex = 7;
            btnPrecos.Text = "Lista de &Preços";
            btnPrecos.TextAlign = ContentAlignment.MiddleRight;
            btnPrecos.UseVisualStyleBackColor = false;
            btnPrecos.Click += btnPrecos_Click;
            // 
            // FrmPai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOrcamentos);
            Controls.Add(btnProdutos);
            Controls.Add(btnPrecos);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
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
