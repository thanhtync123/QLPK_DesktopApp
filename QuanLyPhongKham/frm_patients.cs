using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuanLyPhongKham
{
    public partial class frm_patients : Form
    {
        string connectionString = "server=localhost;port=3306;database=clinic_db2;uid=root;pwd=;";

        public frm_patients()
        {
            InitializeComponent();
        }

        private void frm_patients_Load(object sender, EventArgs e)
        {
            cb_gender.SelectedIndex = 0;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            LoadPatients();
        }

        private void LoadPatients()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT `id`, `name`, DATE_FORMAT(`date_of_birth`, '%Y-%m-%d') AS `date_of_birth`, `gender`, `phone`, `address`, `created_at`, `updated_at` FROM `patients` WHERE 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (!dt.Columns.Contains("note"))
                        {
                            dt.Columns.Add("note", typeof(string));
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["id"].ToString() == "13")
                            {
                                row["note"] = "(hôm nay)";
                            }
                            else
                            {
                                row["note"] = "";
                            }
                        }

                        dtgv.DataSource = dt;

                        if (dtgv.Columns.Contains("note"))
                        {
                            dtgv.Columns["note"].HeaderText = "Ghi chú";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO patients (name, date_of_birth, gender, phone, address, created_at, updated_at) " +
                                   "VALUES (@name, @dob, @gender, @phone, @address, NOW(), NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txb_name.Text);
                        cmd.Parameters.AddWithValue("@dob", txb_dob.Text);
                        cmd.Parameters.AddWithValue("@gender", cb_gender.Text);
                        cmd.Parameters.AddWithValue("@phone", txb_phone.Text);
                        cmd.Parameters.AddWithValue("@address", txb_address.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm bệnh nhân thành công!");
                        LoadPatients();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txb_id.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để xóa.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM patients WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txb_id.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công!");
                        LoadPatients();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txb_id.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để cập nhật.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE patients SET name = @name, date_of_birth = @dob, gender = @gender, phone = @phone, address = @address, updated_at = NOW() WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txb_name.Text);
                        cmd.Parameters.AddWithValue("@dob", txb_dob.Text);
                        cmd.Parameters.AddWithValue("@gender", cb_gender.Text);
                        cmd.Parameters.AddWithValue("@phone", txb_phone.Text);
                        cmd.Parameters.AddWithValue("@address", txb_address.Text);
                        cmd.Parameters.AddWithValue("@id", txb_id.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thành công!");
                        LoadPatients();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadPatients();
            ClearFields();
        }

        private void ClearFields()
        {
            txb_id.Text = "";
            txb_name.Text = "";
            txb_dob.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cb_gender.SelectedIndex = 0;
            txb_phone.Text = "";
            txb_address.Text = "123";
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv.Rows[e.RowIndex];

                txb_id.Text = row.Cells["id"].Value.ToString();
                txb_name.Text = row.Cells["name"].Value.ToString();
                txb_dob.Text = Convert.ToDateTime(row.Cells["date_of_birth"].Value).ToString("dd/MM/yyyy");
                cb_gender.Text = row.Cells["gender"].Value.ToString();
                txb_phone.Text = row.Cells["phone"].Value.ToString();
                txb_address.Text = row.Cells["address"].Value.ToString();
            }
        }
    }
}
