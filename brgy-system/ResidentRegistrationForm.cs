using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QRCoder;

namespace brgy_system
{
    public partial class ResidentRegistrationForm : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True";
        private DataTable residentsDataTable;

        public ResidentRegistrationForm()
        {
            InitializeComponent();
            InitializePanel();
            LoadResidentData();
            dtpDOB.ValueChanged += new EventHandler(dtpDOB_ValueChanged);
            cbReligion.DropDownStyle = ComboBoxStyle.DropDownList;

            cbReligion.SelectedIndexChanged += (s, e) =>
            {
                txtReligion.Visible = cbReligion.SelectedItem?.ToString() == "Others";
            };

            // KeyPress validations
            txtAddressPhase.KeyPress += NumericOnly_KeyPress;
            txtAddressPackage.KeyPress += NumericOnly_KeyPress;
            txtAddressBlock.KeyPress += NumericOnly_KeyPress;

            txtFirstName.KeyPress += LettersOnly_KeyPress;
            txtMiddleName.KeyPress += LettersOnly_KeyPress;
            txtLastName.KeyPress += LettersOnly_KeyPress;

            // Set ComboBoxes to DropDownList so the user can only select, not type
            cbCivilStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReligion.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void InitializePanel()
        {
            dgvResidents.EnableHeadersVisualStyles = false;
            dgvResidents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
            dgvResidents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvResidents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvResidents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            dgvResidents.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvResidents.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvResidents.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            dgvResidents.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgvResidents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvResidents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResidents.GridColor = System.Drawing.Color.FromArgb(211, 211, 211);

            dgvResidents.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            dgvResidents.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvResidents.BackgroundColor = System.Drawing.Color.FromArgb(233, 234, 244);

            // Auto-size columns to fit content
            foreach (DataGridViewColumn column in dgvResidents.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadResidentData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ResidentID AS ID, FirstName AS First_Name, MiddleName AS Middle_Name, LastName AS Last_Name, Age, AddressPhase AS Phase, AddressPackage AS Package, AddressBlock AS Block, CivilStatus AS Civil_Status, Religion FROM Residents";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    residentsDataTable = new DataTable();
                    adapter.Fill(residentsDataTable);

                    dgvResidents.DataSource = residentsDataTable;

                    // DataGridView Styling
                    dgvResidents.EnableHeadersVisualStyles = false;
                    dgvResidents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
                    dgvResidents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvResidents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvResidents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

                    dgvResidents.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvResidents.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvResidents.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

                    dgvResidents.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                    dgvResidents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

                    dgvResidents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgvResidents.GridColor = System.Drawing.Color.FromArgb(211, 211, 211);

                    dgvResidents.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
                    dgvResidents.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                    dgvResidents.BackgroundColor = System.Drawing.Color.FromArgb(233, 234, 244);

                    // Auto-size columns to fit content
                    foreach (DataGridViewColumn column in dgvResidents.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    dgvResidents.AllowUserToResizeColumns = true;

                    // Optionally, remove the "Add New Row" if not needed
                    dgvResidents.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading residents: " + ex.Message);
                }
            }
        }

        // Allow numbers only
        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                ShowTooltip((Control)sender, "Numbers only");
            }
        }

        // Allow letters and basic characters only
        private void LettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                ShowTooltip((Control)sender, "Letters only");
            }
        }

        private void ShowTooltip(Control control, string message)
        {
            ToolTip tt = new ToolTip();
            tt.Show(message, control, 0, -20, 1500);
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            DateTime dob = dtpDOB.Value;
            int age = CalculateAge(dob);
            txtAge.Text = age.ToString();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                string firstName = txtFirstName.Text.Trim();
                string middleName = txtMiddleName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                DateTime dob = dtpDOB.Value;

                string addressPhase = "Phase " + txtAddressPhase.Text.Trim();
                string addressPackage = "Package " + txtAddressPackage.Text.Trim();
                string addressBlock = "Block " + txtAddressBlock.Text.Trim();

                string civilStatus = cbCivilStatus.SelectedItem.ToString();
                string religion = cbReligion.SelectedItem.ToString() == "Others" ? txtReligion.Text.Trim() : cbReligion.SelectedItem.ToString();
                string placeOfBirth = txtPlaceOfBirth.Text.Trim();
                string gender = cbGender.SelectedItem.ToString();
                int age = CalculateAge(dob);

                InsertResidentIntoDatabase(firstName, middleName, lastName, age, addressPhase, addressPackage, addressBlock,
                    placeOfBirth, civilStatus, religion, dob, gender);

                string fullName = $"{firstName} {middleName} {lastName}";
                string qrContent =
                        $"QR CODE ID \n\n" +
                        $"Name: {fullName}\n" +
                        $"Age: {age}\n" +
                        $"Date Of Birth: {dob:yyyy-MM-dd}\n" +
                        $"Gender: {gender}\n" +
                        $"Civil Status: {civilStatus}\n" +
                        $"Religion: {religion}\n" +
                        $"Place of Birth: {placeOfBirth}\n" +
                        $"Address: {addressPhase}, {addressPackage}, {addressBlock} Barangay 176-B Caloocan City";
                byte[] qrImageBytes = GenerateQRCode(firstName, lastName, qrContent);
                pbQRCode.Image = ByteArrayToImage(qrImageBytes);
                SaveQRCodeInDatabase(qrImageBytes);
                string qrFilePath = SaveQRCodeToFile(firstName, lastName, qrImageBytes);

                MessageBox.Show($"Successful Registration! {firstName} {lastName}'s QR Code saved to: {qrFilePath}");
                ClearFields();
            }
        }

        private bool ValidateFields()
        {
            if (txtFirstName.Text.Trim().Length < 3)
            {
                txtFirstName.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtMiddleName.Text.Trim()) && txtMiddleName.Text.Trim().Length < 1)
            {
                txtMiddleName.Focus();
                return false;
            }

            if (txtLastName.Text.Trim().Length < 3)
            {
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddressPhase.Text))
            {
                txtAddressPhase.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddressPackage.Text))
            {
                txtAddressPackage.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddressBlock.Text))
            {
                txtAddressBlock.Focus();
                return false;
            }

            if (cbCivilStatus.SelectedItem == null)
            {
                cbCivilStatus.Focus();
                return false;
            }

            if (cbGender.SelectedItem == null)
            {
                cbGender.Focus();
                return false;
            }

            if (cbReligion.SelectedItem == null)
            {
                cbReligion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPlaceOfBirth.Text))
            {
                txtPlaceOfBirth.Focus();
                return false;
            }

            if (cbReligion.SelectedItem.ToString() == "Others" && string.IsNullOrWhiteSpace(txtReligion.Text))
            {
                txtReligion.Focus();
                return false;
            }

            return true;
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;
            return age;
        }

        private void InsertResidentIntoDatabase(string firstName, string middleName, string lastName, int age, string addressPhase,
                                                 string addressPackage, string addressBlock, string placeOfBirth, string civilStatus,
                                                 string religion, DateTime dob, string gender)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Residents 
                        (FirstName, MiddleName, LastName, Age, AddressPhase, AddressPackage, AddressBlock, 
                         PlaceOfBirth, CivilStatus, Religion, DateOfBirth, Gender) 
                         VALUES 
                        (@FirstName, @MiddleName, @LastName, @Age, @AddressPhase, @AddressPackage, @AddressBlock, 
                         @PlaceOfBirth, @CivilStatus, @Religion, @DateOfBirth, @Gender)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleName", middleName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@AddressPhase", addressPhase);
                        cmd.Parameters.AddWithValue("@AddressPackage", addressPackage);
                        cmd.Parameters.AddWithValue("@AddressBlock", addressBlock);
                        cmd.Parameters.AddWithValue("@PlaceOfBirth", placeOfBirth);
                        cmd.Parameters.AddWithValue("@CivilStatus", civilStatus);
                        cmd.Parameters.AddWithValue("@Religion", religion);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dob);
                        cmd.Parameters.AddWithValue("@Gender", gender);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void SaveQRCodeInDatabase(byte[] qrImageBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Residents SET QRCode = @QRCode WHERE FirstName = @FirstName AND LastName = @LastName";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QRCode", qrImageBytes);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving QR code image: " + ex.Message);
                }
            }
        }

        private byte[] GenerateQRCode(string firstName, string lastName, string content)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                using (MemoryStream ms = new MemoryStream())
                {
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating QR Code: " + ex.Message);
                return null;
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private string SaveQRCodeToFile(string firstName, string lastName, byte[] qrImageBytes)
        {
            try
            {
                string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string qrFileName = $"{firstName} {lastName}QR.png";
                string qrFilePath = Path.Combine(downloadFolder, qrFileName);
                File.WriteAllBytes(qrFilePath, qrImageBytes);
                return qrFilePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving QR Code to file: " + ex.Message);
                return null;
            }
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtAddressPhase.Clear();
            txtAddressPackage.Clear();
            txtAddressBlock.Clear();
            txtPlaceOfBirth.Clear();
            txtAge.Clear();
            cbCivilStatus.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            cbReligion.SelectedIndex = -1;
            txtReligion.Clear();
            txtReligion.Visible = false;
            dtpDOB.Value = DateTime.Now;
            pbQRCode.Image = null;
        }

        private void pbQRCode_Click(object sender, EventArgs e)
        {
            // Optional QR click behavior
        }

        private void dgvResidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbReligion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
