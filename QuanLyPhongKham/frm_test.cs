using System;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuanLyPhongKham
{
    public partial class frm_test : Form
    {
        bool isUserChangingTemplate = false;
        public frm_test()
        {
            InitializeComponent();

        }

        private void frm_test_Load(object sender, EventArgs e)
        {
            LoadExam.InitialDTGVCommon(dtgv_exam);
            LoadExam.LoadDTGVCommon(dtgv_exam, "Xét nghiệm");
            LoadComboboxTemplate();
            webBrowser1.Visible = false;
        }
        private void LoadComboboxTemplate()
        {
            string query = "SELECT id, name, template_content FROM templates where type = 'Xét nghiệm'";
            Db.LoadComboBoxData(cb_template, query, "name", "id");
            cb_template.Text = "Chọn biểu mẫu";
        }
        private void dtgv_exam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgv_exam.Rows[e.RowIndex].Cells["id_exam"].Value != null)
            {
                DataGridViewRow row = dtgv_exam.Rows[e.RowIndex];

                var date_of_birth = row.Cells["date_of_birth"].Value?.ToString(); // <-- Thêm dòng này

                Db.SetTextAndMoveCursorToEnd(txb_id_exam, row.Cells["id_exam"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_id_patient, row.Cells["id_patient"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_name, row.Cells["name"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_gender, row.Cells["gender"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_dob, date_of_birth); // dùng biến đã khai báo
                Db.SetTextAndMoveCursorToEnd(txb_phone, row.Cells["phone"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_address, row.Cells["address"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_reception_date, row.Cells["updated_at"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_reason, row.Cells["reason"].Value?.ToString());
                Db.SetTextAndMoveCursorToEnd(txb_note, row.Cells["note"].Value?.ToString());

                var dob = DateTime.ParseExact(date_of_birth, "dd/MM/yyyy", null);
                var age = DateTime.Now.Year - dob.Year - (DateTime.Now < dob.AddYears(DateTime.Now.Year - dob.Year) ? 1 : 0);
                txb_age.Text = age.ToString() + " tuổi";

                LoadDTGV_Service();
            }

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
               WHERE e.id = @exam_id AND s.type = 'Xét nghiệm'";

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

        private void dtgv_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_service.Rows[e.RowIndex];
                var name_service = row.Cells["name"].Value?.ToString();
                txb_service.Text = name_service;
            }
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
        JOIN services s ON s.id = es.service_id AND s.type = 'Xét nghiệm'
        LEFT JOIN examination_results er ON er.examination_service_id = es.id
        WHERE DATE(e.updated_at) 
              BETWEEN STR_TO_DATE(@from_date, '%d/%m/%Y') 
              AND STR_TO_DATE(@to_date, '%d/%m/%Y')
    ";



            if (rdn_all.Checked)
            {
                query += "";
            }
            if (rdn_resulted.Checked)
            {

                query += " AND er.id IS NOT NULL ";
            }
            else if (rdn_noresult.Checked)
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

        private void cb_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgv_result.Rows.Clear();
            if (cb_template.SelectedIndex > 0)

                LoadDataToDataGridViewResult();

        }
        private void LoadDataToDataGridViewResult()
        {
            int selectedTemplateId = Convert.ToInt32(cb_template.SelectedValue);
            string sql = "SELECT `template_content` FROM `templates` WHERE `id` = @template_id;";
            Db.ResetConnection();
            Db.cmd = new MySqlCommand(sql, Db.conn);
            Db.cmd.Parameters.AddWithValue("@template_id", selectedTemplateId);
            Db.dr = Db.cmd.ExecuteReader();

            if (Db.dr.HasRows && Db.dr.Read())
            {
                string jsonData = Db.dr.GetString("template_content");
                JArray jsonArray = JArray.Parse(jsonData);
                string previousTestName = string.Empty;

                foreach (var item in jsonArray)
                {
                    string testName = item["name"].ToString();
                    foreach (var result in item["results"])
                    {
                        string resultTestName = result["test_name"].ToString();
                        string resultValue = result["result"].ToString();
                        string unit = result["unit"].ToString();
                        string normalRange = result["normal_range"].ToString();

                        if (testName != previousTestName)
                        {
                            dtgv_result.Rows.Add(testName, resultTestName, resultValue, unit, normalRange);
                            previousTestName = testName;
                        }
                        else
                        {
                            dtgv_result.Rows.Add("", resultTestName, resultValue, unit, normalRange);
                        }
                    }
                }
            }
            Db.dr.Close();
            Db.ResetConnection();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            JArray resultArr = new JArray();
            JObject group = null;

            foreach (DataGridViewRow r in dtgv_result.Rows)
            {
                if (r.IsNewRow) continue;
                var gName = r.Cells[0].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(gName))
                {
                    group = new JObject { ["name"] = gName, ["results"] = new JArray() };
                    resultArr.Add(group);
                }
                ((JArray)group["results"]).Add(new JObject
                {
                    ["test_name"] = r.Cells[1].Value?.ToString(),
                    ["result"] = r.Cells[2].Value?.ToString(),
                    ["unit"] = r.Cells[3].Value?.ToString(),
                    ["normal_range"] = r.Cells[4].Value?.ToString()
                });
            }

            var sql = "INSERT INTO examination_results (examination_service_id, template_id, result, final_result) VALUES (@examination_service_id, @template_id, @result, @final_result);";
            var param = new Dictionary<string, object>
                {
                    { "@examination_service_id", Convert.ToInt32(dtgv_service.CurrentRow.Cells[0].Value) },
                    { "@template_id", Convert.ToInt32(cb_template.SelectedValue) },
                    { "@result", resultArr.ToString(Newtonsoft.Json.Formatting.None) },
                    { "@final_result", txb_final_result.Text }
                };

            Db.Add(sql, param);
            MessageBox.Show("Đã lưu!");
            LoadDTGV_Service();
        }

        private void dtgv_service_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dtgv_service.Rows[e.RowIndex];
                var name_service = row.Cells["name"].Value?.ToString();
                txb_service.Text = name_service;

                // Clear previous results
                dtgv_result.Rows.Clear();
                txb_final_result.Text = string.Empty;

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

                    var exam_service_id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);

                    Db.ResetConnection();
                    using (MySqlCommand cmd = new MySqlCommand(sql, Db.conn))
                    {
                        cmd.Parameters.AddWithValue("@examination_service_id", exam_service_id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isUserChangingTemplate = false;

                                // Display final result
                                Db.SetTextAndMoveCursorToEnd(txb_final_result, reader["final_result"].ToString());


                                // Set template combobox
                                var templateId = reader["template_id"];
                                if (templateId != DBNull.Value)
                                {
                                    cb_template.SelectedValue = Convert.ToInt32(templateId);
                                }

                                // Get JSON result string
                                string jsonResult = reader["result"].ToString();

                                // Check if JSON is valid
                                if (!string.IsNullOrEmpty(jsonResult))
                                {
                                    try
                                    {
                                        JArray jsonArray = JArray.Parse(jsonResult);
                                        string previousTestName = "";

                                        foreach (JObject item in jsonArray)
                                        {
                                            string testName = item["name"]?.ToString() ?? "";

                                            if (item["results"] is JArray resultArray)
                                            {
                                                foreach (JObject result in resultArray)
                                                {
                                                    string resultTestName = result["test_name"]?.ToString() ?? "";
                                                    string resultValue = result["result"]?.ToString() ?? "";
                                                    string unit = result["unit"]?.ToString() ?? "";
                                                    string normalRange = result["normal_range"]?.ToString() ?? "";

                                                    // Add to DataGridView
                                                    if (!string.IsNullOrEmpty(testName) && testName != previousTestName)
                                                    {
                                                        dtgv_result.Rows.Add(testName, resultTestName, resultValue, unit, normalRange);
                                                        previousTestName = testName;
                                                    }
                                                    else
                                                    {
                                                        dtgv_result.Rows.Add("", resultTestName, resultValue, unit, normalRange);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (JsonReaderException ex)
                                    {
                                        MessageBox.Show("JSON không hợp lệ: " + ex.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Không có dữ liệu kết quả.");
                                }
                            }
                        } // reader sẽ tự động đóng ở đây
                    } // cmd sẽ tự động đóng ở đây

                    isUserChangingTemplate = true;
                }
                else
                {
                    btn_save.Enabled = true;
                    btn_edit.Enabled = false;
                    cb_template.SelectedIndex = 0;
                    txb_final_result.Text = "";

                    if (cb_template.SelectedIndex > 0)
                    {
                        LoadDataToDataGridViewResult();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng được chọn trong dtgv_service không
                if (dtgv_service.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dịch vụ để chỉnh sửa!");
                    return;
                }

                // Thu thập dữ liệu từ DataGridView dtgv_result để tạo JSON
                JArray resultArr = new JArray();
                JObject group = null;

                foreach (DataGridViewRow r in dtgv_result.Rows)
                {
                    if (r.IsNewRow) continue;
                    var gName = r.Cells[0].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(gName))
                    {
                        group = new JObject { ["name"] = gName, ["results"] = new JArray() };
                        resultArr.Add(group);
                    }
                    ((JArray)group["results"]).Add(new JObject
                    {
                        ["test_name"] = r.Cells[1].Value?.ToString(),
                        ["result"] = r.Cells[2].Value?.ToString(),
                        ["unit"] = r.Cells[3].Value?.ToString(),
                        ["normal_range"] = r.Cells[4].Value?.ToString()
                    });
                }

                // Chuẩn bị câu lệnh SQL để cập nhật
                string sql = @"UPDATE examination_results 
                      SET template_id = @template_id, 
                          result = @result, 
                          final_result = @final_result 
                      WHERE examination_service_id = @examination_service_id";

                // Chuẩn bị tham số cho hàm Update
                var param = new Dictionary<string, object>
        {
            { "@examination_service_id", Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value) },
            { "@template_id", Convert.ToInt32(cb_template.SelectedValue) },
            { "@result", resultArr.ToString(Newtonsoft.Json.Formatting.None) },
            { "@final_result", txb_final_result.Text }
        };

                // Gọi hàm Update từ lớp Db
                Db.Update(sql, param);

                // Thông báo thành công
                MessageBox.Show("Cập nhật kết quả thành công!");

                // Tải lại DataGridView dịch vụ để cập nhật trạng thái
                LoadDTGV_Service();

                // Vô hiệu hóa nút sửa và kích hoạt nút lưu nếu cần
                btn_edit.Enabled = false;
                btn_save.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật kết quả: " + ex.Message);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dữ liệu để in không
                if (dtgv_service.CurrentRow == null || dtgv_result.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ và đảm bảo có kết quả để in!");
                    return;
                }

                string html = $@"
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; margin: 10px; color: #333; background-color: #fff; line-height: 1.3; font-size: 12px; }}
        .header {{ text-align: center; margin-bottom: 8px; }}
        .hospital-name {{ font-size: 20px; font-weight: bold; color: #2c3e50; margin-bottom: 2px; text-transform: uppercase; }}
        .hospital-address {{ font-size: 12px; margin-bottom: 0; color: #2c3e50; }}
        .hospital-phone {{ font-size: 12px; color: #2c3e50; margin-top: 2px; }}
        .divider {{ border-top: 1px solid #3498db; margin: 5px 0; }}
        .title {{ text-align: center; font-size: 18px; font-weight: bold; margin: 8px 0; color: #2c3e50; text-transform: uppercase; }}
        .print-time {{ text-align: right; font-size: 10px; color: #7f8c8d; font-style: italic; margin: 2px 0; }}
        .section-title {{ font-size: 14px; font-weight: bold; color: #2980b9; margin: 8px 0 5px 0; text-transform: uppercase; border-left: 3px solid #3498db; padding-left: 5px; }}
        .id-container {{ display: flex; justify-content: space-between; font-size: 12px; margin: 5px 0; }}
        .info-row {{ display: flex; flex-wrap: wrap; margin: 2px 0; }}
        .info-item {{ margin-right: 15px; font-size: 12px; white-space: nowrap; }}
        .info-label {{ font-weight: bold; }}
        table {{ width: 100%; border-collapse: collapse; margin: 5px 0; font-size: 11px; }}
        th, td {{ padding: 3px; text-align: left; border: 1px solid #ddd; }}
        th {{ background-color: #f2f2f2; font-weight: bold; }}
        .conclusion {{ font-size: 12px; margin-top: 5px; padding: 5px; border-left: 3px solid #e74c3c; }}
        .signature {{ margin-top: 15px; text-align: right; font-size: 12px; }}
        .signature-title {{ font-weight: bold; margin-top: 5px; }}
        .signature-note {{ margin-top: 30px; font-style: italic; }}
        @media print {{ body {{ margin: 0; }} th {{ background-color: #f8f8f8; }} }}
    </style>
</head>
<body>
    <div class='header'>
        <div class='hospital-name'>BỆNH VIỆN ĐA KHOA XYZ</div>
        <div class='hospital-address'>123 Đường Láng, Quận Đống Đa, Hà Nội</div>
        <div class='hospital-phone'>Điện thoại: (024) 1234 5678</div>
    </div>
    
    <div class='divider'></div>
    
    <div class='title'>PHIẾU KẾT QUẢ XÉT NGHIỆM</div>
    <div class='print-time'>Thời gian in phiếu: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</div>
    
    <div class='id-container'>
        <div><span class='info-label'>Mã phiếu khám:</span> {txb_id_exam.Text}</div>
        <div><span class='info-label'>Mã kết quả:</span> {dtgv_service.CurrentRow.Cells["examination_service_id"].Value?.ToString() ?? ""}</div>
    </div>
    
    <div class='section-title'>THÔNG TIN BỆNH NHÂN</div>
    <div>
        <div class='info-row'>
            <div class='info-item'><span class='info-label'>Mã BN:</span> {txb_id_patient.Text}</div>
            <div class='info-item'><span class='info-label'>Họ tên:</span> <strong>{txb_name.Text}</strong></div>
            <div class='info-item'><span class='info-label'>Giới tính:</span> {txb_gender.Text}</div>
            <div class='info-item'><span class='info-label'>Ngày sinh:</span> {txb_dob.Text}</div>
        </div>
        <div class='info-row'>
            <div class='info-item'><span class='info-label'>Điện thoại:</span> {txb_phone.Text}</div>
            <div class='info-item'><span class='info-label'>Địa chỉ:</span> {txb_address.Text}</div>
        </div>
        <div class='info-row'>
            <div class='info-item'><span class='info-label'>Ngày tiếp nhận:</span> {txb_reception_date.Text}</div>
            <div class='info-item'><span class='info-label'>Chỉ định:</span> <strong>{txb_service.Text}</strong></div>
            <div class='info-item'><span class='info-label'>Lý do khám:</span> <em>{txb_reason.Text}</em></div>
        </div>
    </div>
    
    <div class='section-title'>KẾT QUẢ XÉT NGHIỆM</div>
    <table>
        <tr>
            <th style='width: 20%;'>Nhóm xét nghiệm</th>
            <th style='width: 25%;'>Tên xét nghiệm</th>
            <th style='width: 15%;'>Kết quả</th>
            <th style='width: 15%;'>Đơn vị</th>
            <th style='width: 20%;'>Giá trị bình thường</th>
        </tr>";

                // Thêm các dòng dữ liệu từ DataGridView
                foreach (DataGridViewRow row in dtgv_result.Rows)
                {
                    if (row.IsNewRow) continue;
                    string groupName = row.Cells[0].Value?.ToString() ?? "";
                    string testName = row.Cells[1].Value?.ToString() ?? "";
                    string result = row.Cells[2].Value?.ToString() ?? "";
                    string unit = row.Cells[3].Value?.ToString() ?? "";
                    string normalRange = row.Cells[4].Value?.ToString() ?? "";

                    html += $@"
        <tr>
            <td>{groupName}</td>
            <td>{testName}</td>
            <td>{result}</td>
            <td>{unit}</td>
            <td>{normalRange}</td>
        </tr>";
                }

                html += $@"
    </table>
    
    <div class='section-title'>KẾT LUẬN</div>
    <div class='conclusion'>
        {txb_final_result.Text.Replace(Environment.NewLine, "<br/>")}
    </div>
    
    <div class='signature'>
        <div>Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}</div>
        <div class='signature-title'>BÁC SĨ XÉT NGHIỆM</div>
        <div class='signature-note'>(Ký và ghi rõ họ tên)</div>
    </div>
</body>
</html>";


                Form previewForm = new Form
                {
                    Text = "Xem trước ",
                    Width = 800,
                    Height = 1000,
                    StartPosition = FormStartPosition.CenterScreen
                };

                WebBrowser browser = new WebBrowser
                {
                    Dock = DockStyle.Fill,
                    DocumentText = html
                };
                System.Windows.Forms.Button printButton = new System.Windows.Forms.Button
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuẩn bị in: " + ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dtgv_exam.Rows.Clear();
            LoadExam.LoadDTGVCommon(dtgv_exam, "Xét nghiệm");
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
			string keyword = txb_search.Text.Trim();
			LoadExam.LoadDTGVCommon(dtgv_exam, "Xét nghiệm", keyword);
		}
    }
}