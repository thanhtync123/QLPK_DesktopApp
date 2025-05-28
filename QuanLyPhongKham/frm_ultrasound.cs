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
using Org.BouncyCastle.Math.Field;

namespace QuanLyPhongKham
{
    public partial class frm_ultrasound : Form
    {

        private bool isUserChangingTemplate = true;


        public frm_ultrasound()
        {
            InitializeComponent();
            LoadExam.InitialDTGVCommon(dtgv_exam);

        }

        private void frm_ultrasound_Load(object sender, EventArgs e)
        {
            LoadExam.LoadDTGVCommon(dtgv_exam, "Siêu âm");
            LoadComboboxTemplate();
            chb_anh1.Checked=true;
            chb_anh2.Checked = true;
            chb_anh3.Checked = true;
            chb_anh4.Checked = true;

        }
        private int snapCount = 0;

       
        private void btn_snap_Click(object sender, EventArgs e)
        {
          
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

        private string imageUrl1 = null;
        private string imageUrl2 = null;
        private string imageUrl3 = null;
        private string imageUrl4 = null;
        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var files = ofd.FileNames;

                // Xác định picturebox đầu tiên đang trống để thêm ảnh vào
                PictureBox[] pictureBoxes = { pb_1, pb_2, pb_3, pb_4 };
                string[] imageUrls = { imageUrl1, imageUrl2, imageUrl3, imageUrl4 };

                int nextEmptyIndex = 0;
                // Tìm vị trí trống đầu tiên
                for (int i = 0; i < pictureBoxes.Length; i++)
                {
                    if (pictureBoxes[i].Image == null)
                    {
                        nextEmptyIndex = i;
                        break;
                    }
                }

                // Thêm các ảnh mới vào các picturebox trống
                for (int i = 0; i < files.Length && nextEmptyIndex < pictureBoxes.Length; i++, nextEmptyIndex++)
                {
                    try
                    {
                        if (pictureBoxes[nextEmptyIndex].Image != null)
                        {
                            pictureBoxes[nextEmptyIndex].Image.Dispose();
                        }

                        pictureBoxes[nextEmptyIndex].Image = Image.FromFile(files[i]);
                        pictureBoxes[nextEmptyIndex].Visible = true;

                        // Lưu đường dẫn ảnh
                        switch (nextEmptyIndex)
                        {
                            case 0: imageUrl1 = files[i]; break;
                            case 1: imageUrl2 = files[i]; break;
                            case 2: imageUrl3 = files[i]; break;
                            case 3: imageUrl4 = files[i]; break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                var mabn = txb_id_patient.Text.Trim();
                var tenbn = txb_name.Text.Trim();
                var ngaysinh = txb_dob.Text.Trim();
                var diachi = txb_address.Text.Trim();
                var sdt = txb_phone.Text.Trim();
                var chandoan = txb_chandoan.Text.Trim();
                var chandoanphu = txb_chandoanphu.Text.Trim();
                var mota = txb_result.Text.Trim();
                var ketqua = txb_final_result.Text.Trim();
                var chidinh = txb_service.Text.Trim();

                // Tạo đường dẫn ảnh trống để tránh lỗi URI
                string projectDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string emptyImagePath = Path.Combine(projectDir, "Resources", "empty.png");

                // Đảm bảo ảnh trống tồn tại
                if (!File.Exists(emptyImagePath))
                {
                    string resourcesDir = Path.Combine(projectDir, "Resources");
                    Directory.CreateDirectory(resourcesDir);

                    // Tạo ảnh trống 1x1 pixel
                    using (Bitmap emptyBmp = new Bitmap(1, 1))
                    {
                        using (Graphics g = Graphics.FromImage(emptyBmp))
                        {
                            g.Clear(Color.Transparent);
                        }
                        emptyBmp.Save(emptyImagePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }

                // Thu thập các ảnh được chọn vào một danh sách
                var selectedImages = new List<string>();

                // Chỉ thêm vào danh sách nếu checkbox được chọn và ảnh tồn tại
                if (chb_anh1.Checked && !string.IsNullOrEmpty(imageUrl1)) selectedImages.Add(imageUrl1);
                if (chb_anh2.Checked && !string.IsNullOrEmpty(imageUrl2)) selectedImages.Add(imageUrl2);
                if (chb_anh3.Checked && !string.IsNullOrEmpty(imageUrl3)) selectedImages.Add(imageUrl3);
                if (chb_anh4.Checked && !string.IsNullOrEmpty(imageUrl4)) selectedImages.Add(imageUrl4);

                // Kiểm tra xem có ảnh nào được chọn không
                if (selectedImages.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một ảnh để in.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Đảm bảo luôn có đủ 4 ảnh để truyền vào báo cáo (thêm ảnh trống nếu cần)
                while (selectedImages.Count < 4)
                {
                    selectedImages.Add(emptyImagePath);
                }

                // Truyền các ảnh theo thứ tự đã được tái sắp xếp
                using (frm_report_ultrasound printForm = new frm_report_ultrasound(
                    selectedImages[0], selectedImages[1], selectedImages[2], selectedImages[3],
                    mabn, tenbn, ngaysinh, diachi, sdt,
                    chandoan, chandoanphu, mota, ketqua, chidinh))
                {
                    printForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void dtgv_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ResetPictureBoxes();

                DataGridViewRow row = dtgv_service.Rows[e.RowIndex];
                txb_service.Text = row.Cells["name"].Value?.ToString();

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
                        Db.SetTextAndMoveCursorToEnd(txb_result, Db.dr["result"].ToString().Replace("\\r\\n", "\r\n"));
                        Db.SetTextAndMoveCursorToEnd(txb_final_result, Db.dr["final_result"].ToString());
                        cb_template.SelectedValue = Convert.ToInt32(Db.dr["template_id"]);
                        isUserChangingTemplate = true;

                        string filePaths = Db.dr["file_path"].ToString();
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
        private void LoadImagesFromPaths(string[] paths)
        {
            snapCount = 0;
            string projectDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;

            PictureBox[] pictureBoxes = { pb_1, pb_2, pb_3, pb_4 };
            string[] imageUrls = new string[4];

            // Luôn hiển thị các PictureBox trước, ngay cả khi chưa có ảnh
            foreach (var pb in pictureBoxes)
            {
                pb.Visible = true;
            }

            for (int i = 0; i < paths.Length && i < 4; i++)
            {
                string fileName = paths[i].Trim();
                if (!string.IsNullOrEmpty(fileName))
                {
                    // Xử lý đường dẫn đúng
                    string fullPath;
                    if (fileName.StartsWith("images/"))
                        fullPath = Path.Combine(projectDir, fileName); // Đường dẫn tương đối
                    else
                        fullPath = Path.Combine(projectDir, "images", fileName); // Chỉ tên file

                    Console.WriteLine($"Đang tìm ảnh tại: {fullPath}");

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            PictureBox pb = pictureBoxes[i];
                            if (pb.Image != null)
                            {
                                pb.Image.Dispose();
                                pb.Image = null;
                            }
                            pb.Image = Image.FromFile(fullPath);
                            imageUrls[i] = fullPath;
                            snapCount++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi đọc ảnh {fullPath}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Không tìm thấy file: {fullPath}");
                        MessageBox.Show($"Không tìm thấy file ảnh: {fullPath}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            // Gán lại các đường dẫn hình ảnh để in
            imageUrl1 = imageUrls[0];
            imageUrl2 = imageUrls[1];
            imageUrl3 = imageUrls[2];
            imageUrl4 = imageUrls[3];

            Console.WriteLine($"Đã hiển thị {snapCount} ảnh");
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








        // Hàm reset các PictureBox
        private void ResetPictureBoxes()
        {
            // Chỉ xóa ảnh, không ẩn PictureBox
            if (pb_1.Image != null) { pb_1.Image.Dispose(); pb_1.Image = null; }
            if (pb_2.Image != null) { pb_2.Image.Dispose(); pb_2.Image = null; }
            if (pb_3.Image != null) { pb_3.Image.Dispose(); pb_3.Image = null; }
            if (pb_4.Image != null) { pb_4.Image.Dispose(); pb_4.Image = null; }

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
                string projectDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string imagesDir = Path.Combine(projectDir, "images");
                Directory.CreateDirectory(imagesDir);  // tạo nếu chưa có

                var pbs = new[] { pb_1, pb_2, pb_3, pb_4 };
                var paths = pbs.Where(p => p.Image != null).Select(p =>
                {
                    string name = Guid.NewGuid() + ".jpg";
                    p.Image.Save(Path.Combine(imagesDir, name), System.Drawing.Imaging.ImageFormat.Jpeg);
                    return $"images/{name}";
                }).ToList();

                string filePaths = string.Join(",", paths);
                int id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
                int tid = Convert.ToInt32(cb_template.SelectedValue);
                string result = txb_result.Text.Replace("'", "''");
                string final = txb_final_result.Text.Replace("'", "''");

                string query = $@"
        INSERT INTO examination_results 
        (examination_service_id, template_id, result, final_result, file_path) 
        VALUES ({id}, {tid}, '{result}', '{final}', '{filePaths}');";

                var cmd = new MySqlCommand(query, Db.conn);
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Thêm kết quả thành công." : "Không có dữ liệu nào được thêm.");
                LoadDTGV_Service();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                string projectDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string folder = Path.Combine(projectDir, "images");
                Directory.CreateDirectory(folder);

                var pbs = new[] { pb_1, pb_2, pb_3, pb_4 };
                var imgs = pbs.Where(p => p.Image != null).Select(p =>
                {
                    string name = Guid.NewGuid() + ".jpg";
                    p.Image.Save(Path.Combine(folder, name), System.Drawing.Imaging.ImageFormat.Jpeg);
                    return name;
                }).ToList();

                string filePaths = string.Join(",", imgs);
                int id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
                int tid = Convert.ToInt32(cb_template.SelectedValue);
                string result = txb_result.Text.Replace("'", "''");
                string final = txb_final_result.Text.Replace("'", "''");

                string query = imgs.Count > 0
                    ? $@"UPDATE examination_results SET template_id={tid}, result='{result}', final_result='{final}', file_path='{filePaths}' WHERE examination_service_id={id};"
                    : $@"UPDATE examination_results SET template_id={tid}, result='{result}', final_result='{final}' WHERE examination_service_id={id};";

                var cmd = new MySqlCommand(query, Db.conn);
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Sửa kết quả thành công." : "Không có dữ liệu nào được sửa.");
                LoadDTGV_Service();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
                string sql = "SELECT `template_content`,`result_content` FROM `templates` WHERE `id` = @template_id;";
                Db.ResetConnection();
                Db.cmd = new MySqlCommand(sql, Db.conn);
                Db.cmd.Parameters.AddWithValue("@template_id", selectedTemplateId);
                Db.dr = Db.cmd.ExecuteReader();

                if (Db.dr.Read())
                {
                    txb_result.Text = Db.dr["template_content"].ToString()
                              .Replace("\\r\\n", "\r\n"); // chuyển chuỗi '\\r\\n' về ký tự xuống dòng thật
                    txb_final_result.Text = Db.dr["result_content"].ToString();
                }
                  

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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PasteImageFromClipboard()
        {
            try
            {
                // Kiểm tra xem clipboard có chứa hình ảnh không
                if (Clipboard.ContainsImage())
                {
                    Image img = Clipboard.GetImage();
                    if (img != null)
                    {
                        // Tìm PictureBox trống đầu tiên
                        PictureBox[] pictureBoxes = { pb_1, pb_2, pb_3, pb_4 };
                        int targetIndex = -1;

                        for (int i = 0; i < pictureBoxes.Length; i++)
                        {
                            if (pictureBoxes[i].Image == null)
                            {
                                targetIndex = i;
                                break;
                            }
                        }

                        if (targetIndex != -1)
                        {
                            // Gán ảnh vào PictureBox
                            PictureBox targetPb = pictureBoxes[targetIndex];
                            targetPb.Image = img;
                            targetPb.Visible = true;

                            // Lưu ảnh vào file và cập nhật đường dẫn
                            string projectDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                            string imagesDir = Path.Combine(projectDir, "images");
                            Directory.CreateDirectory(imagesDir);

                            string fileName = Guid.NewGuid() + ".jpg";
                            string filePath = Path.Combine(imagesDir, fileName);
                            img.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                            // Cập nhật đường dẫn ảnh tương ứng - cách an toàn
                            switch (targetIndex)
                            {
                                case 0: imageUrl1 = filePath; break;
                                case 1: imageUrl2 = filePath; break;
                                case 2: imageUrl3 = filePath; break;
                                case 3: imageUrl4 = filePath; break;
                            }

                            // Tăng biến đếm ảnh
                            snapCount++;

                            MessageBox.Show("Đã paste ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Tất cả các ô đã có ảnh. Vui lòng xóa ít nhất một ảnh để paste.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Clipboard không chứa hình ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi paste ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                PasteImageFromClipboard();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả ảnh?", "Xác nhận",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Giải phóng bộ nhớ cho các ảnh
                if (pb_1.Image != null) { pb_1.Image.Dispose(); pb_1.Image = null; }
                if (pb_2.Image != null) { pb_2.Image.Dispose(); pb_2.Image = null; }
                if (pb_3.Image != null) { pb_3.Image.Dispose(); pb_3.Image = null; }
                if (pb_4.Image != null) { pb_4.Image.Dispose(); pb_4.Image = null; }

 

                // Xóa tất cả đường dẫn
                imageUrl1 = imageUrl2 = imageUrl3 = imageUrl4 = null;

                // Reset biến đếm ảnh
                snapCount = 0;

                
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }
    }
}