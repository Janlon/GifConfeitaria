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
            dg.Size = new Size(525, 384);
            dg.TabIndex = 12;
            dg.CellEndEdit += dg_CellEndEdit;
            // 
            // cboProdutos
            // 
            cboProdutos.Dock = DockStyle.Top;
            cboProdutos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdutos.FormattingEnabled = true;
            cboProdutos.Items.AddRange(new object[] { "Selecione" });
            cboProdutos.Location = new Point(0, 0);
            cboProdutos.Name = "cboProdutos";
            cboProdutos.Size = new Size(160, 33);
            cboProdutos.TabIndex = 11;
            cboProdutos.SelectedIndexChanged += cboProdutos_SelectedIndexChanged;
            // 
            // lblProdutoId
            // 
            lblProdutoId.AutoSize = true;
            lblProdutoId.Location = new Point(12, 36);
            lblProdutoId.Name = "lblProdutoId";
            lblProdutoId.Size = new Size(117, 25);
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
            lblTotal.Text = "R$ 0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmOrcamentos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
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
        private ComboBox cboProdutos;
        private Label lblProdutoId;
        private Label lblTotal;
    }
}