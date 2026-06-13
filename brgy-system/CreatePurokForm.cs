using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace brgy_system
{
    public partial class CreatePurokForm : Form
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True";

        public CreatePurokForm()
        {
            InitializeComponent();
        }

        // Helper method to capitalize the first letter of each word
        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Capitalizes the first letter of each word
            var words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }

            return string.Join(" ", words);
        }

        // Validation methods
        private bool ValidateFields()
        {
            // Validate FirstName and LastName (no numbers, special chars, 3+ letters)
            if (!ValidateName(txtFirstName.Text) || !ValidateName(txtLastName.Text))
            {
                MessageBox.Show("First Name and Last Name must contain at least 3 letters, no numbers or special characters.");
                return false;
            }

            // Validate MiddleName (optional, only validated if filled)
            if (!string.IsNullOrEmpty(txtMiddleName.Text) && !ValidateName(txtMiddleName.Text))
            {
                MessageBox.Show("Middle Name must contain at least 3 letters, no numbers or special characters.");
                return false;
            }

            // Validate Gender (ComboBox cannot be typed)
            if (cbGender.SelectedItem == null)
            {
                MessageBox.Show("Please select a Gender.");
                return false;
            }

            // Validate Age (Maximum 3 numbers)
            if (numAge.Value < 1 || numAge.Value > 100)
            {
                MessageBox.Show("Age must be between 1 and 100.");
                return false;
            }

            // Validate Contact Number (no characters, no special chars, 11 digits only)
            if (!ValidateContactNumber(txtContactNumber.Text))
            {
                MessageBox.Show("Contact Number must be 11 digits with no characters or special characters.");
                return false;
            }

            // Validate PurokNumber, Phase, Package, Block (no characters or special characters)
            if (!ValidateTextField(txtPurokNumber.Text) || !ValidateTextField(txtPhase.Text) || !ValidateTextField(txtPackage.Text) || !ValidateTextField(txtBlock.Text))
            {
                MessageBox.Show("Purok Number, Phase, Package, and Block must not contain characters or special characters.");
                return false;
            }

            // Validate Religion (If "Others" is selected, ensure input in txtReligion)
            if (cbReligion.SelectedItem != null && cbReligion.SelectedItem.ToString() == "Others" && string.IsNullOrEmpty(txtReligion.Text))
            {
                MessageBox.Show("Please specify the Religion when 'Others' is selected.");
                return false;
            }

            // Ensure all fields are filled (skip txtMiddleName since it's optional)
            if (string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) ||
                cbGender.SelectedItem == null ||
                numAge.Value <= 0 ||
                string.IsNullOrEmpty(txtContactNumber.Text) ||
                string.IsNullOrEmpty(txtPurokNumber.Text) ||
                string.IsNullOrEmpty(txtPhase.Text) ||
                string.IsNullOrEmpty(txtPackage.Text) ||
                string.IsNullOrEmpty(txtBlock.Text) ||
                cbReligion.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            return true;
        }

        // Validate name input (No numbers, no special characters, and at least 3 letters)
        private bool ValidateName(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Length >= 3 && Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        // Validate contact number (11 digits only, no characters or special characters)
        private bool ValidateContactNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d{11}$");
        }

        // Validate text fields to ensure no characters or special characters
        private bool ValidateTextField(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$");
        }

        private void InsertPurokIntoDatabase(string firstName, string middleName, string lastName, string gender, int age, string contactNumber, string purokNumber, string phase, string package, string block, string religion, string civilStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO PurokLeaders (FirstName, MiddleName, LastName, Gender, Age, ContactNumber, PurokNumber, Phase, Package, Block, CivilStatus, Religion) " +
                                   "VALUES (@FirstName, @MiddleName, @LastName, @Gender, @Age, @ContactNumber, @PurokNumber, @Phase, @Package, @Block, @CivilStatus, @Religion)";

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

                    // Check if "Others" is selected in cbReligion
                    if (cbReligion.SelectedItem != null && cbReligion.SelectedItem.ToString() == "Others")
                    {
                        // Use the value from txtReligion if "Others" is selected
                        cmd.Parameters.AddWithValue("@Religion", txtReligion.Text);
                    }
                    else
                    {
                        // Otherwise, use the selected item in cbReligion
                        cmd.Parameters.AddWithValue("@Religion", cbReligion.SelectedItem.ToString());
                    }

                    // Add Civil Status to the parameters
                    cmd.Parameters.AddWithValue("@CivilStatus", cbCivilStatus.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New purok leader added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding purok leader: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    // Capitalize first letter of each word for name fields (no capitalization for txtReligion)
                    string firstName = CapitalizeFirstLetter(txtFirstName.Text);
                    string middleName = CapitalizeFirstLetter(txtMiddleName.Text);
                    string lastName = CapitalizeFirstLetter(txtLastName.Text);
                    string gender = cbGender.SelectedItem.ToString();
                    int age = (int)numAge.Value;
                    string contactNumber = txtContactNumber.Text;

                    string purokNumber = "Purok " + txtPurokNumber.Text;
                    string phase = "Phase " + txtPhase.Text;
                    string package = "Package " + txtPackage.Text;
                    string block = "Block " + txtBlock.Text;

                    string religion = cbReligion.SelectedItem.ToString();
                    string civilStatus = cbCivilStatus.SelectedItem.ToString(); // Get Civil Status value

                    InsertPurokIntoDatabase(firstName, middleName, lastName, gender, age, contactNumber, purokNumber, phase, package, block, religion, civilStatus); // Pass civilStatus as a parameter

                    // Clear all inputs
                    txtFirstName.Clear();
                    txtMiddleName.Clear();
                    txtLastName.Clear();
                    cbGender.SelectedItem = null;
                    numAge.Value = 0;
                    txtContactNumber.Clear();
                    txtPurokNumber.Clear();
                    txtPhase.Clear();
                    txtPackage.Clear();
                    txtBlock.Clear();
                    cbReligion.SelectedItem = null;
                    txtReligion.Clear();  // Clear txtReligion if it was enabled
                    cbCivilStatus.SelectedItem = null;

                    txtFirstName.Focus();

                    // Show the RegisterRoleUserAccount form
                    RegisterRoleUserAccount roleForm = new RegisterRoleUserAccount();
                    roleForm.Show();
                }
                else
                {
                    MessageBox.Show("Please fill in all required fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving purok: " + ex.Message);
            }
        }

        private void cbCivilStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure Civil Status options are limited (removed because Civil Status field is now removed)
        }

        private void txtReligion_TextChanged(object sender, EventArgs e)
        {
            // Enable txtReligion when 'Others' is selected in Religion dropdown
            if (cbReligion.SelectedItem != null && cbReligion.SelectedItem.ToString() == "Others")
            {
                txtReligion.Enabled = true;
            }
            else
            {
                txtReligion.Enabled = false;
                txtReligion.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
