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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            InitializeButtonStyles();  // Ensure buttons start with the desired default style
        }

        private void InitializeButtonStyles()
        {
            // Set default foreground (text) color and border color to white for all buttons
            btnViewResidents.ForeColor = Color.White;
            btnViewResidents.FlatAppearance.BorderColor = Color.White;
            btnViewStaff.ForeColor = Color.White;
            btnViewStaff.FlatAppearance.BorderColor = Color.White;
            btnViewPurok.ForeColor = Color.White;
            btnViewPurok.FlatAppearance.BorderColor = Color.White;
            btnRecord.ForeColor = Color.White;
            btnRecord.FlatAppearance.BorderColor = Color.White;
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatAppearance.BorderColor = Color.White;

            // Set the background color of all buttons to Transparent by default
            btnViewResidents.BackColor = Color.Transparent;
            btnViewStaff.BackColor = Color.Transparent;
            btnViewPurok.BackColor = Color.Transparent;
            btnRecord.BackColor = Color.Transparent;
            btnLogout.BackColor = Color.Transparent;
        }

        private void btnViewResidents_Click(object sender, EventArgs e)
        {
            // Add logic to display residents control
            panelContainer.Controls.Clear();
            ResidentsUserControl residentsControl = new ResidentsUserControl();
            panelContainer.Controls.Add(residentsControl);
            residentsControl.Dock = DockStyle.Fill;

            // Set background color to light blue for the clicked button
            btnViewResidents.BackColor = Color.LightBlue;
            // Set the font color to black for the clicked button
            btnViewResidents.ForeColor = Color.Black;
            btnViewResidents.FlatAppearance.BorderColor = Color.Black;

            // Reset the other buttons' background color and text color
            ResetOtherButtons(btnViewResidents);
        }

        private void btnViewStaff_Click_1(object sender, EventArgs e)
        {
            // Add logic to display staff control
            panelContainer.Controls.Clear();
            StaffUserControl staffControl = new StaffUserControl();
            panelContainer.Controls.Add(staffControl);
            staffControl.Dock = DockStyle.Fill;

            // Set background color to light blue for the clicked button
            btnViewStaff.BackColor = Color.LightBlue;
            // Set the font color to black for the clicked button
            btnViewStaff.ForeColor = Color.Black;
            btnViewStaff.FlatAppearance.BorderColor = Color.Black;

            // Reset the other buttons' background color and text color
            ResetOtherButtons(btnViewStaff);
        }

        private void btnViewPurok_Click(object sender, EventArgs e)
        {
            // Add logic to display purok control
            panelContainer.Controls.Clear();
            PurokLeaderUserControl purokControl = new PurokLeaderUserControl();
            panelContainer.Controls.Add(purokControl);
            purokControl.Dock = DockStyle.Fill;

            // Set background color to light blue for the clicked button
            btnViewPurok.BackColor = Color.LightBlue;
            // Set the font color to black for the clicked button
            btnViewPurok.ForeColor = Color.Black;
            btnViewPurok.FlatAppearance.BorderColor = Color.Black;

            // Reset the other buttons' background color and text color
            ResetOtherButtons(btnViewPurok);
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            // Add logic to display record control
            panelContainer.Controls.Clear();
            ServiceRequestUserControl recordControl = new ServiceRequestUserControl();
            panelContainer.Controls.Add(recordControl);
            recordControl.Dock = DockStyle.Fill;

            // Set background color to light blue for the clicked button
            btnRecord.BackColor = Color.LightBlue;
            // Set the font color to black for the clicked button
            btnRecord.ForeColor = Color.Black;
            btnRecord.FlatAppearance.BorderColor = Color.Black;

            // Reset the other buttons' background color and text color
            ResetOtherButtons(btnRecord);
        }

        private void ResetOtherButtons(Button clickedButton)
        {
            // Reset the other buttons' background color and text color to default
            foreach (Button button in new Button[] { btnViewResidents, btnViewStaff, btnViewPurok, btnRecord })
            {
                if (button != clickedButton)
                {
                    button.BackColor = Color.Transparent;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = Color.White;
                }
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();

                this.Close();
            }
        }
    }
}
