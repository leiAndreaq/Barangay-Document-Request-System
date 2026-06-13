using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class ResidentsUserControl : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";
        private DataTable residentsDataTable;

        public ResidentsUserControl()
        {
            InitializeComponent();
            InitializePanel();
            LoadResidentData();
        }

        private void InitializePanel()
        {
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b"),
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            Label titleLabel = new Label
            {
                Text = "Resident's Record".ToUpper(),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                Margin = new Padding(5, 0, 0, 0)
            };

            TextBox searchTextBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                PlaceholderText = "Search by name...",
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(15),
                Padding = new Padding(0)
            };

            searchTextBox.TextChanged += SearchTextBox_TextChanged;

            tableLayoutPanel.Controls.Add(titleLabel, 0, 0);
            tableLayoutPanel.Controls.Add(searchTextBox, 1, 0);

            topPanel.Controls.Add(tableLayoutPanel);
            this.Controls.Add(topPanel);

            // Add a column for the "Download" button in the DataGridView if not already added
            if (!dgvResidents.Columns.Contains("Download"))
            {
                DataGridViewButtonColumn downloadButton = new DataGridViewButtonColumn();
                downloadButton.Name = "Download";  // Ensure this name matches the event handler
                downloadButton.HeaderText = "QR Code";
                downloadButton.Text = "Download QR";
                downloadButton.UseColumnTextForButtonValue = true;

                // Adding button with default design
                dgvResidents.Columns.Add(downloadButton);
            }

            // Adjust the width of the "Download" button column
            dgvResidents.Columns["Download"].Width = 150;  // Set width to 150 for better visibility

            // Default DataGridView Styling without any extra design
            dgvResidents.EnableHeadersVisualStyles = true;
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

            foreach (DataGridViewColumn column in dgvResidents.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvResidents.AllowUserToResizeColumns = true;
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

                    // Add a column for the "Download" button in the DataGridView if not already added
                    if (!dgvResidents.Columns.Contains("Download"))
                    {
                        DataGridViewButtonColumn downloadButton = new DataGridViewButtonColumn();
                        downloadButton.Name = "Download";  // Ensure this name matches the event handler
                        downloadButton.HeaderText = "QR Code";
                        downloadButton.Text = "Download";
                        downloadButton.UseColumnTextForButtonValue = true;
                        dgvResidents.Columns.Add(downloadButton);  // Add button in the last column
                    }


                    // Additional DataGridView styling here...
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

                    foreach (DataGridViewColumn column in dgvResidents.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    dgvResidents.AllowUserToResizeColumns = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading residents: " + ex.Message);
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = ((TextBox)sender).Text.ToLower();

            if (!System.Text.RegularExpressions.Regex.IsMatch(searchQuery, @"^[a-z\s]*$"))
            {
                dgvResidents.DataSource = residentsDataTable.Clone();
                return;
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var filteredRows = residentsDataTable.AsEnumerable()
                    .Where(row => row.Field<string>("First_Name").ToLower().Contains(searchQuery) ||
                                  row.Field<string>("Middle_Name").ToLower().Contains(searchQuery) ||
                                  row.Field<string>("Last_Name").ToLower().Contains(searchQuery))
                    .ToList();

                DataTable filteredTable = filteredRows.Any() ? filteredRows.CopyToDataTable() : residentsDataTable.Clone();
                dgvResidents.DataSource = filteredTable;
            }
            else
            {
                dgvResidents.DataSource = residentsDataTable;
            }
        }

        private void dgvResidents_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a button in the "Download" column
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvResidents.Columns["Download"].Index)
            {
                // Get the ResidentID from the current row
                int residentId = Convert.ToInt32(dgvResidents.Rows[e.RowIndex].Cells["ID"].Value);

                // Call the function to download the QR code
                DownloadQRCode(residentId);
            }
        }

        private void DownloadQRCode(int residentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT FirstName, MiddleName, LastName, QRCode FROM Residents WHERE ResidentID = @ResidentID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResidentID", residentId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the Resident's Full Name
                                string firstName = reader["FirstName"].ToString();
                                string middleName = reader["MiddleName"].ToString();
                                string lastName = reader["LastName"].ToString();

                                // Create the full name (e.g., "John Doe")
                                string fullName = $"{firstName} {middleName} {lastName}";

                                // Retrieve the QR Code as binary data
                                byte[] qrCodeData = reader["QRCode"] as byte[];

                                if (qrCodeData != null && qrCodeData.Length > 0)
                                {
                                    // Convert binary data to an image
                                    using (MemoryStream ms = new MemoryStream(qrCodeData))
                                    {
                                        var qrImage = Image.FromStream(ms);

                                        // Construct the file name for the QR code: "[FullName_QR.png]"
                                        string fileName = $"{fullName.Replace(" ", "_")}_QR.png"; // Replace spaces with underscores
                                        string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                                        string destinationPath = Path.Combine(downloadsFolder, fileName);

                                        // Save the image to the Downloads folder
                                        qrImage.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Png);

                                        MessageBox.Show("QR Code downloaded successfully!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("QR Code not found.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Resident not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Display more detailed error messages
                    MessageBox.Show($"Error downloading QR Code: {ex.Message}");
                }
            }
        }


    }
}