using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuanLyPhongKham
{
    public partial class frm_patients : Form
    {
        public frm_patients()
        {
            InitializeComponent();
        }

        private Dictionary<string, object> GetPatientFormData()
        {
            return new Dictionary<string, object>
            {
                { "@name", txb_name.Text.Trim() },
                { "@date_of_birth", DateTime.ParseExact(dtpk_dob.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-dd") },
                { "@gender", rdn_male.Checked ? "Nam" : "Nữ" },
                { "@phone", txb_phone.Text.Trim() },
                { "@address", txb_address.Text.Trim() }
            };
        }

        private void SetButtonState(bool isRowSelected)
        {
            btn_add.Enabled = !isRowSelected;
            btn_update.Enabled = isRowSelected;
            btn_delete.Enabled = isRowSelected;
            btn_re_updated.Enabled = isRowSelected;  
        }

        private void ClearForm()
        {
            txb_id.Clear();
            txb_name.Clear();
            txb_phone.Clear();
            txb_address.Clear();
            dtpk_dob.Value = DateTime.Today;
            rdn_male.Checked = true;

            SetButtonState(false);
        }

        private void LoadAllPatients()
        {
            string query = @"SELECT 
                `id`, 
                `name`, 
                DATE_FORMAT(`date_of_birth`, '%d/%m/%Y') AS `date_of_birth`, 
                `gender`, 
                `phone`, 
                `address`, 
                DATE_FORMAT(`created_at`, '%d/%m/%Y %H:%i') AS `created_at`, 
                DATE_FORMAT(`updated_at`, '%d/%m/%Y %H:%i') AS `updated_at`
            FROM `patients`
            ORDER BY updated_at DESC
            ";

            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã bệnh nhân";
            dtgv.Columns["name"].HeaderText = "Họ tên";
            dtgv.Columns["date_of_birth"].HeaderText = "Ngày sinh";
            dtgv.Columns["gender"].HeaderText = "Giới tính";
            dtgv.Columns["phone"].HeaderText = "Số điện thoại";
            dtgv.Columns["address"].HeaderText = "Địa chỉ";
            dtgv.Columns["created_at"].HeaderText = "Ngày tạo";
            dtgv.Columns["updated_at"].HeaderText = "Tiếp nhận lúc";
            dtgv.Columns["created_at"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dtgv.EnableHeadersVisualStyles = false;
            dtgv.AllowUserToAddRows = false;

            // Thêm sự kiện CellFormatting
            dtgv.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var updatedAtValue = dtgv.Rows[e.RowIndex].Cells["updated_at"].Value?.ToString();
                    string todayStr = DateTime.Today.ToString("dd/MM/yyyy");

                    bool isToday = false;

                    if (!string.IsNullOrEmpty(updatedAtValue))
                    {
                        // Lấy phần ngày: substring đầu 10 ký tự "dd/MM/yyyy"
                        string updatedDateOnly = updatedAtValue.Length >= 10 ? updatedAtValue.Substring(0, 10) : updatedAtValue;

                        isToday = (updatedDateOnly == todayStr);
                    }

                    if ((dtgv.Columns[e.ColumnIndex].Name == "updated_at" || dtgv.Columns[e.ColumnIndex].Name == "name") && isToday)
                    {
                        e.CellStyle.BackColor = Color.PaleGreen;  // xanh lá nhẹ nhàng
                        e.CellStyle.ForeColor = Color.Black;      // chữ màu đen dễ đọc
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                    }

                }
            };



        }


        private void frm_patients_Load(object sender, EventArgs e)
        {
            dtpk_dob.Format = DateTimePickerFormat.Custom;
            dtpk_dob.CustomFormat = "dd/MM/yyyy";
            rdn_male.Checked= true;

            LoadAllPatients();

            txb_id.ReadOnly = true;
            SetButtonState(false);

            // Gán sự kiện cho ô tìm kiếm
            txb_search.TextChanged += txb_search_TextChanged;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO patients (name, date_of_birth, gender, phone, address, created_at)
                             VALUES (@name, @date_of_birth, @gender, @phone, @address, NOW())";

            var data = GetPatientFormData();
            Db.Add(query, data);

            LoadAllPatients();
            ClearForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để sửa.");
                return;
            }

            string query = @"UPDATE patients SET 
                            name = @name, 
                            date_of_birth = @date_of_birth, 
                            gender = @gender, 
                            phone = @phone, 
                            address = @address, 
                            updated_at = NOW()
                            WHERE id = @id";

            var data = GetPatientFormData();
            data.Add("@id", txb_id.Text.Trim());

            Db.Update(query, data);

            LoadAllPatients();
            ClearForm();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM patients WHERE id = @id";
                var data = new Dictionary<string, object>
                {
                    { "@id", txb_id.Text.Trim() }
                };

                Db.Delete(query, data);
                LoadAllPatients();
                ClearForm();
            }
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv.Rows[e.RowIndex];

                txb_id.Text = row.Cells["id"].Value.ToString();
                txb_name.Text = row.Cells["name"].Value.ToString();
                txb_phone.Text = row.Cells["phone"].Value.ToString();
                txb_address.Text = row.Cells["address"].Value.ToString();

                string dobString = row.Cells["date_of_birth"].Value.ToString();
                if (DateTime.TryParseExact(dobString, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime dob))
                {
                    dtpk_dob.Value = dob;
                }

                string gender = row.Cells["gender"].Value.ToString();
                rdn_male.Checked = (gender == "Nam");
                rdn_female.Checked = (gender == "Nữ");

                SetButtonState(true);  // Kích hoạt các nút khi có dòng được chọn
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadAllPatients();
        }

        private void SearchPatients(string keyword)
        {
            string escapedKeyword = MySqlHelper.EscapeString(keyword); // nếu bạn dùng MySql.Data

            string query = $@"SELECT 
                `id`, 
                `name`, 
                DATE_FORMAT(`date_of_birth`, '%d/%m/%Y') AS `date_of_birth`, 
                `gender`, 
                `phone`, 
                `address`, 
                `created_at`, 
                DATE_FORMAT(`updated_at`, '%d/%m/%Y') AS `updated_at`
            FROM `patients`
            WHERE `id` LIKE '%{escapedKeyword}%' OR `name` LIKE '%{escapedKeyword}%'";

            Db.LoadDTGV(dtgv, query);
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            SearchPatients(txb_search.Text.Trim());
        }

        private void btn_re_updated_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để cập nhật lại.");
                return;
            }

            // Cập nhật trường updated_at với thời gian hiện tại
            string query = @"UPDATE patients SET 
                     updated_at = NOW()
                     WHERE id = @id";

            var data = new Dictionary<string, object>
            {
                { "@id", txb_id.Text.Trim() }
            };

            // Gọi hàm Update để thực thi câu lệnh SQL
            Db.Update(query, data);

            // Tải lại danh sách bệnh nhân
            LoadAllPatients();

            MessageBox.Show("Cập nhật lại thời gian tiếp nhận thành công.");
        }
    }
}
