using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";

        public static string loggedInPurokLeaderFullName;
        public static int loggedInPurokLeaderID;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            AuthenticateUser(username, password);
        }

        private void AuthenticateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Role, UserID FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            string role = reader["Role"].ToString();
                            int userID = Convert.ToInt32(reader["UserID"]);

                            NavigateToDashboard(role);
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void NavigateToDashboard(string role)
        {
            switch (role)
            {
                case "Admin":
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                    this.Hide();
                    break;

                case "Staff":
                    StaffDashboard staffDashboard = new StaffDashboard();
                    staffDashboard.Show();
                    this.Hide();
                    break;

                case "Purok Leader":
                    PurokLeaderDashboard purokDashboard = new PurokLeaderDashboard();
                    purokDashboard.Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("Role not recognized.");
                    break;
            }
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;  // Disable password masking
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;   // Enable password masking
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
