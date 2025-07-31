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
            dtgv_patients.Columns.Add("pulse", "Mạch");
            dtgv_patients.Columns.Add("blood_pressure", "Huyết áp");
            dtgv_patients.Columns.Add("respiratory_rate", "Nhịp thở");
            dtgv_patients.Columns.Add("weight", "Cân nặng");
            dtgv_patients.Columns.Add("height", "Chiều cao");
            dtgv_patients.Columns.Add("temperature", "Nhiệt độ");
            dtgv_patients.Columns.Add("last_diagnoses_id", "MCĐ cuối");
            dtgv_patients.Columns.Add("last_diagnoses_name", "TCĐ cuối");
            dtgv_patients.Columns.Add("state", "Tình trạng");
            foreach (DataGridViewColumn col in dtgv_patients.Columns)
                col.Visible = false;
            dtgv_patients.Columns["ID"].Visible = true;
            dtgv_patients.Columns["name"].Visible = true;
            dtgv_patients.Columns["time_patients"].Visible = true;
            dtgv_patients.Columns["state"].Visible = true;

            // Load data
            dtgv_patients.Rows.Clear();
            string sql = @"SELECT
                            p.id, 
                            p.name, 
                            DATE_FORMAT(p.date_of_birth, '%d/%m/%Y') AS date_of_birth, 
                            p.gender, 
                            p.phone, 
                            p.address, 
                            DATE_FORMAT(p.updated_at, '%H:%i:%s') AS updated_time, 
                            p.pulse,
                            p.blood_pressure,
                            p.respiratory_rate,
                            p.weight,
                            p.height, 
                            p.temperature,
                            e.diagnosis_id AS last_diagnoses_id,
                            d.name AS last_diagnoses_name
                        FROM patients p
                        LEFT JOIN (
                            SELECT *
                            FROM examinations e1
                            WHERE e1.updated_at = (
                                SELECT MAX(e2.updated_at)
                                FROM examinations e2
                                WHERE e2.patient_id = e1.patient_id
                            )
                        ) e ON e.patient_id = p.id
                        LEFT JOIN diagnoses d ON e.diagnosis_id = d.id
                        WHERE DATE(p.updated_at) = CURDATE()
                        ORDER BY p.updated_at DESC;
                        ";
            Db.ResetConnection();
            MySqlCommand cmd = Db.CreateCommand(sql);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                object lastDiagnosesId = dr["last_diagnoses_id"];
                string state = (lastDiagnosesId == null || lastDiagnosesId == DBNull.Value) ? "Mới đăng ký" : "Đã từng khám";

                int rowIndex = dtgv_patients.Rows.Add(
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
                    dr["temperature"],
                    dr["last_diagnoses_id"],
                    dr["last_diagnoses_name"],
                    state
                );

                // Lấy dòng vừa thêm
                DataGridViewRow row = dtgv_patients.Rows[rowIndex];

                // Tô màu cả dòng theo giá trị state
                if (state == "Mới đăng ký")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
     
                }

            }



            dr.Close();
            Db.ResetConnection();





        }

        private void frm_examination_Load(object sender, EventArgs e)
        {

            LoadExamID();
            LoadGrid();
            LoadComboboxDiagnoses();
            LoadComboboxDoctorNote();
            LoadDTGV_Service();
            LoadDTGV_Med();
            Update_FollowUpDate();
            cbo_diagnoses.SelectedIndex = 0;





        }

        private void dtgv_patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadExamID();
            id = Convert.ToInt32(dtgv_patients.CurrentRow.Cells["ID"].Value);
            selectedPatientId = id;
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
            if (dtgv_patients.CurrentRow.Cells["last_diagnoses_id"].Value == null || dtgv_patients.CurrentRow.Cells["last_diagnoses_id"].Value == DBNull.Value)
                cbo_diagnoses.SelectedIndex = -1;
            else cbo_diagnoses.SelectedValue = dtgv_patients.CurrentRow.Cells["last_diagnoses_id"].Value.ToString();


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
            cbo_diagnoses.SelectedIndex = 0;
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
                Db.ResetConnection(); // Mở kết nối một lần


                int diagnosisId;

                // 1. Kiểm tra chẩn đoán đã tồn tại
                using (MySqlCommand cmdCheck = new MySqlCommand("SELECT id FROM diagnoses WHERE name = @name", Db.conn))
                {
                    cmdCheck.Parameters.AddWithValue("@name", cbo_diagnoses.Text.Trim());
                    object result = cmdCheck.ExecuteScalar();

                    if (result == null)
                    {
                        // 2. Nếu chưa có, thêm mới
                        using (MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO diagnoses (name) VALUES (@name)", Db.conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@name", cbo_diagnoses.Text.Trim());
                            cmdInsert.ExecuteNonQuery();
                        }

                        using (MySqlCommand cmdGetId = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn))
                        {
                            diagnosisId = Convert.ToInt32(cmdGetId.ExecuteScalar());
                        }
                    }
                    else
                    {
                        diagnosisId = Convert.ToInt32(result);
                    }
                }

                // 3. Thêm phiếu khám
                string queryExamination = $@"
                    INSERT INTO examinations (
                        id, patient_id, reason, diagnosis_id, doctor_note_id, note, 
                        pulse, blood_pressure, respiratory_rate, weight, height, temperature, 
                        type, follow_up, price, state, created_at, updated_at
                    ) 
                    VALUES (
                        NULL, 
                        @patient_id, @reason, @diagnosis_id, @doctor_note_id, @note,
                        @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature,
                        'chỉ định', NULL, @price, 'Chưa gọi', CURRENT_TIMESTAMP(), CURRENT_TIMESTAMP()
                    );";

                using (MySqlCommand cmdExam = new MySqlCommand(queryExamination, Db.conn))
                {
                    cmdExam.Parameters.AddWithValue("@patient_id", txb_id.Text);
                    cmdExam.Parameters.AddWithValue("@reason", txb_reason.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@diagnosis_id", diagnosisId);
                    cmdExam.Parameters.AddWithValue("@doctor_note_id", cb_doctornote.SelectedValue);
                    cmdExam.Parameters.AddWithValue("@note", txb_note.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@pulse", txb_pulse.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@blood_pressure", txb_blood_pressure.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@respiratory_rate", txb_respiratory_rate.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@weight", txb_weight.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@height", txb_height.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@temperature", txb_temperature.Text.Trim());
                    cmdExam.Parameters.AddWithValue("@price", lb_total_price_service.Text.Replace(".", "").Replace(" đ", "").Trim());

                    cmdExam.ExecuteNonQuery();
                }

                // 4. Lấy ID phiếu khám vừa thêm
                int examinationID;
                using (MySqlCommand cmdGetExamId = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn))
                {
                    examinationID = Convert.ToInt32(cmdGetExamId.ExecuteScalar());
                }

                // 5. Thêm các dịch vụ chỉ định
                foreach (DataGridViewRow row in dtgv_service_patient.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string queryService = @"
            INSERT INTO examination_services 
            (id, examination_id, service_id, price) 
            VALUES (NULL, @examination_id, @service_id, @price);";

                        using (MySqlCommand cmdService = new MySqlCommand(queryService, Db.conn))
                        {
                            cmdService.Parameters.AddWithValue("@examination_id", examinationID);
                            cmdService.Parameters.AddWithValue("@service_id", row.Cells["id_service2"].Value);
                            string priceStr = row.Cells["price2"].Value?.ToString().Replace(".", "").Trim();
                            int price = 0;
                            int.TryParse(priceStr, out price); // an toàn nếu dữ liệu rỗng/lỗi
                            cmdService.Parameters.AddWithValue("@price", price);
                            cmdService.ExecuteNonQuery();
                        }
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
                if (Db.conn != null && Db.conn.State == ConnectionState.Open)
                {
                    Db.conn.Close();
                }
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
                int stt = 1;

                foreach (var row in frm.AllRows)
                {
                    int index = dtgv_service_patient.Rows.Add();

                    dtgv_service_patient.Rows[index].Cells[0].Value = row.Cells[0].Value; // Mã chỉ định
                    dtgv_service_patient.Rows[index].Cells[1].Value = stt++;              // STT
                    dtgv_service_patient.Rows[index].Cells[2].Value = row.Cells[1].Value; // Tên chỉ định
                    dtgv_service_patient.Rows[index].Cells[3].Value = row.Cells[2].Value; // Thành tiền
                    dtgv_service_patient.Rows[index].Cells[4].Value = "";                 // Ghi chú
                    dtgv_service_patient.Rows[index].Cells[5].Value = "-";                // Thao tác
                }

                // Tính tổng thành tiền
                decimal total = 0;
                foreach (DataGridViewRow row in dtgv_service_patient.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal value))
                        total += value;
                }

                lb_total_price_service.Text = total.ToString("N0") + " đ";
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
            dtgv_patient_med.Rows[r].Cells["morning"].Value = "";
            dtgv_patient_med.Rows[r].Cells["afternoon"].Value = "";
            dtgv_patient_med.Rows[r].Cells["days_of_use"].Value = "";
        }

        private void dtgv_patient_med_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dtgv_patient_med.Columns[e.ColumnIndex].Name != "delete_med") return;
            dtgv_patient_med.Rows.RemoveAt(e.RowIndex);
        }

        private void dtgv_patient_med_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dtgv_patient_med.Rows.Count) return;

            UpdateMedicationSummary(); // gọi xử lý

        }

        private void dtgv_patient_med_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dtgv_patient_med.IsCurrentCellDirty)

            //    dtgv_patient_med.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }

        private void btn_save_med_Click(object sender, EventArgs e)
        {
            if (txb_name.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bệnh nhân và phiếu khám!");
                return;
            }
            if (dtgv_patient_med.Rows.Count == 1)
            {
                MessageBox.Show("Vui lòng thêm thuốc vào toa!");
                return;
            }

            try
            {
                string insertExaminationQuery = $@"
                    INSERT INTO `examinations` (
                        `id`, `patient_id`, `reason`, `diagnosis_id`, `doctor_note_id`, `note`,
                        `pulse`, `blood_pressure`, `respiratory_rate`, `weight`, `height`,
                        `temperature`, `type`, `follow_up`, `price`, `state`, `created_at`, `updated_at`
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
                        '{txb_follow_up.Text}',
                        '{Convert.ToInt32(txb_total_price_med.Text.Replace(".", ""))}',
                        'Chưa gọi',
                        current_timestamp(),
                        current_timestamp()
                    );";

                Db.ExecuteNonQuery(insertExaminationQuery);

                string query = "";
                foreach (DataGridViewRow row in dtgv_patient_med.Rows)
                {
                    if (row.IsNewRow) continue;

                    string medId = row.Cells["id_med_2"].Value?.ToString()?.Trim();
                    string morningStr = row.Cells["morning"].Value?.ToString()?.Trim();
                    string afternoonStr = row.Cells["afternoon"].Value?.ToString()?.Trim();
                    string unit = row.Cells["unit_2"].Value?.ToString()?.Trim();
                    string note = row.Cells["note_2"].Value?.ToString()?.Trim();

                    string dayStr = row.Cells["days_of_use"].Value?.ToString()?.Trim();
                    string totalStr = row.Cells["total_quantity"].Value?.ToString()?.Trim();

                    // Xử lý NULL an toàn cho các số nguyên
                    string morning = string.IsNullOrEmpty(morningStr) ? "NULL" : morningStr;
                    string afternoon = string.IsNullOrEmpty(afternoonStr) ? "NULL" : afternoonStr;
                    string days_of_use = string.IsNullOrEmpty(dayStr) ? "NULL" : dayStr;
                    string total_quantity = string.IsNullOrEmpty(totalStr) ? "NULL" : totalStr;

                    // Escape các giá trị chuỗi để tránh lỗi nếu có dấu nháy đơn
                    unit = unit?.Replace("'", "''");
                    note = note?.Replace("'", "''");

                    query = $@"
                        INSERT INTO `examination_medications` (
                            `id`, `examination_id`, `medication_id`, `morning`, `afternoon`, `unit`,
                            `days_of_use`, `total_quantity_med`, `note`,
                            `created_at`, `updated_at`
                        ) VALUES (
                            NULL,
                            '{txb_exam_id.Text}',
                            '{medId}',
                            {morning},
                            {afternoon},
                            '{unit}',
                            {days_of_use},
                            {total_quantity},
                            '{note}',
                            current_timestamp(),
                            current_timestamp()
                        );";
                    Db.ExecuteNonQuery(query);
                }
                LoadExamID();
                MessageBox.Show("Thêm toa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:\n" + ex.Message);
            }







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
                    dosages.Add($"Chiều uống {afternoon:00} {unit}");

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
                chandoan, chandoanphu, ngaykham,
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
        private void UpdateMedicationSummary()
        {
            foreach (DataGridViewRow row in dtgv_patient_med.Rows)
            {
                if (row.IsNewRow) continue;

                int days_of_use = 0, morning = 0, afternoon = 0;

                int.TryParse(row.Cells["days_of_use"].Value?.ToString(), out days_of_use);
                int.TryParse(row.Cells["morning"].Value?.ToString(), out morning);
                int.TryParse(row.Cells["afternoon"].Value?.ToString(), out afternoon);

                int total_med = days_of_use * (morning + afternoon);
                row.Cells["total_quantity"].Value = total_med > 0 ? (object)total_med : "";
            }

            maxDayOfUse = 0;
            foreach (DataGridViewRow r in dtgv_patient_med.Rows)
            {
                if (r.IsNewRow) continue;
                if (r.Cells["days_of_use"].Value != null &&
                    int.TryParse(r.Cells["days_of_use"].Value.ToString(), out int day))
                {
                    if (day > maxDayOfUse)
                        maxDayOfUse = day;
                }
            }

            lb_dayofuse.Text = maxDayOfUse + "";
            int total = 50000 * maxDayOfUse;
            txb_total_price_med.Text = total.ToString("#,##0");
            txb_follow_up.Text = DateTime.Today.AddDays(maxDayOfUse).ToString("dd/MM/yyyy");


            Update_FollowUpDate();
        }

        private void btn_select_med_Click(object sender, EventArgs e)
        {
            frm_popupLUMedication frm = new frm_popupLUMedication();
            dtgv_patient_med.Rows.Clear();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var rowData in frm.selectedMedications)
                    dtgv_patient_med.Rows.Add(rowData);
                UpdateMedicationSummary();

            }


        }

        private void dtgv_med_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgv_service_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}








