using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class AccountsForm : Form
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";

        public AccountsForm()
        {
            InitializeComponent();
            LoadUserAccounts();
        }

        // Method to load user accounts into the DataGridView
        // Method to load user accounts into the DataGridView
        private void LoadUserAccounts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, Username, FullName, Role, Password FROM Users"; // Include Password in the query
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAccount.DataSource = dt; // Binding the DataTable to the DataGridView

                    // Set up DataGridView column headers
                    dgvAccount.Columns["UserID"].HeaderText = "User ID";
                    dgvAccount.Columns["Username"].HeaderText = "Username";
                    dgvAccount.Columns["FullName"].HeaderText = "Full Name";
                    dgvAccount.Columns["Role"].HeaderText = "Role";
                    dgvAccount.Columns["Password"].HeaderText = "Password";  // Optional: You can display this column, but hide it in the UI

                    // Apply styling to DataGridView (same as in StaffUserControl)
                    dgvAccount.EnableHeadersVisualStyles = false;
                    dgvAccount.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
                    dgvAccount.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvAccount.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAccount.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

                    dgvAccount.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvAccount.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvAccount.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
                    dgvAccount.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                    dgvAccount.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

                    dgvAccount.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgvAccount.GridColor = System.Drawing.Color.FromArgb(211, 211, 211);

                    dgvAccount.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
                    dgvAccount.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                    dgvAccount.BackgroundColor = System.Drawing.Color.FromArgb(233, 234, 244);

                    // Add a button column for Edit
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true, // Display text on the button
                        FlatStyle = FlatStyle.Flat
                    };

                    if (!dgvAccount.Columns.Contains("Edit"))
                    {
                        dgvAccount.Columns.Add(editButtonColumn); // Add the button column to the DataGridView
                    }

                    // Automatically fill remaining space for all columns except the button column
                    foreach (DataGridViewColumn column in dgvAccount.Columns)
                    {
                        if (column.Name != "Edit")
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Fill the space for columns
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user accounts: " + ex.Message);
                }
            }
        }


        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the Edit button column (last column)
            if (e.ColumnIndex == dgvAccount.Columns["Edit"].Index)
            {
                // Get the UserID and other data from the selected row
                int userID = Convert.ToInt32(dgvAccount.Rows[e.RowIndex].Cells["UserID"].Value);
                string username = dgvAccount.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                string fullName = dgvAccount.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                string role = dgvAccount.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                string password = dgvAccount.Rows[e.RowIndex].Cells["Password"].Value.ToString();  // Get the password

                // Open the EditUserForm with the selected user's data, including the password
                EditUserForm editForm = new EditUserForm(userID, username, fullName, role, password);
                editForm.ShowDialog(); // Show the Edit form

                // After editing, reload the user accounts
                LoadUserAccounts();
            }
        }

        // Form load event
        private void AccountsForm_Load(object sender, EventArgs e)
        {
            // Load user accounts when the form is loaded
            LoadUserAccounts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
