using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace MedicalAppointmentSystem
{
    public partial class AppointmentForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString;

        public AppointmentForm()
        {
            InitializeComponent();
            LoadDoctors();
            LoadPatients();
        }

        private void LoadDoctors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DoctorID, FullName FROM Doctors WHERE Availability = 1";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbDoctors.Items.Add(new { Text = reader["FullName"].ToString(), Value = reader["DoctorID"] });
                }
            }
        }

        private void LoadPatients()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PatientID, FullName FROM Patients";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbPatients.Items.Add(new { Text = reader["FullName"].ToString(), Value = reader["PatientID"] });
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedItem == null || cmbPatients.SelectedItem == null)
            {
                MessageBox.Show("Please select doctor and patient.");
                return;
            }

            int doctorId = (int)cmbDoctors.SelectedItem.GetType().GetProperty("Value").GetValue(cmbDoctors.SelectedItem, null);
            int patientId = (int)cmbPatients.SelectedItem.GetType().GetProperty("Value").GetValue(cmbPatients.SelectedItem, null);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Appointments (DoctorID, PatientID, AppointmentDate, Notes) " +
                               "VALUES (@DoctorID, @PatientID, @AppointmentDate, @Notes)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                cmd.Parameters.AddWithValue("@PatientID", patientId);
                cmd.Parameters.AddWithValue("@AppointmentDate", dateTimePicker.Value);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Appointment booked successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error booking appointment: " + ex.Message);
                }
            }
        }
    }
}

