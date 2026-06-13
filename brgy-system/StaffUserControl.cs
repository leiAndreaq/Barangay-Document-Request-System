using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class StaffUserControl : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";
        private int selectedStaffID = -1;

        public StaffUserControl()
        {
            InitializeComponent();
            InitializeButtonPanel();
            InitializePanel();
            LoadStaffData();
        }

        private void InitializePanel()
        {
            // Top panel for title label and search bar
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,  // Increased height to fit the new button below search
                BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b"),
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // TableLayoutPanel for title label, search bar, and the new "Show Accounts" button
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2, // Title and Search Bar
                RowCount = 2, // Title + Search bar + New Button
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F)); // Title
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // Search bar and new button

            // Title label
            Label titleLabel = new Label
            {
                Text = "Staff Management".ToUpper(),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 10, 10, 10)
            };

            // Search bar
            TextBox searchTextBox = new TextBox
            {
                Width = 640,
                Height = 30,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                PlaceholderText = "Search by name...",
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };

            searchTextBox.Anchor = AnchorStyles.None; // Center the search box vertically
            searchTextBox.TextChanged += SearchTextBox_TextChanged;

            // "Show Accounts" Button
            Button btnShowAccounts = new Button
            {
                Text = "Show Accounts",
                Width = 120,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(46, 204, 113),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(5)
            };
            btnShowAccounts.Click += btnShowAccounts_Click;

            // Add title label and search bar to the TableLayoutPanel
            tableLayoutPanel.Controls.Add(titleLabel, 0, 0); // Title in first row
            tableLayoutPanel.Controls.Add(searchTextBox, 1, 0); // Search bar in first row
            tableLayoutPanel.Controls.Add(btnShowAccounts, 1, 1); // Show Accounts button in second row

            // Add TableLayoutPanel to top panel
            topPanel.Controls.Add(tableLayoutPanel);

            // Add top panel to the user control
            this.Controls.Add(topPanel);
        }

        private void InitializeButtonPanel()
        {
            // Use FlowLayoutPanel for automatic button layout
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(0), // Remove padding to eliminate extra space
                Margin = new Padding(0),  // Remove margin to avoid unnecessary space
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1e3a58"),
                FlowDirection = FlowDirection.LeftToRight, // Align buttons horizontally
                WrapContents = false // Prevent buttons from wrapping to the next line
            };

            Button btnAddStaff = new Button
            {
                Text = "Add Staff",
                Width = 120,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(10)
            };
            btnAddStaff.Click += btnAddStaff_Click;

            Button btnEdit = new Button
            {
                Text = "Edit Staff",
                Width = 120,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(241, 196, 15),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(10)
            };
            btnEdit.Click += btnEdit_Click;

            Button btnDelete = new Button
            {
                Text = "Delete Staff",
                Width = 120,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(231, 76, 60),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(10)
            };
            btnDelete.Click += btnDelete_Click_1;

            // Add buttons to the FlowLayoutPanel
            buttonPanel.Controls.Add(btnAddStaff);
            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnDelete);

            // Add buttonPanel to the user control
            this.Controls.Add(buttonPanel);
        }

        private void LoadStaffData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT StaffID, FirstName, MiddleName, LastName, Gender, Age, PurokNumber, Phase, Package, Block, CivilStatus, Religion, ContactNumber FROM Staff";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvStaff.DataSource = dt;

                    // Rename the ContactNumber column to "Contacts"
                    dgvStaff.Columns["ContactNumber"].HeaderText = "Contacts";

                    dgvStaff.EnableHeadersVisualStyles = false;
                    dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
                    dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvStaff.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvStaff.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

                    dgvStaff.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvStaff.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvStaff.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
                    dgvStaff.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                    dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

                    dgvStaff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgvStaff.GridColor = System.Drawing.Color.FromArgb(211, 211, 211);

                    dgvStaff.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
                    dgvStaff.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                    dgvStaff.BackgroundColor = System.Drawing.Color.FromArgb(233, 234, 244);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading staff data: " + ex.Message);
                }
            }
        }

        // Event handler for the Show Accounts button
        private void btnShowAccounts_Click(object sender, EventArgs e)
        {
            // Open the new user control form for accounts
            AccountsForm accountsForm = new AccountsForm();
            accountsForm.ShowDialog(); // Show the user control for accounts

            // You may want to hide or disable buttons on the current user control
            this.Hide();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            // Code to add staff (show create staff form)
            CreateStaffForm createStaffForm = new CreateStaffForm();
            createStaffForm.ShowDialog();
            LoadStaffData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the Staff ID to edit", "Edit Staff", "", -1, -1);
            int staffID;
            if (int.TryParse(input, out staffID) && staffID > 0)
            {
                // Check if the ID exists in the database
                if (IsStaffIDValid(staffID))
                {
                    EditStaffForm editForm = new EditStaffForm(staffID, LoadStaffData);
                    editForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Staff ID is not valid or has been deleted. Please enter a valid ID.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Staff ID. Please enter a valid ID.");
            }
        }

        // Method to check if the staff ID exists in the database
        private bool IsStaffIDValid(int staffID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Staff WHERE StaffID = @StaffID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StaffID", staffID);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // If count is greater than 0, the staff ID exists
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking Staff ID: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
            {
                int staffID = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["StaffID"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to delete staff with ID {staffID}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteStaff(staffID);
                }
            }
            else
            {
                MessageBox.Show("Please select a staff member to delete.");
            }
        }

        private void DeleteStaff(int staffID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Staff WHERE StaffID = @StaffID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StaffID", staffID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Staff with ID {staffID} deleted successfully.");

                    LoadStaffData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting staff: {ex.Message}");
                }
            }
        }

        // Search event handler to filter rows
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = ((TextBox)sender).Text.ToLower();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var filteredRows = dgvStaff.DataSource as DataTable;

                var filteredRowsResult = filteredRows.AsEnumerable()
                    .Where(row => row.Field<string>("FirstName").ToLower().Contains(searchQuery) ||
                                  row.Field<string>("MiddleName").ToLower().Contains(searchQuery) ||
                                  row.Field<string>("LastName").ToLower().Contains(searchQuery))
                    .ToList();

                DataTable filteredTable = filteredRowsResult.Any() ? filteredRowsResult.CopyToDataTable() : filteredRows.Clone();
                dgvStaff.DataSource = filteredTable;
            }
            else
            {
                LoadStaffData();
            }
        }
    }
}
