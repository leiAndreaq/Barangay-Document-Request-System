using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class PurokLeaderUserControl : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";

        public PurokLeaderUserControl()
        {
            InitializeComponent();
            InitializeButtonPanel();
            InitializePanel();
            LoadPurokLeaderData();
        }

        // Method to check if the Purok Leader ID exists in the database
        private bool IsPurokLeaderIDValid(int purokLeaderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM PurokLeaders WHERE PurokLeaderID = @PurokLeaderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PurokLeaderID", purokLeaderID);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // If count is greater than 0, the Purok Leader ID exists
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking Purok Leader ID: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnEditPurok_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the Purok Leader ID to edit", "Edit Purok Leader", "", -1, -1);
            int purokLeaderID;

            if (int.TryParse(input, out purokLeaderID) && purokLeaderID > 0)
            {
                // Check if the Purok Leader ID exists in the database
                if (IsPurokLeaderIDValid(purokLeaderID))
                {
                    EditPurokLeaderForm editForm = new EditPurokLeaderForm(purokLeaderID, LoadPurokLeaderData);
                    editForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Purok Leader ID is not valid or has been deleted. Please enter a valid ID.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Purok Leader ID. Please enter a valid ID.");
            }
        }

        private void InitializePanel()
        {
            // Top panel for title label and search bar
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b"),
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // TableLayoutPanel for title label and search bar
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2, // Title and Search Bar
                RowCount = 1,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F)); // Title
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // Search bar

            // Title label
            Label titleLabel = new Label
            {
                Text = "Purok Leader's Information".ToUpper(),
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

            // Add title label and search bar to the TableLayoutPanel
            tableLayoutPanel.Controls.Add(titleLabel, 0, 0); // Title in first column
            tableLayoutPanel.Controls.Add(searchTextBox, 1, 0); // Search bar in second column

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

            Button btnAddPurok = new Button
            {
                Text = "Add Purok Leader",
                Width = 150,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(10)
            };
            btnAddPurok.Click += btnAddPurok_Click;

            Button btnEditPurok = new Button
            {
                Text = "Edit Purok Leader",
                Width = 150,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(241, 196, 15),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(10)
            };
            btnEditPurok.Click += btnEditPurok_Click;

            Button btnDeletePurok = new Button
            {
                Text = "Delete Purok Leader",
                Width = 150,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(231, 76, 60),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(10)
            };
            btnDeletePurok.Click += btnDeletePurok_Click;

            buttonPanel.Controls.Add(btnAddPurok);
            buttonPanel.Controls.Add(btnEditPurok);
            buttonPanel.Controls.Add(btnDeletePurok);

            // Add buttonPanel to the user control
            this.Controls.Add(buttonPanel);
        }

        private void LoadPurokLeaderData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PurokLeaderID, FirstName, MiddleName, LastName, Gender, Age, ContactNumber, PurokNumber, Phase, Package, Block, CivilStatus, Religion FROM PurokLeaders";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPurokLeaders.DataSource = dt;

                    // Optionally rename the column header to "Contacts"
                    dgvPurokLeaders.Columns["ContactNumber"].HeaderText = "Contacts";  // Rename header to "Contacts"

                    dgvPurokLeaders.EnableHeadersVisualStyles = false;
                    dgvPurokLeaders.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
                    dgvPurokLeaders.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvPurokLeaders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPurokLeaders.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

                    dgvPurokLeaders.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvPurokLeaders.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvPurokLeaders.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
                    dgvPurokLeaders.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                    dgvPurokLeaders.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

                    dgvPurokLeaders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgvPurokLeaders.GridColor = System.Drawing.Color.FromArgb(211, 211, 211);

                    dgvPurokLeaders.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
                    dgvPurokLeaders.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                    dgvPurokLeaders.BackgroundColor = System.Drawing.Color.FromArgb(233, 234, 244);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Purok Leaders: " + ex.Message);
                }
            }
        }

        private void btnAddPurok_Click(object sender, EventArgs e)
        {
            CreatePurokForm createPurokForm = new CreatePurokForm();
            createPurokForm.ShowDialog();
            LoadPurokLeaderData();
        }

        private void btnEditPurok_Click_1(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the Purok Leader ID to edit", "Edit Purok Leader", "", -1, -1);
            int purokLeaderID;

            if (int.TryParse(input, out purokLeaderID) && purokLeaderID > 0)
            {
                EditPurokLeaderForm editForm = new EditPurokLeaderForm(purokLeaderID, LoadPurokLeaderData);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Purok Leader ID. Please enter a valid ID.");
            }
        }

        private void btnDeletePurok_Click(object sender, EventArgs e)
        {
            if (dgvPurokLeaders.SelectedRows.Count > 0)
            {
                int PurokLeaderID = Convert.ToInt32(dgvPurokLeaders.SelectedRows[0].Cells["PurokLeaderID"].Value);
                DialogResult result = MessageBox.Show($"Are you sure you want to delete Purok Leader with ID {PurokLeaderID}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeletePurokLeader(PurokLeaderID);
                }
            }
            else
            {
                MessageBox.Show("Please select a Purok Leader to delete.");
            }
        }

        private void DeletePurokLeader(int PurokLeaderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM PurokLeaders WHERE PurokLeaderID = @PurokLeaderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PurokLeaderID", PurokLeaderID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Purok Leader with ID {PurokLeaderID} deleted successfully.");

                    LoadPurokLeaderData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting Purok Leader: {ex.Message}");
                }
            }
        }

        // Search event handler to filter rows
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = ((TextBox)sender).Text.ToLower();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var filteredRows = dgvPurokLeaders.DataSource as DataTable;

                var filteredRowsResult = filteredRows.AsEnumerable()
                    .Where(row => row.Field<string>("FirstName").ToLower().Contains(searchQuery) ||
                                  row.Field<string>("MiddleName").ToLower().Contains(searchQuery) ||
                                  row.Field<string>("LastName").ToLower().Contains(searchQuery))
                    .ToList();

                DataTable filteredTable = filteredRowsResult.Any() ? filteredRowsResult.CopyToDataTable() : filteredRows.Clone();
                dgvPurokLeaders.DataSource = filteredTable;
            }
            else
            {
                LoadPurokLeaderData();
            }
        }
    }
}
