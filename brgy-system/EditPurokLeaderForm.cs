using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace brgy_system
{
    public partial class EditPurokLeaderForm : Form
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True";
        private int PurokLeaderID;
        private Action refreshPurokfDataCallback;

        public EditPurokLeaderForm(int PurokLeaderID, Action refreshCallback)
        {
            InitializeComponent();
            this.PurokLeaderID = PurokLeaderID;
            this.refreshPurokfDataCallback = refreshCallback;
            LoadPurokData();
        }

        private void LoadPurokData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM PurokLeaders WHERE PurokLeaderID = @PurokLeaderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PurokLeaderID", PurokLeaderID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtMiddleName.Text = reader["MiddleName"].ToString(); // Middle Name is optional
                        txtLastName.Text = reader["LastName"].ToString();
                        cbGender.SelectedItem = reader["Gender"].ToString();
                        numAge.Value = Convert.ToInt32(reader["Age"]);
                        txtContactNumber.Text = reader["ContactNumber"].ToString();
                        txtPurokNumber.Text = reader["PurokNumber"].ToString();
                        txtPhase.Text = reader["Phase"].ToString();
                        txtPackage.Text = reader["Package"].ToString();
                        txtBlock.Text = reader["Block"].ToString();
                        cbCivilStatus.SelectedItem = reader["CivilStatus"].ToString();  // ComboBox for Civil Status
                        cbReligion.SelectedItem = reader["Religion"].ToString();  // ComboBox for Religion

                        // Check if "Others" is selected in Religion and show the textbox accordingly
                        if (cbReligion.SelectedItem.ToString() == "Others")
                        {
                            txtReligion.Visible = true;  // Show the Religion text box
                            txtReligion.Text = reader["Religion"].ToString(); // Set the value from the database
                        }
                        else
                        {
                            txtReligion.Visible = false;  // Hide the Religion text box
                            txtReligion.Text = ""; // Clear the field if not visible
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Purok data: " + ex.Message);
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
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
                string civilStatus = cbCivilStatus.SelectedItem.ToString();  // ComboBox for Civil Status
                string religion = cbReligion.SelectedItem.ToString();  // ComboBox for Religion

                // If "Others" is selected in Religion, validate txtReligion
                if (cbReligion.SelectedItem.ToString() == "Others" && string.IsNullOrEmpty(txtReligion.Text))
                {
                    MessageBox.Show("Please specify the Religion when 'Others' is selected.");
                    return;
                }

                // Proceed with saving/updating the data
                UpdatePurokInDatabase(firstName, middleName, lastName, gender, age, contactNumber, purokNumber, phase, package, block, civilStatus, religion);
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private bool ValidateFields()
        {
            // Validate First Name
            if (!ValidateName(txtFirstName.Text))
            {
                MessageBox.Show("First Name must contain at least 3 letters and no special characters.");
                return false;
            }

            // Validate Last Name
            if (!ValidateName(txtLastName.Text))
            {
                MessageBox.Show("Last Name must contain at least 3 letters and no special characters.");
                return false;
            }

            // Validate Middle Name (Optional, but check if it contains valid characters if filled)
            if (!string.IsNullOrEmpty(txtMiddleName.Text) && !ValidateName(txtMiddleName.Text))
            {
                MessageBox.Show("Middle Name must contain at least 3 letters and no special characters.");
                return false;
            }

            // Validate Gender
            if (cbGender.SelectedItem == null)
            {
                MessageBox.Show("Gender is required.");
                return false;
            }

            // Validate Age
            if (numAge.Value <= 0)
            {
                MessageBox.Show("Age must be greater than 0.");
                return false;
            }

            // Validate Contact Number (11 digits only)
            if (!ValidateContactNumber(txtContactNumber.Text))
            {
                MessageBox.Show("Contact Number must be exactly 11 digits and contain only numbers.");
                return false;
            }

            // Validate PurokNumber, Phase, Package, Block (Alphanumeric only)
            if (!ValidateAlphanumeric(txtPurokNumber.Text) || !ValidateAlphanumeric(txtPhase.Text) || !ValidateAlphanumeric(txtPackage.Text) || !ValidateAlphanumeric(txtBlock.Text))
            {
                MessageBox.Show("Purok Number, Phase, Package, and Block must not contain special characters.");
                return false;
            }

            // Validate Civil Status
            if (cbCivilStatus.SelectedItem == null)
            {
                MessageBox.Show("Civil Status is required.");
                return false;
            }

            // Validate Religion
            if (cbReligion.SelectedItem == null)
            {
                MessageBox.Show("Religion is required.");
                return false;
            }

            // Special handling for "Others" in Religion ComboBox
            if (cbReligion.SelectedItem.ToString() == "Others" && string.IsNullOrEmpty(txtReligion.Text))
            {
                MessageBox.Show("Please specify the Religion when 'Others' is selected.");
                return false;
            }

            return true;
        }

        private bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 3 && Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        private bool ValidateContactNumber(string contactNumber)
        {
            return !string.IsNullOrEmpty(contactNumber) && Regex.IsMatch(contactNumber, @"^\d{11}$");
        }

        private bool ValidateAlphanumeric(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Z0-9\s]+$");
        }

        private void UpdatePurokInDatabase(string firstName, string middleName, string lastName, string gender, int age, string contactNumber, string purokNumber, string phase, string package, string block, string civilStatus, string religion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE PurokLeaders SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                                   "Gender = @Gender, Age = @Age, ContactNumber = @ContactNumber, PurokNumber = @PurokNumber, Phase = @Phase, " +
                                   "Package = @Package, Block = @Block, CivilStatus = @CivilStatus, Religion = @Religion WHERE PurokLeaderID = @PurokLeaderID";

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
                    cmd.Parameters.AddWithValue("@CivilStatus", civilStatus);  // ComboBox for Civil Status
                    cmd.Parameters.AddWithValue("@Religion", religion);  // ComboBox for Religion
                    cmd.Parameters.AddWithValue("@PurokLeaderID", PurokLeaderID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Purok Leader updated successfully!");

                    refreshPurokfDataCallback();  // Refresh Purok Leader data after successful update

                    this.Close();  // Close the form after updating
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating Purok Leader: " + ex.Message);
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
