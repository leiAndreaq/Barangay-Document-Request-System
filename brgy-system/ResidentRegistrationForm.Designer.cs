namespace brgy_system
{
    partial class ResidentRegistrationForm
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
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtLastName = new TextBox();
            dtpDOB = new DateTimePicker();
            txtAddressPhase = new TextBox();
            txtAddressPackage = new TextBox();
            txtAddressBlock = new TextBox();
            cbCivilStatus = new ComboBox();
            cbReligion = new ComboBox();
            txtPlaceOfBirth = new TextBox();
            cbGender = new ComboBox();
            btnRegister = new Button();
            lblFirstName = new Label();
            lblDOB = new Label();
            lblAddressPhase = new Label();
            lblCivilStatus = new Label();
            lblReligion = new Label();
            lblPlaceOfBirth = new Label();
            lblGender = new Label();
            pbQRCode = new PictureBox();
            txtAge = new TextBox();
            lblAge = new Label();
            txtReligion = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            dgvResidents = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pbQRCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResidents).BeginInit();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(467, 93);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(190, 31);
            txtFirstName.TabIndex = 0;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(663, 93);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.PlaceholderText = "Middle Name";
            txtMiddleName.Size = new Size(190, 31);
            txtMiddleName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(859, 93);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(190, 31);
            txtLastName.TabIndex = 2;
            // 
            // dtpDOB
            // 
            dtpDOB.Location = new Point(467, 174);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(300, 31);
            dtpDOB.TabIndex = 3;
            // 
            // txtAddressPhase
            // 
            txtAddressPhase.Location = new Point(1182, 93);
            txtAddressPhase.Name = "txtAddressPhase";
            txtAddressPhase.PlaceholderText = "Phase";
            txtAddressPhase.Size = new Size(190, 31);
            txtAddressPhase.TabIndex = 4;
            // 
            // txtAddressPackage
            // 
            txtAddressPackage.Location = new Point(1378, 93);
            txtAddressPackage.Name = "txtAddressPackage";
            txtAddressPackage.PlaceholderText = "Package";
            txtAddressPackage.Size = new Size(190, 31);
            txtAddressPackage.TabIndex = 5;
            // 
            // txtAddressBlock
            // 
            txtAddressBlock.Location = new Point(1574, 93);
            txtAddressBlock.Name = "txtAddressBlock";
            txtAddressBlock.PlaceholderText = "Block";
            txtAddressBlock.Size = new Size(190, 31);
            txtAddressBlock.TabIndex = 6;
            // 
            // cbCivilStatus
            // 
            cbCivilStatus.FormattingEnabled = true;
            cbCivilStatus.Items.AddRange(new object[] { "Single", "Married", "Divorced", "Widowed", "Separated" });
            cbCivilStatus.Location = new Point(664, 270);
            cbCivilStatus.Name = "cbCivilStatus";
            cbCivilStatus.Size = new Size(189, 33);
            cbCivilStatus.TabIndex = 7;
            // 
            // cbReligion
            // 
            cbReligion.FormattingEnabled = true;
            cbReligion.Items.AddRange(new object[] { "Roman Catholic", "Christian", "Iglesia Ni Cristo", "Muslim", "Others" });
            cbReligion.Location = new Point(1182, 242);
            cbReligion.Name = "cbReligion";
            cbReligion.Size = new Size(300, 33);
            cbReligion.TabIndex = 8;
            cbReligion.SelectedIndexChanged += cbReligion_SelectedIndexChanged;
            // 
            // txtPlaceOfBirth
            // 
            txtPlaceOfBirth.Location = new Point(1182, 164);
            txtPlaceOfBirth.Name = "txtPlaceOfBirth";
            txtPlaceOfBirth.Size = new Size(507, 31);
            txtPlaceOfBirth.TabIndex = 9;
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.Location = new Point(467, 270);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(190, 33);
            cbGender.TabIndex = 10;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(474, 338);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(112, 34);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(1, 20, 58);
            lblFirstName.Location = new Point(467, 65);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(96, 25);
            lblFirstName.TabIndex = 12;
            lblFirstName.Text = "Full Name";
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDOB.ForeColor = Color.FromArgb(1, 20, 58);
            lblDOB.Location = new Point(467, 146);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(119, 25);
            lblDOB.TabIndex = 15;
            lblDOB.Text = "Date of Birth";
            // 
            // lblAddressPhase
            // 
            lblAddressPhase.AutoSize = true;
            lblAddressPhase.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAddressPhase.ForeColor = Color.FromArgb(1, 20, 58);
            lblAddressPhase.Location = new Point(1182, 65);
            lblAddressPhase.Name = "lblAddressPhase";
            lblAddressPhase.Size = new Size(79, 25);
            lblAddressPhase.TabIndex = 16;
            lblAddressPhase.Text = "Address";
            // 
            // lblCivilStatus
            // 
            lblCivilStatus.AutoSize = true;
            lblCivilStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCivilStatus.ForeColor = Color.FromArgb(1, 20, 58);
            lblCivilStatus.Location = new Point(664, 242);
            lblCivilStatus.Name = "lblCivilStatus";
            lblCivilStatus.Size = new Size(103, 25);
            lblCivilStatus.TabIndex = 19;
            lblCivilStatus.Text = "Civil Status";
            // 
            // lblReligion
            // 
            lblReligion.AutoSize = true;
            lblReligion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblReligion.ForeColor = Color.FromArgb(1, 20, 58);
            lblReligion.Location = new Point(1182, 214);
            lblReligion.Name = "lblReligion";
            lblReligion.Size = new Size(81, 25);
            lblReligion.TabIndex = 20;
            lblReligion.Text = "Religion";
            // 
            // lblPlaceOfBirth
            // 
            lblPlaceOfBirth.AutoSize = true;
            lblPlaceOfBirth.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPlaceOfBirth.ForeColor = Color.FromArgb(1, 20, 58);
            lblPlaceOfBirth.Location = new Point(1182, 136);
            lblPlaceOfBirth.Name = "lblPlaceOfBirth";
            lblPlaceOfBirth.Size = new Size(126, 25);
            lblPlaceOfBirth.TabIndex = 21;
            lblPlaceOfBirth.Text = "Place Of Birth";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(1, 20, 58);
            lblGender.Location = new Point(467, 242);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(74, 25);
            lblGender.TabIndex = 22;
            lblGender.Text = "Gender";
            // 
            // pbQRCode
            // 
            pbQRCode.BorderStyle = BorderStyle.FixedSingle;
            pbQRCode.Location = new Point(88, 93);
            pbQRCode.Name = "pbQRCode";
            pbQRCode.Size = new Size(220, 223);
            pbQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            pbQRCode.TabIndex = 23;
            pbQRCode.TabStop = false;
            pbQRCode.Click += pbQRCode_Click;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(784, 174);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(83, 31);
            txtAge.TabIndex = 24;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAge.ForeColor = Color.FromArgb(1, 20, 58);
            lblAge.Location = new Point(784, 146);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(45, 25);
            lblAge.TabIndex = 25;
            lblAge.Text = "Age";
            // 
            // txtReligion
            // 
            txtReligion.Location = new Point(1182, 296);
            txtReligion.Name = "txtReligion";
            txtReligion.Size = new Size(507, 31);
            txtReligion.TabIndex = 59;
            txtReligion.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 6F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(1, 20, 58);
            label3.Location = new Point(1182, 279);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 60;
            label3.Text = "If Others, Please Specify.";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 20, 58);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(3, 890);
            panel1.TabIndex = 61;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 20, 58);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1917, 5);
            panel2.TabIndex = 62;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 20, 58);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(3, 887);
            panel3.Name = "panel3";
            panel3.Size = new Size(1917, 3);
            panel3.TabIndex = 63;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(1, 20, 58);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1917, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(3, 882);
            panel4.TabIndex = 64;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 6F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(1, 20, 58);
            label1.Location = new Point(88, 75);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 65;
            label1.Text = "QR CODE ID";
            // 
            // dgvResidents
            // 
            dgvResidents.AllowUserToAddRows = false;
            dgvResidents.AllowUserToDeleteRows = false;
            dgvResidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResidents.Dock = DockStyle.Bottom;
            dgvResidents.Location = new Point(3, 430);
            dgvResidents.Name = "dgvResidents";
            dgvResidents.ReadOnly = true;
            dgvResidents.RowHeadersWidth = 62;
            dgvResidents.Size = new Size(1914, 457);
            dgvResidents.TabIndex = 66;
            dgvResidents.CellContentClick += dgvResidents_CellContentClick;
            // 
            // ResidentRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 234, 244);
            Controls.Add(dgvResidents);
            Controls.Add(label1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(txtReligion);
            Controls.Add(lblAge);
            Controls.Add(txtAge);
            Controls.Add(pbQRCode);
            Controls.Add(lblGender);
            Controls.Add(lblPlaceOfBirth);
            Controls.Add(lblReligion);
            Controls.Add(lblCivilStatus);
            Controls.Add(lblAddressPhase);
            Controls.Add(lblDOB);
            Controls.Add(lblFirstName);
            Controls.Add(btnRegister);
            Controls.Add(cbGender);
            Controls.Add(txtPlaceOfBirth);
            Controls.Add(cbReligion);
            Controls.Add(cbCivilStatus);
            Controls.Add(txtAddressBlock);
            Controls.Add(txtAddressPackage);
            Controls.Add(txtAddressPhase);
            Controls.Add(dtpDOB);
            Controls.Add(txtLastName);
            Controls.Add(txtMiddleName);
            Controls.Add(txtFirstName);
            Name = "ResidentRegistrationForm";
            Size = new Size(1920, 890);
            ((System.ComponentModel.ISupportInitialize)pbQRCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResidents).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }



        #endregion

        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private DateTimePicker dtpDOB;
        private TextBox txtAddressPhase;
        private TextBox txtAddressPackage;
        private TextBox txtAddressBlock;
        private ComboBox cbCivilStatus;
        private ComboBox cbReligion;
        private TextBox txtPlaceOfBirth;
        private ComboBox cbGender;
        private Button btnRegister;
        private Label lblFirstName;
        private Label lblDOB;
        private Label lblAddressPhase;
        private Label lblCivilStatus;
        private Label lblReligion;
        private Label lblPlaceOfBirth;
        private Label lblGender;
        private PictureBox pbQRCode;
        private TextBox txtAge;
        private Label lblAge;
        private TextBox txtReligion;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private DataGridView dgvResidents;
    }
}
