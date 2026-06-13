namespace brgy_system
{
    partial class PurokLeaderUserControl
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

        private void InitializeComponent()
        {
            dgvPurokLeaders = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPurokLeaders).BeginInit();
            SuspendLayout();
            // 
            // dgvPurokLeaders
            // 
            dgvPurokLeaders.AllowUserToAddRows = false;
            dgvPurokLeaders.AllowUserToDeleteRows = false;
            dgvPurokLeaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurokLeaders.Dock = DockStyle.Fill;
            dgvPurokLeaders.Location = new Point(0, 0);
            dgvPurokLeaders.Name = "dgvPurokLeaders";
            dgvPurokLeaders.ReadOnly = true;
            dgvPurokLeaders.RowHeadersWidth = 62;
            dgvPurokLeaders.Size = new Size(1642, 903);
            dgvPurokLeaders.TabIndex = 0;
            // 
            // PurokLeaderUserControl
            // 
            Controls.Add(dgvPurokLeaders);
            Name = "PurokLeaderUserControl";
            Size = new Size(1642, 903);
            ((System.ComponentModel.ISupportInitialize)dgvPurokLeaders).EndInit();
            ResumeLayout(false);
        }



        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion

        private DataGridView dgvPurokLeaders;
    }
}
