namespace brgy_system
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            checkPassword = new CheckBox();
            panel4 = new Panel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUser = new TextBox();
            label4 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightCyan;
            label1.Location = new Point(116, 21);
            label1.Name = "label1";
            label1.Size = new Size(310, 48);
            label1.TabIndex = 0;
            label1.Text = "LOGIN FORM";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(52, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(440, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 137);
            panel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 20, 58);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(540, 13);
            panel3.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 6F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(52, 102);
            label2.Name = "label2";
            label2.Size = new Size(436, 28);
            label2.TabIndex = 3;
            label2.Text = "Barangay 176-B Zone 15 District 1 Phase 2 Package 1 Luwalhati Street\r\n       Bagong Silang Caloocan City 1428 Metro Manila Philippines";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 20, 58);
            panel2.Controls.Add(checkPassword);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(txtUser);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(540, 282);
            panel2.TabIndex = 3;
            // 
            // checkPassword
            // 
            checkPassword.AutoSize = true;
            checkPassword.Location = new Point(445, 159);
            checkPassword.Name = "checkPassword";
            checkPassword.Size = new Size(22, 21);
            checkPassword.TabIndex = 12;
            checkPassword.UseVisualStyleBackColor = true;
            checkPassword.CheckedChanged += checkPassword_CheckedChanged;
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightCyan;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 272);
            panel4.Name = "panel4";
            panel4.Size = new Size(540, 10);
            panel4.TabIndex = 11;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightCyan;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(355, 219);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.LightCyan;
            txtPassword.Cursor = Cursors.Hand;
            txtPassword.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(179, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(257, 32);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.LightCyan;
            txtUser.Cursor = Cursors.Hand;
            txtUser.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.Location = new Point(179, 100);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(288, 32);
            txtUser.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LightCyan;
            label4.Location = new Point(42, 154);
            label4.Name = "label4";
            label4.Size = new Size(122, 25);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightCyan;
            label3.Location = new Point(40, 103);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(540, 419);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Form";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Label label4;
        private TextBox txtPassword;
        private TextBox txtUser;
        private Button btnLogin;
        private Panel panel3;
        private Panel panel4;
        private CheckBox checkPassword;
    }
}
