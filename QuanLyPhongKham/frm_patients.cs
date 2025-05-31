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
        { "@address", txb_address.Text.Trim() },
        { "@pulse", txb_pulse.Text.Trim() },
        { "@blood_pressure", txb_blood_pressure.Text.Trim() },
        { "@respiratory_rate", txb_respiratory_rate.Text.Trim() },
        { "@weight", txb_weight.Text.Trim() },
        { "@height", txb_height.Text.Trim() },
        { "@temperature", txb_temperature.Text.Trim() }
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
            txb_pulse.Text = "  Lần/phút";
            txb_blood_pressure.Text = "  mmHg";
            txb_respiratory_rate.Text = "  Lần/phút";
            txb_weight.Text = "  kg";
            txb_height.Text = "  cm";
            txb_temperature.Text = "  °C";

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
    `pulse`, 
    `blood_pressure`, 
    `respiratory_rate`, 
    `weight`, 
    `height`, 
    `temperature`, 
    DATE_FORMAT(`created_at`, '%d/%m/%Y %H:%i') AS `created_at`, 
    DATE_FORMAT(`updated_at`, '%d/%m/%Y %H:%i') AS `updated_at`
FROM `patients`
ORDER BY updated_at DESC";

            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã BN";
            dtgv.Columns["name"].HeaderText = "Họ tên";
            dtgv.Columns["date_of_birth"].HeaderText = "Ngày sinh";
            dtgv.Columns["gender"].HeaderText = "Giới tính";
            dtgv.Columns["phone"].HeaderText = "SĐT";
            dtgv.Columns["address"].HeaderText = "Địa chỉ";
            dtgv.Columns["pulse"].HeaderText = "Mạch";
            dtgv.Columns["blood_pressure"].HeaderText = "Huyết áp";
            dtgv.Columns["respiratory_rate"].HeaderText = "Nhịp thở";
            dtgv.Columns["weight"].HeaderText = "Cân nặng";
            dtgv.Columns["height"].HeaderText = "Chiều cao";
            dtgv.Columns["temperature"].HeaderText = "Nhiệt độ";
            dtgv.Columns["created_at"].HeaderText = "Ngày tạo";
            dtgv.Columns["updated_at"].HeaderText = "Cập nhật lúc";
            dtgv.Columns["created_at"].DefaultCellStyle.Format = "dd/MM/yyyy";
            
            dtgv.Columns["id"].Width = 80;
            dtgv.Columns["name"].Width = 200;
            dtgv.Columns["date_of_birth"].Width = 120;
            dtgv.Columns["gender"].Width = 80;
            dtgv.Columns["phone"].Width = 130;
            dtgv.Columns["address"].Width = 200;
            dtgv.Columns["pulse"].Width = 115;
            dtgv.Columns["blood_pressure"].Width = 115;
            dtgv.Columns["respiratory_rate"].Width = 115;
            dtgv.Columns["weight"].Width = 115;
            dtgv.Columns["height"].Width = 115;
            dtgv.Columns["temperature"].Width = 115;
            dtgv.Columns["created_at"].Width = 140;
            dtgv.Columns["updated_at"].Width = 170;



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

            string query = @"INSERT INTO patients 
(name, date_of_birth, gender, phone, address, pulse, blood_pressure, respiratory_rate, weight, height, temperature, created_at)
VALUES 
(@name, @date_of_birth, @gender, @phone, @address, @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature, NOW())";


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
    pulse = @pulse,
    blood_pressure = @blood_pressure,
    respiratory_rate = @respiratory_rate,
    weight = @weight,
    height = @height,
    temperature = @temperature,
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
                txb_pulse.Text = row.Cells["pulse"].Value?.ToString();
                txb_blood_pressure.Text = row.Cells["blood_pressure"].Value?.ToString();
                txb_respiratory_rate.Text = row.Cells["respiratory_rate"].Value?.ToString();
                txb_weight.Text = row.Cells["weight"].Value?.ToString();
                txb_height.Text = row.Cells["height"].Value?.ToString();
                txb_temperature.Text = row.Cells["temperature"].Value?.ToString();

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
                MessageBox.Show("Vui lòng chọn bệnh nhân để tái tiếp nhận.");
                return;
            }

            string query = @"UPDATE patients SET 
            name = @name, 
            date_of_birth = @date_of_birth, 
            gender = @gender, 
            phone = @phone, 
            address = @address, 
            pulse = @pulse,
            blood_pressure = @blood_pressure,
            respiratory_rate = @respiratory_rate,
            weight = @weight,
            height = @height,
            temperature = @temperature,
            updated_at = NOW()
        WHERE id = @id";


            var data = GetPatientFormData();
            data.Add("@id", txb_id.Text.Trim());

            Db.Update(query, data);
            MessageBox.Show("Tái tiếp nhận thành công!");
            LoadAllPatients();
            ClearForm();
        }
    }
}
