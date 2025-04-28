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

        private bool isUserChangingTemplate = true;

        public frm_xray()
        {
            InitializeComponent();
            LoadExam.InitialDTGVCommon(dtgv_exam); // Khởi tạo DataGridView
            LoadExam.LoadDTGVCommon(dtgv_exam, "X-quang"); // Tải dữ liệu cho X-quang
        }
        private void frm_xray_Load(object sender, EventArgs e)
        {

            LoadComboboxTemplate();
            webBrowser1.Visible = false;
        
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

            Db.conn = new MySqlConnection(Db.connectionString);
            Db.ResetConnection();
            Db.cmd = new MySqlCommand(sql, Db.conn);
            Db.cmd.Parameters.AddWithValue("@exam_id", Convert.ToInt16(txb_id_exam.Text));
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_service.Rows.Clear();

            while (Db.dr.Read())
            {
                int i = dtgv_service.Rows.Add();
                DataGridViewRow drr = dtgv_service.Rows[i];

                drr.Cells["id"].Value = Db.dr["id"];
                drr.Cells["name"].Value = Db.dr["name"];
                drr.Cells["state"].Value = Db.dr["state"];
                drr.Cells["examination_service_id"].Value = Db.dr["examination_service_id"];
            }

            Db.dr.Close();
            Db.ResetConnection();


        }
        private void LoadComboboxTemplate()
        {
            string query = "SELECT id, name, template_content,type FROM templates where type = 'X-quang' ";
            Db.LoadComboBoxData(cb_template, query, "name", "id");
            
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
                Db.SetTextAndMoveCursorToEnd(txb_id_exam, id_exam);
                Db.SetTextAndMoveCursorToEnd(txb_name, name);
                Db.SetTextAndMoveCursorToEnd(txb_gender, gender);
                txb_dob.Text = date_of_birth + "";
                var dob = DateTime.ParseExact(date_of_birth, "dd/MM/yyyy", null);
                var age = DateTime.Now.Year - dob.Year - (DateTime.Now < dob.AddYears(DateTime.Now.Year - dob.Year) ? 1 : 0);
                txb_age.Text = age.ToString()+ " tuổi"; ;

                Db.SetTextAndMoveCursorToEnd(txb_phone, phone);
                Db.SetTextAndMoveCursorToEnd(txb_address, address);
                Db.SetTextAndMoveCursorToEnd(txb_reception_date, updated_at);
                Db.SetTextAndMoveCursorToEnd(txb_reason, reason);
                Db.SetTextAndMoveCursorToEnd(txb_id_patient, id_patient);
                Db.SetTextAndMoveCursorToEnd(txb_note, note);

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
                er.examination_service_id = @examination_service_id";

                    Db.ResetConnection();
                    Db.cmd = new MySqlCommand(sql, Db.conn);
                    var exam_service_id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
                    Db.cmd.Parameters.AddWithValue("@examination_service_id", exam_service_id);

                    Db.dr = Db.cmd.ExecuteReader();
                    if (Db.dr.Read())
                    {
                        isUserChangingTemplate = false;
                        Db.SetTextAndMoveCursorToEnd(txb_result, Db.dr["result"].ToString()
                             .Replace("\\r\\n", "\r\n")); // chuyển chuỗi '\\r\\n' về ký tự xuống dòng thật

                        Db.SetTextAndMoveCursorToEnd(txb_final_result, Db.dr["final_result"].ToString());

                        cb_template.SelectedValue = Convert.ToInt32(Db.dr["template_id"]);
                        
                        isUserChangingTemplate = true;
                    }

                    Db.dr.Close();
                    Db.ResetConnection();
                }
                else
                {
                    btn_save.Enabled = true;
                    btn_edit.Enabled = false;
                    cb_template.Text = "Chọn biểu mẫu";
                    txb_result.Text = "";
                    txb_final_result.Text = "";
                        
                }
            }

        }

        private void cb_template_SelectedIndexChanged(object sender, EventArgs e)
        {

     

            if (isUserChangingTemplate && cb_template.SelectedIndex >= 0 && dtgv_service.CurrentRow != null)
            {
                int selectedTemplateId = Convert.ToInt32(cb_template.SelectedValue);
                string sql = "SELECT `template_content` FROM `templates` WHERE `id` = @template_id;";
                Db.ResetConnection();
                Db.cmd = new MySqlCommand(sql, Db.conn);
                Db.cmd.Parameters.AddWithValue("@template_id", selectedTemplateId);
                Db.dr = Db.cmd.ExecuteReader();

                if (Db.dr.Read())
                    txb_result.Text = Db.dr["template_content"].ToString()
                                .Replace("\\r\\n", "\r\n"); // chuyển chuỗi '\\r\\n' về ký tự xuống dòng thật

                Db.dr.Close();
                Db.ResetConnection();
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

            MySqlCommand cmd = new MySqlCommand(query, Db.conn);
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

            MySqlCommand cmd = new MySqlCommand(query, Db.conn);
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
        SELECT DISTINCT
            DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i') AS time_exam,
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
            e.note
        FROM examinations e
        JOIN patients p ON e.patient_id = p.id
        JOIN diagnoses d ON e.diagnosis_id = d.id
        JOIN examination_services es ON es.examination_id = e.id
        JOIN services s ON s.id = es.service_id AND s.type = 'X-quang'
        LEFT JOIN examination_results er ON er.examination_service_id = es.id
        WHERE DATE(e.updated_at) 
              BETWEEN STR_TO_DATE(@from_date, '%d/%m/%Y') 
              AND STR_TO_DATE(@to_date, '%d/%m/%Y')
    ";

            if (rdn_all.Checked )
            {
                query += "";
            }    
            if (rdn_resulted.Checked )
            {
            
                query += " AND er.id IS NOT NULL ";
            }
            else if (rdn_noresult.Checked )
            {
      
                query += " AND er.id IS NULL ";
            }

            Db.conn = new MySqlConnection(Db.connectionString);
            Db.ResetConnection();
            MySqlCommand cmd = new MySqlCommand(query, Db.conn);
            cmd.Parameters.AddWithValue("@from_date", from_date);
            cmd.Parameters.AddWithValue("@to_date", to_date);

            Db.dr = cmd.ExecuteReader();
            dtgv_exam.Rows.Clear();

            while (Db.dr.Read())
            {
                int i = dtgv_exam.Rows.Add();
                DataGridViewRow drr = dtgv_exam.Rows[i];
                drr.Cells["id_exam"].Value = Db.dr["id_exam"];
                drr.Cells["id_patient"].Value = Db.dr["id_patient"];
                drr.Cells["name"].Value = Db.dr["name"];
                drr.Cells["gender"].Value = Db.dr["gender"];
                drr.Cells["date_of_birth"].Value = Db.dr["date_of_birth"];
                drr.Cells["phone"].Value = Db.dr["phone"];
                drr.Cells["address"].Value = Db.dr["address"];
                drr.Cells["updated_at"].Value = Db.dr["updated_at"];
                drr.Cells["reason"].Value = Db.dr["reason"];
                drr.Cells["diagnosis"].Value = Db.dr["diagnosis"];
                drr.Cells["note"].Value = Db.dr["note"];
                drr.Cells["time_exam"].Value = Db.dr["time_exam"];
            }

            Db.dr.Close();
            Db.ResetConnection();
        }



        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dtgv_service.CurrentRow == null || txb_result.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn dịch vụ X-quang có kết quả để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string html = $@"
    <html>
    <head>
        <style>
            body {{ font-family: 'Segoe UI', sans-serif; margin: 10px; color: #333; background-color: #fff; line-height: 1.3; }}
            .header {{ text-align: center; margin-bottom: 8px; }}
            .clinic-name {{ font-size: 20px; font-weight: bold; color: #2c3e50; margin-bottom: 2px; text-transform: uppercase; }}
            .clinic-address {{ font-size: 12px; margin-bottom: 2px; }}
            .divider {{ border-top: 1px solid #3498db; margin: 5px 0; }}
            .thin-divider {{ border-top: 1px solid #ddd; margin: 5px 0; }}
            .title {{ text-align: center; font-size: 18px; font-weight: bold; margin: 8px 0; color: #2c3e50; text-transform: uppercase; }}
            .print-time {{ text-align: right; font-size: 10px; color: #7f8c8d; font-style: italic; margin-bottom: 5px; }}
            .section-title {{ font-size: 14px; font-weight: bold; color: #2980b9; margin: 8px 0 5px 0; text-transform: uppercase; border-left: 3px solid #3498db; padding-left: 5px; }}
            .main-container {{ display: flex; justify-content: space-between; gap: 10px; }}
            .info-column {{ width: 49%; }}
            .info-item {{ margin: 2px 0; font-size: 14px; }}
            .info-label {{ font-weight: bold; display: inline-block; min-width: 90px; }}
            .result-box {{ background-color: #f8f9fa; padding: 8px; border-radius: 3px; border-left: 3px solid #3498db; margin-top: 5px; font-size: 14px; line-height: 1.4; }}
            .signature {{ margin-top: 20px; text-align: right; font-size: 12px; }}
            .signature-title {{ font-weight: bold; margin-top: 5px; font-size: 14px; }}
            .signature-note {{ margin-top: 30px; font-style: italic; }}
            @media print {{ body {{ margin: 0; }} .result-box {{ background-color: #fff; border-left: 1px solid #000; }} }}
        </style>
    </head>
    <body>
        <div class='header'>
            <div class='clinic-name'>PHÒNG KHÁM ĐA KHOA</div>
            <div class='clinic-address'>Địa chỉ: 123 Đường Thanh Niên, Quận Hải Châu, Đà Nẵng | ĐT: 0123-456-789</div>
        </div>
        <div class='divider'></div>
        <div class='title'>PHIẾU KẾT QUẢ X-QUANG</div>
        <div class='print-time'>Thời gian in phiếu: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</div>
        <div class='thin-divider'></div>
        <div class='main-container'>
            <!-- Thông tin bệnh nhân -->
            <div class='info-column'>
                <div class='section-title'>THÔNG TIN BỆNH NHÂN</div>
                <div class='info-item'><span class='info-label'>Mã BN:</span> {txb_id_patient.Text}</div>
                <div class='info-item'><span class='info-label'>Họ tên:</span> <strong>{txb_name.Text}</strong></div>
                <div class='info-item'><span class='info-label'>Giới tính:</span> {txb_gender.Text}</div>
                <div class='info-item'><span class='info-label'>Ngày sinh:</span> {txb_dob.Text}</div>
                <div class='info-item'><span class='info-label'>SĐT:</span> {txb_phone.Text}</div>
                <div class='info-item'><span class='info-label'>Địa chỉ:</span> {txb_address.Text}</div>
            </div>
            <!-- Thông tin khám -->
            <div class='info-column'>
                <div class='section-title'>THÔNG TIN KHÁM</div>
                <div class='info-item'><span class='info-label'>Mã phiếu khám:</span> {txb_id_exam.Text}</div>
                <div class='info-item'><span class='info-label'>Ngày khám:</span> {txb_reception_date.Text}</div>
                <div class='info-item'><span class='info-label'>Chỉ định:</span> <strong>{txb_service.Text}</strong></div>
                <div class='info-item'><span class='info-label'>Mã phiếu KQ:</span> {dtgv_service.CurrentRow.Cells["examination_service_id"].Value?.ToString()}</div>
                <div class='info-item'><span class='info-label'>Lý do khám:</span> <em>{txb_reason.Text}</em></div>
            </div>
        </div>
        <!-- Kết quả X-quang -->
        <div class='section-title'>KẾT QUẢ X-QUANG</div>
        <div class='result-box'>{txb_result.Text.Replace(Environment.NewLine, "<br/>")}</div>
        <!-- Kết luận (nếu có) -->
        {(string.IsNullOrWhiteSpace(txb_final_result.Text) ? "" : $@"
            <div class='section-title'>KẾT LUẬN</div>
            <div class='result-box' style='border-left: 3px solid #e74c3c;'><strong>{txb_final_result.Text.Replace(Environment.NewLine, "<br/>")}</strong></div>
        ")}
        <!-- Thông tin bác sĩ -->
        <div class='signature'>
            <div>Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}</div>
            <div class='signature-title'>BÁC SĨ X-QUANG</div>
            <div class='signature-note'>(Ký, họ tên)</div>
        </div>
    </body>
    </html>";


            Form previewForm = new Form
            {
                Text = "Xem trước kết quả X-quang",
                Width = 800,
                Height = 1000,
                StartPosition = FormStartPosition.CenterScreen
            };

            WebBrowser browser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                DocumentText = html
            };

            Button printButton = new Button
            {
                Text = "In phiếu",
                Dock = DockStyle.Bottom,
                Height = 40
            };

            printButton.Click += (s, ev) => {
                browser.ShowPrintPreviewDialog();  // Hiển thị hộp thoại xem trước bản in của hệ thống
            };

            previewForm.Controls.Add(browser);
            previewForm.Controls.Add(printButton);
            previewForm.ShowDialog();
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dtgv_exam.Rows.Clear();
            LoadExam.LoadDTGVCommon(dtgv_exam, "X-quang"); 
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
			string keyword = txb_search.Text.Trim();
			LoadExam.LoadDTGVCommon(dtgv_exam, "X-quang", keyword);
		}


    }
}
