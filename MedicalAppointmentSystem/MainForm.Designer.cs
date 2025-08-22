using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnDoctors = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnManageAppointments = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoctors
            // 
            this.btnDoctors.Location = new System.Drawing.Point(100, 50);
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.Size = new System.Drawing.Size(200, 40);
            this.btnDoctors.TabIndex = 0;
            this.btnDoctors.Text = "View Doctors";
            this.btnDoctors.UseVisualStyleBackColor = true;
            this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.Location = new System.Drawing.Point(100, 110);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(200, 40);
            this.btnAppointments.TabIndex = 1;
            this.btnAppointments.Text = "Book Appointment";
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnManageAppointments
            // 
            this.btnManageAppointments.Location = new System.Drawing.Point(100, 170);
            this.btnManageAppointments.Name = "btnManageAppointments";
            this.btnManageAppointments.Size = new System.Drawing.Size(200, 40);
            this.btnManageAppointments.TabIndex = 2;
            this.btnManageAppointments.Text = "Manage Appointments";
            this.btnManageAppointments.UseVisualStyleBackColor = true;
            this.btnManageAppointments.Click += new System.EventHandler(this.btnManageAppointments_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.btnDoctors);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnManageAppointments);
            this.Name = "MainForm";
            this.Text = "Medical Appointment System";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnDoctors;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnManageAppointments;
    }
}

