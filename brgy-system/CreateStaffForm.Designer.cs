namespace brgy_system
{
    partial class CreateStaffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateStaffForm));
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtLastName = new TextBox();
            cbGender = new ComboBox();
            numAge = new NumericUpDown();
            txtContactNumber = new TextBox();
            txtPurokNumber = new TextBox();
            txtPhase = new TextBox();
            txtPackage = new TextBox();
            txtBlock = new TextBox();
            cbReligion = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label11 = new Label();
            label12 = new Label();
            btnSave = new Button();
            cbCivilStatus = new ComboBox();
            txtReligion = new TextBox();
            label1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            btnClose = new Button();
            pictureBox2 = new PictureBox();
            label9 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(140, 104);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(150, 31);
            txtFirstName.TabIndex = 0;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(296, 104);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.PlaceholderText = "Middle Name";
            txtMiddleName.Size = new Size(150, 31);
            txtMiddleName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(452, 104);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(150, 31);
            txtLastName.TabIndex = 2;
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.Location = new Point(126, 152);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(182, 33);
            cbGender.TabIndex = 3;
            // 
            // numAge
            // 
            numAge.Location = new Point(126, 200);
            numAge.Name = "numAge";
            numAge.Size = new Size(182, 31);
            numAge.TabIndex = 4;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(125, 248);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(183, 31);
            txtContactNumber.TabIndex = 5;
            // 
            // txtPurokNumber
            // 
            txtPurokNumber.Location = new Point(158, 295);
            txtPurokNumber.Name = "txtPurokNumber";
            txtPurokNumber.Size = new Size(150, 31);
            txtPurokNumber.TabIndex = 6;
            // 
            // txtPhase
            // 
            txtPhase.Location = new Point(140, 351);
            txtPhase.Name = "txtPhase";
            txtPhase.PlaceholderText = "Phase";
            txtPhase.Size = new Size(150, 31);
            txtPhase.TabIndex = 7;
            // 
            // txtPackage
            // 
            txtPackage.Location = new Point(296, 351);
            txtPackage.Name = "txtPackage";
            txtPackage.PlaceholderText = "Package";
            txtPackage.Size = new Size(150, 31);
            txtPackage.TabIndex = 8;
            // 
            // txtBlock
            // 
            txtBlock.Location = new Point(452, 351);
            txtBlock.Name = "txtBlock";
            txtBlock.PlaceholderText = "Block";
            txtBlock.Size = new Size(150, 31);
            txtBlock.TabIndex = 9;
            // 
            // cbReligion
            // 
            cbReligion.FormattingEnabled = true;
            cbReligion.Items.AddRange(new object[] { "Roman Catholic", "Christian", "Iglesia Ni Cristo", "Muslim", "Others" });
            cbReligion.Location = new Point(438, 198);
            cbReligion.Name = "cbReligion";
            cbReligion.Size = new Size(182, 33);
            cbReligion.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Location = new Point(47, 152);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 15;
            label4.Text = "Gender";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.White;
            label5.Location = new Point(72, 200);
            label5.Name = "label5";
            label5.Size = new Size(44, 25);
            label5.TabIndex = 16;
            label5.Text = "Age";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.White;
            label6.Location = new Point(35, 248);
            label6.Name = "label6";
            label6.Size = new Size(81, 25);
            label6.TabIndex = 17;
            label6.Text = "Contacts";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.ForeColor = Color.White;
            label7.Location = new Point(20, 295);
            label7.Name = "label7";
            label7.Size = new Size(128, 25);
            label7.TabIndex = 18;
            label7.Text = "Purok Number";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.ForeColor = Color.White;
            label8.Location = new Point(54, 354);
            label8.Name = "label8";
            label8.Size = new Size(77, 25);
            label8.TabIndex = 19;
            label8.Text = "Address";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.ForeColor = Color.White;
            label11.Location = new Point(331, 152);
            label11.Name = "label11";
            label11.Size = new Size(97, 25);
            label11.TabIndex = 22;
            label11.Text = "Civil Status";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.ForeColor = Color.White;
            label12.Location = new Point(353, 198);
            label12.Name = "label12";
            label12.Size = new Size(75, 25);
            label12.TabIndex = 23;
            label12.Text = "Religion";
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Location = new Point(0, 412);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(652, 34);
            btnSave.TabIndex = 24;
            btnSave.Text = "Add Staff";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // cbCivilStatus
            // 
            cbCivilStatus.FormattingEnabled = true;
            cbCivilStatus.Items.AddRange(new object[] { "Single", "Married", "Divorced", "Widowed", "Separated" });
            cbCivilStatus.Location = new Point(438, 151);
            cbCivilStatus.Name = "cbCivilStatus";
            cbCivilStatus.Size = new Size(182, 33);
            cbCivilStatus.TabIndex = 25;
            cbCivilStatus.SelectedIndexChanged += cbCivilStatus_SelectedIndexChanged;
            // 
            // txtReligion
            // 
            txtReligion.Location = new Point(438, 252);
            txtReligion.Multiline = true;
            txtReligion.Name = "txtReligion";
            txtReligion.Size = new Size(182, 59);
            txtReligion.TabIndex = 26;
            txtReligion.TextChanged += txtReligion_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 104);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 12;
            label1.Text = "Full Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 6F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(438, 234);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 28;
            label3.Text = "If Others, Please Specify.";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(233, 234, 244);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label9);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 83);
            panel1.TabIndex = 29;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(650, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(2, 81);
            panel4.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(2, 81);
            panel3.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(652, 2);
            panel2.TabIndex = 8;
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
            label9.Location = new Point(162, 25);
            label9.Name = "label9";
            label9.Size = new Size(367, 36);
            label9.TabIndex = 5;
            label9.Text = "Staff Registration Form";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 83);
            panel5.Name = "panel5";
            panel5.Size = new Size(2, 329);
            panel5.TabIndex = 30;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Black;
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(650, 83);
            panel6.Name = "panel6";
            panel6.Size = new Size(2, 329);
            panel6.TabIndex = 31;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Black;
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(2, 411);
            panel7.Name = "panel7";
            panel7.Size = new Size(648, 1);
            panel7.TabIndex = 32;
            // 
            // CreateStaffForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(1, 20, 58);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(652, 446);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(txtReligion);
            Controls.Add(cbCivilStatus);
            Controls.Add(btnSave);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(cbReligion);
            Controls.Add(txtBlock);
            Controls.Add(txtPackage);
            Controls.Add(txtPhase);
            Controls.Add(txtPurokNumber);
            Controls.Add(txtContactNumber);
            Controls.Add(numAge);
            Controls.Add(cbGender);
            Controls.Add(txtLastName);
            Controls.Add(txtMiddleName);
            Controls.Add(txtFirstName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateStaffForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Barangay Staff Registration Form";
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private ComboBox cbGender;
        private NumericUpDown numAge;
        private TextBox txtContactNumber;
        private TextBox txtPurokNumber;
        private TextBox txtPhase;
        private TextBox txtPackage;
        private TextBox txtBlock;
        private ComboBox cbReligion;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label11;
        private Label label12;
        private Button btnSave;
        private ComboBox cbCivilStatus;
        private TextBox txtReligion;
        private Label label1;
        private Label label3;
        private Panel panel1;
        private Label label9;
        private PictureBox pictureBox2;
        private Button btnClose;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
    }
}
