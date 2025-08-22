using System;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            new DoctorListForm().ShowDialog();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            new AppointmentForm().ShowDialog();
        }

        private void btnManageAppointments_Click(object sender, EventArgs e)
        {
            new ManageAppointmentsForm().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
