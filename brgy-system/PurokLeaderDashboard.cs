using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace brgy_system
{
    public partial class PurokLeaderDashboard : Form
    {
        public PurokLeaderDashboard()
        {
            InitializeComponent();
            InitializeButtonStyles();  // Ensure buttons start with the desired default style
        }

        private void InitializeButtonStyles()
        {
            // Set default foreground (text) color and border color to white for both buttons
            btnRegisterResident.ForeColor = Color.White;
            btnRegisterResident.FlatAppearance.BorderColor = Color.White;
            btnEndorsement.ForeColor = Color.White;
            btnEndorsement.FlatAppearance.BorderColor = Color.White;

            // Set the background color of both buttons to Transparent by default
            btnRegisterResident.BackColor = Color.Transparent;
            btnEndorsement.BackColor = Color.Transparent;

            // Add event handlers for hover effect
            btnRegisterResident.MouseEnter += new EventHandler(Button_MouseEnter);
            btnRegisterResident.MouseLeave += new EventHandler(Button_MouseLeave);
            btnEndorsement.MouseEnter += new EventHandler(Button_MouseEnter);
            btnEndorsement.MouseLeave += new EventHandler(Button_MouseLeave);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            // Change the foreground color and border color to black when the mouse enters the button
            Button button = sender as Button;
            if (button != null)
            {
                button.ForeColor = Color.Black;
                button.FlatAppearance.BorderColor = Color.White;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            // Reset the foreground color and border color back to white when the mouse leaves the button
            Button button = sender as Button;
            if (button != null)
            {
                button.ForeColor = Color.Black;
                button.FlatAppearance.BorderColor = Color.White;
            }
        }

        private void btnResident_Click(object sender, EventArgs e)
        {
            FormPanel.Controls.Clear();

            ResidentRegistrationForm registrationForm = new ResidentRegistrationForm();

            registrationForm.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(registrationForm);

            // Set background color to light blue for the clicked button
            btnRegisterResident.BackColor = Color.LightBlue;
            // Set the font color to black for the clicked button
            btnRegisterResident.ForeColor = Color.Black;
            btnRegisterResident.FlatAppearance.BorderColor = Color.White;

            // Reset the other button's background color and text color
            btnEndorsement.BackColor = Color.Transparent;
            btnEndorsement.ForeColor = Color.White;  // Ensure the text color stays white
            btnEndorsement.FlatAppearance.BorderColor = Color.White;  // Keep the border color white
        }

        private void btnEndorsement_Click(object sender, EventArgs e)
        {
            FormPanel.Controls.Clear();

            EndorsementForm endorsementForm = new EndorsementForm();

            endorsementForm.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(endorsementForm);

            // Set background color to light blue for the clicked button
            btnEndorsement.BackColor = Color.LightBlue;
            // Set the font color to black for the clicked button
            btnEndorsement.ForeColor = Color.Black;
            btnEndorsement.FlatAppearance.BorderColor = Color.Black;

            // Reset the other button's background color and text color
            btnRegisterResident.BackColor = Color.Transparent;
            btnRegisterResident.ForeColor = Color.White;  // Ensure the text color stays white
            btnRegisterResident.FlatAppearance.BorderColor = Color.White;  // Keep the border color white
        }

        private void PurokDashboard_Load(object sender, EventArgs e)
        {
            // You can optionally call InitializeButtonStyles() here if needed
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();

                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: any painting code
        }
    }
}
