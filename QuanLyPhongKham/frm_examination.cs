﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using System.CodeDom;
using System.Text.RegularExpressions;

namespace QuanLyPhongKham
{
    public partial class frm_examination : Form
    {
        int id;
        private Timer timer = new Timer();
        private int? selectedPatientId = null;
        public frm_examination()
        {
            InitializeComponent();




            timer.Interval = 3000;
            timer.Tick += (s, e) =>
            {
                // Lưu ID bệnh nhân hiện tại nếu có
                if (dtgv_patients.CurrentRow != null && dtgv_patients.CurrentRow.Cells["ID"].Value != null)
                {
                    selectedPatientId = Convert.ToInt32(dtgv_patients.CurrentRow.Cells["ID"].Value);
                }

                // Reload dữ liệu
                LoadGrid();

                // Khôi phục lựa chọn dòng cũ nếu còn tồn tại
                if (selectedPatientId.HasValue)
                {
                    foreach (DataGridViewRow row in dtgv_patients.Rows)
                    {
                        if (row.Cells["ID"].Value != null && Convert.ToInt32(row.Cells["ID"].Value) == selectedPatientId)
                        {
                            dtgv_patients.CurrentCell = row.Cells[0];
                            dtgv_patients.Rows[row.Index].Selected = true;
                            break;
                        }
                    }
                }
            };
            dtgv_patients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {

            dtgv_patients.Columns.Clear();
            dtgv_patients.Columns.Add("ID", "ID");
            dtgv_patients.Columns.Add("name", "Tên BN");
            dtgv_patients.Columns.Add("date_of_birth", "Ngày sinh");
            dtgv_patients.Columns.Add("gender", "Giới tính");
            dtgv_patients.Columns.Add("phone", "SĐT");
            dtgv_patients.Columns.Add("address", "Địa chỉ");
            dtgv_patients.Columns.Add("time_patients", "Tiếp nhận lúc");
            //
            dtgv_patients.Columns.Add("pulse", "Mạch");
            dtgv_patients.Columns.Add("blood_pressure", "Huyết áp");
            dtgv_patients.Columns.Add("respiratory_rate", "Nhịp thở");
            dtgv_patients.Columns.Add("weight", "Cân nặng");
            dtgv_patients.Columns.Add("height", "Chiều cao");
            dtgv_patients.Columns.Add("temperature", "Nhiệt độ");
            foreach (DataGridViewColumn col in dtgv_patients.Columns)
                col.Visible = false;
            dtgv_patients.Columns["ID"].Visible = true;
            dtgv_patients.Columns["name"].Visible = true;
            dtgv_patients.Columns["time_patients"].Visible = true;

            // Load data
            dtgv_patients.Rows.Clear();
            string sql = @"SELECT 
                            id, 
                            name, 
                            DATE_FORMAT(date_of_birth, '%d/%m/%Y') AS date_of_birth, 
                            gender, 
                            phone, 
                            address, 
                            DATE_FORMAT(updated_at, '%H:%i:%s') AS updated_time, 
                            pulse,
                            blood_pressure,
                            respiratory_rate,
                            weight,
                            height, 
                            temperature
                            FROM patients WHERE DATE(updated_at) = CURDATE()
                            order by updated_time DESC";
            Db.ResetConnection();
            MySqlCommand cmd = Db.CreateCommand(sql);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dtgv_patients.Rows.Add(
                       dr["id"],
                       dr["name"],
                       dr["date_of_birth"],
                       dr["gender"],
                       dr["phone"],
                       dr["address"],
                       dr["updated_time"],
                       dr["pulse"],
                       dr["blood_pressure"],
                       dr["respiratory_rate"],
                       dr["weight"],
                       dr["height"],
                       dr["temperature"]);
            }

            dr.Close();
            Db.ResetConnection();

            



        }

        private void frm_examination_Load(object sender, EventArgs e)
        {
           

            LoadGrid();
            LoadComboboxDiagnoses();
            LoadComboboxDoctorNote();
            LoadComboboxMedication();
            LoadExamID();
            LoadDTGV_Service();
            btn_deletemed.Enabled = false;
            cbo_diagnoses.SelectedIndex = 0;
    
       



        }

        private void dtgv_patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dtgv_patients.CurrentRow.Cells["ID"].Value);
            selectedPatientId = id; // Lưu ID bệnh nhân hiện tại để khôi phục sau khi reload
            txb_name.Text = dtgv_patients.CurrentRow.Cells["name"].Value.ToString();
            txb_id.Text = id.ToString();
            txb_ngaysinh.Text = dtgv_patients.CurrentRow.Cells["date_of_birth"].Value.ToString();
            int lastFourChars = Convert.ToInt32(txb_ngaysinh.Text.Substring(txb_ngaysinh.Text.Length - 4));
            int currentYear = DateTime.Now.Year;
            txb_age.Text = (currentYear - lastFourChars).ToString();
            txb_address.Text = dtgv_patients.CurrentRow.Cells["address"].Value.ToString();
            txb_gender.Text = dtgv_patients.CurrentRow.Cells["gender"].Value.ToString();
            txb_phone.Text = dtgv_patients.CurrentRow.Cells["phone"].Value.ToString();

            txb_pulse.Text = dtgv_patients.CurrentRow.Cells["pulse"].Value.ToString();
            txb_blood_pressure.Text = dtgv_patients.CurrentRow.Cells["blood_pressure"].Value.ToString();
            txb_respiratory_rate.Text = dtgv_patients.CurrentRow.Cells["respiratory_rate"].Value.ToString();
            txb_weight.Text = dtgv_patients.CurrentRow.Cells["weight"].Value.ToString();
            txb_height.Text = dtgv_patients.CurrentRow.Cells["height"].Value.ToString();
            txb_temperature.Text = dtgv_patients.CurrentRow.Cells["temperature"].Value.ToString();


        }
        //1
        private void LoadComboboxDoctorNote()
        {

            string query = "SELECT id, content FROM doctor_notes order by content asc";
            Db.LoadComboBoxData(cb_doctornote, query, "content", "id");

        }
        private void LoadComboboxDiagnoses()
        {
            string query = "SELECT id, name FROM diagnoses order by name asc";
            Db.LoadComboBoxData(cbo_diagnoses, query, "name", "id");
            cbo_diagnoses.SelectedIndex = 0;  // Chọn phần tử đầu tiên sau khi load dữ liệu
        }


        private void LoadComboboxMedication()
        {
            string query = "SELECT id, name FROM medications order by name asc";
            Db.LoadComboBoxData(cb_medname2, query, "name", "id");

        }

        private void btn_addmed_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgv_med.Rows.Add();
            dtgv_med.Rows[rowIndex].Cells[0].Value = cb_medname2.SelectedValue;
            dtgv_med.Rows[rowIndex].Cells[1].Value = cb_medname2.Text;
            dtgv_med.Rows[rowIndex].Cells[2].Value = txb_unit.Text;
            dtgv_med.Rows[rowIndex].Cells[3].Value = txb_dosage.Text;
            dtgv_med.Rows[rowIndex].Cells[4].Value = txb_route.Text;
            dtgv_med.Rows[rowIndex].Cells[5].Value = txb_times.Text;
            dtgv_med.Rows[rowIndex].Cells[6].Value = txb_mednote.Text;
            dtgv_med.Rows[rowIndex].Cells[7].Value = txb_quantity.Text;
            dtgv_med.Rows[rowIndex].Cells[8].Value = txb_price.Text;
            dtgv_med.Rows[rowIndex].Cells[9].Value = txb_totalpricepermed.Text;
            lb_totalprice.Text = "Tổng tiền";

            decimal total = 0;
            foreach (DataGridViewRow row in dtgv_med.Rows)

                if (row.Cells[9].Value != null && decimal.TryParse(row.Cells[9].Value.ToString(), out decimal rowTotal))

                    total += rowTotal;


            lb_totalprice.Text = "Tổng tiền: " + total.ToString("N0") + " đ";
            TinhNgayTaiKham();
           
         


        }
        private void TinhNgayTaiKham()
        {
            int maxDays = 0;

            for (int i = 0; i < dtgv_med.Rows.Count; i++)
            {
                if (dtgv_med.Rows[i].IsNewRow) continue;

                var quantityStr = dtgv_med.Rows[i].Cells["quantity"].Value?.ToString() ?? "0";
                var usage = dtgv_med.Rows[i].Cells["med_note"].Value?.ToString() ?? "";

                int quantity = int.TryParse(quantityStr, out int q) ? q : 0;

                // Regex: tìm các từ "sáng", "trưa", "chiều", "tối" không phân biệt hoa thường
                var matches = Regex.Matches(usage, @"\b(sáng|trưa|chiều|tối)\b", RegexOptions.IgnoreCase);
                int timesPerDay = matches.Count;

                if (timesPerDay == 0) timesPerDay = 1;

                int days = (int)Math.Ceiling((double)quantity / timesPerDay);

                if (days > maxDays)
                    maxDays = days;
            }

            DateTime ngayTaiKham = DateTime.Today.AddDays(maxDays);
            txb_taikham.Text = checkBox1.Checked ? ngayTaiKham.ToString("dd/MM/yyyy") : "Không";
        }
        private void cb_medname_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void cb_medname2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cb_medname2.SelectedIndex != 0)
            {
                if (Db.conn.State != ConnectionState.Open)
                    Db.ResetConnection(); // dùng Db.ResetConnection() nếu đã viết sẵn trong Db.cs

                string query = "SELECT id, name, unit, dosage, route, times_per_day, note, price FROM medications WHERE id = @id order by name";
                int selectedId = Convert.ToInt32(cb_medname2.SelectedValue);

                Db.cmd = new MySqlCommand(query, Db.conn);
                Db.cmd.Parameters.AddWithValue("@id", selectedId);
                Db.dr = Db.cmd.ExecuteReader();

                if (Db.dr.Read())
                {
                    txb_unit.Text = Db.dr["unit"].ToString();
                    txb_dosage.Text = Db.dr["dosage"].ToString();
                    txb_route.Text = Db.dr["route"].ToString();
                    txb_times.Text = Db.dr["times_per_day"].ToString();
                    txb_mednote.Text = Db.dr["note"].ToString();
                    txb_price.Text = Db.dr["price"].ToString();
                    txb_quantity.Text = "1";
                }

                int quantity = Convert.ToInt32(txb_quantity.Value);
                int price = Convert.ToInt32(txb_price.Text);
                txb_totalpricepermed.Text = (quantity * price).ToString();

                Db.dr.Close();
                Db.ResetConnection();
            }
        }
        private void txb_quantity_ValueChanged(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(txb_quantity.Value);
            int price = Convert.ToInt32(txb_price.Text);
            txb_totalpricepermed.Text = quantity * price + "";
        }

        private void btn_deletemed_Click(object sender, EventArgs e)
        {
            if (dtgv_med.SelectedRows.Count > 0)
                dtgv_med.Rows.RemoveAt(dtgv_med.SelectedRows[0].Index);

            else
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");

            decimal total = 0;
            foreach (DataGridViewRow row in dtgv_med.Rows)

                if (row.Cells[9].Value != null && decimal.TryParse(row.Cells[9].Value.ToString(), out decimal rowTotal))

                    total += rowTotal;


            lb_totalprice.Text = "Tổng tiền: " + total.ToString("N0") + " đ";
            TinhNgayTaiKham();

        }

        private void dtgv_med_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_deletemed.Enabled = true;
        }
        private void LoadExamID()
        {
            ResetConnection();
            string query = "SELECT max(id)+1 as exam_id from examinations";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            if (Db.dr.Read())
                txb_exam_id.Text = Db.dr["exam_id"].ToString();

            Db.dr.Close();



        }
        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            dtgv_service.Rows.Clear();
            var keyword = txb_search.Text.Trim();
            LoadDTGV_Service(keyword);

        }

        private void LoadDTGV_Service(String keyword = "")
        {
            ResetConnection();
            string query = $@"SELECT id,`name`, `type`, `price`
                        FROM `services`
                         WHERE name LIKE '%{keyword}%'
                        ORDER BY 
                          CASE `type`
                            WHEN 'X-quang' THEN 1
                            WHEN 'Siêu âm' THEN 2
                            WHEN 'Xét nghiệm' THEN 3
                            WHEN 'Điện tim' THEN 4
                          END;

                        ";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            while (Db.dr.Read())
            {
                int i = dtgv_service.Rows.Add();
                DataGridViewRow drr = dtgv_service.Rows[i];
                drr.Cells["id_service"].Value = Db.dr["id"];
                drr.Cells["service_name"].Value = Db.dr["name"];
                drr.Cells["type"].Value = Db.dr["type"];
                drr.Cells["price1"].Value = Db.dr["price"];
                drr.Cells["add_service"].Value = "+";
            }


            Db.dr.Close();
        }

        private void btn_add_examination_Click(object sender, EventArgs e)
        {
            try
            {
                Db.ResetConnection();
                string diagnosisName = cbo_diagnoses.Text.Trim();

                // Kiểm tra xem chẩn đoán đã có chưa
                string checkSql = "SELECT id FROM diagnoses WHERE name = @name LIMIT 1;";
                MySqlCommand checkCmd = new MySqlCommand(checkSql, Db.conn);
                checkCmd.Parameters.AddWithValue("@name", diagnosisName);
                object diagnosisResult = checkCmd.ExecuteScalar();

                int diagnosisID;

                if (diagnosisResult != null)
                {
                    diagnosisID = Convert.ToInt32(diagnosisResult);
                }
                else
                {
                    // Nếu chưa có thì thêm mới
                    string insertDiagnosisSql = "INSERT INTO diagnoses (name, created_at, updated_at) VALUES (@name, current_timestamp(), current_timestamp());";
                    MySqlCommand insertDiagnosisCmd = new MySqlCommand(insertDiagnosisSql, Db.conn);
                    insertDiagnosisCmd.Parameters.AddWithValue("@name", diagnosisName);
                    insertDiagnosisCmd.ExecuteNonQuery();

                    // Lấy ID vừa thêm
                    string getNewIDSql = "SELECT LAST_INSERT_ID();";
                    MySqlCommand getNewIDCmd = new MySqlCommand(getNewIDSql, Db.conn);
                    diagnosisID = Convert.ToInt32(getNewIDCmd.ExecuteScalar());
                }

                // Thêm phiếu khám
                string queryExamination = @"
        INSERT INTO examinations 
        (id, patient_id, reason, diagnosis_id, doctor_note_id, note, pulse, blood_pressure, respiratory_rate, weight, height, temperature, type, created_at, updated_at) 
        VALUES 
        (NULL, @patient_id, @reason, @diagnosis_id, @doctor_note_id, @note, @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature, @type, current_timestamp(), current_timestamp());";

                MySqlCommand cmd = new MySqlCommand(queryExamination, Db.conn);
                cmd.Parameters.AddWithValue("@patient_id", Convert.ToInt16(txb_id.Text));
                cmd.Parameters.AddWithValue("@reason", lbsdfsf.Text);
                cmd.Parameters.AddWithValue("@diagnosis_id", diagnosisID);
                cmd.Parameters.AddWithValue("@doctor_note_id", Convert.ToInt16(cb_doctornote.SelectedValue));
                cmd.Parameters.AddWithValue("@note", txb_note.Text);
                cmd.Parameters.AddWithValue("@pulse", txb_pulse.Text);
                cmd.Parameters.AddWithValue("@blood_pressure", txb_blood_pressure.Text);
                cmd.Parameters.AddWithValue("@respiratory_rate", txb_respiratory_rate.Text);
                cmd.Parameters.AddWithValue("@weight", txb_weight.Text);
                cmd.Parameters.AddWithValue("@height", txb_height.Text);
                cmd.Parameters.AddWithValue("@temperature", txb_temperature.Text);
                cmd.Parameters.AddWithValue("@type", "toa thuốc");

                cmd.ExecuteNonQuery();

                // Lấy ID phiếu khám
                cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn);
                int examinationID = Convert.ToInt32(cmd.ExecuteScalar());

                // Lưu thuốc
                foreach (DataGridViewRow row in dtgv_med.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string queryMedication = "INSERT INTO examination_medications (examination_id, medication_id, unit, dosage, route, times, note, quantity, price, created_at, updated_at) " +
                                                 "VALUES (@examination_id, @medication_id, @unit, @dosage, @route, @times, @note, @quantity, @price, current_timestamp(), current_timestamp());";
                        cmd = new MySqlCommand(queryMedication, Db.conn);
                        cmd.Parameters.AddWithValue("@examination_id", examinationID);
                        cmd.Parameters.AddWithValue("@medication_id", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@unit", row.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@dosage", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@route", row.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@times", row.Cells[5].Value);
                        cmd.Parameters.AddWithValue("@note", row.Cells[6].Value);
                        cmd.Parameters.AddWithValue("@quantity", row.Cells[7].Value);
                        cmd.Parameters.AddWithValue("@price", row.Cells[8].Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                LoadExamID();
                MessageBox.Show("Thêm phiếu khám và toa thuốc thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                Db.ResetConnection();
            }

        }
        private void ResetConnection()
        {
            if (Db.conn.State == ConnectionState.Open)

                Db.conn.Close();
            if (Db.conn.State != ConnectionState.Open)

                Db.conn.Open();

        }

        private void dtgv_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                if (dtgv_service.Columns[e.ColumnIndex].Name == "add_service")
                {
                    DataGridViewRow selectedRow = dtgv_service.Rows[e.RowIndex];
                    var idService = selectedRow.Cells["id_service"].Value?.ToString();
                    var nameService = selectedRow.Cells["service_name"].Value?.ToString();
                    var priceService = selectedRow.Cells["price1"].Value?.ToString();
                    if (decimal.TryParse(priceService, out decimal price))
                    
                        priceService = price.ToString("N0"); // Format với N0
                    
                    int rowIndex = dtgv_service_patient.Rows.Add();
                    dtgv_service_patient.Rows[rowIndex].Cells["id_service2"].Value = idService;
                    dtgv_service_patient.Rows[rowIndex].Cells["name_service2"].Value = nameService;
                    dtgv_service_patient.Rows[rowIndex].Cells["price2"].Value = priceService;
                    dtgv_service_patient.Rows[rowIndex].Cells["delete_service"].Value = "-";
                    UpdateTotalServicePrice();


                }
            }
        }

        private void dtgv_service_patient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                if (dtgv_service_patient.Columns[e.ColumnIndex].Name == "delete_service")
                {
                    dtgv_service_patient.Rows.RemoveAt(e.RowIndex);
                    UpdateTotalServicePrice();
                }



        }

        private void btn_save_examination_service_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                Db.ResetConnection();

                // Kiểm tra chẩn đoán đã tồn tại chưa (dùng tham số để tránh lỗi SQL Injection)
                string checkDiagnosisQuery = "SELECT id FROM diagnoses WHERE name = @name";
                MySqlCommand cmd = new MySqlCommand(checkDiagnosisQuery, Db.conn);
                cmd.Parameters.AddWithValue("@name", cbo_diagnoses.Text);

                object result = cmd.ExecuteScalar();
                int diagnosisId;

                if (result == null)
                {
                    // Chẩn đoán chưa tồn tại, thêm mới
                    string insertDiagnosisQuery = "INSERT INTO diagnoses (name) VALUES (@name)";
                    cmd = new MySqlCommand(insertDiagnosisQuery, Db.conn);
                    cmd.Parameters.AddWithValue("@name", cbo_diagnoses.Text);
                    cmd.ExecuteNonQuery();

                    // Lấy ID mới thêm
                    cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn);
                    diagnosisId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    // Chẩn đoán đã tồn tại, lấy id
                    diagnosisId = Convert.ToInt32(result);
                }

                // Thêm phiếu khám
                string queryExamination = @"
INSERT INTO examinations 
(id, patient_id, reason, diagnosis_id, doctor_note_id, note, pulse, blood_pressure, respiratory_rate, weight, height, temperature, type, created_at, updated_at) 
VALUES 
(NULL, @patient_id, @reason, @diagnosis_id, @doctor_note_id, @note, @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature, @type, current_timestamp(), current_timestamp());";

                cmd = new MySqlCommand(queryExamination, Db.conn);
                cmd.Parameters.AddWithValue("@patient_id", Convert.ToInt16(txb_id.Text));
                cmd.Parameters.AddWithValue("@reason", txb_reason.Text);
                cmd.Parameters.AddWithValue("@diagnosis_id", diagnosisId);
                cmd.Parameters.AddWithValue("@doctor_note_id", Convert.ToInt16(cb_doctornote.SelectedValue));
                cmd.Parameters.AddWithValue("@note", txb_note.Text);
                cmd.Parameters.AddWithValue("@pulse", txb_pulse.Text);
                cmd.Parameters.AddWithValue("@blood_pressure", txb_blood_pressure.Text);
                cmd.Parameters.AddWithValue("@respiratory_rate", txb_respiratory_rate.Text);
                cmd.Parameters.AddWithValue("@weight", txb_weight.Text);
                cmd.Parameters.AddWithValue("@height", txb_height.Text);
                cmd.Parameters.AddWithValue("@temperature", txb_temperature.Text);
                cmd.Parameters.AddWithValue("@type", "chỉ định");

                cmd.ExecuteNonQuery();

                // Lấy ID phiếu khám
                cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn);
                int examinationID = Convert.ToInt32(cmd.ExecuteScalar());

                // Thêm các dịch vụ chỉ định
                foreach (DataGridViewRow row in dtgv_service_patient.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string queryService = @"
INSERT INTO examination_services 
(id, examination_id, service_id, price) 
VALUES (NULL, @examination_id, @service_id, @price);";
                        cmd = new MySqlCommand(queryService, Db.conn);
                        cmd.Parameters.AddWithValue("@examination_id", examinationID);
                        cmd.Parameters.AddWithValue("@service_id", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@price", row.Cells[2].Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadExamID();
                MessageBox.Show("Lưu chỉ định thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                ResetConnection();
            }

        }
        private void btn_tinhtien_Click(object sender, EventArgs e)
        {
            UpdateTotalServicePrice();
        }
        private void UpdateTotalServicePrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dtgv_service_patient.Rows)
            {
                if (row.Cells["price2"].Value != null)
                {
                    decimal price;
                    if (decimal.TryParse(row.Cells["price2"].Value.ToString(), out price))
                    {
                        total += price;
                    }
                }
            }

            lb_total_price_service.Text = total.ToString("N0");
        }
        private void btn_pre_prescription_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            frm_popupLUMedication frm = new frm_popupLUMedication();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var row in frm.AllRows)
                {
                    int index = dtgv_med.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                        dtgv_med.Rows[index].Cells[i].Value = row.Cells[i].Value;


                }
                foreach (DataGridViewRow row in dtgv_med.Rows)

                    if (row.Cells[9].Value != null && decimal.TryParse(row.Cells[9].Value.ToString(), out decimal rowTotal))

                        total += rowTotal;


                lb_totalprice.Text = "Tổng tiền: " + total.ToString("N0") + " đ";
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dtgv_med.Rows.Clear();
            txb_quantity.Value = 1;
            txb_totalpricepermed.Text = "0";
            txb_times.Text = "";
            
            txb_dosage.Text = "";
            txb_price.Text = "";
            txb_mednote.Text = "";
            txb_route.Text = "";
            txb_unit.Text = "";

        }
        




        private void btn_print_service_Click(object sender, EventArgs e)
        {

            var mabn = txb_id.Text;
            var tenbn = txb_name.Text;
            var diachi = txb_address.Text;
            var ngaysinh = txb_age.Text;
            var gioitinh = txb_gender.Text;
            var loidan = cb_doctornote.Text;
            var chandoan = cbo_diagnoses.Text;
            var chandoanphu = txb_reason.Text;
            var tongtien = lb_total_price_service.Text;
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");
            var sdt = txb_phone.Text;

            frm_report_service frm = new frm_report_service(
                GetDataTableFromDataGridView(dtgv_service_patient),
                mabn, tenbn, diachi, ngaysinh, gioitinh, loidan, chandoan, chandoanphu, ngaykham, tongtien,sdt // thêm tongtien
            );
            frm.ShowDialog();
        }
        private void btn_print_prescription_Click(object sender, EventArgs e)
        {
           
            var mabn = txb_id.Text;
            var tenbn = txb_name.Text;
            var diachi = txb_address.Text;
            var ngaysinh = txb_ngaysinh.Text;
            var gioitinh = txb_gender.Text;
            var loidan = cb_doctornote.Text;
            var chandoan = cbo_diagnoses.Text;
            var chandoanphu = txb_reason.Text;
            var tongtien = lb_totalprice.Text;
            var taikham = txb_taikham.Text;
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");
            var sdt = txb_phone.Text;
            List<string> medList = new List<string>();

            for (int i = 0; i < dtgv_med.Rows.Count; i++)
            {
                if (dtgv_med.Rows[i].IsNewRow) continue;
                var name = dtgv_med.Rows[i].Cells["med_name"].Value?.ToString() ?? "";
                var quantity = dtgv_med.Rows[i].Cells["quantity"].Value?.ToString() ?? "";
                var usage = dtgv_med.Rows[i].Cells["med_note"].Value?.ToString() ?? "";
                var unit =  dtgv_med.Rows[i].Cells["unit"].Value?.ToString() ?? "";
                // Căn lề phải tên thuốc cho đều (giả sử tối đa 30 ký tự, bạn có thể điều chỉnh)
                string line1 = $"{i + 1}/ {name.PadRight(30)} {quantity} {unit}";
                string line2 = $"   {usage}";

                medList.Add(line1);
                medList.Add(line2);
            }

            string thuocChiTiet = string.Join("\n", medList);




            frm_report_med frm = new frm_report_med(
              GetDataTableFromDataGridView(dtgv_med),
              mabn,
              tenbn,
              txb_ngaysinh.Text,   
              txb_address.Text,    
              gioitinh,
              loidan,
              chandoan,
              chandoanphu,
              ngaykham,
              tongtien,
              sdt,
              thuocChiTiet,
              taikham
      
          );
            frm.ShowDialog();


        }

        public DataTable GetDataTableFromDataGridView(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                string columnName = column.Name; 
                Type columnType = column.ValueType ?? typeof(string);
                dt.Columns.Add(columnName, columnType);
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value ?? DBNull.Value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;

        }
        private void btn_pre_service_Click(object sender, EventArgs e)
        {
            dtgv_service_patient.Rows.Clear();
            frm_popupLUService frm = new frm_popupLUService();
      
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var row in frm.AllRows)
                {
                    int index = dtgv_service_patient.Rows.Add();
                    for (int i = 0; i <= 2; i++)
                        dtgv_service_patient.Rows[index].Cells[i].Value = row.Cells[i].Value;
                    dtgv_service_patient.Rows[index].Cells[4].Value = "-";


                }
                decimal total = 0;
      
                foreach (DataGridViewRow row in dtgv_service_patient.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua dòng trắng cuối cùng

                    if (decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal value))

                        total += value;

                }
         
                lb_total_price_service.Text = total.ToString("N0") + " đ"; // Ví dụ: 100,000 đ
            }
        }

        private void dtgv_med_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TinhNgayTaiKham();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TinhNgayTaiKham();
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


    } 
}








