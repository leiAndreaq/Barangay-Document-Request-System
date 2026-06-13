using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace brgy_system
{
    public partial class RegisterRoleUserAccount : Form
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True";

        public RegisterRoleUserAccount()
        {
            InitializeComponent();
            LoadRoleData();
        }

        private void LoadRoleData()
        {
            cbRole.Items.Clear();
            cbRole.Items.Add("Staff");
            cbRole.Items.Add("Purok Leader");
            cbRole.SelectedIndex = 0;
            txtFullName.Text = string.Empty;
        }

        private void LoadUserData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "";
                    if (cbRole.SelectedItem.ToString() == "Staff")
                    {
                        query = "SELECT TOP 1 FirstName, MiddleName, LastName FROM Staff ORDER BY StaffID DESC"; // Get the last inserted staff
                    }
                    else if (cbRole.SelectedItem.ToString() == "Purok Leader")
                    {
                        query = "SELECT TOP 1 FirstName, MiddleName, LastName FROM PurokLeaders ORDER BY PurokLeaderID DESC"; // Get the last inserted Purok Leader
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string firstName = reader["FirstName"] == DBNull.Value ? "" : reader["FirstName"].ToString();
                        string middleName = reader["MiddleName"] == DBNull.Value ? "" : reader["MiddleName"].ToString();
                        string lastName = reader["LastName"] == DBNull.Value ? "" : reader["LastName"].ToString();

                        string fullName = $"{firstName} {middleName} {lastName}".Trim();
                        txtFullName.Text = fullName;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user data: " + ex.Message);
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    string role = cbRole.SelectedItem.ToString();
                    string fullName = txtFullName.Text;

                    // Check if the username is unique before inserting into the database
                    if (IsUsernameUnique(username))
                    {
                        // Check if the password length is valid
                        if (password.Length >= 6)
                        {
                            InsertUserAccountIntoDatabase(username, password, role, fullName);
                        }
                        else
                        {
                            MessageBox.Show("Password must be at least 6 characters long.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user account: " + ex.Message);
            }
        }

        // Validate that the username is unique
        private bool IsUsernameUnique(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int userCount = (int)cmd.ExecuteScalar();
                    return userCount == 0; // If count is 0, the username is unique
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking username uniqueness: " + ex.Message);
                    return false;
                }
            }
        }

        private bool ValidateFields()
        {
            // Validate fields (ensure the user is filling all necessary fields)
            return !string.IsNullOrEmpty(txtUsername.Text) &&
                   !string.IsNullOrEmpty(txtPassword.Text) &&
                   cbRole.SelectedItem != null && cbRole.SelectedItem.ToString() != "None";
        }

        private void InsertUserAccountIntoDatabase(string username, string password, string role, string fullName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, Password, Role, FullName) VALUES (@Username, @Password, @Role, @FullName)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@FullName", fullName);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User account created successfully!");

                    LoadUserData();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating user account: " + ex.Message);
                }
            }
        }

        private void RegisterRoleUserAccount_Load(object sender, EventArgs e)
        {
            cbRole.SelectedIndexChanged += (sender, e) => LoadUserData();
        }
    }
}
