using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuanLyPhongKham
{
    public partial class frm_xray : Form
    {

        string connectionString = "Server=localhost;Database=clinic_db2;Uid=root;Pwd=;";
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adt;
        DataTable dt;
        MySqlDataReader dr;
        private bool isUserChangingTemplate = true;
        private void ResetConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        public frm_xray()
        {
            InitializeComponent();
        }
        private void frm_xray_Load(object sender, EventArgs e)
        {
            LoadDTGVPatients();
            LoadComboboxTemplate();
        }
        public void LoadDTGVPatients()
        {
            dtgv_exam.Columns.Add("id_patient", "Mã BN");
            dtgv_exam.Columns.Add("name", "Họ tên");
            dtgv_exam.Columns.Add("id_exam", "Mã phiếu khám");
            dtgv_exam.Columns.Add("gender", "Giới tính");
            dtgv_exam.Columns.Add("date_of_birth", "Ngày sinh");
            dtgv_exam.Columns.Add("phone", "SĐT");
            dtgv_exam.Columns.Add("address", "Địa chỉ");
            dtgv_exam.Columns.Add("updated_at", "Ngày cập nhật");
            dtgv_exam.Columns.Add("reason", "Lý do khám");
            dtgv_exam.Columns.Add("diagnosis", "Chẩn đoán");
            dtgv_exam.Columns.Add("note", "Ghi chú");

            string[] columnsToHide = {
                "id_exam", "gender", "date_of_birth", "phone",
                "address", "updated_at", "reason", "diagnosis", "note"
                };

            foreach (string columnName in columnsToHide)
                    dtgv_exam.Columns[columnName].Visible = false;
               
            

            String sql = @"SELECT 
                    e.id AS id_exam,
                    p.id AS id_patient,
                    p.name,
                    p.gender,
                    DATE_FORMAT(p.date_of_birth, '%d/%m/%Y') AS date_of_birth,
                    p.phone,
                    p.address,
                    DATE_FORMAT(p.updated_at, '%d/%m/%Y %H:%i') AS updated_at,
                    e.reason,
                    d.name AS diagnosis,
                    e.note,
                    s.id AS service_id,
                    s.name AS service_name,
                    es.id AS examination_service_id,
                    CASE 
                        WHEN er.id IS NOT NULL THEN 'Đã có KQ'
                        ELSE 'Chưa có KQ'
                    END AS state
                FROM examinations e
                JOIN patients p ON e.patient_id = p.id
                JOIN diagnoses d ON e.diagnosis_id = d.id
                JOIN examination_services es ON e.id = es.examination_id
                JOIN services s ON es.service_id = s.id
                LEFT JOIN examination_results er ON er.examination_service_id = es.id
                WHERE DATE(p.updated_at) = CURDATE()
                  AND s.type = 'X-quang'

                ";

            conn = new MySqlConnection(connectionString);
            ResetConnection();
            cmd = new MySqlCommand(sql, conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int i = dtgv_exam.Rows.Add();
                DataGridViewRow drr = dtgv_exam.Rows[i];
                drr.Cells["id_exam"].Value = dr["id_exam"];
                drr.Cells["id_patient"].Value = dr["id_patient"];
                drr.Cells["name"].Value = dr["name"];
                drr.Cells["gender"].Value = dr["gender"];
                drr.Cells["date_of_birth"].Value = dr["date_of_birth"];
                drr.Cells["phone"].Value = dr["phone"];
                drr.Cells["address"].Value = dr["address"];
                drr.Cells["updated_at"].Value = dr["updated_at"];
                drr.Cells["reason"].Value = dr["reason"];
                drr.Cells["diagnosis"].Value = dr["diagnosis"];
                drr.Cells["note"].Value = dr["note"];
            }

            dr.Close();
            ResetConnection();

        }
        private void LoadDTGV_Service()
        {
            string sql = @"SELECT s.id, s.name, es.id AS examination_service_id,
                      CASE 
                          WHEN er.id IS NOT NULL THEN 'Đã có KQ'
                          ELSE 'Chưa có KQ'
                      END AS state
               FROM examinations e
               JOIN examination_services es ON e.id = es.examination_id
               JOIN services s ON es.service_id = s.id
               LEFT JOIN examination_results er ON er.examination_service_id = es.id
               WHERE e.id = @exam_id AND s.type = 'X-quang'";

            conn = new MySqlConnection(connectionString);
            ResetConnection();
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt16(txb_id_exam.Text));
            dr = cmd.ExecuteReader();
            dtgv_service.Rows.Clear();

            while (dr.Read())
            {
                int i = dtgv_service.Rows.Add();
                DataGridViewRow drr = dtgv_service.Rows[i];

                drr.Cells["id"].Value = dr["id"];
                drr.Cells["name"].Value = dr["name"];
                drr.Cells["state"].Value = dr["state"];
                drr.Cells["examination_service_id"].Value = dr["examination_service_id"];
            }

            dr.Close();
            ResetConnection();


        }
        private void LoadComboboxTemplate()
        {
            string query = "SELECT id, name, template_content FROM templates";
            ResetConnection();
            cmd = new MySqlCommand(query, conn);
            adt = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adt.Fill(dt);
            cb_template.DataSource = dt;
            cb_template.DisplayMember = "name";
            cb_template.ValueMember = "id";
            ResetConnection();
            cb_template.Text = "Chọn biểu mẫu";


        }
        private void dtgv_exam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && dtgv_exam.Rows[e.RowIndex].Cells["id_exam"].Value != null)
            {
                DataGridViewRow row = dtgv_exam.Rows[e.RowIndex];
                var id_exam = row.Cells["id_exam"].Value?.ToString();
                var id_patient = row.Cells["id_patient"].Value?.ToString();
                var name = row.Cells["name"].Value?.ToString();
                var gender = row.Cells["gender"].Value?.ToString();
                var date_of_birth = row.Cells["date_of_birth"].Value?.ToString();
                var phone = row.Cells["phone"].Value?.ToString();
                var address = row.Cells["address"].Value?.ToString();
                var updated_at = row.Cells["updated_at"].Value?.ToString();
                var reason = row.Cells["reason"].Value?.ToString();
                var diagnosis = row.Cells["diagnosis"].Value?.ToString();
                var note = row.Cells["note"].Value?.ToString();
                txb_id_exam.Text = id_exam;
                txb_name.Text = name;
                txb_gender.Text = gender;
                txb_dob.Text = date_of_birth;
                txb_phone.Text = phone;
                txb_address.Text = address;
                txb_reception_date.Text = updated_at;
                txb_reason.Text = reason;
                txb_id_patient.Text = id_patient;
                txb_note.Text = note;
                LoadDTGV_Service();
            }

        }
   
        private void dtgv_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_service.Rows[e.RowIndex];
                var name_service = row.Cells["name"].Value?.ToString();
                txb_service.Text = name_service;
                if (dtgv_service.CurrentRow.Cells["state"].Value.ToString() == "Đã có KQ")
                {
                    btn_save.Enabled = false;
                    btn_edit.Enabled = true;
                    string sql = @"SELECT 
                            es.id AS examination_service_id,
                            er.result AS result,
                            er.template_id,
                            er.final_result
                            
                        FROM 
                            examinations e
                        JOIN examination_services es ON e.id = es.examination_id
                        JOIN services s ON es.service_id = s.id
                        JOIN examination_results er ON er.examination_service_id = es.id
                        WHERE 
                            er.examination_service_id = @examination_service_id
                        ";
                    conn = new MySqlConnection(connectionString);
                    ResetConnection();
                    cmd = new MySqlCommand(sql, conn);
                    var exam_service_id = Convert.ToInt16(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
                    cmd.Parameters.AddWithValue("@examination_service_id", exam_service_id);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        isUserChangingTemplate = false; // Tạm thời tắt sự kiện người dùng thay đổi
                        txb_result.Text = dr["result"].ToString()
                           .Replace("\\n", "\r\n")
                           .Replace("\n", "\r\n");
                        cb_template.SelectedValue = Convert.ToInt32(dr["template_id"]);
                        txb_final_result.Text = dr["final_result"].ToString();
                        isUserChangingTemplate = true; // Bật lại sự kiện
                    }

                    dr.Close();
                    ResetConnection();
                }
                else  // Nếu không có kết quả, mặc định chọn template
                {
                    btn_save.Enabled = true;
                    btn_edit.Enabled = false;
                }
            }
        }
       
        private void cb_template_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Chỉ xử lý khi người dùng thực sự thay đổi template
            if (isUserChangingTemplate && cb_template.SelectedIndex > 0 && dtgv_service.CurrentRow != null)
            {
                int selectedTemplateId = Convert.ToInt32(cb_template.SelectedValue);
                string sql = "SELECT `template_content` FROM `templates` WHERE `id` = @template_id;";
                conn = new MySqlConnection(connectionString);
                ResetConnection();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@template_id", selectedTemplateId);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    txb_result.Text = dr["template_content"].ToString();
                                       //.Replace("\\n", "\r\n")
                                       //.Replace("\n", "\r\n");
                dr.Close();
                ResetConnection();
            }




        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var examination_service_id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
            var template_id = Convert.ToInt32(cb_template.SelectedValue);
            string result = txb_result.Text;
            string final_result = txb_final_result.Text;

            string query = @"INSERT INTO examination_results 
                (examination_service_id, template_id, result,final_result) 
                VALUES (@examination_service_id, @template_id, @result,@final_result);";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@examination_service_id", examination_service_id);
            cmd.Parameters.AddWithValue("@template_id", template_id);
            cmd.Parameters.AddWithValue("@result", result);
            cmd.Parameters.AddWithValue("@final_result", final_result);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm kết quả thành công.");
                LoadDTGV_Service();
            }    
             
            else
                MessageBox.Show("Không có dữ liệu nào được thêm.");
            





        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            var examination_service_id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
            var template_id = Convert.ToInt32(cb_template.SelectedValue);
            string result = txb_result.Text;
            string final_result = txb_final_result.Text;
            string query = @"UPDATE examination_results SET 
                            template_id=@template_id,
                            result=@result,
                            final_result = @final_result
                            WHERE examination_service_id = @examination_service_id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@examination_service_id", examination_service_id);
            cmd.Parameters.AddWithValue("@template_id", template_id);
            cmd.Parameters.AddWithValue("@result", result);
            cmd.Parameters.AddWithValue("@final_result", final_result);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Sửa kết quả thành công.");
                LoadDTGV_Service();
            }
            else
                MessageBox.Show("Không có dữ liệu nào được sửa.");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
          
            var from_date = dtpk_fromdate.Text;
            var to_date = dtpk_todate.Text;

            string query = @"
        SELECT 
            DISTINCT e.id AS id_exam,
            p.id AS id_patient,
            p.name,
            p.gender,
            DATE_FORMAT(p.date_of_birth, '%d/%m/%Y') AS date_of_birth,
            p.phone,
            p.address,
            DATE_FORMAT(p.updated_at, '%d/%m/%Y %H:%i') AS updated_at,
            e.reason,
            d.name AS diagnosis,
            e.note
        FROM examinations e
        JOIN patients p ON e.patient_id = p.id
        JOIN diagnoses d ON e.diagnosis_id = d.id
        JOIN examination_services es ON es.examination_id = e.id
        JOIN services s ON s.id = es.service_id AND s.type = 'X-quang'
        LEFT JOIN examination_results er ON er.examination_service_id = es.id
        WHERE DATE(p.updated_at) 
              BETWEEN STR_TO_DATE(@from_date, '%d/%m/%Y') 
              AND STR_TO_DATE(@to_date, '%d/%m/%Y')
    ";
     
            if (!rdn_resulted.Checked)
            {
                query += " AND er.id IS NOT NULL ";
            }
            else if (!rdn_noresult.Checked)
            {
                query += " AND er.id IS NULL ";
            }

            conn = new MySqlConnection(connectionString);
            ResetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@from_date", from_date);
            cmd.Parameters.AddWithValue("@to_date", to_date);

            dr = cmd.ExecuteReader();
            dtgv_exam.Rows.Clear();

            while (dr.Read())
            {
                int i = dtgv_exam.Rows.Add();
                DataGridViewRow drr = dtgv_exam.Rows[i];
                drr.Cells["id_exam"].Value = dr["id_exam"];
                drr.Cells["id_patient"].Value = dr["id_patient"];
                drr.Cells["name"].Value = dr["name"];
                drr.Cells["gender"].Value = dr["gender"];
                drr.Cells["date_of_birth"].Value = dr["date_of_birth"];
                drr.Cells["phone"].Value = dr["phone"];
                drr.Cells["address"].Value = dr["address"];
                drr.Cells["updated_at"].Value = dr["updated_at"];
                drr.Cells["reason"].Value = dr["reason"];
                drr.Cells["diagnosis"].Value = dr["diagnosis"];
                drr.Cells["note"].Value = dr["note"];
            }

            dr.Close();
            ResetConnection();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dtgv_service.CurrentRow == null || txb_result.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn dịch vụ X-quang có kết quả để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Configure the PrintDocument
            printDocument1.DocumentName = "X-Ray Results";
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            // Configure the PrintPreviewDialog
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11, FontStyle.Regular);
            Font resultFont = new Font("Arial", 10, FontStyle.Regular);

            // Define positions and measurements
            int pageWidth = e.PageBounds.Width;
            int yPos = 50;
            int leftMargin = 50;
            int rightMargin = pageWidth - 50;
            int contentWidth = rightMargin - leftMargin;
            int columnWidth = contentWidth / 2 - 10; // For two-column layout with spacing

            // -- HEADER SECTION --
            // Draw hospital/clinic header with centered text
            string clinicName = "PHÒNG KHÁM ĐA KHOA";
            int clinicNameX = leftMargin + (contentWidth - (int)e.Graphics.MeasureString(clinicName, titleFont).Width) / 2;
            e.Graphics.DrawString(clinicName, titleFont, Brushes.Black, new Point(clinicNameX, yPos));
            yPos += 30;

            string clinicAddress = "Địa chỉ: 123 Đường Thanh Niên, Quận Hải Châu, Đà Nẵng";
            int addressX = leftMargin + (contentWidth - (int)e.Graphics.MeasureString(clinicAddress, normalFont).Width) / 2;
            e.Graphics.DrawString(clinicAddress, normalFont, Brushes.Black, new Point(addressX, yPos));
            yPos += 20;

            string clinicPhone = "Điện thoại: 0123-456-789";
            int phoneX = leftMargin + (contentWidth - (int)e.Graphics.MeasureString(clinicPhone, normalFont).Width) / 2;
            e.Graphics.DrawString(clinicPhone, normalFont, Brushes.Black, new Point(phoneX, yPos));
            yPos += 30;

            // -- TITLE SECTION --
            // Draw report title centered
            string reportTitle = "PHIẾU KẾT QUẢ X-QUANG";
            int reportTitleX = leftMargin + (contentWidth - (int)e.Graphics.MeasureString(reportTitle, titleFont).Width) / 2;

            // Draw title with underline
            e.Graphics.DrawString(reportTitle, titleFont, Brushes.Black, new Point(reportTitleX, yPos));
            yPos += 30;

            // Draw horizontal line under title
            using (Pen linePen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawLine(linePen, leftMargin, yPos, rightMargin, yPos);
            }
            yPos += 20;

            // -- PRINT TIME SECTION --
            string printTime = "Thời gian in phiếu: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            e.Graphics.DrawString(printTime, normalFont, Brushes.Black, new Point(leftMargin, yPos));
            yPos += 20;

            // -- PATIENT INFORMATION SECTION --
            // Draw patient information section
            e.Graphics.DrawString("THÔNG TIN BỆNH NHÂN", headerFont, Brushes.Black, new Point(leftMargin, yPos));
            yPos += 25;

            // Define two-column layout for patient details
            string patientId = "Mã BN: " + txb_id_patient.Text;
            string patientName = "Họ tên: " + txb_name.Text;
            string gender = "Giới tính: " + txb_gender.Text;
            string dob = "Ngày sinh: " + txb_dob.Text;
            string phone = "SĐT: " + txb_phone.Text;
            string address = "Địa chỉ: " + txb_address.Text;

            // Left column
            int col1X = leftMargin + 10;
            int col2X = leftMargin + columnWidth + 20;

            e.Graphics.DrawString(patientId, normalFont, Brushes.Black, new Point(col1X, yPos));
            e.Graphics.DrawString(patientName, normalFont, Brushes.Black, new Point(col2X, yPos));
            yPos += 20;

            e.Graphics.DrawString(gender, normalFont, Brushes.Black, new Point(col1X, yPos));
            e.Graphics.DrawString(dob, normalFont, Brushes.Black, new Point(col2X, yPos));
            yPos += 20;

            e.Graphics.DrawString(phone, normalFont, Brushes.Black, new Point(col1X, yPos));
            e.Graphics.DrawString(address, normalFont, Brushes.Black, new Point(col2X, yPos));
            yPos += 25;

            // -- EXAMINATION INFORMATION SECTION --
            // Draw examination information section
            e.Graphics.DrawString("THÔNG TIN KHÁM", headerFont, Brushes.Black, new Point(leftMargin, yPos));
            yPos += 25;

            string examId = "Mã phiếu khám: " + txb_id_exam.Text;
            string examDate = "Ngày khám: " + txb_reception_date.Text;
            string reason = "Lý do khám: " + txb_reason.Text;
            string serviceName = "Chỉ định: " + txb_service.Text;
            string examinationServiceId = "Mã phiếu KQ: " + dtgv_service.CurrentRow.Cells["examination_service_id"].Value?.ToString();

            e.Graphics.DrawString(examId, normalFont, Brushes.Black, new Point(col1X, yPos));
            e.Graphics.DrawString(examDate, normalFont, Brushes.Black, new Point(col2X, yPos));
            yPos += 20;

            e.Graphics.DrawString(reason, normalFont, Brushes.Black, new Point(col1X, yPos));
            yPos += 20;

            e.Graphics.DrawString(serviceName, normalFont, Brushes.Black, new Point(col1X, yPos));
            e.Graphics.DrawString(examinationServiceId, normalFont, Brushes.Black, new Point(col2X, yPos));
            yPos += 25;


            // -- X-RAY RESULT SECTION --
            // Draw X-ray result
            e.Graphics.DrawString("KẾT QUẢ X-QUANG", headerFont, Brushes.Black, new Point(leftMargin, yPos));
            yPos += 25;

            // Print the result text, wrapping it as needed
            RectangleF resultRect = new RectangleF(leftMargin + 10, yPos, contentWidth - 20, 500);
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(txb_result.Text, resultFont, Brushes.Black, resultRect, sf);
            }

            int resultTextHeight = (int)e.Graphics.MeasureString(txb_result.Text, resultFont, contentWidth - 20).Height;
            yPos += resultTextHeight + 10;

            // -- FINAL RESULT SECTION --
            // Final result
            if (!string.IsNullOrWhiteSpace(txb_final_result.Text))
            {
                e.Graphics.DrawString("KẾT LUẬN:", headerFont, Brushes.Black, new Point(leftMargin, yPos));
                yPos += 25;

                RectangleF finalResultRect = new RectangleF(leftMargin + 10, yPos, contentWidth - 20, 500);
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString(txb_final_result.Text, normalFont, Brushes.Black, finalResultRect, sf);
                }

                int finalResultTextHeight = (int)e.Graphics.MeasureString(txb_final_result.Text, normalFont, contentWidth - 20).Height;
                yPos += finalResultTextHeight + 10;
            }

            // -- SIGNATURE SECTION --
            // Date and signature
            string dateStr = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            // Align date and signature on the right
            int dateX = rightMargin - (int)e.Graphics.MeasureString(dateStr, normalFont).Width - 10;
            e.Graphics.DrawString(dateStr, normalFont, Brushes.Black, new Point(dateX, yPos));
            yPos += 20;

            string doctor = "BÁC SĨ X-QUANG";
            int doctorX = rightMargin - (int)e.Graphics.MeasureString(doctor, headerFont).Width - 10;
            e.Graphics.DrawString(doctor, headerFont, Brushes.Black, new Point(doctorX, yPos));
            yPos += 60;

            // Space for signature
            string signature = "(Ký, họ tên)";
            int signatureX = rightMargin - (int)e.Graphics.MeasureString(signature, normalFont).Width - 10;
            e.Graphics.DrawString(signature, normalFont, Brushes.Black, new Point(signatureX, yPos));


            // Clean up the event after printing
            printDocument1.PrintPage -= PrintDocument_PrintPage;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dtgv_exam.Rows.Clear();
            
            String sql = @"SELECT 
                    e.id AS id_exam,
                    p.id AS id_patient,
                    p.name,
                    p.gender,
                    DATE_FORMAT(p.date_of_birth, '%d/%m/%Y') AS date_of_birth,
                    p.phone,
                    p.address,
                    DATE_FORMAT(p.updated_at, '%d/%m/%Y %H:%i') AS updated_at,
                    e.reason,
                    d.name AS diagnosis,
                    e.note,
                    s.id AS service_id,
                    s.name AS service_name,
                    es.id AS examination_service_id,
                    CASE 
                        WHEN er.id IS NOT NULL THEN 'Đã có KQ'
                        ELSE 'Chưa có KQ'
                    END AS state
                FROM examinations e
                JOIN patients p ON e.patient_id = p.id
                JOIN diagnoses d ON e.diagnosis_id = d.id
                JOIN examination_services es ON e.id = es.examination_id
                JOIN services s ON es.service_id = s.id
                LEFT JOIN examination_results er ON er.examination_service_id = es.id
                WHERE DATE(p.updated_at) = CURDATE()
                  AND s.type = 'X-quang'

                ";

            conn = new MySqlConnection(connectionString);
            ResetConnection();
            cmd = new MySqlCommand(sql, conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int i = dtgv_exam.Rows.Add();
                DataGridViewRow drr = dtgv_exam.Rows[i];
                drr.Cells["id_exam"].Value = dr["id_exam"];
                drr.Cells["id_patient"].Value = dr["id_patient"];
                drr.Cells["name"].Value = dr["name"];
                drr.Cells["gender"].Value = dr["gender"];
                drr.Cells["date_of_birth"].Value = dr["date_of_birth"];
                drr.Cells["phone"].Value = dr["phone"];
                drr.Cells["address"].Value = dr["address"];
                drr.Cells["updated_at"].Value = dr["updated_at"];
                drr.Cells["reason"].Value = dr["reason"];
                drr.Cells["diagnosis"].Value = dr["diagnosis"];
                drr.Cells["note"].Value = dr["note"];
            }

            dr.Close();
            ResetConnection();
        }
    }
}
