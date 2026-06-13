using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class EditUserForm : Form
    {
        private int userID;
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";

        // Constructor to initialize form with existing user data
        public EditUserForm(int userID, string username, string fullName, string role, string password)
        {
            InitializeComponent();
            this.userID = userID;

            // Prefill the form fields with the selected user data
            txtUsername.Text = username;
            txtFullName.Text = fullName;
            cmbRole.Text = role;
            txtPassword.Text = password; // You can leave this empty if password is not changed
            txtPassword.UseSystemPasswordChar = true; // Mask the password

            // Connect the KeyPress event handlers
            txtUsername.KeyPress += new KeyPressEventHandler(txtUsername_KeyPress);
            txtFullName.KeyPress += new KeyPressEventHandler(txtFullName_KeyPress);
            cmbRole.KeyPress += new KeyPressEventHandler(cmbRole_KeyPress);
        }

        // Save button click event to update user data
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs before saving
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(cmbRole.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Validate password length
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            // Check if the username is already taken
            if (IsUsernameTaken(txtUsername.Text))
            {
                MessageBox.Show("Username already exists. Please choose a different one.");
                return;
            }

            // Get the new password, if provided
            string password = string.IsNullOrEmpty(txtPassword.Text) ? null : txtPassword.Text;

            // Update the user in the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Prepare the update query for the user
                    string query = "UPDATE Users SET Username = @Username, FullName = @FullName, Password = @Password, Role = @Role WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Password", password);  // Only update password if provided
                    cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("User information updated successfully!");
                        this.Close(); // Close the Edit form after saving
                    }
                    else
                    {
                        MessageBox.Show("Error updating user information.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Validate username uniqueness (check in the database)
        private bool IsUsernameTaken(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND UserID != @UserID"; // Exclude current user from check
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@UserID", userID); // Avoid checking for the current user

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // If count > 0, then the username is taken
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // KeyPress event for validations
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only alphabets and numbers for the username
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Block invalid input
            }
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only alphabets and spaces for the full name (no numbers or special characters)
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true; // Block invalid input
            }
        }

        private void cmbRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent users from typing into the ComboBox
            e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
