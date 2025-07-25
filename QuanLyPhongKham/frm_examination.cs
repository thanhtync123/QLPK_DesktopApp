using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyPhongKham
{
    public partial class frm_examination : Form
    {
        int id;
        private Timer timer = new Timer();
        private int? selectedPatientId = null;
        int maxDayOfUse = 0;
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
        private void UpdateSTT()
        {
            for (int i = 0; i < dtgv_service_patient.Rows.Count; i++)
            {
                dtgv_service_patient.Rows[i].Cells["STT"].Value = i + 1;
            }
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
            LoadExamID();
            LoadDTGV_Service();
            LoadDTGV_Med();


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




        private void btn_addmed_Click(object sender, EventArgs e)
        {





        }





        private void dtgv_med_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void LoadDTGV_Med()
        {
            ResetConnection();
            string query = @"SELECT `id`, `name`, `note`,`unit`, `price` FROM `medications` order by name";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            while (Db.dr.Read())
            {
                int i = dtgv_med.Rows.Add();
                DataGridViewRow drr = dtgv_med.Rows[i];
                drr.Cells["id_med"].Value = Db.dr["id"];
                drr.Cells["med_name"].Value = Db.dr["name"];
                drr.Cells["price"].Value = Db.dr["price"];
                drr.Cells["note"].Value = Db.dr["note"];
                drr.Cells["unit"].Value = Db.dr["unit"];
                drr.Cells["add_med"].Value = "+";
            }
            Db.dr.Close();
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
                    UpdateSTT(); // Cập nhật số thứ tự trong DataGridView dịch vụ chỉ định


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
                        string queryService = $@"
                        INSERT INTO examination_services 
                        (id, examination_id, service_id, price) 
                        VALUES (NULL, @examination_id, @service_id, @price);";
                        cmd = new MySqlCommand(queryService, Db.conn);
                        cmd.Parameters.AddWithValue("@examination_id", examinationID);
                        cmd.Parameters.AddWithValue("@service_id", row.Cells["id_service2"].Value);
                        cmd.Parameters.AddWithValue("@price", row.Cells["price2"].Value);
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
                mabn, tenbn, diachi, ngaysinh, gioitinh, loidan, chandoan, chandoanphu, ngaykham, tongtien, sdt // thêm tongtien
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

        private void dtgv_med_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dtgv_med.Columns[e.ColumnIndex].Name != "add_med") return;

            int r = dtgv_patient_med.Rows.Add();
            dtgv_patient_med.Rows[r].Cells["id_med_2"].Value = dtgv_med.Rows[e.RowIndex].Cells["id_med"].Value;
            dtgv_patient_med.Rows[r].Cells["med_name_2"].Value = dtgv_med.Rows[e.RowIndex].Cells["med_name"].Value;
            dtgv_patient_med.Rows[r].Cells["note_2"].Value = dtgv_med.Rows[e.RowIndex].Cells["note"].Value;
            dtgv_patient_med.Rows[r].Cells["unit_2"].Value = dtgv_med.Rows[e.RowIndex].Cells["unit"].Value;
        }

        private void dtgv_patient_med_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dtgv_patient_med.Columns[e.ColumnIndex].Name != "delete_med") return;
            dtgv_patient_med.Rows.RemoveAt(e.RowIndex);
        }

        private void dtgv_patient_med_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dtgv_patient_med.Rows.Count) return;

            var row = dtgv_patient_med.Rows[e.RowIndex];
            var days_of_useCell = Convert.ToInt16(row.Cells["days_of_use"].Value);
            var morningCell = Convert.ToInt16(row.Cells["morning"].Value);
            var afternoonCell = Convert.ToInt16(row.Cells["afternoon"].Value);
            row.Cells["total_quantity"].Value = days_of_useCell * (morningCell + afternoonCell);


            foreach (DataGridViewRow r in dtgv_patient_med.Rows)
            {
                if (r.Cells["days_of_use"].Value != null && int.TryParse(r.Cells["days_of_use"].Value.ToString(), out int day))
                {
                    if (day > maxDayOfUse)
                        maxDayOfUse = day;
                }
            }
            lb_dayofuse.Text = maxDayOfUse + "";
            int total = 50000 * maxDayOfUse;
            txb_total_price_med.Text = string.Format("{0:N0} đ", total);
            Update_FollowUpDate();











        }

        private void dtgv_patient_med_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dtgv_patient_med.IsCurrentCellDirty)

            //    dtgv_patient_med.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }

        private void btn_save_med_Click(object sender, EventArgs e)
        {
            if (txb_name.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bệnh nhân và phiếu khám!");
                return;
            }
            string insertExaminationQuery = $@"
            INSERT INTO `examinations` (
                `id`,
                `patient_id`,
                `reason`,
                `diagnosis_id`,
                `doctor_note_id`,
                `note`,
                `pulse`,
                `blood_pressure`,
                `respiratory_rate`,
                `weight`,
                `height`,
                `temperature`,
                `type`,
                `created_at`,
                `updated_at`
            ) VALUES (
                NULL,
                '{txb_id.Text}',
                NULL,
                '{cbo_diagnoses.SelectedValue}',
                '{cb_doctornote.SelectedValue}',
                '{txb_note.Text}',
                '{txb_pulse.Text}',
                '{txb_blood_pressure.Text}',   
                '{txb_respiratory_rate.Text}',
                '{txb_weight.Text}',
                '{txb_height.Text}',
                '{txb_temperature.Text}',
                'toa thuốc',
                current_timestamp(),
                current_timestamp()
            );";
            Db.ExecuteNonQuery(insertExaminationQuery);
            //MessageBox.Show("Thêm phiếu khám thành công!");


            foreach (DataGridViewRow row in dtgv_patient_med.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối

                string query = $@"
                INSERT INTO `examination_medications` (
                    `id`, `examination_id`, `medication_id`, `morning`, `afternoon`, `unit`,
                    `days_of_use`, `total_quantity_med`, `note`,`follow_up`,`state`,
                    `created_at`, `updated_at`
                ) VALUES (
                    NULL,
                    '{txb_exam_id.Text}',
                    '{row.Cells["id_med_2"].Value?.ToString()}',
                    '{row.Cells["morning"].Value?.ToString()}',
                    '{row.Cells["afternoon"].Value?.ToString()}',
                    '{row.Cells["unit_2"].Value?.ToString()}',
                    '{row.Cells["days_of_use"].Value?.ToString()}',
                    '{row.Cells["total_quantity"].Value?.ToString()}',
                    '{row.Cells["note_2"].Value?.ToString()}',
                    '{txb_follow_up.Text}',
                    'Chưa gọi',
                    current_timestamp(),
                    current_timestamp()
                );";

                Db.ExecuteNonQuery(query);
            }

            MessageBox.Show("Thêm toa thành công!");






        }
        private void Update_FollowUpDate()
        {
            if (chb_follow_up.Checked)
            {
                DateTime followUpDate = DateTime.Now.AddDays(maxDayOfUse);
                string formattedDate = followUpDate.ToString("dd/MM/yyyy");
                txb_follow_up.Text = formattedDate;
            }
            else
            {
                txb_follow_up.Text = "Không";
            }
        }
        private void chb_follow_up_CheckedChanged(object sender, EventArgs e)
        {
            Update_FollowUpDate();
        }

        private void btn_print_med_Click(object sender, EventArgs e)
        {
            var mabn = txb_id.Text;
            var tenbn = txb_name.Text;
            var diachi = txb_address.Text;
            var ngaysinh = txb_age.Text;
            var loidan = cb_doctornote.Text;
            var chandoan = cbo_diagnoses.Text;
            var chandoanphu = txb_reason.Text;
            var tongtien = txb_total_price_med.Text;
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");
            var sdt = txb_phone.Text;
            var taikham = txb_follow_up.Text;
            var songaythuoc = lb_dayofuse.Text;
            string thuoc = "";
            int stt = 1;

            foreach (DataGridViewRow row in dtgv_patient_med.Rows)
            {
                if (row.IsNewRow) continue;

                string medName = row.Cells["med_name_2"].Value?.ToString().Trim() ?? "";
                string totalQty = row.Cells["total_quantity"].Value?.ToString().Trim() ?? "";
                string unit = row.Cells["unit_2"].Value?.ToString().Trim() ?? "";

                string morningStr = row.Cells["morning"].Value?.ToString().Trim() ?? "0";
                string afternoonStr = row.Cells["afternoon"].Value?.ToString().Trim() ?? "0";
                string note = row.Cells["note_2"].Value?.ToString().Trim() ?? "";

                int morning = int.TryParse(morningStr, out var m) ? m : 0;
                int afternoon = int.TryParse(afternoonStr, out var a) ? a : 0;

                // Dòng 1: STT / Tên thuốc + số lượng + đơn vị
                thuoc += $"{stt}/ {medName,-40}{totalQty} {unit}\r\n";

                // Dòng 2: Liều dùng
                List<string> dosages = new List<string>();
                if (morning > 0)
                    dosages.Add($"Sáng uống {morning:00} {unit}");
                if (afternoon > 0)
                    dosages.Add($"chiều uống {afternoon:00} {unit}");

                string dosageLine = string.Join(", ", dosages);

                if (!string.IsNullOrWhiteSpace(note))
                    dosageLine += $" ({note})";

                if (!string.IsNullOrWhiteSpace(dosageLine))
                    thuoc += dosageLine + "\r\n";

                // Cách dòng
                thuoc += "\r\n";
                stt++;
            }

            // Nếu cần bỏ dòng trắng cuối cùng:
            thuoc = thuoc.TrimEnd();


            var frm = new frm_report_med(
                mabn, tenbn, ngaysinh, diachi, loidan,
                chandoan, chandoanphu, ngaykham, // thêm chandoanphu vào đây
                tongtien, sdt, thuoc, taikham, songaythuoc
            );

            frm.ShowDialog();

        }

        private void txb_med_search_TextChanged(object sender, EventArgs e)
        {
            ResetConnection();
            dtgv_med.Rows.Clear();
            string query = $@"
                        SELECT `id`, `name`, `note`, `unit`, `price`
                        FROM `medications`
                        WHERE `name` LIKE '%{txb_med_search.Text}%'
                        ORDER BY `name`";

            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            while (Db.dr.Read())
            {
                int i = dtgv_med.Rows.Add();
                DataGridViewRow drr = dtgv_med.Rows[i];
                drr.Cells["id_med"].Value = Db.dr["id"];
                drr.Cells["med_name"].Value = Db.dr["name"];
                drr.Cells["price"].Value = Db.dr["price"];
                drr.Cells["note"].Value = Db.dr["note"];
                drr.Cells["unit"].Value = Db.dr["unit"];
                drr.Cells["add_med"].Value = "+";
            }
            Db.dr.Close();
        }
    }
}








