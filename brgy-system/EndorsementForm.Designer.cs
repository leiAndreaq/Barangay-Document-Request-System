namespace brgy_system
{
    partial class EndorsementForm
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
            txtFullName = new TextBox();
            txtCivilStatus = new TextBox();
            txtDOB = new TextBox();
            cbEndorsementType = new ComboBox();
            dtpEndorsementDate = new DateTimePicker();
            btnGeneratePDF = new Button();
            btnUploadQR = new Button();
            pbQRcode = new PictureBox();
            txtPOB = new TextBox();
            txtAddress = new TextBox();
            txtReligion = new TextBox();
            label2 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblAge = new Label();
            txtAge = new TextBox();
            txtGender = new TextBox();
            label1 = new Label();
            btnScanQR = new Button();
            dgvEndorsements = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbQRcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEndorsements).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.White;
            txtFullName.Enabled = false;
            txtFullName.ForeColor = Color.White;
            txtFullName.Location = new Point(54, 373);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(351, 31);
            txtFullName.TabIndex = 0;
            // 
            // txtCivilStatus
            // 
            txtCivilStatus.BackColor = Color.White;
            txtCivilStatus.Enabled = false;
            txtCivilStatus.ForeColor = Color.White;
            txtCivilStatus.Location = new Point(205, 442);
            txtCivilStatus.Name = "txtCivilStatus";
            txtCivilStatus.ReadOnly = true;
            txtCivilStatus.Size = new Size(173, 31);
            txtCivilStatus.TabIndex = 1;
            // 
            // txtDOB
            // 
            txtDOB.BackColor = Color.White;
            txtDOB.Enabled = false;
            txtDOB.ForeColor = Color.White;
            txtDOB.Location = new Point(462, 373);
            txtDOB.Name = "txtDOB";
            txtDOB.ReadOnly = true;
            txtDOB.Size = new Size(195, 31);
            txtDOB.TabIndex = 2;
            // 
            // cbEndorsementType
            // 
            cbEndorsementType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEndorsementType.FormattingEnabled = true;
            cbEndorsementType.Items.AddRange(new object[] { "Clearance", "Permit" });
            cbEndorsementType.Location = new Point(139, 651);
            cbEndorsementType.Name = "cbEndorsementType";
            cbEndorsementType.Size = new Size(411, 33);
            cbEndorsementType.TabIndex = 3;
            // 
            // dtpEndorsementDate
            // 
            dtpEndorsementDate.Enabled = false;
            dtpEndorsementDate.Location = new Point(209, 724);
            dtpEndorsementDate.Name = "dtpEndorsementDate";
            dtpEndorsementDate.Size = new Size(300, 31);
            dtpEndorsementDate.TabIndex = 5;
            // 
            // btnGeneratePDF
            // 
            btnGeneratePDF.Location = new Point(257, 806);
            btnGeneratePDF.Name = "btnGeneratePDF";
            btnGeneratePDF.Size = new Size(160, 57);
            btnGeneratePDF.TabIndex = 6;
            btnGeneratePDF.Text = "Register";
            btnGeneratePDF.UseVisualStyleBackColor = true;
            btnGeneratePDF.Click += btnGeneratePDF_Click;
            // 
            // btnUploadQR
            // 
            btnUploadQR.Location = new Point(160, 260);
            btnUploadQR.Name = "btnUploadQR";
            btnUploadQR.Size = new Size(112, 34);
            btnUploadQR.TabIndex = 8;
            btnUploadQR.Text = "Upload QR";
            btnUploadQR.UseVisualStyleBackColor = true;
            btnUploadQR.Click += btnUploadQR_Click_1;
            // 
            // pbQRcode
            // 
            pbQRcode.BackColor = Color.FromArgb(233, 234, 244);
            pbQRcode.BorderStyle = BorderStyle.FixedSingle;
            pbQRcode.Location = new Point(242, 28);
            pbQRcode.Name = "pbQRcode";
            pbQRcode.Size = new Size(222, 213);
            pbQRcode.SizeMode = PictureBoxSizeMode.StretchImage;
            pbQRcode.TabIndex = 9;
            pbQRcode.TabStop = false;
            // 
            // txtPOB
            // 
            txtPOB.BackColor = Color.White;
            txtPOB.Enabled = false;
            txtPOB.ForeColor = Color.White;
            txtPOB.Location = new Point(183, 491);
            txtPOB.Name = "txtPOB";
            txtPOB.ReadOnly = true;
            txtPOB.Size = new Size(474, 31);
            txtPOB.TabIndex = 10;
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.White;
            txtAddress.Enabled = false;
            txtAddress.ForeColor = Color.White;
            txtAddress.Location = new Point(139, 538);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(518, 31);
            txtAddress.TabIndex = 11;
            // 
            // txtReligion
            // 
            txtReligion.BackColor = Color.White;
            txtReligion.Enabled = false;
            txtReligion.ForeColor = Color.White;
            txtReligion.Location = new Point(381, 442);
            txtReligion.Name = "txtReligion";
            txtReligion.ReadOnly = true;
            txtReligion.Size = new Size(276, 31);
            txtReligion.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(1, 20, 58);
            label2.Location = new Point(54, 345);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 14;
            label2.Text = "Full Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(1, 20, 58);
            label5.Location = new Point(54, 491);
            label5.Name = "label5";
            label5.Size = new Size(123, 25);
            label5.TabIndex = 17;
            label5.Text = "Place of Birth";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(1, 20, 58);
            label7.Location = new Point(381, 414);
            label7.Name = "label7";
            label7.Size = new Size(81, 25);
            label7.TabIndex = 19;
            label7.Text = "Religion";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(1, 20, 58);
            label8.Location = new Point(260, 623);
            label8.Name = "label8";
            label8.Size = new Size(167, 25);
            label8.TabIndex = 20;
            label8.Text = "Endorsement Type";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(1, 20, 58);
            label9.Location = new Point(295, 696);
            label9.Name = "label9";
            label9.Size = new Size(109, 25);
            label9.TabIndex = 21;
            label9.Text = "Date Issued";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(1, 20, 58);
            label6.Location = new Point(54, 541);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 18;
            label6.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(1, 20, 58);
            label3.Location = new Point(462, 346);
            label3.Name = "label3";
            label3.Size = new Size(119, 25);
            label3.TabIndex = 15;
            label3.Text = "Date of Birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(1, 20, 58);
            label4.Location = new Point(205, 414);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 16;
            label4.Text = "Civil Status";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAge.ForeColor = Color.FromArgb(1, 20, 58);
            lblAge.Location = new Point(411, 345);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(45, 25);
            lblAge.TabIndex = 27;
            lblAge.Text = "Age";
            // 
            // txtAge
            // 
            txtAge.BackColor = Color.White;
            txtAge.Enabled = false;
            txtAge.ForeColor = Color.White;
            txtAge.Location = new Point(411, 373);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(45, 31);
            txtAge.TabIndex = 26;
            // 
            // txtGender
            // 
            txtGender.BackColor = Color.White;
            txtGender.Enabled = false;
            txtGender.ForeColor = Color.White;
            txtGender.Location = new Point(54, 442);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(145, 31);
            txtGender.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(1, 20, 58);
            label1.Location = new Point(54, 414);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 29;
            label1.Text = "Gender";
            // 
            // btnScanQR
            // 
            btnScanQR.Location = new Point(423, 260);
            btnScanQR.Name = "btnScanQR";
            btnScanQR.Size = new Size(112, 34);
            btnScanQR.TabIndex = 30;
            btnScanQR.Text = "Scan QR";
            btnScanQR.UseVisualStyleBackColor = true;
            btnScanQR.Click += btnScanQR_Click;
            // 
            // dgvEndorsements
            // 
            dgvEndorsements.AllowUserToAddRows = false;
            dgvEndorsements.AllowUserToDeleteRows = false;
            dgvEndorsements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEndorsements.Dock = DockStyle.Right;
            dgvEndorsements.Location = new Point(706, 0);
            dgvEndorsements.Name = "dgvEndorsements";
            dgvEndorsements.ReadOnly = true;
            dgvEndorsements.RowHeadersWidth = 62;
            dgvEndorsements.Size = new Size(1214, 889);
            dgvEndorsements.TabIndex = 31;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 20, 58);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(701, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 889);
            panel1.TabIndex = 32;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 20, 58);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(5, 889);
            panel2.TabIndex = 33;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(1, 20, 58);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(5, 884);
            panel3.Name = "panel3";
            panel3.Size = new Size(696, 5);
            panel3.TabIndex = 34;
            // 
            // EndorsementForm
            // 
            BackColor = Color.FromArgb(233, 234, 244);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvEndorsements);
            Controls.Add(btnScanQR);
            Controls.Add(label1);
            Controls.Add(txtGender);
            Controls.Add(lblAge);
            Controls.Add(txtAge);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtReligion);
            Controls.Add(txtAddress);
            Controls.Add(txtPOB);
            Controls.Add(pbQRcode);
            Controls.Add(btnUploadQR);
            Controls.Add(btnGeneratePDF);
            Controls.Add(dtpEndorsementDate);
            Controls.Add(cbEndorsementType);
            Controls.Add(txtDOB);
            Controls.Add(txtCivilStatus);
            Controls.Add(txtFullName);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Name = "EndorsementForm";
            Size = new Size(1920, 889);
            ((System.ComponentModel.ISupportInitialize)pbQRcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEndorsements).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFullName;
        private TextBox txtCivilStatus;
        private TextBox txtDOB;
        private ComboBox cbEndorsementType;
        private DateTimePicker dtpEndorsementDate;
        private Button btnGeneratePDF;
        private Button btnUploadQR;
        private PictureBox pbQRcode;
        private TextBox txtPOB;
        private TextBox txtAddress;
        private TextBox txtReligion;
        private Label label2;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label lblAge;
        private TextBox txtAge;
        private TextBox txtGender;
        private Label label1;
        private Button btnScanQR;
        private DataGridView dgvEndorsements;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}
