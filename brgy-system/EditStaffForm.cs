using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace brgy_system
{
    public partial class EditStaffForm : Form
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True";
        private int staffID;
        private Action refreshStaffDataCallback;

        public EditStaffForm(int staffID, Action refreshCallback)
        {
            InitializeComponent();
            this.staffID = staffID;
            this.refreshStaffDataCallback = refreshCallback;
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Staff WHERE StaffID = @StaffID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StaffID", staffID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtMiddleName.Text = reader["MiddleName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        cbGender.SelectedItem = reader["Gender"].ToString();
                        numAge.Value = Convert.ToInt32(reader["Age"]);
                        txtContactNumber.Text = reader["ContactNumber"].ToString();
                        txtPurokNumber.Text = reader["PurokNumber"].ToString();
                        txtPhase.Text = reader["Phase"].ToString();
                        txtPackage.Text = reader["Package"].ToString();
                        txtBlock.Text = reader["Block"].ToString();
                        cbCivilStatus.SelectedItem = reader["CivilStatus"].ToString(); // Use ComboBox for Civil Status
                        cbReligion.SelectedItem = reader["Religion"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading staff data: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                string firstName = txtFirstName.Text;
                string middleName = txtMiddleName.Text;
                string lastName = txtLastName.Text;
                string gender = cbGender.SelectedItem.ToString();
                int age = (int)numAge.Value;
                string contactNumber = txtContactNumber.Text;
                string purokNumber = txtPurokNumber.Text;
                string phase = txtPhase.Text;
                string package = txtPackage.Text;
                string block = txtBlock.Text;
                string civilStatus = cbCivilStatus.SelectedItem.ToString(); // Use ComboBox for Civil Status
                string religion = cbReligion.SelectedItem.ToString();

                // Check if "Others" is selected in cbReligion and validate txtReligion
                if (cbReligion.SelectedItem.ToString() == "Others" && string.IsNullOrEmpty(txtReligion.Text))
                {
                    MessageBox.Show("Please specify the Religion when 'Others' is selected.");
                    return; // Exit if religion is not provided
                }

                // Proceed with updating staff data
                UpdateStaffInDatabase(firstName, middleName, lastName, gender, age, contactNumber, purokNumber, phase, package, block, civilStatus, religion);
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private bool ValidateFields()
        {
            // Validate that no required field is empty and that fields have proper values
            if (string.IsNullOrEmpty(txtFirstName.Text) || !ValidateName(txtFirstName.Text))
            {
                MessageBox.Show("First Name must contain at least 3 letters and no special characters.");
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text) || !ValidateName(txtLastName.Text))
            {
                MessageBox.Show("Last Name must contain at least 3 letters and no special characters.");
                return false;
            }

            if (cbGender.SelectedItem == null)
            {
                MessageBox.Show("Please select a Gender.");
                return false;
            }

            if (numAge.Value <= 0 || numAge.Value > 100)
            {
                MessageBox.Show("Age must be between 1 and 100.");
                return false;
            }

            if (!ValidateContactNumber(txtContactNumber.Text))
            {
                MessageBox.Show("Contact Number must be 11 digits with no characters or special characters.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPurokNumber.Text) || !ValidateTextField(txtPurokNumber.Text))
            {
                MessageBox.Show("Purok Number must not contain special characters.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPhase.Text) || !ValidateTextField(txtPhase.Text))
            {
                MessageBox.Show("Phase must not contain special characters.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPackage.Text) || !ValidateTextField(txtPackage.Text))
            {
                MessageBox.Show("Package must not contain special characters.");
                return false;
            }

            if (string.IsNullOrEmpty(txtBlock.Text) || !ValidateTextField(txtBlock.Text))
            {
                MessageBox.Show("Block must not contain special characters.");
                return false;
            }

            if (cbCivilStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a Civil Status.");
                return false;
            }

            if (cbReligion.SelectedItem == null)
            {
                MessageBox.Show("Please select a Religion.");
                return false;
            }

            return true;
        }

        private bool ValidateName(string name)
        {
            // Check if the name contains at least 3 letters and no special characters
            return !string.IsNullOrEmpty(name) && name.Length >= 3 && Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool ValidateContactNumber(string contactNumber)
        {
            // Validate that the contact number contains exactly 11 digits
            return Regex.IsMatch(contactNumber, @"^\d{11}$");
        }

        private bool ValidateTextField(string text)
        {
            // Ensure no special characters are included
            return Regex.IsMatch(text, @"^[a-zA-Z0-9\s]+$");
        }

        private void UpdateStaffInDatabase(string firstName, string middleName, string lastName, string gender, int age, string contactNumber, string purokNumber, string phase, string package, string block, string civilStatus, string religion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Staff SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                                   "Gender = @Gender, Age = @Age, ContactNumber = @ContactNumber, PurokNumber = @PurokNumber, Phase = @Phase, " +
                                   "Package = @Package, Block = @Block, CivilStatus = @CivilStatus, Religion = @Religion WHERE StaffID = @StaffID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                    cmd.Parameters.AddWithValue("@PurokNumber", purokNumber);
                    cmd.Parameters.AddWithValue("@Phase", phase);
                    cmd.Parameters.AddWithValue("@Package", package);
                    cmd.Parameters.AddWithValue("@Block", block);
                    cmd.Parameters.AddWithValue("@CivilStatus", civilStatus);
                    cmd.Parameters.AddWithValue("@Religion", religion);
                    cmd.Parameters.AddWithValue("@StaffID", staffID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Staff updated successfully!");

                    refreshStaffDataCallback(); // Refresh staff data after successful update

                    this.Close(); // Close the form after updating
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating staff: " + ex.Message);
                }
            }
        }
    }
}
