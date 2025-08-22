using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    partial class DoctorListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewDoctors;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewDoctors = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoctors)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDoctors
            // 
            this.dataGridViewDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDoctors.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDoctors.Name = "dataGridViewDoctors";
            this.dataGridViewDoctors.Size = new System.Drawing.Size(560, 300);
            this.dataGridViewDoctors.TabIndex = 0;
            // 
            // DoctorListForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 341);
            this.Controls.Add(this.dataGridViewDoctors);
            this.Name = "DoctorListForm";
            this.Text = "List of Doctors";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoctors)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

