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
using WMPLib;
using System.IO;
using System.Collections.Generic;

namespace QuanLyPhongKham
{
    public partial class frm_ultrasound : Form
    {

        private bool isUserChangingTemplate = true;


        public frm_ultrasound()
        {
            InitializeComponent();
            LoadExam.InitialDTGVCommon(dtgv_exam);
            LoadExam.LoadDTGVCommon(dtgv_exam, "Siêu âm");
        }
        private void frm_ultrasound_Load(object sender, EventArgs e)
        {
            LoadComboboxTemplate();
            loadvideo();
            webBrowser1.Visible = false;
        }
        private int snapCount = 0;

        private void loadvideo()
        {
            // Ẩn tất cả các PictureBox khi bắt đầu
            pb_1.Visible = false;
            pb_2.Visible = false;
            pb_3.Visible = false;
            pb_4.Visible = false;

            // Thiết lập màu nền
            pb_1.BackColor = pb_2.BackColor = pb_3.BackColor = pb_4.BackColor = Color.LightGray;

            // Thiết lập SizeMode cho tất cả PictureBox
            pb_1.SizeMode = pb_2.SizeMode = pb_3.SizeMode = pb_4.SizeMode = PictureBoxSizeMode.StretchImage;

            // Mở video và phát
            wmp.URL = @"D:\123.mp4";
            wmp.Ctlcontrols.play();

            // Reset biến đếm
            snapCount = 0;
        }

        private void btn_snap_Click(object sender, EventArgs e)
        {
            // Kiểm tra số lần chụp và video đang phát
            if (snapCount >= 4)
            {
                MessageBox.Show("Đã chụp đủ 4 ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (wmp.currentMedia == null)
            {
                MessageBox.Show("Không có video nào đang phát!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Tạm dừng video
                wmp.Ctlcontrols.pause();

                // Chụp ảnh từ màn hình
                Bitmap screenshot = new Bitmap(wmp.Width, wmp.Height);
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    g.CopyFromScreen(wmp.PointToScreen(Point.Empty), Point.Empty, wmp.Size);
                }

                // Xác định PictureBox để hiển thị ảnh
                PictureBox currentPb = null;
                switch (snapCount)
                {
                    case 0: currentPb = pb_1; break;
                    case 1: currentPb = pb_2; break;
                    case 2: currentPb = pb_3; break;
                    case 3: currentPb = pb_4; break;
                }

                // Hiển thị ảnh
                if (currentPb != null)
                {
                    currentPb.Image = screenshot;
                    currentPb.Visible = true;
                }

                snapCount++;

                // Tiếp tục phát video
                wmp.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               WHERE e.id = @exam_id AND s.type = 'Siêu âm'";

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
            string query = "SELECT id, name, template_content,type FROM templates where type = 'Siêu âm' ";
            Db.LoadComboBoxData(cb_template, query, "name", "id");
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            //if (dtgv_service.CurrentRow == null || txb_result.Text.Trim() == "")
            //{
            //    MessageBox.Show("Vui lòng chọn dịch vụ có kết quả để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Tạo HTML phiếu kết quả siêu âm
            string html = $@"
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; margin: 10px; color: #333; background-color: #fff; line-height: 1.3; font-size: 12px; }}
        .header {{ text-align: center; margin-bottom: 8px; }}
        .clinic-name {{ font-size: 20px; font-weight: bold; color: #2c3e50; margin-bottom: 2px; text-transform: uppercase; }}
        .clinic-address {{ font-size: 12px; margin-bottom: 0; color: #2c3e50; }}
        .clinic-phone {{ font-size: 12px; color: #2c3e50; margin-top: 2px; }}
        .divider {{ border-top: 1px solid #3498db; margin: 5px 0; }}
        .title {{ text-align: center; font-size: 18px; font-weight: bold; margin: 8px 0; color: #2c3e50; text-transform: uppercase; }}
        .print-time {{ text-align: right; font-size: 10px; color: #7f8c8d; font-style: italic; margin: 2px 0; }}
        .section-title {{ font-size: 14px; font-weight: bold; color: #2980b9; margin: 8px 0 5px 0; text-transform: uppercase; border-left: 3px solid #3498db; padding-left: 5px; }}
        .info-row {{ display: flex; flex-wrap: wrap; margin: 2px 0; }}
        .info-item {{ margin-right: 15px; font-size: 12px; white-space: nowrap; }}
        .info-label {{ font-weight: bold; }}
        .result-box {{ background-color: #f8f9fa; padding: 8px; border-radius: 3px; border-left: 3px solid #3498db; margin-top: 5px; font-size: 12px; line-height: 1.4; }}
        .image-container {{ display: flex; flex-wrap: wrap; gap: 8px; margin-top: 5px; }}
        .image-container img {{ max-width: 48%; height: auto; border: 1px solid #ddd; border-radius: 3px; }}
        .signature {{ margin-top: 15px; text-align: right; font-size: 12px; }}
        .signature-title {{ font-weight: bold; margin-top: 5px; }}
        .signature-note {{ margin-top: 30px; font-style: italic; }}
        @media print {{ 
            body {{ margin: 0; background-color: #fff; }} 
            .result-box {{ background-color: #fff; border-left: 1px solid #000; }}
            .image-container img {{ max-width: 48%; border: 1px solid #999; }}
        }}
    </style>
</head>
<body>
    <div class='header'>
        <div class='clinic-name'>PHÒNG KHÁM ĐA KHOA</div>
        <div class='clinic-address'>Địa chỉ: 123 Đường Thanh Niên, Quận Hải Châu, Đà Nẵng</div>
        <div class='clinic-phone'>Điện thoại: 0123-456-789</div>
    </div>
    
    <div class='divider'></div>
    
    <div class='title'>PHIẾU KẾT QUẢ SIÊU ÂM</div>
    <div class='print-time'>Thời gian in phiếu: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</div>
    
    <div class='section-title'>THÔNG TIN BỆNH NHÂN</div>
    <div>
        <div class='info-row'>
            <div class='info-item'><span class='info-label'>Mã BN:</span> {txb_id_patient.Text}</div>
            <div class='info-item'><span class='info-label'>Họ tên:</span> <strong>{txb_name.Text}</strong></div>
            <div class='info-item'><span class='info-label'>Giới tính:</span> {txb_gender.Text}</div>
            <div class='info-item'><span class='info-label'>Ngày sinh:</span> {txb_dob.Text}</div>
        </div>
        <div class='info-row'>
            <div class='info-item'><span class='info-label'>SĐT:</span> {txb_phone.Text}</div>
            <div class='info-item'><span class='info-label'>Địa chỉ:</span> {txb_address.Text}</div>
        </div>
    </div>
    
    <div class='section-title'>THÔNG TIN KHÁM</div>
    <div>
        <div class='info-row'>
            <div class='info-item'><span class='info-label'>Mã phiếu khám:</span> {txb_id_exam.Text}</div>
            <div class='info-item'><span class='info-label'>Ngày khám:</span> {txb_reception_date.Text}</div>
            <div class='info-item'><span class='info-label'>Mã phiếu KQ:</span> {dtgv_service.CurrentRow.Cells["examination_service_id"].Value?.ToString()}</div>
        </div>
        <div class='info-row'>
            <div class='info-item'><span class='info-label'>Chỉ định:</span> <strong>{txb_service.Text}</strong></div>
            <div class='info-item'><span class='info-label'>Lý do khám:</span> <em>{txb_chandoanphu.Text}</em></div>
        </div>
    </div>
    
    <div class='section-title'>KẾT QUẢ SIÊU ÂM</div>
    <div class='result-box'>
        {txb_result.Text.Replace(Environment.NewLine, "<br/>")}
    </div>
";

            // Thêm phần kết luận nếu có
            if (!string.IsNullOrWhiteSpace(txb_final_result.Text))
            {
                html += $@"
    <div class='section-title'>KẾT LUẬN</div>
    <div class='result-box' style='border-left: 3px solid #e74c3c;'>
        <strong>{txb_final_result.Text.Replace(Environment.NewLine, "<br/>")}</strong>
    </div>
";
            }

            // Thêm ảnh từ PictureBox
            string imageHtml = "";
            PictureBox[] pictureBoxes = { pb_1, pb_2, pb_3, pb_4 };
            foreach (var pb in pictureBoxes)
            {
                if (pb != null && pb.Image != null)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Explicitly save as JPEG to avoid RawFormat issues
                            pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] imageBytes = ms.ToArray();
                            string base64String = Convert.ToBase64String(imageBytes);
                            imageHtml += $"<img src='data:image/jpeg;base64,{base64String}' />";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the error and continue with other images
                        MessageBox.Show($"Lỗi khi xử lý ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (!string.IsNullOrEmpty(imageHtml))
            {
                html += $@"
    <div class='section-title'>HÌNH ẢNH SIÊU ÂM</div>
    <div class='image-container'>
        {imageHtml}
    </div>
";
            }

            // Thêm phần chữ ký
            html += $@"
    <div class='signature'>
        <div>Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}</div>
        <div class='signature-title'>BÁC SĨ</div>
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

        private void dtgv_exam_CellClick(object sender, DataGridViewCellEventArgs e) // KHÔNG CẦN TẠO LẠI SỰ KIỆN VÌ ĐÃ TẠO
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
                txb_age.Text = age.ToString() + " tuổi"; ;
                txb_chandoan.Text = diagnosis + "";
                Db.SetTextAndMoveCursorToEnd(txb_phone, phone);
                Db.SetTextAndMoveCursorToEnd(txb_address, address);
                Db.SetTextAndMoveCursorToEnd(txb_reception_date, updated_at);
                Db.SetTextAndMoveCursorToEnd(txb_chandoanphu, reason);
                Db.SetTextAndMoveCursorToEnd(txb_id_patient, id_patient);
                Db.SetTextAndMoveCursorToEnd(txb_note, note);

                LoadDTGV_Service();
            }
        }

        private void dtgv_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Reset các PictureBox và snapCount
                ResetPictureBoxes();

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
                er.final_result,
                er.file_path
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

                        // Lấy đường dẫn ảnh
                        string filePaths = Db.dr["file_path"].ToString();

                        // Hiển thị các ảnh
                        if (!string.IsNullOrEmpty(filePaths))
                        {
                            LoadImagesFromPaths(filePaths.Split(','));
                        }
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

        // Hàm để hiển thị ảnh từ đường dẫn
        // Hàm để hiển thị ảnh từ đường dẫn
        private void LoadImagesFromPaths(string[] paths)
        {
            snapCount = 0;

            for (int i = 0; i < paths.Length && i < 4; i++) // Giới hạn tối đa 4 ảnh
            {
                string path = paths[i].Trim(); // Loại bỏ khoảng trắng thừa nếu có

                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    try
                    {
                        Image img = Image.FromFile(path);

                        PictureBox currentPb = null;
                        switch (i)
                        {
                            case 0: currentPb = pb_1; break;
                            case 1: currentPb = pb_2; break;
                            case 2: currentPb = pb_3; break;
                            case 3: currentPb = pb_4; break;
                        }

                        if (currentPb != null)
                        {
                            currentPb.Image = img;
                            currentPb.Visible = true;
                            snapCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc ảnh {path}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Console.WriteLine($"Đường dẫn không hợp lệ hoặc file không tồn tại: '{path}'");
                }
            }

            Console.WriteLine($"Đã hiển thị {snapCount} ảnh");
        }

        // Hàm reset các PictureBox
        private void ResetPictureBoxes()
        {
            // Xóa tất cả ảnh và ẩn PictureBox
            pb_1.Image = null;
            pb_2.Image = null;
            pb_3.Image = null;
            pb_4.Image = null;

            pb_1.Visible = false;
            pb_2.Visible = false;
            pb_3.Visible = false;
            pb_4.Visible = false;

            snapCount = 0;
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
        JOIN services s ON s.id = es.service_id AND s.type = 'Siêu âm'
        LEFT JOIN examination_results er ON er.examination_service_id = es.id
        WHERE DATE(e.updated_at) 
              BETWEEN STR_TO_DATE(@from_date, '%d/%m/%Y') 
              AND STR_TO_DATE(@to_date, '%d/%m/%Y')
    ";

            if (rdn_all.Checked)
            
                query += "";
            
            if (rdn_resulted.Checked)
            

                query += " AND er.id IS NOT NULL ";
            
            else if (rdn_noresult.Checked)
            

                query += " AND er.id IS NULL ";
            

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

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> imagePaths = new List<string>();

  
                string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;


                string folderPath = Path.Combine(projectPath, "images");

   
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Lưu các ảnh từ PictureBox
                for (int i = 0; i < snapCount; i++)
                {
                    PictureBox currentPb = null;
                    switch (i)
                    {
                        case 0: currentPb = pb_1; break;
                        case 1: currentPb = pb_2; break;
                        case 2: currentPb = pb_3; break;
                        case 3: currentPb = pb_4; break;
                    }

                    if (currentPb != null && currentPb.Image != null)
                    {
                        string randomFileName = Guid.NewGuid().ToString() + ".jpg";
                        string fullPath = Path.Combine(folderPath, randomFileName);

                        currentPb.Image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imagePaths.Add(fullPath);
                    }
                }

                string filePaths = string.Join(",", imagePaths);

                var examination_service_id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
                var template_id = Convert.ToInt32(cb_template.SelectedValue);
                string result = txb_result.Text;
                string final_result = txb_final_result.Text;

                string query = @"INSERT INTO examination_results 
(examination_service_id, template_id, result, final_result, file_path) 
VALUES (@examination_service_id, @template_id, @result, @final_result, @file_path);";

                MySqlCommand cmd = new MySqlCommand(query, Db.conn);
                cmd.Parameters.AddWithValue("@examination_service_id", examination_service_id);
                cmd.Parameters.AddWithValue("@template_id", template_id);
                cmd.Parameters.AddWithValue("@result", result);
                cmd.Parameters.AddWithValue("@final_result", final_result);
                cmd.Parameters.AddWithValue("@file_path", filePaths);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm kết quả thành công.");
                    LoadDTGV_Service();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào được thêm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> imagePaths = new List<string>();

                // Lấy thư mục gốc dự án
                string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string folderPath = Path.Combine(projectPath, "images");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Lưu ảnh nếu có
                for (int i = 0; i < snapCount; i++)
                {
                    PictureBox currentPb = null;
                    switch (i)
                    {
                        case 0: currentPb = pb_1; break;
                        case 1: currentPb = pb_2; break;
                        case 2: currentPb = pb_3; break;
                        case 3: currentPb = pb_4; break;
                    }

                    if (currentPb != null && currentPb.Image != null)
                    {
                        string randomFileName = Guid.NewGuid().ToString() + ".jpg";
                        string fullPath = Path.Combine(folderPath, randomFileName);

                        currentPb.Image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                        // Lưu **tên file** thay vì full path
                        imagePaths.Add(randomFileName);
                    }
                }

                string filePaths = string.Join(",", imagePaths);

                var examination_service_id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
                var template_id = Convert.ToInt32(cb_template.SelectedValue);
                string result = txb_result.Text;
                string final_result = txb_final_result.Text;

                string query;
                MySqlCommand cmd;

                if (imagePaths.Count > 0)
                {
                    // Nếu có ảnh mới thì update cả file_path
                    query = @"UPDATE examination_results SET 
                    template_id=@template_id,
                    result=@result,
                    final_result=@final_result,
                    file_path=@file_path
                    WHERE examination_service_id = @examination_service_id";

                    cmd = new MySqlCommand(query, Db.conn);
                    cmd.Parameters.AddWithValue("@file_path", filePaths);
                }
                else
                {
                    // Không ảnh mới thì giữ nguyên file_path
                    query = @"UPDATE examination_results SET 
                    template_id=@template_id,
                    result=@result,
                    final_result=@final_result
                    WHERE examination_service_id = @examination_service_id";

                    cmd = new MySqlCommand(query, Db.conn);
                }

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
                {
                    MessageBox.Show("Không có dữ liệu nào được sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dtgv_exam.Rows.Clear();
            LoadExam.LoadDTGVCommon(dtgv_exam, "Siêu âm");
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


        private void btn_resetpicturebox_Click(object sender, EventArgs e)
        {
            ResetPictureBoxes();
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
			string keyword = txb_search.Text.Trim();
			LoadExam.LoadDTGVCommon(dtgv_exam, "Siêu âm", keyword);
		}

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.Multiselect = true;
            txb_filepath.Text = ""; 

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var files = ofd.FileNames;
                if (files.Length > 0)
                {
                    pb_1.Visible = true;
                    pb_1.Image = Image.FromFile(files[0]);
                }
                if (files.Length > 1)
                {
                    pb_2.Visible = true;
                    pb_2.Image = Image.FromFile(files[1]);
                }
                if (files.Length > 2)
                {
                    pb_3.Visible = true;
                    pb_3.Image = Image.FromFile(files[2]);
                }
                if (files.Length > 3)
                {
                    pb_4.Visible = true;
                    pb_4.Image = Image.FromFile(files[3]);
                }
                txb_filepath.Text = string.Join(";", files);

            }
          
        }
    }
}