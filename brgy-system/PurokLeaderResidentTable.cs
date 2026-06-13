using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace brgy_system
{
    public partial class PurokLeaderResidentTable : UserControl
    {
        private string connectionString = "Data Source=LEI-2905\\SQLEXPRESS;Initial Catalog=brgy-sys;Integrated Security=True;Trust Server Certificate=True";
        private DataTable residentsDataTable;

        public PurokLeaderResidentTable()
        {
            InitializeComponent();
            LoadResidentData();
        }

        private void LoadResidentData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Modify query to load residents data in descending order by ResidentID
                    string query = "SELECT ResidentID AS ID, FirstName AS First_Name, MiddleName AS Middle_Name, LastName AS Last_Name, Age, AddressPhase AS Phase, AddressPackage AS Package, AddressBlock AS Block, CivilStatus AS Civil_Status, Religion, Gender FROM Residents ORDER BY ResidentID DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    residentsDataTable = new DataTable();
                    adapter.Fill(residentsDataTable);

                    dgvResidents.DataSource = residentsDataTable;
                    dgvResidents.AllowUserToAddRows = false;  // Prevent the extra row from appearing

                    // Set a smaller width for the ID column
                    dgvResidents.Columns["ID"].Width = 50;

                    // Additional DataGridView styling
                    dgvResidents.EnableHeadersVisualStyles = false;
                    dgvResidents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#17263b");
                    dgvResidents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvResidents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvResidents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

                    dgvResidents.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvResidents.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvResidents.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

                    dgvResidents.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                    dgvResidents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

                    dgvResidents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgvResidents.GridColor = System.Drawing.Color.FromArgb(211, 211, 211);

                    dgvResidents.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
                    dgvResidents.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                    dgvResidents.BackgroundColor = System.Drawing.Color.FromArgb(233, 234, 244);

                    foreach (DataGridViewColumn column in dgvResidents.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    dgvResidents.AllowUserToResizeColumns = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading residents: " + ex.Message);
                }
            }
        }
    }
}
