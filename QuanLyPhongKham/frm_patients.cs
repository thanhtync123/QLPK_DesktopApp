using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace QuanLyPhongKham
{
    public partial class frm_patients : Form
    {
        public static event Action OnPatientChanged;
        private Timer debounceTimer;
        private string pendingKeyword = "";
        public frm_patients()
        {
            InitializeComponent();
        }
        int pagesize = 10;
        int currentpage = 1;
        int totalpage = 0;
        private void LoadPatients(string keyword = "")
        {
         
            var offset = (currentpage - 1) * pagesize;
            string where = "";
            if (!string.IsNullOrEmpty(keyword))
            {
                string escapedKeyword = MySqlHelper.EscapeString(keyword);
                where = $"WHERE `id` LIKE '%{escapedKeyword}%' OR `name` LIKE '%{escapedKeyword}%'";
            }

            string query = $@"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY updated_at DESC) AS STT,
                    `id`, 
                    `name`, 
                    YEAR(date_of_birth) AS date_of_birth,
                    `gender`, 
                    `phone`, 
                    `address`, 
                    `pulse`, 
                    `blood_pressure`, 
                    `respiratory_rate`, 
                    `weight`, 
                    `height`, 
                    `temperature`, 
                    DATE_FORMAT(`created_at`, '%d/%m/%Y %H:%i') AS `created_at_format`, 
                    DATE_FORMAT(`updated_at`, '%d/%m/%Y %H:%i') AS `updated_at_format`,
                    `updated_at`
                FROM `patients`
                {where}
                ORDER BY `updated_at` DESC
            LIMIT {pagesize}
            OFFSET {offset}
                         "
            ;
            Db.ResetConnection();
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv.Rows.Add();
                DataGridViewRow row = dtgv.Rows[i];
                row.Cells["STT"].Value = Db.dr["STT"];
                row.Cells["id"].Value = Db.dr["id"];
                row.Cells["name"].Value = Db.dr["name"];
                row.Cells["date_of_birth"].Value = Db.dr["date_of_birth"];
                row.Cells["gender"].Value = Db.dr["gender"];
                row.Cells["phone"].Value = Db.dr["phone"];
                row.Cells["address"].Value = Db.dr["address"];
                row.Cells["pulse"].Value = Db.dr["pulse"];
                row.Cells["blood_pressure"].Value = Db.dr["blood_pressure"];
                row.Cells["respiratory_rate"].Value = Db.dr["respiratory_rate"];
                row.Cells["weight"].Value = Db.dr["weight"];
                row.Cells["height"].Value = Db.dr["height"];
                row.Cells["temperature"].Value = Db.dr["temperature"];
                row.Cells["created_at_format"].Value = Db.dr["created_at_format"];
                row.Cells["updated_at_format"].Value = Db.dr["updated_at_format"];
            }
            if (dtgv.Rows.Count == 1)
            {
                dtgv.Rows.Add();
                dtgv.Rows[0].Cells["name"].Value = "❌ Không tìm thấy dữ liệu";
                dtgv.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                dtgv.Rows[0].DefaultCellStyle.Font = new Font(dtgv.Font, FontStyle.Italic);

            }


            Db.dr.Close();


            dtgv.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var updatedAtRaw = dtgv.Rows[e.RowIndex].Cells["updated_at_format"].Value?.ToString();
                    if (!string.IsNullOrEmpty(updatedAtRaw) && DateTime.TryParse(updatedAtRaw, out DateTime updatedDate))
                    {
                        if (updatedDate.Date == DateTime.Today)
                        {
                            string colName = dtgv.Columns[e.ColumnIndex].Name;
                            if (colName == "name" || colName == "updated_at_format")
                            {
                                e.CellStyle.BackColor = Color.PaleGreen;
                                e.CellStyle.ForeColor = Color.Black;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            }
                        }
                    }
                }
            };
        }





 
        private void frm_patients_Load(object sender, EventArgs e)
        {

            txb_id.ReadOnly = true;
            SetButtonState(false);
            LoadPatients("");
            LoadTotalPage();

            // KHỞI TẠO DEBOUNCE TIMER
            debounceTimer = new Timer();
            debounceTimer.Interval = 300; // debounce 300ms
            debounceTimer.Tick += DebounceTimer_Tick;



        }
        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            LoadTotalPage(pendingKeyword); 
            currentpage = 1;             
            LoadPatients(pendingKeyword);
        }



        private void ClearForm()
        {
            txb_id.Clear();
            txb_name.Clear();
            rdn_male.Checked = false;
            rdn_female.Checked = false;
            txb_phone.Clear();
            txb_address.Clear();
            txb_pulse.Text = " Lần/phút";
            txb_blood_pressure.Text=" mmHg";
            txb_respiratory_rate.Text=" Lần/phút";
            txb_weight.Text=" kg";
            txb_height.Text=" cm";
            txb_temperature.Text= " °C";
            txb_dob.Text = "";
            txb_age.Text = "";


            SetButtonState(false);
        }
        private void SetButtonState(bool isEditing)
        {
            btn_add.Enabled = !isEditing;
            btn_update.Enabled = isEditing;
            btn_delete.Enabled = isEditing;
            btn_re_updated.Enabled = isEditing;
        }
        private Dictionary<string, object> GetPatientFormData()
        {
            return new Dictionary<string, object>
            {
                {"id", txb_id.Text },
                {"name", txb_name.Text },
                {"date_of_birth", $"{txb_dob.Text}-01-01"},
                {"gender", rdn_male.Checked ? "Nam" : "Nữ" },
                {"phone", txb_phone.Text },
                {"address", txb_address.Text },
                {"pulse", txb_pulse.Text },
                {"blood_pressure", txb_blood_pressure.Text },
                {"respiratory_rate", txb_respiratory_rate.Text },
                {"weight", txb_weight.Text },
                {"height", txb_height.Text },
                {"temperature", txb_temperature.Text }
            };
        }
        private bool CheckForm()
        {
            if (txb_dob.Text == "" || Convert.ToInt16(txb_dob.Text) < 1900 || Convert.ToInt16(txb_dob.Text) > DateTime.Now.Year)
            {
                MessageBox.Show("Năm sinh không hợp lệ. Vui lòng nhập lại! (từ 1900 đến năm hiện tại)");
                return false;
            }
            if (rdn_female.Checked == false && rdn_male.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txb_phone.Text))
                if (txb_phone.Text.Length != 10)
                {
                    MessageBox.Show("SĐT phải có đúng 10 số, vui lòng nhập lại!");
                    return false;
                }
            

            return true;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if(!CheckForm()) return;
            var data = GetPatientFormData();
            string query = @"INSERT INTO patients 
                (name, date_of_birth, gender, phone, address, pulse, blood_pressure, respiratory_rate, weight, height, temperature) 
                VALUES (@name, @date_of_birth, @gender, @phone, @address, @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature)";
            Db.Add(query, data);
            ClearForm();
            LoadPatients();
            OnPatientChanged?.Invoke(); 
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!CheckForm()) return;
            var data = GetPatientFormData();
            string query = @"UPDATE patients 
                SET name=@name, date_of_birth=@date_of_birth, gender=@gender, phone=@phone, address=@address, pulse=@pulse, 
                    blood_pressure=@blood_pressure, respiratory_rate=@respiratory_rate, weight=@weight, height=@height, temperature=@temperature, 
                    updated_at=NOW() 
                WHERE id=@id";

            Db.Update(query, data);
            ClearForm();
            LoadPatients();
            OnPatientChanged?.Invoke();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var data = GetPatientFormData();
            string query = "DELETE FROM patients WHERE id=@id";

            Db.Delete(query, data);
            ClearForm();
            LoadPatients();
            OnPatientChanged?.Invoke();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
  
            ClearForm();
            LoadPatients();
            txb_dob.Text = "";
            rdn_male.Checked = false;
            rdn_female.Checked = false;
        }


        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv.Rows[e.RowIndex];

                txb_id.Text = row.Cells["id"].Value.ToString();
                txb_name.Text = row.Cells["name"].Value.ToString();
                txb_dob.Text = row.Cells["date_of_birth"].Value.ToString();
                (row.Cells["gender"].Value.ToString() == "Nam" ? rdn_male : rdn_female).Checked = true;
                txb_phone.Text = row.Cells["phone"].Value.ToString();
                txb_address.Text = row.Cells["address"].Value.ToString();
                txb_pulse.Text = row.Cells["pulse"].Value.ToString();
                txb_blood_pressure.Text = row.Cells["blood_pressure"].Value.ToString();
                txb_respiratory_rate.Text = row.Cells["respiratory_rate"].Value.ToString();
                txb_weight.Text = row.Cells["weight"].Value.ToString();
                txb_height.Text = row.Cells["height"].Value.ToString();
                txb_temperature.Text = row.Cells["temperature"].Value.ToString();
                SetButtonState(true);
            }
        }


        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            LoadPatients(txb_search.Text.Trim());
        }

        private void btn_re_updated_Click(object sender, EventArgs e)
        {
            if (!CheckForm()) return;
            CheckForm();
            var data = GetPatientFormData();
            string query = @"UPDATE patients 
                     SET name=@name, 
                         date_of_birth=@date_of_birth, 
                         gender=@gender, 
                         phone=@phone, 
                         address=@address, 
                         pulse=@pulse, 
                         blood_pressure=@blood_pressure, 
                         respiratory_rate=@respiratory_rate, 
                         weight=@weight, 
                         height=@height, 
                         temperature=@temperature, 
                         updated_at=NOW() 
                     WHERE id=@id";

            Db.Update(query, data);
            MessageBox.Show("Tái tiếp nhận và cập nhật thông tin thành công!");
            ClearForm();
            LoadPatients();
            OnPatientChanged?.Invoke();
        }

        private void txb_dob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && txb_dob.Text.Length >= 4)
                e.Handled = true;

        }
        private void LoadTotalPage(string keyword = "")
        {
            string where = "";
            if (!string.IsNullOrEmpty(keyword))
            {
                string escapedKeyword = MySqlHelper.EscapeString(keyword);
                where = $"WHERE `id` LIKE '%{escapedKeyword}%' OR `name` LIKE '%{escapedKeyword}%'";
            }

            string countQuery = $"SELECT COUNT(*) FROM patients {where}";
            Db.ResetConnection();
            MySqlCommand cmd = new MySqlCommand(countQuery, Db.conn);
            int totalRecords = Convert.ToInt32(cmd.ExecuteScalar());
            totalpage = (int)Math.Ceiling((double)totalRecords / pagesize);

            if (currentpage > totalpage)
                currentpage = totalpage > 0 ? totalpage : 1;

            Db.ResetConnection();
        }

        private void dtgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {


        }

        private void btn_firstpage_Click(object sender, EventArgs e)
        {
                currentpage=1;
                LoadPatients(txb_search.Text.Trim());
            lb_currentpage.Text = currentpage.ToString();

        }

        private void btn_downpage_Click(object sender, EventArgs e)
        {
            if(currentpage > 1 )
            {
                currentpage--;
                LoadPatients(txb_search.Text.Trim());
                lb_currentpage.Text = currentpage.ToString();
            }

        }

        private void btn_uppage_Click(object sender, EventArgs e)
        {
            if (currentpage < totalpage)
            {
                currentpage++;
                LoadPatients(txb_search.Text.Trim());
                lb_currentpage.Text = currentpage.ToString();
            }

        }

        private void btn_maxpage_Click(object sender, EventArgs e)
        {
            currentpage = totalpage;
            LoadPatients(txb_search.Text.Trim());
            lb_currentpage.Text = currentpage.ToString();
        }

        private void txb_dob_TextChanged(object sender, EventArgs e)
        {
 
            if (txb_dob.TextLength == 4 && int.TryParse(txb_dob.Text, out int yearOfBirth))
            {
                int currentYear = DateTime.Now.Year;
                int age = currentYear - yearOfBirth;
                if (age >= 0 && age <= 150)
                    txb_age.Text = age.ToString();
                else
                    txb_age.Text = "";
            }
            else
            
                txb_age.Text = "";
            
        }

        private void txb_age_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu nhập được số tuổi hợp lệ
            if (int.TryParse(txb_age.Text, out int age))
            {
                int currentYear = DateTime.Now.Year;
                int yearOfBirth = currentYear - age;

                if (yearOfBirth > 1900 && yearOfBirth <= currentYear)
                    txb_dob.Text = yearOfBirth.ToString();
                else
                    txb_dob.Text = "";
            }
            else
            
                txb_dob.Text = "";
            
        }

        private void txb_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && txb_age.Text.Length >= 3)
                e.Handled = true;
        }



        private void btn_cancel_reupdated_Click_1(object sender, EventArgs e)
        {
            if (!CheckForm()) return;
            var s = dtgv.CurrentRow.Cells["updated_at_format"].Value?.ToString();
            if (!s.StartsWith(DateTime.Now.ToString("dd/MM/yyyy")))
            {
                MessageBox.Show("Khách hàng không được tiếp nhận trong hôm nay, không thể hủy tiếp nhận");
                return;
            }
            
            CheckForm();
            var data = GetPatientFormData();
            string query = @"UPDATE patients 
                         SET updated_at = DATE_SUB(NOW(), INTERVAL 1 DAY)
                     WHERE id=@id";

            Db.Update(query, data);
            MessageBox.Show("Hủy tiếp nhận thành công!");
            ClearForm();
            LoadPatients();
            OnPatientChanged?.Invoke();
        }

        private void txb_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            
                e.Handled = true; 
            
        }

        private void txb_name_TextChanged(object sender, EventArgs e)
        {
            pendingKeyword = txb_name.Text.Trim();
            debounceTimer.Stop();
            debounceTimer.Start();   
        }
    }
}

