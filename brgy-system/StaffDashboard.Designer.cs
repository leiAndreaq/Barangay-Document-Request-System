namespace brgy_system
{
    partial class StaffDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffDashboard));
            panel1 = new Panel();
            btnLogout = new Button();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            dgvEndorsementList = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEndorsementList).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(233, 234, 244);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 151);
            panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(26, 30, 104);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(26, 30, 104);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Verdana", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1752, 49);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(88, 28);
            btnLogout.TabIndex = 15;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(1, 20, 58);
            label1.Location = new Point(831, 96);
            label1.Name = "label1";
            label1.Size = new Size(258, 36);
            label1.TabIndex = 14;
            label1.Text = "Staff Dashboard";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(740, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(440, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(dgvEndorsementList);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 151);
            panel3.Name = "panel3";
            panel3.Size = new Size(1920, 927);
            panel3.TabIndex = 3;
            // 
            // dgvEndorsementList
            // 
            dgvEndorsementList.AllowUserToAddRows = false;
            dgvEndorsementList.AllowUserToDeleteRows = false;
            dgvEndorsementList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvEndorsementList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEndorsementList.Location = new Point(168, 88);
            dgvEndorsementList.Name = "dgvEndorsementList";
            dgvEndorsementList.ReadOnly = true;
            dgvEndorsementList.RowHeadersWidth = 62;
            dgvEndorsementList.Size = new Size(1598, 781);
            dgvEndorsementList.TabIndex = 0;
            dgvEndorsementList.CellContentClick += dgvEndorsementList_CellContentClick;
            // 
            // StaffDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1078);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StaffDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff Dashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEndorsementList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private DataGridView dgvEndorsementList;
        private Label label1;
        private PictureBox pictureBox2;
        private Button btnLogout;
    }
}