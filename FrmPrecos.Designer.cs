namespace GifConfeitaria
{
    partial class FrmPrecos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrecos));
            dg = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dg).BeginInit();
            SuspendLayout();
            // 
            // dg
            // 
            dg.AllowUserToOrderColumns = true;
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg.Dock = DockStyle.Fill;
            dg.Location = new Point(0, 0);
            dg.Margin = new Padding(5, 6, 5, 6);
            dg.MultiSelect = false;
            dg.Name = "dg";
            dg.RowHeadersWidth = 51;
            dg.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dg.Size = new Size(473, 227);
            dg.TabIndex = 1;
            dg.CellEndEdit += dg_CellEndEdit;
            dg.KeyDown += dg_KeyDown;
            // 
            // FrmPrecos
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 227);
            Controls.Add(dg);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FrmPrecos";
            Text = "Lista de Preços - Produtos e Serviços";
            Load += FrmPrecos_Load;
            ((System.ComponentModel.ISupportInitialize)dg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dg;
    }
}