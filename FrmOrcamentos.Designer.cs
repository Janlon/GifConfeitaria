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
            comboBox1 = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            dg = new DataGridView();
            lblTotal = new Label();
            lblIdProduto = new Label();
            lblQtdPreco = new Label();
            lblPreco = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(668, 39);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dg, 0, 1);
            tableLayoutPanel1.Controls.Add(comboBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblTotal, 0, 2);
            tableLayoutPanel1.Controls.Add(lblIdProduto, 0, 3);
            tableLayoutPanel1.Controls.Add(lblQtdPreco, 0, 4);
            tableLayoutPanel1.Controls.Add(lblPreco, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.4670486F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.53295F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(674, 350);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dg
            // 
            dg.AllowUserToOrderColumns = true;
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg.Dock = DockStyle.Fill;
            dg.Location = new Point(5, 39);
            dg.Margin = new Padding(5);
            dg.Name = "dg";
            dg.RowHeadersWidth = 51;
            dg.Size = new Size(664, 208);
            dg.TabIndex = 1;
            dg.CellEndEdit += dg_CellEndEdit;
            dg.RowPrePaint += dg_RowPrePaint;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.DeepPink;
            lblTotal.ImageAlign = ContentAlignment.MiddleRight;
            lblTotal.Location = new Point(3, 252);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(108, 37);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "R$ 0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIdProduto
            // 
            lblIdProduto.AutoSize = true;
            lblIdProduto.Location = new Point(3, 289);
            lblIdProduto.Name = "lblIdProduto";
            lblIdProduto.Size = new Size(142, 20);
            lblIdProduto.TabIndex = 4;
            lblIdProduto.Text = "lblIdProduto";
            // 
            // lblQtdPreco
            // 
            lblQtdPreco.AutoSize = true;
            lblQtdPreco.Location = new Point(3, 309);
            lblQtdPreco.Name = "lblQtdPreco";
            lblQtdPreco.Size = new Size(136, 20);
            lblQtdPreco.TabIndex = 5;
            lblQtdPreco.Text = "lblQtdPreco";
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(3, 329);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(97, 21);
            lblPreco.TabIndex = 6;
            lblPreco.Text = "lblPreco";
            // 
            // FrmOrcamentos
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 350);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmOrcamentos";
            Text = "Meus Gastos - Custos do Produto";
            Load += FrmOrcamentos_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dg).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox comboBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dg;
        private Label lblTotal;
        private Label lblIdProduto;
        private Label lblQtdPreco;
        private Label lblPreco;
    }
}