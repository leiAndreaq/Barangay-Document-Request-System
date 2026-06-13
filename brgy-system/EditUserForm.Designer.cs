namespace brgy_system
{
    partial class EditUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUserForm));
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            label4 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            btnClose = new Button();
            pictureBox2 = new PictureBox();
            label9 = new Label();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(110, 137);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(279, 31);
            txtFullName.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(110, 210);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(213, 31);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(110, 109);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 3;
            label1.Text = "Full Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(110, 182);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(341, 182);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Location = new Point(0, 276);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(656, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(341, 210);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(206, 31);
            txtPassword.TabIndex = 2;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Staff", "Purok Leader" });
            cmbRole.Location = new Point(408, 137);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(182, 33);
            cmbRole.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(408, 109);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 9;
            label4.Text = "User Role";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(233, 234, 244);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(btnClose);
            panel5.Controls.Add(pictureBox2);
            panel5.Controls.Add(label9);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(656, 83);
            panel5.TabIndex = 55;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Black;
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(654, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(2, 81);
            panel6.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Black;
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(2, 81);
            panel7.TabIndex = 9;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Black;
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(656, 2);
            panel8.TabIndex = 8;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(231, 76, 60);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(607, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(37, 34);
            btnClose.TabIndex = 7;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(20, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 72);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(1, 20, 58);
            label9.Location = new Point(226, 27);
            label9.Name = "label9";
            label9.Size = new Size(204, 36);
            label9.TabIndex = 5;
            label9.Text = "Edit Account";
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(1, 20, 58);
            ClientSize = new Size(656, 310);
            Controls.Add(panel5);
            Controls.Add(label4);
            Controls.Add(cmbRole);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtFullName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditUserForm";
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFullName;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Label label4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Button btnClose;
        private PictureBox pictureBox2;
        private Label label9;
    }
}