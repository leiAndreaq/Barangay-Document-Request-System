namespace brgy_system
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            panel1 = new Panel();
            panelContainer = new Panel();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            btnLogout = new Button();
            btnViewPurok = new Button();
            btnRecord = new Button();
            btnViewStaff = new Button();
            btnViewResidents = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 20, 58);
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(panelContainer);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 143);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 936);
            panel1.TabIndex = 0;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.White;
            panelContainer.BackgroundImage = (Image)resources.GetObject("panelContainer.BackgroundImage");
            panelContainer.BackgroundImageLayout = ImageLayout.Stretch;
            panelContainer.Controls.Add(label2);
            panelContainer.Controls.Add(pictureBox2);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(246, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1674, 936);
            panelContainer.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(233, 234, 244);
            label2.Location = new Point(215, 357);
            label2.Name = "label2";
            label2.Size = new Size(1265, 318);
            label2.TabIndex = 1;
            label2.Text = "  WELCOME TO THE\r\nADMIN DASHBOARD";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(703, 99);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(214, 206);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 54, 93);
            panel3.Controls.Add(btnLogout);
            panel3.Controls.Add(btnViewPurok);
            panel3.Controls.Add(btnRecord);
            panel3.Controls.Add(btnViewStaff);
            panel3.Controls.Add(btnViewResidents);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(246, 936);
            panel3.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(217, 217, 217);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 3;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.Maroon;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Tahoma", 11F);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(70, 879);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(104, 45);
            btnLogout.TabIndex = 16;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnViewPurok
            // 
            btnViewPurok.BackColor = Color.FromArgb(217, 217, 217);
            btnViewPurok.Cursor = Cursors.Hand;
            btnViewPurok.FlatAppearance.BorderSize = 3;
            btnViewPurok.FlatAppearance.MouseOverBackColor = Color.DarkTurquoise;
            btnViewPurok.FlatStyle = FlatStyle.Flat;
            btnViewPurok.Font = new Font("Tahoma", 11F);
            btnViewPurok.ForeColor = Color.Black;
            btnViewPurok.Location = new Point(13, 188);
            btnViewPurok.Name = "btnViewPurok";
            btnViewPurok.Size = new Size(221, 47);
            btnViewPurok.TabIndex = 15;
            btnViewPurok.Text = "Purok Leaders";
            btnViewPurok.UseVisualStyleBackColor = false;
            btnViewPurok.Click += btnViewPurok_Click;
            // 
            // btnRecord
            // 
            btnRecord.BackColor = Color.FromArgb(217, 217, 217);
            btnRecord.Cursor = Cursors.Hand;
            btnRecord.FlatAppearance.BorderSize = 3;
            btnRecord.FlatAppearance.MouseOverBackColor = Color.DarkTurquoise;
            btnRecord.FlatStyle = FlatStyle.Flat;
            btnRecord.Font = new Font("Tahoma", 11F);
            btnRecord.ForeColor = Color.Black;
            btnRecord.Location = new Point(13, 271);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(221, 47);
            btnRecord.TabIndex = 14;
            btnRecord.Text = "Records";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // btnViewStaff
            // 
            btnViewStaff.BackColor = Color.FromArgb(217, 217, 217);
            btnViewStaff.Cursor = Cursors.Hand;
            btnViewStaff.FlatAppearance.BorderSize = 3;
            btnViewStaff.FlatAppearance.MouseOverBackColor = Color.DarkTurquoise;
            btnViewStaff.FlatStyle = FlatStyle.Flat;
            btnViewStaff.Font = new Font("Tahoma", 11F);
            btnViewStaff.ForeColor = Color.Black;
            btnViewStaff.Location = new Point(13, 107);
            btnViewStaff.Name = "btnViewStaff";
            btnViewStaff.Size = new Size(221, 47);
            btnViewStaff.TabIndex = 13;
            btnViewStaff.Text = "Staff";
            btnViewStaff.UseVisualStyleBackColor = false;
            btnViewStaff.Click += btnViewStaff_Click_1;
            // 
            // btnViewResidents
            // 
            btnViewResidents.BackColor = Color.FromArgb(217, 217, 217);
            btnViewResidents.Cursor = Cursors.Hand;
            btnViewResidents.FlatAppearance.BorderSize = 3;
            btnViewResidents.FlatAppearance.MouseOverBackColor = Color.DarkTurquoise;
            btnViewResidents.FlatStyle = FlatStyle.Flat;
            btnViewResidents.Font = new Font("Tahoma", 11F);
            btnViewResidents.ForeColor = Color.Black;
            btnViewResidents.Location = new Point(13, 29);
            btnViewResidents.Name = "btnViewResidents";
            btnViewResidents.Size = new Size(221, 47);
            btnViewResidents.TabIndex = 12;
            btnViewResidents.Text = "Resident's Table";
            btnViewResidents.UseVisualStyleBackColor = false;
            btnViewResidents.Click += btnViewResidents_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(233, 234, 244);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1920, 145);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(1, 20, 58);
            label1.Location = new Point(879, 93);
            label1.Name = "label1";
            label1.Size = new Size(381, 36);
            label1.TabIndex = 4;
            label1.Text = "Admin Office Dashboard";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(836, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(440, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1920, 1079);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Admin Dashboard";
            panel1.ResumeLayout(false);
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel3;
        private Panel panelContainer;
        private Button btnRecord;
        private Button btnViewStaff;
        private Button btnViewResidents;
        private Button btnViewPurok;
        private Label label2;
        private PictureBox pictureBox2;
        private Button btnLogout;
    }
}