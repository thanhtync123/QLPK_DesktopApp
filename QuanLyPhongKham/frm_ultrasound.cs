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
        private Timer timer = new Timer();
        private int? selectedExamId = null;
        private void frm_ultrasound_Load(object sender, EventArgs e)
        {
            LoadExam.LoadDTGVCommon(dtgv_exam, "Siêu âm");
            LoadComboboxTemplate();

            // Thiết lập timer tự động reload mỗi 3 giây và lưu trạng thái dòng hiện tại
            timer.Interval = 3000;
            timer.Tick += (s, ev) =>
            {
                // Lưu id_exam của dòng hiện tại (nếu có)
                if (dtgv_exam.CurrentRow != null && dtgv_exam.CurrentRow.Cells["id_exam"].Value != null)
                {
                    selectedExamId = Convert.ToInt32(dtgv_exam.CurrentRow.Cells["id_exam"].Value);
                }

                // Reload dữ liệu
                LoadExam.LoadDTGVCommon(dtgv_exam, "Siêu âm");

                // Khôi phục lựa chọn dòng cũ nếu còn tồn tại
                if (selectedExamId.HasValue)
                {
                    foreach (DataGridViewRow row in dtgv_exam.Rows)
                    {
                        if (row.Cells["id_exam"].Value != null && Convert.ToInt32(row.Cells["id_exam"].Value) == selectedExamId)
                        {
                            dtgv_exam.CurrentCell = row.Cells[0];
                            dtgv_exam.Rows[row.Index].Selected = true;
                            break;
                        }
                    }
                }
            };
            timer.Start();
        }
        private int snapCount = 0;

       
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

        private string imageUrl1 = null;
        private string imageUrl2 = null;
        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.Multiselect = true;


            if (ofd.ShowDialog() == DialogResult.OK)
            {

                var files = ofd.FileNames;
                if (files.Length > 0)
                {
                    pb_1.Visible = true;
                    imageUrl1 = files[0];
                    pb_1.Image = Image.FromFile(files[0]);
                }
                if (files.Length > 1)
                {
                    pb_2.Visible = true;
                    imageUrl2= files[1]; 
                    pb_2.Image = Image.FromFile(files[1]);
                }



            }

        }
        private void btn_print_Click(object sender, EventArgs e)
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
                using (frm_report_ultrasound printForm = new frm_report_ultrasound(imageUrl1,imageUrl2,mabn,tenbn,ngaysinh,diachi,sdt,chandoan,chandoanphu,mota,ketqua,chidinh))
                {
                    printForm.ShowDialog();
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
            string imagesDir = Path.Combine(projectDir, "images");

            for (int i = 0; i < paths.Length && i < 2; i++) // chỉ xử lý 2 ảnh
            {
                string fileName = paths[i].Trim();
                if (!string.IsNullOrEmpty(fileName))
                {
                    string fullPath = Path.Combine(imagesDir, fileName);
                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            PictureBox pb = (i == 0) ? pb_1 : pb_2;
                            if (pb.Image != null)
                            {
                                pb.Image.Dispose();
                                pb.Image = null;
                            }
                            pb.Image = Image.FromFile(fullPath);
                            pb.Visible = true;
                            snapCount++;

                            // Gán đường dẫn ảnh để in
                            if (i == 0) imageUrl1 = fullPath;
                            else if (i == 1) imageUrl2 = fullPath;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi đọc ảnh {fullPath}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"File ảnh không tồn tại: {fullPath}");
                    }
                }
            }

            Console.WriteLine($"Đã hiển thị {snapCount} ảnh");

            //snapCount = 0;
            //string projectDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            //string imagesDir = Path.Combine(projectDir, "images");

            //for (int i = 0; i < paths.Length && i < 4; i++)
            //{
            //    string fileName = paths[i].Trim();
            //    if (!string.IsNullOrEmpty(fileName))
            //    {
            //        string fullPath = Path.Combine(imagesDir, fileName);
            //        if (File.Exists(fullPath))
            //        {
            //            try
            //            {
            //                PictureBox pb = null;
            //                switch (i)
            //                {
            //                    case 0: pb = pb_1; break;
            //                    case 1: pb = pb_2; break;
            //                    case 2: pb = pb_3; break;
            //                    case 3: pb = pb_4; break;
            //                }
            //                if (pb != null)
            //                {
            //                    if (pb.Image != null)
            //                    {
            //                        pb.Image.Dispose();
            //                        pb.Image = null;
            //                    }
            //                    pb.Image = Image.FromFile(fullPath);
            //                    pb.Visible = true;
            //                    snapCount++;
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show($"Lỗi khi đọc ảnh {fullPath}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine($"File ảnh không tồn tại: {fullPath}");
            //        }
            //    }
            //}

            //Console.WriteLine($"Đã hiển thị {snapCount} ảnh");
        }

        private void dtgv_exam_CellClick(object sender, DataGridViewCellEventArgs e) // KHÔNG CẦN TẠO LẠI SỰ KIỆN VÌ ĐÃ TẠO
        {
            if (e.RowIndex >= 0 && dtgv_exam.Rows[e.RowIndex].Cells["id_exam"].Value != null)
            {
                DataGridViewRow row = dtgv_exam.Rows[e.RowIndex];
                selectedExamId = Convert.ToInt32(row.Cells["id_exam"].Value);
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


    }
}