namespace GifConfeitaria
{
    partial class FrmProdutos
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
            dataGridViewProdutos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProdutos
            // 
            dataGridViewProdutos.AllowUserToOrderColumns = true;
            dataGridViewProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutos.Dock = DockStyle.Fill;
            dataGridViewProdutos.Location = new Point(0, 0);
            dataGridViewProdutos.Margin = new Padding(3, 4, 3, 4);
            dataGridViewProdutos.Name = "dataGridViewProdutos";
            dataGridViewProdutos.RowHeadersWidth = 51;
            dataGridViewProdutos.Size = new Size(723, 600);
            dataGridViewProdutos.TabIndex = 0;
            dataGridViewProdutos.CellEndEdit += dataGridViewProdutos_CellEndEdit;
            dataGridViewProdutos.CellValidating += dataGridViewProdutos_CellValidating;
            // 
            // FrmProdutos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 600);
            Controls.Add(dataGridViewProdutos);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmProdutos";
            Text = "FrmProdutos";
            Load += FrmProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewProdutos;
    }
}