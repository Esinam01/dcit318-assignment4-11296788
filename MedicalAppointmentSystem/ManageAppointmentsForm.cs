using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace MedicalAppointmentSystem
{
    public partial class ManageAppointmentsForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString;
        private SqlDataAdapter adapter;
        private DataTable dt;

        public ManageAppointmentsForm()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT a.AppointmentID, 
                                        p.FullName AS Patient, 
                                        d.FullName AS Doctor, 
                                        a.AppointmentDate, 
                                        a.Notes
                                 FROM Appointments a
                                 JOIN Patients p ON a.PatientID = p.PatientID
                                 JOIN Doctors d ON a.DoctorID = d.DoctorID";

                adapter = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                dt = new DataTable();
                adapter.Fill(dt);

                // Corrected the DataGridView name
                dataGridViewAppointments.DataSource = dt;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Apply changes made in DataGridView back to DB
                adapter.Update(dt);
                MessageBox.Show("Appointment updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAppointments.SelectedRows.Count > 0)
            {
                // Remove row from grid
                dataGridViewAppointments.Rows.RemoveAt(dataGridViewAppointments.SelectedRows[0].Index);

                try
                {
                    adapter.Update(dt); // Push delete to DB
                    MessageBox.Show("Appointment deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting appointment: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.");
            }
        }
    }
}