using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery("GetAllMedicines", null);
                dataGridViewMedicines.DataSource = dt;
            }
            catch (Exception ex)
            {
                DatabaseHelper.ShowError(ex);
            }
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", txtName.Text),
                    new SqlParameter("@Category", txtCategory.Text),
                    new SqlParameter("@Price", decimal.Parse(txtPrice.Text)),
                    new SqlParameter("@Quantity", int.Parse(txtQuantity.Text))
                };

                int result = DatabaseHelper.ExecuteNonQuery("AddMedicine", parameters);
                if (result > 0)
                {
                    MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMedicines();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.ShowError(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SearchTerm", txtSearch.Text)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery("SearchMedicine", parameters);
                dataGridViewMedicines.DataSource = dt;
            }
            catch (Exception ex)
            {
                DatabaseHelper.ShowError(ex);
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dataGridViewMedicines.SelectedRows.Count > 0)
            {
                try
                {
                    int medicineId = Convert.ToInt32(dataGridViewMedicines.SelectedRows[0].Cells["MedicineID"].Value);
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MedicineID", medicineId),
                        new SqlParameter("@Quantity", int.Parse(txtUpdateQuantity.Text))
                    };

                    int result = DatabaseHelper.ExecuteNonQuery("UpdateStock", parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMedicines();
                        txtUpdateQuantity.Clear();
                    }
                }
                catch (Exception ex)
                {
                    DatabaseHelper.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a medicine to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRecordSale_Click(object sender, EventArgs e)
        {
            if (dataGridViewMedicines.SelectedRows.Count > 0)
            {
                try
                {
                    int medicineId = Convert.ToInt32(dataGridViewMedicines.SelectedRows[0].Cells["MedicineID"].Value);
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MedicineID", medicineId),
                        new SqlParameter("@QuantitySold", int.Parse(txtSaleQuantity.Text))
                    };

                    int result = DatabaseHelper.ExecuteNonQuery("RecordSale", parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Sale recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMedicines();
                        txtSaleQuantity.Clear();
                    }
                }
                catch (Exception ex)
                {
                    DatabaseHelper.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a medicine to sell", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadMedicines();
            txtSearch.Clear();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }
    }
}

