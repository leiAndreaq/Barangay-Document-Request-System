namespace brgy_system
{
    partial class ServiceRequestUserControl
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
            dgvServiceRequests = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvServiceRequests).BeginInit();
            SuspendLayout();
            // 
            // dgvServiceRequests
            // 
            dgvServiceRequests.AllowUserToAddRows = false;
            dgvServiceRequests.AllowUserToDeleteRows = false;
            dgvServiceRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServiceRequests.Dock = DockStyle.Fill;
            dgvServiceRequests.Location = new Point(0, 0);
            dgvServiceRequests.Name = "dgvServiceRequests";
            dgvServiceRequests.ReadOnly = true;
            dgvServiceRequests.RowHeadersWidth = 62;
            dgvServiceRequests.Size = new Size(800, 450);
            dgvServiceRequests.TabIndex = 0;
            // 
            // ServiceRequestUserControl
            // 
            Controls.Add(dgvServiceRequests);
            Name = "ServiceRequestUserControl";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvServiceRequests).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private DataGridView dgvServiceRequests;
    }
}
