using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace MedicalAppointmentSystem
{
    public partial class DoctorListForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString;

        public DoctorListForm()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DoctorID, FullName, Specialty, " +
                               "CASE WHEN Availability = 1 THEN 'Available' ELSE 'Not Available' END AS Availability " +
                               "FROM Doctors";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewDoctors.DataSource = dt;

                // Adjust column sizes
                dataGridViewDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewDoctors.ReadOnly = true;
            }
        }
    }
}
