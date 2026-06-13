namespace brgy_system
{
    partial class RegisterRoleUserAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterRoleUserAccount));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            cbRole = new ComboBox();
            label4 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            label5 = new Label();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(113, 143);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(221, 31);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(113, 180);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(221, 31);
            txtPassword.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(113, 106);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(221, 31);
            txtFullName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(1, 20, 58);
            label1.Location = new Point(8, 143);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(1, 20, 58);
            label2.Location = new Point(12, 180);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(1, 20, 58);
            label3.Location = new Point(8, 106);
            label3.Name = "label3";
            label3.Size = new Size(102, 25);
            label3.TabIndex = 5;
            label3.Text = "Full Name";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(222, 217);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(113, 67);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(221, 33);
            cbRole.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(1, 20, 58);
            label4.Location = new Point(53, 67);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 8;
            label4.Text = "Role";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 2);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(2, 261);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(349, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(2, 261);
            panel3.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(2, 261);
            panel4.Name = "panel4";
            panel4.Size = new Size(347, 2);
            panel4.TabIndex = 12;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(1, 20, 58);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(2, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(347, 51);
            panel5.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(233, 234, 244);
            label5.Location = new Point(81, 13);
            label5.Name = "label5";
            label5.Size = new Size(200, 25);
            label5.TabIndex = 14;
            label5.Text = "Sign In Staff Account";
            // 
            // RegisterRoleUserAccount
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 234, 244);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(351, 263);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(cbRole);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtFullName);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterRoleUserAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign in ";
            Load += RegisterRoleUserAccount_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private ComboBox cbRole;
        private Label label4;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label5;
    }
}