using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace brgy_system
{
    public partial class StaffDashboard : Form
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public StaffDashboard()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadEndorsements();
        }

        private void InitializeDataGridView()
        {
            // Add the "Take Action" button column if not already added
            if (!dgvEndorsementList.Columns.Contains("TakeAction"))
            {
                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
                actionColumn.Name = "TakeAction";
                actionColumn.Text = "Take Action";
                actionColumn.UseColumnTextForButtonValue = true;
                dgvEndorsementList.Columns.Add(actionColumn);
            }

            // Apply auto-resizing to fit the content
            dgvEndorsementList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvEndorsementList.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            // Set the background color and font for the column headers
            dgvEndorsementList.EnableHeadersVisualStyles = false;
            dgvEndorsementList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(24, 28, 41); // Dark blue
            dgvEndorsementList.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvEndorsementList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvEndorsementList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set alternating row color
            dgvEndorsementList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245); // Light gray for alternate rows
            dgvEndorsementList.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White; // White for normal rows
            dgvEndorsementList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Set the font and alignment for the data cells
            dgvEndorsementList.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvEndorsementList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEndorsementList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Adjust column widths to fit content and prevent horizontal scrolling
            dgvEndorsementList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Apply custom width to the 'Take Action' button column (if desired)
            dgvEndorsementList.Columns["TakeAction"].Width = 120;

            // Set row height for better readability
            dgvEndorsementList.RowTemplate.Height = 40;

            // Set alignment for all data columns to center (optional)
            foreach (DataGridViewColumn col in dgvEndorsementList.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void LoadEndorsements()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT e.EndorsementID, " +
                                   "e.EndorsementType, " +
                                   "CONCAT(r.FirstName, ' ', r.MiddleName, ' ', r.LastName) AS ResidentFullName, " +
                                   "e.DateEndorsed " +  // Include DateEndorsed
                                   "FROM Endorsements e " +
                                   "JOIN Residents r ON e.ResidentID = r.ResidentID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvEndorsementList.DataSource = dt;
                    dgvEndorsementList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading endorsements: " + ex.Message);
            }
        }

        private void dgvEndorsementList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvEndorsementList.Columns["TakeAction"].Index)
            {
                string fullName = dgvEndorsementList.Rows[e.RowIndex].Cells["ResidentFullName"].Value?.ToString();
                string endorsementType = dgvEndorsementList.Rows[e.RowIndex].Cells["EndorsementType"].Value?.ToString();
                string dateEndorsed = dgvEndorsementList.Rows[e.RowIndex].Cells["DateEndorsed"].Value?.ToString(); // Get DateEndorsed value

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(endorsementType) || string.IsNullOrEmpty(dateEndorsed))
                {
                    MessageBox.Show("Error: Resident data, endorsement type, or endorsement date is missing.");
                    return;
                }

                DialogResult result = MessageBox.Show($"Would you like to create the {endorsementType} document for {fullName}?",
                                                      $"Create {endorsementType}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (endorsementType == "Clearance")
                    {
                        GenerateBarangayClearancePDF(fullName, endorsementType, dateEndorsed); // Barangay Clearance PDF
                    }
                    else if (endorsementType == "Permit")
                    {
                        GenerateBusinessPermitPDF(fullName, endorsementType, dateEndorsed); // Business Permit PDF
                    }
                    else
                    {
                        MessageBox.Show("Invalid endorsement type.");
                    }

                    dgvEndorsementList.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        // For generating Barangay Clearance PDF
        private void GenerateBarangayClearancePDF(string fullName, string endorsementType, string dateEndorsed)
        {
            try
            {
                string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                              $"{endorsementType}_{fullName}.pdf");

                // Create a new PDF document
                PdfDocument document = new PdfDocument();
                document.Info.Title = $"{endorsementType} Certificate";

                // Add a page to the document
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Background image (if needed, but not mandatory)
                string bgPath = @"C:\Users\New Admin\source\repos\brgy-system\Background.png";
                if (File.Exists(bgPath))
                {
                    try
                    {
                        XImage bgImage = XImage.FromFile(bgPath);
                        double pageWidth = page.Width.Point;
                        double pageHeight = page.Height.Point;
                        double aspectRatio = bgImage.PixelWidth / (double)bgImage.PixelHeight;
                        double newWidth = pageWidth;
                        double newHeight = pageWidth / aspectRatio;

                        if (newHeight > pageHeight)
                        {
                            newHeight = pageHeight;
                            newWidth = pageHeight * aspectRatio;
                        }
                        gfx.DrawImage(bgImage, 0, 0, newWidth, newHeight);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading background image: {ex.Message}");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Background image not found.");
                    return;
                }

                // Add Logo image (optional)
                string logoPath = @"C:\Users\New Admin\source\repos\brgy-system\Logo.png";
                if (File.Exists(logoPath))
                {
                    try
                    {
                        XImage logoImage = XImage.FromFile(logoPath);
                        double logoWidth = 90;
                        double logoHeight = 90;
                        gfx.DrawImage(logoImage, 50, 110, logoWidth, logoHeight);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading logo: {ex.Message}");
                        return;
                    }
                }

                // Fonts for the document
                XFont defaultFont = new XFont("Arial", 12);
                XFont boldFont = new XFont("Arial", 14);

                int y = 100;
                int left = 50;
                int right = 50;
                int maxWidth = (int)page.Width.Point - left - right;

                // Header content
                gfx.DrawString("Republic of the Philippines", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);
                y += 30;
                gfx.DrawString("City of Caloocan", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);
                y += 40;
                gfx.DrawString("OFFICE OF THE BARANGAY CAPTAIN", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);
                y += 40;
                gfx.DrawString("BARANGAY CLEARANCE", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);

                y += 30;
                gfx.DrawLine(XPens.Black, left, y, page.Width.Point - right, y);
                y += 40;

                // TO WHOM IT MAY CONCERN
                gfx.DrawString("TO WHOM IT MAY CONCERN:", defaultFont, XBrushes.Black, left, y);
                y += 35;

                string paragraph1 = $"This is to certify that {fullName}, a resident of Barangay 176 Bagong Silang, Caloocan City, is known to be a good moral character and law-abiding citizen of this community.";
                y = DrawText(gfx, paragraph1, defaultFont, left, y, maxWidth);

                y += 30;

                string paragraph2 = $"This certificate is issued upon request for the purpose of {endorsementType}.";
                y = DrawText(gfx, paragraph2, defaultFont, left, y, maxWidth);

                y += 350;

                // Display Date Endorsed
                string paragraph3 = $"Date Endorsed: {dateEndorsed}";
                y = DrawText(gfx, paragraph3, defaultFont, left, y, maxWidth);

                gfx.DrawString("JOEL B. LLORCA", defaultFont, XBrushes.Black, page.Width.Point - right - 150, y);
                y += 35;
                gfx.DrawString("Barangay Captain", defaultFont, XBrushes.Black, page.Width.Point - right - 150, y);

                // Save PDF document
                document.Save(pdfPath);

                MessageBox.Show($"{endorsementType} document generated at: {pdfPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating the PDF: {ex.Message}");
            }
        }

        // For generating Barangay Business Permit PDF
        private void GenerateBusinessPermitPDF(string fullName, string endorsementType, string dateEndorsed)
        {
            try
            {
                string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                              $"{endorsementType}_{fullName}.pdf");

                // Create a new PDF document
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Barangay Business Permit";

                // Add a page to the document
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Background image (if needed, but not mandatory)
                string bgPath = @"C:\Users\New Admin\source\repos\brgy-system\Background.png";
                if (File.Exists(bgPath))
                {
                    try
                    {
                        XImage bgImage = XImage.FromFile(bgPath);
                        double pageWidth = page.Width.Point;
                        double pageHeight = page.Height.Point;
                        double aspectRatio = bgImage.PixelWidth / (double)bgImage.PixelHeight;
                        double newWidth = pageWidth;
                        double newHeight = pageWidth / aspectRatio;

                        if (newHeight > pageHeight)
                        {
                            newHeight = pageHeight;
                            newWidth = pageHeight * aspectRatio;
                        }
                        gfx.DrawImage(bgImage, 0, 0, newWidth, newHeight);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading background image: {ex.Message}");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Background image not found.");
                    return;
                }

                // Add Logo image (optional)
                string logoPath = @"C:\Users\New Admin\source\repos\brgy-system\Logo.png";
                if (File.Exists(logoPath))
                {
                    try
                    {
                        XImage logoImage = XImage.FromFile(logoPath);
                        double logoWidth = 90;
                        double logoHeight = 90;
                        gfx.DrawImage(logoImage, 50, 110, logoWidth, logoHeight);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading logo: {ex.Message}");
                        return;
                    }
                }

                // Fonts for the document
                XFont defaultFont = new XFont("Arial", 12);
                XFont boldFont = new XFont("Arial", 14);

                int y = 100;
                int left = 50;
                int right = 50;
                int maxWidth = (int)page.Width.Point - left - right;

                // Header content
                gfx.DrawString("Republic of the Philippines", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);
                y += 30;
                gfx.DrawString("City of Caloocan", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);
                y += 40;
                gfx.DrawString("OFFICE OF THE BARANGAY CAPTAIN", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);
                y += 40;
                gfx.DrawString("BARANGAY BUSINESS PERMIT", boldFont, XBrushes.Black, new XRect(0, y, page.Width.Point, 0), XStringFormats.TopCenter);

                y += 30;
                gfx.DrawLine(XPens.Black, left, y, page.Width.Point - right, y);
                y += 40;

                // TO WHOM IT MAY CONCERN
                gfx.DrawString("TO WHOM IT MAY CONCERN:", defaultFont, XBrushes.Black, left, y);
                y += 35;

                string paragraph1 = $"This is to certify that {fullName}, of legal age, ";
                y = DrawText(gfx, paragraph1, defaultFont, left, y, maxWidth);

                y += 30;

                string paragraph2 = "     a resident of Barangay 176-B Caloocan City, owns a business that is located at Caloocan City.";
                y = DrawText(gfx, paragraph2, defaultFont, left, y, maxWidth);

                y += 30;

                string paragraph3 = "This certificate is issued for the purpose of securing or renewing the business permit with ";
                y = DrawText(gfx, paragraph3, defaultFont, left, y, maxWidth);

                y += 30;

                string paragraph4 = "     the appropriate government agencies.";
                y = DrawText(gfx, paragraph4, defaultFont, left, y, maxWidth);

                // Footer
                y += 350;
                gfx.DrawString($"Date Issued: {dateEndorsed}", defaultFont, XBrushes.Black, left, y);
                gfx.DrawString("JOEL B. LLORCA", defaultFont, XBrushes.Black, page.Width.Point - right - 150, y);
                y += 35;
                gfx.DrawString("Barangay Captain", defaultFont, XBrushes.Black, page.Width.Point - right - 150, y);

                // Save PDF document
                document.Save(pdfPath);

                MessageBox.Show($"Barangay Business Permit generated at: {pdfPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating the PDF: {ex.Message}");
            }
        }

        private int DrawText(XGraphics gfx, string text, XFont font, int x, int y, int maxWidth)
        {
            // Adjust line height (manually)
            double lineHeight = font.GetHeight() * 1.2;  // GetHeight() with no parameter, adjusted line height

            XTextFormatter tf = new XTextFormatter(gfx);
            tf.DrawString(text, font, XBrushes.Black, new XRect(x, y, maxWidth, 0), XStringFormats.TopLeft);

            return y + (int)lineHeight;  // Return the next y position after the text
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();

                this.Close();
            }
        }
    }
}
