namespace GifConfeitaria
{
    partial class FrmOrcamentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrcamentos));
            splitContainer1 = new SplitContainer();
            dg = new DataGridView();
            cboProdutos = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            lblProdutoId = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dg);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(cboProdutos);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(lblProdutoId);
            splitContainer1.Panel2.Controls.Add(lblTotal);
            splitContainer1.Size = new Size(689, 384);
            splitContainer1.SplitterDistance = 525;
            splitContainer1.TabIndex = 0;
            // 
            // dg
            // 
            dg.AllowUserToOrderColumns = true;
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg.Dock = DockStyle.Fill;
            dg.Location = new Point(0, 0);
            dg.Name = "dg";
            dg.RowHeadersWidth = 51;
            dg.Size = new Size(525, 384);
            dg.TabIndex = 12;
            dg.CellEndEdit += dg_CellEndEdit;
            dg.KeyDown += dg_KeyDown;
            // 
            // cboProdutos
            // 
            cboProdutos.Dock = DockStyle.Top;
            cboProdutos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdutos.FormattingEnabled = true;
            cboProdutos.Items.AddRange(new object[] { "Selecione" });
            cboProdutos.Location = new Point(0, 31);
            cboProdutos.Name = "cboProdutos";
            cboProdutos.Size = new Size(160, 39);
            cboProdutos.TabIndex = 16;
            cboProdutos.SelectedIndexChanged += cboProdutos_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(148, 31);
            label2.TabIndex = 15;
            label2.Text = "Meu Produto";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(0, 312);
            label1.Name = "label1";
            label1.Size = new Size(127, 31);
            label1.TabIndex = 14;
            label1.Text = "Custo Total";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblProdutoId
            // 
            lblProdutoId.AutoSize = true;
            lblProdutoId.Location = new Point(3, 97);
            lblProdutoId.Name = "lblProdutoId";
            lblProdutoId.Size = new Size(142, 31);
            lblProdutoId.TabIndex = 10;
            lblProdutoId.Text = "lblProdutoId";
            // 
            // lblTotal
            // 
            lblTotal.BackColor = Color.Transparent;
            lblTotal.BorderStyle = BorderStyle.FixedSingle;
            lblTotal.Dock = DockStyle.Bottom;
            lblTotal.Font = new Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.DeepPink;
            lblTotal.ImageAlign = ContentAlignment.MiddleRight;
            lblTotal.Location = new Point(0, 343);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(160, 41);
            lblTotal.TabIndex = 13;
            lblTotal.Text = "R$ 00.00";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmOrcamentos
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 384);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmOrcamentos";
            Text = "Meus Gastos - Custos do Produto";
            Load += FrmOrcamentos_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dg;
        private Label lblProdutoId;
        private Label lblTotal;
        private Label label1;
        private Label label2;
        private ComboBox cboProdutos;
    }
}