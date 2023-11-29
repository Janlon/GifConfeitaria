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
            dg.Name = "dg";
            dg.RowHeadersWidth = 51;
            dg.Size = new Size(803, 468);
            dg.TabIndex = 0;
            dg.CellEndEdit += dg_CellEndEdit;
            // 
            // FrmPrecos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 468);
            Controls.Add(dg);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "FrmPrecos";
            Text = "FrmPrecos";
            Load += FrmPrecos_Load;
            ((System.ComponentModel.ISupportInitialize)dg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dg;
    }
}