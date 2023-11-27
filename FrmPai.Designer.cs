
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
            btnPrecos = new Button();
            btnProdutos = new Button();
            btnOrcamentos = new Button();
            SuspendLayout();
            // 
            // btnPrecos
            // 
            btnPrecos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrecos.Location = new Point(87, 152);
            btnPrecos.Name = "btnPrecos";
            btnPrecos.Size = new Size(199, 80);
            btnPrecos.TabIndex = 1;
            btnPrecos.Text = "PREÇOS";
            btnPrecos.UseVisualStyleBackColor = true;
            btnPrecos.Click += btnPrecos_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProdutos.Location = new Point(292, 152);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(199, 80);
            btnProdutos.TabIndex = 3;
            btnProdutos.Text = "PRODUTOS";
            btnProdutos.UseVisualStyleBackColor = true;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnOrcamentos
            // 
            btnOrcamentos.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrcamentos.Location = new Point(497, 152);
            btnOrcamentos.Name = "btnOrcamentos";
            btnOrcamentos.Size = new Size(199, 80);
            btnOrcamentos.TabIndex = 4;
            btnOrcamentos.Text = "ORÇAMENTOS";
            btnOrcamentos.UseVisualStyleBackColor = true;
            btnOrcamentos.Click += btnOrcamentos_Click;
            // 
            // FrmPai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOrcamentos);
            Controls.Add(btnProdutos);
            Controls.Add(btnPrecos);
            IsMdiContainer = true;
            MaximizeBox = false;
            Name = "FrmPai";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrecos;
        private Button btnProdutos;
        private Button btnOrcamentos;
    }
}
