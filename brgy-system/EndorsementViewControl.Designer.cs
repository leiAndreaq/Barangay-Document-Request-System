namespace brgy_system
{
    partial class EndorsementViewControl
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
            dgvEndorsements = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEndorsements).BeginInit();
            SuspendLayout();
            // 
            // dgvEndorsements
            // 
            dgvEndorsements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEndorsements.Dock = DockStyle.Fill;
            dgvEndorsements.Location = new Point(0, 0);
            dgvEndorsements.Name = "dgvEndorsements";
            dgvEndorsements.RowHeadersWidth = 62;
            dgvEndorsements.Size = new Size(800, 450);
            dgvEndorsements.TabIndex = 0;
            // 
            // EndorsementViewControl
            // 
            Controls.Add(dgvEndorsements);
            Name = "EndorsementViewControl";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvEndorsements).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEndorsements;
    }
}
