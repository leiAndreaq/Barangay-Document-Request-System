using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class ServiceRequestUserControl : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";

        public ServiceRequestUserControl()
        {
            InitializeComponent();
            InitializePanel();
            LoadServiceRequestData();
        }

        private void InitializePanel()
        {
            // Top panel for title label, DatePicker, and Search bar
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 140, // Increased height to accommodate proper spacing for search bar
                BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b"),
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // TableLayoutPanel to align title label, DatePicker, and Search bar vertically
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1, // Only one column, all elements will be stacked vertically
                RowCount = 3,   // Three rows: title, DatePicker, and search bar
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // Row styles for proper distribution
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F)); // Title takes 40% of the space
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F)); // DatePicker takes 30% of the space
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F)); // Search bar takes 30% of the space

            // Title label with bottom padding to create space
            Label titleLabel = new Label
            {
                Text = "Service Requests Records".ToUpper(),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 5, 10, 5) // Reduced padding for better alignment
            };

            // DatePicker for filtering by date
            DateTimePicker datePicker = new DateTimePicker
            {
                Width = 200,
                Height = 30,
                Format = DateTimePickerFormat.Short,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                Margin = new Padding(5)
            };

            datePicker.ValueChanged += DatePicker_ValueChanged; // Event handler to filter by date

            // Search bar for filtering by Resident Name
            TextBox searchBar = new TextBox
            {
                Width = 200,
                Height = 30,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                PlaceholderText = "Search by Name...",
                Margin = new Padding(5)
            };

            searchBar.TextChanged += SearchBar_TextChanged; // Event handler for search bar text change

            // Add title label, DatePicker, and search bar to the TableLayoutPanel
            tableLayoutPanel.Controls.Add(titleLabel, 0, 0); // Title in the first row
            tableLayoutPanel.Controls.Add(datePicker, 0, 1); // DatePicker in the second row
            tableLayoutPanel.Controls.Add(searchBar, 0, 2); // Search bar in the third row

            // Add TableLayoutPanel to top panel
            topPanel.Controls.Add(tableLayoutPanel);

            // Add top panel to the user control
            this.Controls.Add(topPanel);
        }

        private void LoadServiceRequestData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            e.EndorsementID,
                            r.FirstName + ' ' + r.MiddleName + ' ' + r.LastName AS ResidentName,
                            e.DateEndorsed,
                            e.EndorsementType
                        FROM 
                            Endorsements e
                            JOIN Residents r ON e.ResidentID = r.ResidentID
                        ORDER BY e.DateEndorsed DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvServiceRequests.DataSource = dt;

                    dgvServiceRequests.EnableHeadersVisualStyles = false;
                    dgvServiceRequests.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
                    dgvServiceRequests.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvServiceRequests.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvServiceRequests.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

                    dgvServiceRequests.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvServiceRequests.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvServiceRequests.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
                    dgvServiceRequests.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                    dgvServiceRequests.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

                    dgvServiceRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgvServiceRequests.GridColor = System.Drawing.Color.FromArgb(211, 211, 211);

                    dgvServiceRequests.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
                    dgvServiceRequests.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                    dgvServiceRequests.BackgroundColor = System.Drawing.Color.FromArgb(233, 234, 244);

                    // Add column for EndorsementType (Document Requested)
                    dgvServiceRequests.Columns["EndorsementType"].HeaderText = "Document Requested";

                    foreach (DataGridViewColumn column in dgvServiceRequests.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    dgvServiceRequests.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading service request records: " + ex.Message);
                }
            }
        }

        // Event handler for DatePicker change to filter data by selected date
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = ((DateTimePicker)sender).Value.Date;
            FilterServiceRequestsByDate(selectedDate);
        }

        // Method to filter data by the selected date
        private void FilterServiceRequestsByDate(DateTime selectedDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            e.EndorsementID,
                            r.FirstName + ' ' + r.MiddleName + ' ' + r.LastName AS ResidentName,
                            e.DateEndorsed,
                            e.EndorsementType
                        FROM 
                            Endorsements e
                            JOIN Residents r ON e.ResidentID = r.ResidentID
                        WHERE 
                            CONVERT(DATE, e.DateEndorsed) = @SelectedDate
                        ORDER BY e.DateEndorsed DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvServiceRequests.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering service request records: " + ex.Message);
                }
            }
        }

        // Event handler for search bar to filter service requests by name
        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = ((TextBox)sender).Text.ToLower();

            if (!string.IsNullOrEmpty(searchText) && searchText.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)))
            {
                // If the input is valid (letters or spaces), filter the data
                FilterServiceRequestsByName(searchText);
            }
            else if (string.IsNullOrEmpty(searchText))
            {
                // If the input is empty, reload all data
                LoadServiceRequestData();
            }
            else
            {
                // If invalid characters are typed (numbers or special chars), clear the table
                dgvServiceRequests.DataSource = null;
            }
        }

        // Method to filter data by the search input for Resident Name
        private void FilterServiceRequestsByName(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            e.EndorsementID,
                            r.FirstName + ' ' + r.MiddleName + ' ' + r.LastName AS ResidentName,
                            e.DateEndorsed,
                            e.EndorsementType
                        FROM 
                            Endorsements e
                            JOIN Residents r ON e.ResidentID = r.ResidentID
                        WHERE 
                            (r.FirstName + ' ' + r.MiddleName + ' ' + r.LastName) LIKE @SearchText
                        ORDER BY e.DateEndorsed DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvServiceRequests.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering service request records: " + ex.Message);
                }
            }
        }
    }
}
