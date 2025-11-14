using System;
using System.CodeDom;
using System.Collections;
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
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
        public static event Action OnExamChanged;
        public frm_examination()
        {
            InitializeComponent();
            frm_patients.OnPatientChanged += () => LoadGrid();

        }

        private void UpdateSTT()
        {
            int stt = 1;
            foreach (DataGridViewRow row in dtgv_service_patient.Rows)
            {
                // if (row.IsNewRow) continue; // bỏ qua dòng trống cuối

                if (row.Cells["name_service2"].Value != null &&
                    row.Cells["name_service2"].Value.ToString() == "Công khám")
                {
                    row.Cells["STT"].Value = "-"; // gán STT = -
                    continue;
                }

                row.Cells["STT"].Value = stt;
                stt++;
            }


        }
        private void SetUpGridPatient()
        {
            dtgv_patients.AutoGenerateColumns = false;
            dtgv_patients.Columns["last_exam_id"].DataPropertyName = "exam_id";
            dtgv_patients.Columns["symptoms"].DataPropertyName = "symptoms";
            dtgv_patients.Columns["STT_P"].DataPropertyName = "STT_P";
            dtgv_patients.Columns["ID_P"].DataPropertyName = "id"; // từ SQL p.id
            dtgv_patients.Columns["name_p"].DataPropertyName = "name"; // từ SQL p.name
            dtgv_patients.Columns["date_of_birth_p"].DataPropertyName = "date_of_birth"; // SQL DATE_FORMAT
            dtgv_patients.Columns["gender_p"].DataPropertyName = "gender";
            dtgv_patients.Columns["phone_p"].DataPropertyName = "phone";
            dtgv_patients.Columns["address_p"].DataPropertyName = "address";
            dtgv_patients.Columns["pulse_p"].DataPropertyName = "pulse";
            dtgv_patients.Columns["blood_pressure_p"].DataPropertyName = "blood_pressure";
            dtgv_patients.Columns["respiratory_rate_p"].DataPropertyName = "respiratory_rate";
            dtgv_patients.Columns["weight_p"].DataPropertyName = "weight";
            dtgv_patients.Columns["height_p"].DataPropertyName = "height";
            dtgv_patients.Columns["temperature_p"].DataPropertyName = "temperature";
            dtgv_patients.Columns["last_diagnoses_id"].DataPropertyName = "last_diagnoses_id";
            dtgv_patients.Columns["last_diagnoses_name"].DataPropertyName = "last_diagnoses_name";
            dtgv_patients.Columns["time_patient"].DataPropertyName = "updated_time"; // SQL DATE_FORMAT
            dtgv_patients.Columns["state"].DataPropertyName = "state";
        }

        private void LoadGrid()
        {

            string sql = @"
                            SELECT
                            MAX(e.id) AS exam_id, 
                            p.id, 
                            p.name, 
                            YEAR(p.date_of_birth) AS date_of_birth, 
                            p.gender, 
                            p.phone, 
                            p.address, 
                            DATE_FORMAT(p.updated_at, '%H:%i') AS updated_time, 
                            p.pulse,
                            p.blood_pressure,
                            p.respiratory_rate,
                            p.weight,
                            p.height, 
                            p.temperature,
                            MAX(e.symptoms) as symptoms,
                            MAX(e.diagnosis_id) AS last_diagnoses_id,  -- Lấy giá trị MAX của e.diagnosis_id
                            MAX(d.name) AS last_diagnoses_name  -- Lấy giá trị MAX của d.name
                        FROM patients p
                            LEFT JOIN examinations e ON p.id = e.patient_id
                                AND e.id = (SELECT MAX(e2.id) FROM examinations e2 WHERE e2.patient_id = p.id)
                            LEFT JOIN diagnoses d ON d.id = e.diagnosis_id
                        WHERE p.updated_at >= CURDATE() 
                            AND p.updated_at < CURDATE() + INTERVAL 1 DAY
                        GROUP BY p.id
                        ORDER BY p.updated_at DESC;

                        ";
            Db.LoadDTGV(dtgv_patients, sql);





        }

        private void frm_examination_Load(object sender, EventArgs e)
        {
            SetUpGridPatient();
            LoadComboboxDiagnoses();
            LoadComboboxDoctorNote();
            LoadExamID();
            LoadGrid();
            LoadDTGV_Service();
            LoadDTGV_Med();
            Update_FollowUpDate();
            lb_d0.Text = "";
            lb_d1.Text = "";
            dtgv_service_patient.Rows.Add("", "-", "Công khám", "Miễn phí", "", "-");
            btn_update_examination.Enabled = false;
            btn_select_med.Enabled = false;
            btn_tinhtien.Enabled = false;
            btn_pre_service.Enabled = false;
            loadComboboxServiceSet();
            loadComboboxMedicationSet();


        }
        private void loadComboboxMedicationSet()
        {
            string query = @"
            select * from preset_medications_set order by name asc
                     ";

            Db.ResetConnection();
            MySqlCommand cmd = new MySqlCommand(query, Db.conn);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);

            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["name"] = "-- Chọn toa thuốc --";
            dt.Rows.InsertAt(dr, 0);

            cb_med_set.DataSource = dt;
            cb_med_set.DisplayMember = "name";
            cb_med_set.ValueMember = "id";

            cb_med_set.SelectedIndex = 0;
            Db.conn.Close();
        }
        private void loadComboboxServiceSet()
        {
            string query = @"
                SELECT 
                    pss.id, 
                    CONCAT(pss.name, ' - ', FORMAT(SUM(s.price), 0)) AS display
                FROM preset_services ps
                INNER JOIN services s
                    ON ps.id_preset_services = s.id
                INNER JOIN preset_services_set pss
                    ON ps.id_preset_services_set = pss.id
                GROUP BY pss.id, pss.name
    ";

            Db.ResetConnection();
            MySqlCommand cmd = new MySqlCommand(query, Db.conn);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);

            DataRow dr = dt.NewRow();
            dr["id"] = 0; 
            dr["display"] = "-- Chọn gói dịch vụ --";
            dt.Rows.InsertAt(dr, 0); 

            cb_services_set.DataSource = dt;
            cb_services_set.DisplayMember = "display"; 
            cb_services_set.ValueMember = "id"; 

            cb_services_set.SelectedIndex = 0; 
            Db.conn.Close();
        }



        private void dtgv_patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            LoadExamID();
            btn_tinhtien.Enabled = true;
            btn_pre_service.Enabled = true;
            btn_select_med.Enabled = true;
            btn_update_examination.Enabled = false;
            btn_save_examination_service.Enabled = true;
            id = Convert.ToInt32(dtgv_patients.CurrentRow.Cells["ID_P"].Value);
            selectedPatientId = id;
            txb_name.Text = dtgv_patients.CurrentRow.Cells["name_p"].Value.ToString();
            txb_id.Text = id.ToString();
            txb_ngaysinh.Text = dtgv_patients.CurrentRow.Cells["date_of_birth_p"].Value.ToString();
            int lastFourChars = Convert.ToInt32(txb_ngaysinh.Text.Substring(txb_ngaysinh.Text.Length - 4));
            int currentYear = DateTime.Now.Year;
            txb_age.Text = (currentYear - lastFourChars).ToString();
            txb_address.Text = dtgv_patients.CurrentRow.Cells["address_p"].Value.ToString();
            txb_gender.Text = dtgv_patients.CurrentRow.Cells["gender_p"].Value.ToString();
            txb_phone.Text = dtgv_patients.CurrentRow.Cells["phone_p"].Value.ToString();
            txb_pulse.Text = dtgv_patients.CurrentRow.Cells["pulse_p"].Value.ToString();
            txb_blood_pressure.Text = dtgv_patients.CurrentRow.Cells["blood_pressure_p"].Value.ToString();
            txb_respiratory_rate.Text = dtgv_patients.CurrentRow.Cells["respiratory_rate_p"].Value.ToString();
            txb_weight.Text = dtgv_patients.CurrentRow.Cells["weight_p"].Value.ToString();
            txb_height.Text = dtgv_patients.CurrentRow.Cells["height_p"].Value.ToString();
            txb_temperature.Text = dtgv_patients.CurrentRow.Cells["temperature_p"].Value.ToString();
            txb_symptoms.Text = dtgv_patients.CurrentRow.Cells["symptoms"].Value.ToString();

            if (dtgv_patients.CurrentRow.Cells["last_diagnoses_id"].Value == null || dtgv_patients.CurrentRow.Cells["last_diagnoses_id"].Value == DBNull.Value)
                cbo_diagnoses.SelectedIndex = 0;
            else
                cbo_diagnoses.SelectedValue = dtgv_patients.CurrentRow.Cells["last_diagnoses_id"].Value.ToString();
            var idVal = dtgv_patients.CurrentRow.Cells["last_diagnoses_id"].Value;
            var nameVal = dtgv_patients.CurrentRow.Cells["last_diagnoses_name"].Value;
            if (idVal != null && idVal != DBNull.Value && (nameVal == null || nameVal == DBNull.Value || nameVal.ToString().Trim() == ""))
                lb_d0.Text = "Lần khám trước: Tên chẩn đoán được bỏ trống";
            else lb_d0.Text = "";

            string state = dtgv_patients.CurrentRow.Cells["state"].Value?.ToString()?.Trim();

            if (state == "Vừa tiếp nhận")
                lb_d1.Text = "";
            else
                lb_d1.Text = dtgv_patients.CurrentRow.Cells["symptoms"].Value == DBNull.Value || dtgv_patients.CurrentRow.Cells["symptoms"].Value.ToString() == ""
                    ? "Lần khám trước triệu chứng được bỏ trống" : "";







        }
        private void LoadComboboxDoctorNote()
        {

            string query = "SELECT id, content FROM doctor_notes order by content asc";
            Db.LoadComboBoxData(cb_doctornote, query, "content", "id");

        }
        private void LoadComboboxDiagnoses()
        {
            string query = "SELECT id, name FROM diagnoses order by name asc ";
            Db.LoadComboBoxData(cbo_diagnoses, query, "name", "id");
            cbo_diagnoses.SelectedIndex = 0;
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
            int stt = 1;
            while (Db.dr.Read())
            {
                int i = dtgv_med.Rows.Add();
                DataGridViewRow drr = dtgv_med.Rows[i];
                drr.Cells["stt_med"].Value = stt++;
                drr.Cells["id_med"].Value = Db.dr["id"];
                drr.Cells["med_name"].Value = Db.dr["name"];
                drr.Cells["price"].Value = Db.dr["price"];
                drr.Cells["note"].Value = Db.dr["note"];
                drr.Cells["unit"].Value = Db.dr["unit"];
                drr.Cells["add_med"].Value = "+";
                drr.Cells["add_med"].Style.Font = new Font("Times New Roman", 22, FontStyle.Bold);
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

                    diagnosisID = Convert.ToInt32(diagnosisResult);

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
        (id, patient_id, symptoms, diagnosis_id, doctor_note_id, note, pulse, blood_pressure, respiratory_rate, weight, height, temperature, type, created_at, updated_at) 
        VALUES 
        (NULL, @patient_id, @symptoms, @diagnosis_id, @doctor_note_id, @note, @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature, @type, current_timestamp(), current_timestamp());";

                MySqlCommand cmd = new MySqlCommand(queryExamination, Db.conn);
                cmd.Parameters.AddWithValue("@patient_id", Convert.ToInt16(txb_id.Text));
                cmd.Parameters.AddWithValue("@symptoms", txb_symptoms.Text);
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
                Db.ResetConnection();
                int diagnosisId;
                using (MySqlCommand cmdCheck = new MySqlCommand("SELECT id FROM diagnoses WHERE name = @name", Db.conn))
                {
                    cmdCheck.Parameters.AddWithValue("@name", cbo_diagnoses.Text.Trim());
                    object result = cmdCheck.ExecuteScalar();

                    if (result == null)
                    {
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
                        id, patient_id, symptoms, diagnosis_id, doctor_note_id, note, 
                        pulse, blood_pressure, respiratory_rate, weight, height, temperature, 
                        type, follow_up, price, state, created_at, updated_at
                    ) 
                    VALUES (
                        NULL, 
                        @patient_id,{(txb_symptoms.Text == "" ? "NULL" : $"'{txb_symptoms.Text}'")}, @diagnosis_id, @doctor_note_id, @note,
                        @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature,
                        'chỉ định', NULL, @price, 'Chưa gọi', CURRENT_TIMESTAMP(), CURRENT_TIMESTAMP()
                    );";

                using (MySqlCommand cmdExam = new MySqlCommand(queryExamination, Db.conn))
                {
                    cmdExam.Parameters.AddWithValue("@patient_id", txb_id.Text);
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
                    if (row.Cells[0].Value == "" || row.Cells[0].Value == null)

                        continue;

                    string serviceName = row.Cells[2].Value?.ToString();
                    if (serviceName == "Công khám" || serviceName == "Kiểm tra")
                        continue;



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
                LoadGrid();
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

            dtgv_service_patient.Rows.Clear();
            frm_popupLUService frm = new frm_popupLUService();
            frm.PatientID = Convert.ToInt16(txb_id.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btn_save_examination_service.Enabled = false;
                btn_update_examination.Enabled = true;
                int stt = 1;
                txb_exam_id.Text = frm.examId;
                foreach (var row in frm.AllRows)
                {
                    int index = dtgv_service_patient.Rows.Add();

                    dtgv_service_patient.Rows[index].Cells[0].Value = row.Cells[0].Value; // Mã chỉ định
                    if (row.Cells[1].Value.ToString() == "Công khám" || row.Cells[1].Value.ToString() == "Kiểm tra")
                        dtgv_service_patient.Rows[index].Cells[1].Value = "-"; // gán STT = -
                    else
                        dtgv_service_patient.Rows[index].Cells[1].Value = stt++;                // STT
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
            var trieuchung = txb_symptoms.Text;
            var tongtien = lb_total_price_service.Text;
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");
            var sdt = txb_phone.Text;

            frm_report_service frm = new frm_report_service(
                GetDataTableFromDataGridView(dtgv_service_patient),
                mabn, tenbn, diachi, ngaysinh, gioitinh, loidan, chandoan, trieuchung, ngaykham, tongtien, sdt // thêm tongtien
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
            frm.PatientID = Convert.ToInt16(txb_id.Text);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                int stt = 1;

                foreach (var row in frm.AllRows)
                {
                    int index = dtgv_service_patient.Rows.Add();

                    dtgv_service_patient.Rows[index].Cells[0].Value = row.Cells[0].Value; 
                    if (row.Cells[1].Value.ToString() == "Công khám" || row.Cells[1].Value.ToString() == "Kiểm tra")
                        dtgv_service_patient.Rows[index].Cells[1].Value = "-"; 
                    else
                        dtgv_service_patient.Rows[index].Cells[1].Value = stt++;           
                    dtgv_service_patient.Rows[index].Cells[2].Value = row.Cells[1].Value; 
                    dtgv_service_patient.Rows[index].Cells[3].Value = row.Cells[2].Value; 
                    dtgv_service_patient.Rows[index].Cells[4].Value = "";                
                    dtgv_service_patient.Rows[index].Cells[5].Value = "-";          
                }

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
            for (int i = 0; i < dtgv_patient_med.Rows.Count; i++)
                dtgv_patient_med.Rows[i].Cells["stt_med_patient"].Value = i + 1;

        }

        private void dtgv_patient_med_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dtgv_patient_med.Columns[e.ColumnIndex].Name != "delete_med") return;
            dtgv_patient_med.Rows.RemoveAt(e.RowIndex);
            for (int i = 0; i < dtgv_patient_med.Rows.Count; i++)
                dtgv_patient_med.Rows[i].Cells["stt_med_patient"].Value = i + 1;

        }

        private void dtgv_patient_med_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dtgv_patient_med.Rows.Count) return;

            UpdateMedicationSummary(); // gọi xử lý

        }


        private void btn_save_med_Click(object sender, EventArgs e)
        {
            Db.ResetConnection(); // Mở kết nối

            if (string.IsNullOrWhiteSpace(txb_name.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bệnh nhân và phiếu khám!");
                return;
            }

            if (dtgv_patient_med.Rows.Count < 1)
            {
                MessageBox.Show("Vui lòng thêm thuốc vào toa!");
                return;
            }

            try
            {
                int diagnosisId;
                string diagnosisName = cbo_diagnoses.Text.Trim().Replace("'", "''");

                // --- Kiểm tra hoặc thêm chẩn đoán ---
                string checkQuery = $"SELECT id FROM diagnoses WHERE name = '{diagnosisName}'";
                MySqlCommand cmdCheck = new MySqlCommand(checkQuery, Db.conn);
                object result = cmdCheck.ExecuteScalar();

                if (result == null)
                {
                    string insertDiagnosis = $"INSERT INTO diagnoses (name) VALUES ('{diagnosisName}')";
                    Db.ExecuteNonQuery(insertDiagnosis);
                    MySqlCommand cmdGetId = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn);
                    diagnosisId = Convert.ToInt32(cmdGetId.ExecuteScalar());
                }
                else
                {
                    diagnosisId = Convert.ToInt32(result);
                }

                int examId; // ID thật của phiếu khám
                string insertExam = "";

                // --- Thêm phiếu khám ---
                try
                {
                    insertExam = $@"
                INSERT INTO `examinations` (
                    `id`, `patient_id`, `symptoms`, `diagnosis_id`, `doctor_note_id`, `note`,
                    `pulse`, `blood_pressure`, `respiratory_rate`, `weight`, `height`,
                    `temperature`, `type`, `follow_up`, `price`, `state`, `created_at`, `updated_at`
                ) VALUES (
                    NULL,
                    '{txb_id.Text}',
                    {(txb_symptoms.Text == "" ? "NULL" : $"'{txb_symptoms.Text}'")},
                    '{diagnosisId}',
                    '{cb_doctornote.SelectedValue}',
                    '{txb_note.Text.Replace("'", "''")}',
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
                );
            ";

                    Db.ExecuteNonQuery(insertExam);
                    MySqlCommand cmdGetExamId = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn);
                    examId = Convert.ToInt32(cmdGetExamId.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm phiếu khám:\n" + ex.Message);
                    return; 
                }
                try
                {
                    foreach (DataGridViewRow row in dtgv_patient_med.Rows)
                    {
                        if (row.IsNewRow) continue;
                        if (row.Cells["id_med_2"].Value == null || string.IsNullOrWhiteSpace(row.Cells["id_med_2"].Value.ToString()))
                            continue;
                        string medId = row.Cells["id_med_2"].Value?.ToString()?.Trim();
                        string morning = string.IsNullOrEmpty(row.Cells["morning"].Value?.ToString()) ? "NULL" : row.Cells["morning"].Value.ToString().Replace(",", ".");
                        string noon = string.IsNullOrEmpty(row.Cells["noon"].Value?.ToString()) ? "NULL" : row.Cells["noon"].Value.ToString().Replace(",", ".");
                        string afternoon = string.IsNullOrEmpty(row.Cells["afternoon"].Value?.ToString()) ? "NULL" : row.Cells["afternoon"].Value.ToString().Replace(",", ".");
                        string evening = string.IsNullOrEmpty(row.Cells["evening"].Value?.ToString()) ? "NULL" : row.Cells["evening"].Value.ToString().Replace(",", ".");
                        string total = string.IsNullOrEmpty(row.Cells["total_quantity"].Value?.ToString()) ? "NULL" : row.Cells["total_quantity"].Value.ToString().Replace(",", ".");
                        string unit = row.Cells["unit_2"].Value?.ToString()?.Replace("'", "''");
                        string note = row.Cells["note_2"].Value?.ToString()?.Replace("'", "''");
                        string days = string.IsNullOrEmpty(row.Cells["days_of_use"].Value?.ToString()) ? "NULL" : row.Cells["days_of_use"].Value.ToString();

                        string insertMed = $@"
                    INSERT INTO `examination_medications` (
                        `id`, `examination_id`, `medication_id`, `morning`,`noon`, `afternoon`,`evening`, `unit`,
                        `days_of_use`, `total_quantity_med`, `note`, `created_at`, `updated_at`
                    ) VALUES (
                        NULL,
                        '{examId}', 
                        '{medId}',
                        {morning},
                        {noon},
                        {afternoon},
                        {evening},
                        '{unit}',
                        {days},
                        {total},
                        '{note}',
                        current_timestamp(),
                        current_timestamp()
                    );
                ";
                        Db.ExecuteNonQuery(insertMed);
                    }

                    LoadGrid();
                    LoadExamID();
                    MessageBox.Show("Thêm toa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm thuốc hoặc load dữ liệu:\n" + ex.Message);
                }
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

                txb_follow_up.Text = "Không";

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
            var chandoanphu = txb_symptoms.Text;
            string tongtien = chb_print_money.Checked ? txb_total_price_med.Text : "";
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
                string note = row.Cells["note_2"].Value?.ToString().Trim() ?? "";

                string morningStr = row.Cells["morning"].Value?.ToString().Trim() ?? "0";
                string afternoonStr = row.Cells["afternoon"].Value?.ToString().Trim() ?? "0";
                string noonStr = row.Cells["noon"].Value?.ToString().Trim() ?? "0";
                string eveningStr = row.Cells["evening"].Value?.ToString().Trim() ?? "0";




                float morning = float.TryParse(morningStr, out var m) ? m : 0;
                float noon = float.TryParse(noonStr, out var n) ? n : 0;
                float afternoon = float.TryParse(afternoonStr, out var a) ? a : 0;
                float evening = float.TryParse(eveningStr, out var ev) ? ev : 0;


                // Dòng 1: STT / Tên thuốc + số lượng + đơn vị (đơn vị in nghiêng)
                thuoc += $"{stt}/ <b>{medName}</b> &nbsp;&nbsp; <b>{totalQty}</b> <i>{unit}</i><br/>";

                // Dòng 2: Liều dùng
                List<string> dosages = new List<string>();

                if (morning > 0)
                    dosages.Add($"<b>Sáng</b> uống {morning:0.##} <i>{unit}</i>");
                if (noon > 0)
                    dosages.Add($"<b>TRƯA UỐNG {noon:0.##} <i>{unit}</i></b>");
                if (afternoon > 0)
                    dosages.Add($"<b>Chiều</b> uống {afternoon:0.##} <i>{unit}</i>");
                if (evening > 0)
                    dosages.Add($"<b>ㅤㅤTỐI UỐNG {evening:0.##} <i>{unit.ToUpper()}</i></b> </b> ");
                string dosageLine = string.Join(", ", dosages);

                if (!string.IsNullOrWhiteSpace(note))
                    dosageLine += $" ({note})";

                if (!string.IsNullOrWhiteSpace(dosageLine))
                    thuoc += dosageLine + "<br/>";
                thuoc += "<br/>";
                stt++;


            }
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
            int stt = 1;
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
                drr.Cells["stt_med"].Value = stt++;
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

                int days_of_use = 0;
                float morning = 0f, noon = 0f, afternoon = 0f, evening = 0f;

                int.TryParse(row.Cells["days_of_use"].Value?.ToString(), out days_of_use);
                float.TryParse(row.Cells["morning"].Value?.ToString(), out morning);
                float.TryParse(row.Cells["noon"].Value?.ToString(), out noon);
                float.TryParse(row.Cells["afternoon"].Value?.ToString(), out afternoon);
                float.TryParse(row.Cells["evening"].Value?.ToString(), out evening);

                float total_med = days_of_use * (morning + noon + afternoon + evening);
                float total_rounded = (float)Math.Ceiling(total_med);

                row.Cells["total_quantity"].Value = total_med > 0
                    ? total_rounded.ToString("0")
                    : "";
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
            frm.PatientID = Convert.ToInt16(txb_id.Text);
            dtgv_patient_med.Rows.Clear();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var rowData in frm.selectedMedications)
                    dtgv_patient_med.Rows.Add(rowData);
                UpdateMedicationSummary();
            }


        }

        private void dtgv_patient_med_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtgv_patient_med.CurrentCell.ColumnIndex == dtgv_patient_med.Columns["morning"].Index ||
                dtgv_patient_med.CurrentCell.ColumnIndex == dtgv_patient_med.Columns["noon"].Index ||
                dtgv_patient_med.CurrentCell.ColumnIndex == dtgv_patient_med.Columns["afternoon"].Index ||
                dtgv_patient_med.CurrentCell.ColumnIndex == dtgv_patient_med.Columns["evening"].Index
                )

                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress -= textBox1_KeyPress;
                    tb.KeyPress += textBox1_KeyPress;
                }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool hasInserted = false;
            foreach (DataGridViewRow row in dtgv_service_patient.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[1].Value.ToString() == "Công khám" || row.Cells[1].Value.ToString() == "Kiểm tra")
                    continue;
                int id_service;
                if (!int.TryParse(row.Cells["id_service2"].Value?.ToString(), out id_service))
                    continue;

                string checkQuery = $@"Select count(*)
                            from examination_services es
                            where service_id = {id_service}
                            and examination_id = {Convert.ToInt16(txb_exam_id.Text)} 
                                ";
                int count = Convert.ToInt32(Db.Scalar(checkQuery));

                if (count == 0)
                {
                    if (row.Cells[2].Value.ToString() == "Công khám" || row.Cells[2].Value.ToString() == "Kiểm tra")
                        continue;
                    try
                    {
                        string insertQuery = $@"
                        INSERT INTO examination_services(service_id, examination_id)
                        VALUES({id_service}, {Convert.ToInt16(txb_exam_id.Text)})";
                        Db.ExecuteNonQuery(insertQuery);
                        hasInserted = true;
                        btn_save_examination_service.Enabled = true;
                        btn_update_examination.Enabled = false;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);

                    }
                }

            }
            if (hasInserted)
            {
                MessageBox.Show("Cập nhật dịch vụ cho phiếu thành công");
                LoadExamID();
            }

        }

        private void dtgv_patients_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dtgv_patients.Columns["STT_P"] != null)
            {
                int totalRows = dtgv_patients.Rows.Count;
                dtgv_patients.Rows[e.RowIndex].Cells["STT_P"].Value = (totalRows - e.RowIndex).ToString();
            }

            var row = dtgv_patients.Rows[e.RowIndex];
            var cellValue = row.Cells["last_exam_id"].Value;

            if (cellValue == DBNull.Value || cellValue == null)
                row.Cells["state"].Value = "Vừa tiếp nhận";
            else
                row.Cells["state"].Value = "Đã từng khám";





        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control ctl = this.ActiveControl;
            while (ctl != null)
            {
                if (ctl is DataGridView) return base.ProcessCmdKey(ref msg, keyData);
                ctl = ctl.Parent;
            }

            // Scroll Form bằng phím
            int x = -this.AutoScrollPosition.X;
            int y = -this.AutoScrollPosition.Y;
            int step = 30;

            if (keyData == Keys.Left) x = Math.Max(0, x - step);
            else if (keyData == Keys.Right) x += step;
            else if (keyData == Keys.Up) y = Math.Max(0, y - step);
            else if (keyData == Keys.Down) y += step;
            else return base.ProcessCmdKey(ref msg, keyData);

            this.AutoScrollPosition = new Point(x, y);
            return true;
        }

        private void btn_cancel_reupdated_Click(object sender, EventArgs e)
        {


            string query = $@"UPDATE patients 
                         SET updated_at = DATE_SUB(NOW(), INTERVAL 1 DAY)
                     WHERE id={Convert.ToInt16(txb_id.Text)}";

            Db.ExecuteNonQuery(query);
            MessageBox.Show("Hủy tiếp nhận thành công!");
            LoadGrid();
        }

        private void dtgv_patients_Click(object sender, EventArgs e)
        {

        }

        private void btn_openSetMedForm_Click(object sender, EventArgs e)
        {
            frm_medications_set frm = new frm_medications_set();
            frm.FormBorderStyle = FormBorderStyle.Fixed3D;
            dtgv_patient_med.Rows.Clear();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var rowData in frm.selectedMedications)
                    dtgv_patient_med.Rows.Add(rowData);
                UpdateMedicationSummary();
            }
        }

        private void cb_services_set_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_services_set.SelectedIndex == 0) return;

            Db.ResetConnection();

            string query = $@"
        SELECT s.id, s.name, s.price, ps.note
        FROM preset_services ps
        INNER JOIN services s
            ON ps.id_preset_services = s.id
        WHERE ps.id_preset_services_set = {cb_services_set.SelectedValue}
    ";

            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();

            dtgv_service_patient.Rows.Clear();

            int firstRow = dtgv_service_patient.Rows.Add();
            DataGridViewRow rowDefault = dtgv_service_patient.Rows[firstRow];
            rowDefault.Cells["id_service2"].Value = 0;
            rowDefault.Cells["STT"].Value = "-"; 
            rowDefault.Cells["name_service2"].Value = "Công khám";
            rowDefault.Cells["price2"].Value = "Miễn phí";
            rowDefault.Cells["notes2"].Value = "";
            rowDefault.Cells["delete_service"].Value = "-";

            int stt = 1;
            while (Db.dr.Read())
            {
                int i = dtgv_service_patient.Rows.Add();
                DataGridViewRow row = dtgv_service_patient.Rows[i];
                row.Cells["id_service2"].Value = Db.dr["id"];
                row.Cells["STT"].Value = stt++; 
                row.Cells["name_service2"].Value = Db.dr["name"];
                row.Cells["price2"].Value = Db.dr["price"];
                row.Cells["notes2"].Value = Db.dr["note"];
                row.Cells["delete_service"].Value = "-";
            }

            Db.dr.Close();
            UpdateTotalServicePrice();
        }

        private void cb_med_set_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_med_set.SelectedIndex == 0) return;
            Db.ResetConnection();
            string query = $@"
             select m.id,m.name,pm.morning,pm.noon,pm.afternoon,pm.evening,pm.unit,pm.days_of_use,pm.total_quantity_med,pm.note 
             from preset_medications pm
             inner join medications m on m.id = pm.id_medications
             where id_preset_medications_set = {cb_med_set.SelectedValue}"
                            ;
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();

            dtgv_patient_med.Rows.Clear();
            int stt = 1;

            while (Db.dr.Read())
            {
                int i = dtgv_patient_med.Rows.Add();
                DataGridViewRow row = dtgv_patient_med.Rows[i];

                row.Cells["stt_med_patient"].Value = stt++;
                row.Cells["med_name_2"].Value = Db.dr["name"];
                row.Cells["morning"].Value = Db.dr["morning"];
                row.Cells["noon"].Value = Db.dr["noon"];
                row.Cells["afternoon"].Value = Db.dr["afternoon"];
                row.Cells["evening"].Value = Db.dr["evening"];
                row.Cells["unit_2"].Value = Db.dr["unit"];
                row.Cells["days_of_use"].Value = Db.dr["days_of_use"];
                row.Cells["total_quantity"].Value = Db.dr["total_quantity_med"];
                row.Cells["note_2"].Value = Db.dr["note"];
                row.Cells["delete_med"].Value = "-";
                row.Cells["id_med_2"].Value = Db.dr["id"];
            }


            Db.dr.Close();

        }
    }
}








