using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace brgy_system
{
    public partial class EndorsementViewControl : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True"; // Your connection string

        public EndorsementViewControl()
        {
            InitializeComponent();
            LoadEndorsements();
        }


        public void LoadEndorsements()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string query = @"
                        SELECT 
                            e.EndorsementID,
                            r.FirstName + ' ' + r.MiddleName + ' ' + r.LastName AS ResidentName,
                            e.DateEndorsed
                        FROM 
                            Endorsements e
                            JOIN Residents r ON e.ResidentID = r.ResidentID
                        ORDER BY e.DateEndorsed DESC";  

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);  

                    
                    dgvEndorsements.DataSource = dt;

                   
                    StyleDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading endorsements: " + ex.Message);
            }
        }


        private void StyleDataGridView()
        {
            dgvEndorsements.EnableHeadersVisualStyles = false;
            dgvEndorsements.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
            dgvEndorsements.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvEndorsements.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvEndorsements.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEndorsements.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvEndorsements.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEndorsements.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgvEndorsements.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvEndorsements.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Remove any unnecessary space in rows
            dgvEndorsements.RowTemplate.Height = 30;

            // Set the DataGridView to automatically fill the entire available space by using Fill mode
            dgvEndorsements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Remove the header height space if desired
            dgvEndorsements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEndorsements.ColumnHeadersHeight = 35; // Custom header height

            // Sorting by DateEndorsed in descending order
            dgvEndorsements.Sort(dgvEndorsements.Columns["DateEndorsed"], System.ComponentModel.ListSortDirection.Descending);
        }
    }
}
 