using System;
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
namespace QuanLyPhongKham
{
    public partial class frm_examination : Form
    {
        int id;


        public frm_examination()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            label27.Visible = false;
            dtgv_patients.Columns.Add("date_of_birth", "Ngày sinh");
            dtgv_patients.Columns["date_of_birth"].Visible = false;
            dtgv_patients.Columns.Add("gender", "Giới tính");
            dtgv_patients.Columns["gender"].Visible = false;
            dtgv_patients.Columns.Add("phone", "SĐT");
            dtgv_patients.Columns["phone"].Visible = false;
            dtgv_patients.Columns.Add("address", "Địa chỉ");
            dtgv_patients.Columns["address"].Visible = false;

            dtgv_patients.Rows.Clear();

            string sql = @"SELECT 
                 id, 
                 name, 
                 DATE_FORMAT(date_of_birth, '%d/%m/%Y') AS date_of_birth, 
                 gender, 
                 phone, 
                 address, 
                 created_at, 
                 DATE_FORMAT(updated_at, '%H:%i:%s') AS updated_time
             FROM patients
             WHERE DATE(updated_at) = CURDATE();";

            Db.ResetConnection();
            MySqlCommand cmd = Db.CreateCommand(sql);
            MySqlDataReader dr = cmd.ExecuteReader();

            bool hasData = false;

            while (dr.Read())
            {
                hasData = true;

                int i = dtgv_patients.Rows.Add();
                DataGridViewRow drr = dtgv_patients.Rows[i];
                drr.Cells["ID"].Value = dr["id"];
                drr.Cells["name"].Value = dr["name"];
                drr.Cells["date_of_birth"].Value = dr["date_of_birth"];
                drr.Cells["gender"].Value = dr["gender"];
                drr.Cells["phone"].Value = dr["phone"];
                drr.Cells["address"].Value = dr["address"];
                drr.Cells["time_patients"].Value = dr["updated_time"];
            }

            dr.Close();
            Db.ResetConnection();

            dr.Close();
            Db.ResetConnection();

            if (!hasData)
            {
                label27.Text = "Không có bệnh nhân nào được tiếp nhận trong hôm nay.";
                label27.Visible = true;
            }
            else
            
                label27.Visible = false;
            


        }

        private void frm_examination_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadComboboxDiagnoses();
            LoadComboboxDoctorNote();
            LoadComboboxMed();
            LoadExamID();
            LoadDTGV_Service();
            btn_deletemed.Enabled = false;
            cb_diagnoses.SelectedIndex = 0;
   


        }

        private void dtgv_patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dtgv_patients.CurrentRow.Cells["ID"].Value);
            txb_name.Text = dtgv_patients.CurrentRow.Cells["name"].Value.ToString();
            txb_id.Text = id.ToString();
            txb_ngaysinh.Text = dtgv_patients.CurrentRow.Cells["date_of_birth"].Value.ToString();
            int lastFourChars = Convert.ToInt32(txb_ngaysinh.Text.Substring(txb_ngaysinh.Text.Length - 4));
            int currentYear = DateTime.Now.Year;
            txb_age.Text = (currentYear - lastFourChars).ToString();
            txb_address.Text = dtgv_patients.CurrentRow.Cells["address"].Value.ToString();
            txb_gender.Text = dtgv_patients.CurrentRow.Cells["gender"].Value.ToString();


        }

        private void LoadComboboxDoctorNote()
        {

            string query = "SELECT id, content FROM doctor_notes order by content asc";
            Db.LoadComboBoxData(cb_doctornote, query, "content", "id");

        }
        private void LoadComboboxDiagnoses()
        {
            string query = "SELECT id, name FROM diagnoses order by name asc";
            Db.LoadComboBoxData(cb_diagnoses, query, "name", "id");
            cb_diagnoses.SelectedIndex = 0;  // Chọn phần tử đầu tiên sau khi load dữ liệu
        }

        private void LoadComboboxMed()
        {
            string query = "SELECT id, name FROM medications order by name asc";
            Db.LoadComboBoxData(cb_medname, query, "name", "id");
            cb_medname.SelectedIndex = 0;  // Chọn phần tử đầu tiên sau khi load dữ liệu

        }

        private void btn_addmed_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgv_med.Rows.Add();
            dtgv_med.Rows[rowIndex].Cells[0].Value = cb_medname.SelectedValue;
            dtgv_med.Rows[rowIndex].Cells[1].Value = cb_medname.Text;
            dtgv_med.Rows[rowIndex].Cells[2].Value = txb_unit.Text;
            dtgv_med.Rows[rowIndex].Cells[3].Value = txb_dosage.Text;
            dtgv_med.Rows[rowIndex].Cells[4].Value = txb_route.Text;
            dtgv_med.Rows[rowIndex].Cells[5].Value = txb_times.Text;
            dtgv_med.Rows[rowIndex].Cells[6].Value = txb_mednote.Text;
            dtgv_med.Rows[rowIndex].Cells[7].Value = txb_quantity.Text;
            dtgv_med.Rows[rowIndex].Cells[8].Value =  txb_price.Text;
            dtgv_med.Rows[rowIndex].Cells[9].Value = txb_totalpricepermed.Text;
            lb_totalprice.Text = "Tổng tiền";

            decimal total = 0;
            foreach (DataGridViewRow row in dtgv_med.Rows)
            
                if (row.Cells[9].Value != null && decimal.TryParse(row.Cells[9].Value.ToString(), out decimal rowTotal))
                
                    total += rowTotal;
                
            
            lb_totalprice.Text = "Tổng tiền: " + total.ToString("N0") + " đ";

        }

        private void cb_medname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_medname.SelectedIndex != 0)
            {
                if (Db.conn.State != ConnectionState.Open)
                    Db.ResetConnection(); // dùng Db.ResetConnection() nếu đã viết sẵn trong Db.cs

                string query = "SELECT id, name, unit, dosage, route, times_per_day, note, price FROM medications WHERE id = @id";
                int selectedId = Convert.ToInt32(cb_medname.SelectedValue);

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
            txb_totalpricepermed.Text = quantity * price+"";
        }

        private void btn_deletemed_Click(object sender, EventArgs e)
        {
            if (dtgv_med.SelectedRows.Count > 0)
                dtgv_med.Rows.RemoveAt(dtgv_med.SelectedRows[0].Index);

            else
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");

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
        private void LoadDTGV_Service()
        {
            ResetConnection();
            string query = "SELECT `id`, `name`, `type`,`price` \r\n FROM `services`\r\nORDER BY FIELD(`type`, 'X-quang', 'Siêu âm', 'Xét nghiệm', 'Điện tim');\r\n";
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
                    string queryExamination = @"
INSERT INTO examinations 
(id, patient_id, reason, diagnosis_id, doctor_note_id, note, pulse, blood_pressure, respiratory_rate, weight, height, temperature, type, created_at, updated_at) 
VALUES 
(NULL, @patient_id, @reason, @diagnosis_id, @doctor_note_id, @note, @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature, @type, current_timestamp(), current_timestamp());";

                MySqlCommand cmd = new MySqlCommand(queryExamination, Db.conn);

                // Gán giá trị cho các parameter
                cmd.Parameters.AddWithValue("@patient_id", Convert.ToInt16(txb_id.Text));
                cmd.Parameters.AddWithValue("@reason", lbsdfsf.Text);
                cmd.Parameters.AddWithValue("@diagnosis_id", Convert.ToInt16(cb_diagnoses.SelectedValue));
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
                string queryGetExamID = "SELECT LAST_INSERT_ID();";
                cmd = new MySqlCommand(queryGetExamID, Db.conn);
                int examinationID = Convert.ToInt32(cmd.ExecuteScalar());

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
                ResetConnection();
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
                string queryExamination = @"
INSERT INTO examinations 
(id, patient_id, reason, diagnosis_id, doctor_note_id, note, pulse, blood_pressure, respiratory_rate, weight, height, temperature, type, created_at, updated_at) 
VALUES 
(NULL, @patient_id, @reason, @diagnosis_id, @doctor_note_id, @note, @pulse, @blood_pressure, @respiratory_rate, @weight, @height, @temperature, @type, current_timestamp(), current_timestamp());";

                MySqlCommand cmd = new MySqlCommand(queryExamination, Db.conn);

                // Gán giá trị cho các parameter
                cmd.Parameters.AddWithValue("@patient_id", Convert.ToInt16(txb_id.Text));
                cmd.Parameters.AddWithValue("@reason", lbsdfsf.Text);
                cmd.Parameters.AddWithValue("@diagnosis_id", Convert.ToInt16(cb_diagnoses.SelectedValue));
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
                string queryGetExamID = "SELECT LAST_INSERT_ID();";
                cmd = new MySqlCommand(queryGetExamID,   Db.conn);
                int examinationID = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (DataGridViewRow row in dtgv_service_patient.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string queryMedication = "INSERT INTO `examination_services` " +
                            "(`id`, `examination_id`, `service_id`, `price`) VALUES " +
                            "(NULL, @examination_id, @service_id, @price);";
                        cmd = new MySqlCommand(queryMedication, Db.conn);
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

            lb_total_price_service.Text = total.ToString("N0"); // định dạng tiền, có thể dùng "C" nếu muốn hiển thị đơn vị tiền tệ
        }

        private void btn_print_prescription_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            // Mở bản xem trước
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Khai báo font
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font contentFont = new Font("Arial", 12);
            Font smallFont = new Font("Arial", 10);
            Font boldContentFont = new Font("Arial", 12, FontStyle.Bold); // Font đậm cho tên thuốc

            // Khởi tạo vị trí
            float y = 20;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;

            // In thông tin phòng khám (căn trái và phải)
            e.Graphics.DrawString("Phòng Khám Đa Khoa Bình Tân", contentFont, Brushes.Black, leftMargin, y);
        
            y += 20;
            e.Graphics.DrawString("166 Lã Văn Quý, Q. Bình Tân", contentFont, Brushes.Black, leftMargin, y);

            y += 20;
            e.Graphics.DrawString("08 54594554", contentFont, Brushes.Black, leftMargin, y);
            y += 40;

            // In tiêu đề chính (căn giữa)
            string title = "ĐƠN THUỐC";
            float titleWidth = e.Graphics.MeasureString(title, titleFont).Width;
            e.Graphics.DrawString(title, titleFont, Brushes.Black, (e.MarginBounds.Width - titleWidth) / 2 + leftMargin, y);
            y += 40;

            // In thông tin bệnh nhân
            e.Graphics.DrawString($"Họ tên: {txb_name.Text}", contentFont, Brushes.Black, leftMargin, y);
            e.Graphics.DrawString($"Năm sinh: {txb_ngaysinh.Text}", contentFont, Brushes.Black, leftMargin + 300, y);
            y += 25;
            e.Graphics.DrawString($"Giới tính: {txb_gender.Text}", contentFont, Brushes.Black, leftMargin, y);
            e.Graphics.DrawString($"Chẩn đoán: {txb_reason.Text}", contentFont, Brushes.Black, leftMargin + 300, y);
            y += 40;

            // In danh sách thuốc (không dùng cột, chỉ in theo định dạng yêu cầu)
            int medicineIndex = 1;
            foreach (DataGridViewRow row in dtgv_med.Rows)
            {
                if (row.IsNewRow) continue;

                // Lấy thông tin thuốc
                string medicineName = row.Cells[1].Value?.ToString() ?? ""; // Tên thuốc (cột 1)
                string quantity = row.Cells[7].Value?.ToString() ?? ""; // Số lượng (cột 7)
                string note = row.Cells[6].Value?.ToString() ?? ""; // Ghi chú (cột 6)

                // In số thứ tự và tên thuốc (in đậm)
                string medicineLine = $"{medicineIndex}. {medicineName}";
                e.Graphics.DrawString(medicineLine, boldContentFont, Brushes.Black, leftMargin, y);

                // In số lượng (căn phải trên cùng dòng)
                string quantityLine = $"Số lượng {quantity} viên";
                float quantityWidth = e.Graphics.MeasureString(quantityLine, contentFont).Width;
                e.Graphics.DrawString(quantityLine, contentFont, Brushes.Black, rightMargin - quantityWidth, y);
                y += 25;

                // In ghi chú (thụt lề)
                if (!string.IsNullOrEmpty(note))
                {
                    e.Graphics.DrawString(note, contentFont, Brushes.Black, leftMargin + 20, y);
                    y += 25;
                }

                medicineIndex++;
            }

            // In lời dặn và chữ ký bác sĩ
            y += 40;
            e.Graphics.DrawString($"Lời dặn: {cb_doctornote.Text}", contentFont, Brushes.Black, leftMargin, y);
            y += 25;
            e.Graphics.DrawString($"Ngày {DateTime.Now.Day} Tháng {DateTime.Now.Month} Năm {DateTime.Now.Year}", smallFont, Brushes.Black, leftMargin + 500, y);
            y += 25;
            e.Graphics.DrawString("Bác sĩ", smallFont, Brushes.Black, leftMargin + 500, y);
            y += 50;
            e.Graphics.DrawString($"BS CK1", contentFont, Brushes.Black, leftMargin + 500, y);
        }




        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDocument1;

            if (dlg.ShowDialog() != DialogResult.OK)
                e.Cancel = true; 
            
        }

        private void btn_print_service_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Khai báo font chữ
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font contentFont = new Font("Arial", 12);
            Font smallFont = new Font("Arial", 10);
            Font boldContentFont = new Font("Arial", 12, FontStyle.Bold); // Font đậm cho tên thuốc

            // Khởi tạo vị trí
            float y = 20;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;

            // In thông tin phòng khám (căn trái)
            e.Graphics.DrawString("Phòng Khám Đa Khoa Bình Tân", contentFont, Brushes.Black, leftMargin, y);
            y += 20;
            e.Graphics.DrawString("166 Lã Văn Quý, Q. Bình Tân", contentFont, Brushes.Black, leftMargin, y);
            y += 20;
            e.Graphics.DrawString("08 54594554", contentFont, Brushes.Black, leftMargin, y);
            y += 40;

            // In tiêu đề chính (căn giữa)
            string title = "Phiếu chỉ định";
            float titleWidth = e.Graphics.MeasureString(title, titleFont).Width;
            e.Graphics.DrawString(title, titleFont, Brushes.Black, (e.MarginBounds.Width - titleWidth) / 2 + leftMargin, y);
            y += 40;

            // In thông tin bệnh nhân
            e.Graphics.DrawString($"Họ tên: {txb_name.Text}", contentFont, Brushes.Black, leftMargin, y);
            e.Graphics.DrawString($"Năm sinh: {txb_ngaysinh.Text}", contentFont, Brushes.Black, leftMargin + 300, y);
            y += 25;
            e.Graphics.DrawString($"Giới tính: {txb_gender.Text}", contentFont, Brushes.Black, leftMargin, y);
            e.Graphics.DrawString($"Chẩn đoán: {txb_reason.Text}", contentFont, Brushes.Black, leftMargin + 300, y);
            y += 40;

            // In danh sách dịch vụ chỉ định
            e.Graphics.DrawString("Mã chỉ định", boldContentFont, Brushes.Black, leftMargin, y);
            e.Graphics.DrawString("Tên chỉ định", boldContentFont, Brushes.Black, leftMargin + 120, y);
            e.Graphics.DrawString("Tiền", boldContentFont, Brushes.Black, leftMargin + 400, y);
            y += 25;
            int serviceIndex = 1;
            foreach (DataGridViewRow row in dtgv_service_patient.Rows)
            {
                if (row.IsNewRow) continue;

                string serviceId = row.Cells[0].Value?.ToString() ?? "";
                string serviceName = row.Cells[1].Value?.ToString() ?? "";
                string price = row.Cells[2].Value?.ToString() ?? ""; // Giả sử cột số 3 là cột Tiền

                e.Graphics.DrawString(serviceId, contentFont, Brushes.Black, leftMargin, y);
                e.Graphics.DrawString(serviceName, contentFont, Brushes.Black, leftMargin + 120, y);
                e.Graphics.DrawString(price, contentFont, Brushes.Black, leftMargin + 400, y);

                y += 20;
            }

            // In lời dặn và chữ ký bác sĩ
            y += 40;
            e.Graphics.DrawString($"Lời dặn: {cb_doctornote.Text}", contentFont, Brushes.Black, leftMargin, y);
            y += 25;

            e.Graphics.DrawString($"Ngày {DateTime.Now.Day} Tháng {DateTime.Now.Month} Năm {DateTime.Now.Year}", smallFont, Brushes.Black, leftMargin + 500, y);
            y += 25;
            e.Graphics.DrawString("Bác sĩ", smallFont, Brushes.Black, leftMargin + 500, y);
            y += 50;
            e.Graphics.DrawString("BS CK1", contentFont, Brushes.Black, leftMargin + 500, y);

        }

        private void printDocument2_BeginPrint(object sender, PrintEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDocument2;

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                e.Cancel = true; // Hủy in nếu người dùng không chọn in
            }
        }


    }


}








