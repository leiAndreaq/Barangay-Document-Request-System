using ZXing;
using SkiaSharp;
using System;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using ZXing.SkiaSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using QRCoder;
using System.Diagnostics;
using System.Data;

namespace brgy_system
{
    public partial class EndorsementForm : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True";
        private BarcodeReader barcodeReader;  // ZXing Barcode reader for QR code decoding

        public EndorsementForm()
        {
            InitializeComponent();
            barcodeReader = new BarcodeReader();  // Initialize ZXing BarcodeReader
            LoadEndorsements();
        }

        private void LoadEndorsements()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            e.EndorsementID,
                            r.FirstName + ' ' + r.MiddleName + ' ' + r.LastName AS ResidentName,
                            e.DateEndorsed
                        FROM 
                            Endorsements e
                            JOIN Residents r ON e.ResidentID = r.ResidentID
                        ORDER BY e.DateEndorsed DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEndorsements.DataSource = dt;
                    StyleDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading endorsements: " + ex.Message);
            }
        }

        private void StyleDataGridView()
        {
            dgvEndorsements.BackgroundColor = this.BackColor;
            dgvEndorsements.BorderStyle = BorderStyle.None;
            dgvEndorsements.EnableHeadersVisualStyles = false;
            dgvEndorsements.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
            dgvEndorsements.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvEndorsements.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvEndorsements.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEndorsements.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvEndorsements.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEndorsements.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgvEndorsements.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvEndorsements.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvEndorsements.RowTemplate.Height = 30;

            dgvEndorsements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEndorsements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEndorsements.ColumnHeadersHeight = 35;

            dgvEndorsements.Sort(dgvEndorsements.Columns["DateEndorsed"], System.ComponentModel.ListSortDirection.Descending);
        }


        // QR upload button for extracting resident data
        private void btnUploadQR_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png; *.jpg; *.jpeg; *.bmp; *.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string qrImagePath = openFileDialog.FileName;
                pbQRcode.Image = Image.FromFile(qrImagePath);
                ExtractResidentData(qrImagePath);
            }
        }

        // Extract data from the uploaded QR code
        private void ExtractResidentData(string qrFilePath)
        {
            try
            {
                // Decode the QR code from the image file using ZXing
                var bitmap = SKBitmap.Decode(qrFilePath);
                var result = barcodeReader.Decode(bitmap); // Using BarcodeReader to decode the QR

                if (result != null)
                {
                    string qrData = result.Text;  // Get the QR code content

                    // Split the QR data by lines
                    var residentData = qrData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    // Ensure there are at least 8 lines (fields) in the QR data
                    if (residentData.Length >= 8)
                    {
                        // Extract and assign the values from the QR code to the corresponding text fields
                        txtFullName.Text = GetFieldValue(residentData, "Name");
                        txtAge.Text = GetFieldValue(residentData, "Age");
                        txtDOB.Text = GetFieldValue(residentData, "Date Of Birth");
                        txtGender.Text = GetFieldValue(residentData, "Gender");
                        txtCivilStatus.Text = GetFieldValue(residentData, "Civil Status");
                        txtReligion.Text = GetFieldValue(residentData, "Religion");
                        txtPOB.Text = GetFieldValue(residentData, "Place of Birth");

                        // Handle Address field, as it may contain more complex data (newlines, commas, etc.)
                        string address = GetFieldValue(residentData, "Address");
                        txtAddress.Text = address; // Assign the entire address to the Address textbox
                    }
                    else
                    {
                        MessageBox.Show("QR code data is in an incorrect format.");
                    }
                }
                else
                {
                    MessageBox.Show("QR code could not be read.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading QR code: " + ex.Message);
            }
        }

        // Helper function to extract a field value from the QR code data
        private string GetFieldValue(string[] data, string fieldName)
        {
            // Search for the specific field in the array
            foreach (var item in data)
            {
                if (item.StartsWith(fieldName))  // Check if the field starts with the specified name
                {
                    // If found, return the value after the colon
                    return item.Split(':')[1].Trim();  // Get the data after the colon
                }
            }
            return "";  // Return empty if the field is not found
        }

        // Handle the registration of the endorsement
        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure that the form has the necessary information
                if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtAge.Text) ||
                    string.IsNullOrEmpty(txtDOB.Text) || string.IsNullOrEmpty(txtGender.Text) ||
                    string.IsNullOrEmpty(txtCivilStatus.Text) || string.IsNullOrEmpty(txtReligion.Text) ||
                    string.IsNullOrEmpty(txtPOB.Text) || string.IsNullOrEmpty(txtAddress.Text) ||
                    cbEndorsementType.SelectedItem == null)
                {
                    MessageBox.Show("Please fill all the details and select endorsement type before registering.");
                    return;
                }

                // Prepare data from the textboxes
                string fullName = txtFullName.Text;
                string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Extract first name and last name
                string firstName = nameParts.Length > 0 ? nameParts[0] : "";
                string lastName = nameParts.Length > 1 ? nameParts[nameParts.Length - 1] : "";

                string age = txtAge.Text;
                string dob = txtDOB.Text;
                string gender = txtGender.Text;
                string civilStatus = txtCivilStatus.Text;
                string religion = txtReligion.Text;
                string placeOfBirth = txtPOB.Text;
                string address = txtAddress.Text;
                string endorsementType = cbEndorsementType.SelectedItem?.ToString() ?? "N/A"; // Get the endorsement type
                string endorsementDate = DateTime.Now.ToShortDateString();

                // Retrieve ResidentID from the database using first name and last name only (no middle name)
                int residentID = GetResidentID(firstName, lastName);

                // Insert the data into the Endorsements table
                if (residentID == 0)
                {
                    MessageBox.Show("Resident information is missing.");
                    return;
                }

                // Assuming you already have a logic to get PurokLeaderID, here it's hardcoded
                int purokLeaderID = GetPurokLeaderID();

                // Insert Endorsement data and pass endorsementType to the function
                InsertEndorsementIntoDatabase(residentID, purokLeaderID, DateTime.Now, endorsementType); // Insert into database

                // Prepare the PDF document
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Endorsement PDF";

                // Create a page and graphics for drawing text
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Define a font for the text
                XFont font = new XFont("Verdana", 12);

                // Add content to the PDF
                gfx.DrawString("Resident Endorsement", font, XBrushes.Black, 30, 50);
                gfx.DrawString($"Name: {fullName}", font, XBrushes.Black, 30, 80);
                gfx.DrawString($"Age: {age}", font, XBrushes.Black, 30, 110);
                gfx.DrawString($"Date of Birth: {dob}", font, XBrushes.Black, 30, 140);
                gfx.DrawString($"Gender: {gender}", font, XBrushes.Black, 30, 170);
                gfx.DrawString($"Civil Status: {civilStatus}", font, XBrushes.Black, 30, 200);
                gfx.DrawString($"Religion: {religion}", font, XBrushes.Black, 30, 230);
                gfx.DrawString($"Place of Birth: {placeOfBirth}", font, XBrushes.Black, 30, 260);
                gfx.DrawString($"Address: {address}", font, XBrushes.Black, 30, 290);
                gfx.DrawString($"Endorsement Type: {endorsementType}", font, XBrushes.Black, 30, 320);
                gfx.DrawString($"Endorsement Date: {endorsementDate}", font, XBrushes.Black, 30, 350);

                // Save the document to a file
                string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Endorsement_{fullName}.pdf");
                document.Save(pdfPath);

                // Show a message to the user
                MessageBox.Show($"PDF Generated: {pdfPath}");

                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
            LoadEndorsements();
        }

        private void ClearFormFields()
        {
            txtFullName.Clear();
            txtAge.Clear();
            txtDOB.Clear();
            txtGender.Clear();
            txtCivilStatus.Clear();
            txtReligion.Clear();
            txtPOB.Clear();
            txtAddress.Clear();
            cbEndorsementType.SelectedIndex = -1; // Reset the combo box selection
        }

        // Function to retrieve ResidentID from the database based on first name and last name (no middle name)
        private int GetResidentID(string firstName, string lastName)
        {
            int residentID = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Modify query to use only FirstName and LastName
                    string query = "SELECT ResidentID FROM Residents WHERE CONCAT(FirstName, ' ', LastName) = @FullName";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FullName", $"{firstName} {lastName}");

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        residentID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving ResidentID: " + ex.Message);
                }
            }
            return residentID;
        }

        // Function to insert the Endorsement data into the database
        // Function to insert the Endorsement data into the database, now including the EndorsementType
        private void InsertEndorsementIntoDatabase(int residentID, int purokLeaderID, DateTime dateEndorsed, string endorsementType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Endorsements (ResidentID, PurokLeaderID, DateEndorsed, EndorsementType) " +
                                   "VALUES (@ResidentID, @PurokLeaderID, @DateEndorsed, @EndorsementType)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ResidentID", residentID);
                    cmd.Parameters.AddWithValue("@PurokLeaderID", purokLeaderID);
                    cmd.Parameters.AddWithValue("@DateEndorsed", dateEndorsed);
                    cmd.Parameters.AddWithValue("@EndorsementType", endorsementType);  // Inserting the EndorsementType

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting Endorsement data: " + ex.Message);
                }
            }
        }

        // Placeholder function to get the PurokLeaderID (replace this with actual logic)
        private int GetPurokLeaderID()
        {
            return 1; // Example Purok Leader ID
        }


        private void OnQRDataExtracted(string fullName, string age, string dob, string gender, string civilStatus, string religion, string placeOfBirth, string address)
        {
            // Populate the textboxes with the extracted data
            txtFullName.Text = fullName;
            txtAge.Text = age;
            txtDOB.Text = dob;
            txtGender.Text = gender;
            txtCivilStatus.Text = civilStatus;
            txtReligion.Text = religion;
            txtPOB.Text = placeOfBirth;
            txtAddress.Text = address;
        }

        // Button to trigger the QR scanning form
        private void btnScanQR_Click(object sender, EventArgs e)
        {
            // Create an instance of the ScanQR form
            ScanQR scanQRForm = new ScanQR();

            // Subscribe to the event to get the extracted QR data
            scanQRForm.QRDataExtracted += OnQRDataExtracted;

            // Show the ScanQR form as a dialog (modal)
            scanQRForm.ShowDialog();
        }
    }
}
