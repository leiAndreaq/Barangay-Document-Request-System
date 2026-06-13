namespace brgy_system
{
    partial class ResidentsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvResidents = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResidents).BeginInit();
            SuspendLayout();
            // 
            // dgvResidents
            // 
            dgvResidents.AllowUserToAddRows = false;
            dgvResidents.AllowUserToDeleteRows = false;
            dgvResidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResidents.Dock = DockStyle.Fill;
            dgvResidents.Location = new Point(0, 0);
            dgvResidents.Name = "dgvResidents";
            dgvResidents.ReadOnly = true;
            dgvResidents.RowHeadersWidth = 62;
            dgvResidents.Size = new Size(800, 450);
            dgvResidents.TabIndex = 0;
            dgvResidents.CellContentClick += dgvResidents_CellContentClick_1;
            // 
            // ResidentsUserControl
            // 
            Controls.Add(dgvResidents);
            Name = "ResidentsUserControl";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvResidents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResidents;
    }
}
