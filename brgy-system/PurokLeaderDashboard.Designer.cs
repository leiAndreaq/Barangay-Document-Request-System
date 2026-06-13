namespace brgy_system
{
    partial class PurokLeaderDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurokLeaderDashboard));
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnLogout = new Button();
            btnRegisterResident = new Button();
            btnEndorsement = new Button();
            FormPanel = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            FormPanel.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(233, 234, 244);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 120);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(1, 20, 58);
            label2.Location = new Point(811, 81);
            label2.Name = "label2";
            label2.Size = new Size(276, 36);
            label2.TabIndex = 14;
            label2.Text = "Purok Dashboard";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(740, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(440, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Location = new Point(1, 120);
            panel2.Name = "panel2";
            panel2.Size = new Size(1919, 959);
            panel2.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(1, 20, 58);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Popup;
            btnLogout.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.LightCyan;
            btnLogout.Location = new Point(1796, 80);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 12;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRegisterResident
            // 
            btnRegisterResident.BackColor = Color.FromArgb(233, 234, 244);
            btnRegisterResident.Cursor = Cursors.Hand;
            btnRegisterResident.FlatAppearance.BorderColor = Color.Black;
            btnRegisterResident.FlatAppearance.BorderSize = 3;
            btnRegisterResident.FlatStyle = FlatStyle.Flat;
            btnRegisterResident.Font = new Font("Tahoma", 11F);
            btnRegisterResident.Location = new Point(951, 6);
            btnRegisterResident.Name = "btnRegisterResident";
            btnRegisterResident.Size = new Size(308, 54);
            btnRegisterResident.TabIndex = 2;
            btnRegisterResident.Text = "Resident's Table";
            btnRegisterResident.UseVisualStyleBackColor = false;
            btnRegisterResident.Click += btnResident_Click;
            // 
            // btnEndorsement
            // 
            btnEndorsement.BackColor = Color.FromArgb(233, 234, 244);
            btnEndorsement.Cursor = Cursors.Hand;
            btnEndorsement.FlatAppearance.BorderColor = Color.Black;
            btnEndorsement.FlatAppearance.BorderSize = 3;
            btnEndorsement.FlatStyle = FlatStyle.Flat;
            btnEndorsement.Font = new Font("Tahoma", 11F);
            btnEndorsement.Location = new Point(637, 6);
            btnEndorsement.Name = "btnEndorsement";
            btnEndorsement.Size = new Size(308, 54);
            btnEndorsement.TabIndex = 3;
            btnEndorsement.Text = "Endorsement Form";
            btnEndorsement.UseVisualStyleBackColor = false;
            btnEndorsement.Click += btnEndorsement_Click;
            // 
            // FormPanel
            // 
            FormPanel.BackColor = Color.Transparent;
            FormPanel.Controls.Add(label1);
            FormPanel.Location = new Point(0, 186);
            FormPanel.Name = "FormPanel";
            FormPanel.Size = new Size(1920, 890);
            FormPanel.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(233, 234, 244);
            label1.Location = new Point(79, 303);
            label1.Name = "label1";
            label1.Size = new Size(1726, 318);
            label1.TabIndex = 7;
            label1.Text = "         WELCOME TO THE\r\nPUROK LEADER DASHBOARD";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 20, 58);
            panel3.Controls.Add(btnRegisterResident);
            panel3.Controls.Add(btnEndorsement);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(1920, 68);
            panel3.TabIndex = 5;
            // 
            // PurokLeaderDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 54, 93);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1920, 1079);
            Controls.Add(panel3);
            Controls.Add(FormPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PurokLeaderDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Purok Dashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            FormPanel.ResumeLayout(false);
            FormPanel.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel FormPanel;
        private Button btnLogout;
        private Panel panel2;
        private Button btnRegisterResident;
        private Button btnEndorsement;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label1;
    }
}