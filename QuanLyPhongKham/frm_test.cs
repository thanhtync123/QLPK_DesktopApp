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
        private int lastClickedRowIndex = -1;
        private bool isLoadingResults = false;

        public frm_test()
        {
            InitializeComponent();

        }

        private void frm_test_Load(object sender, EventArgs e)
        {
            LoadExam.InitialDTGVCommon(dtgv_exam);
            LoadExam.LoadDTGVCommon(dtgv_exam, "Xét nghiệm");
            LoadComboboxTemplate();

        }
        private void LoadComboboxTemplate()
        {
            string query = "SELECT id, name, template_content FROM templates where type = 'Xét nghiệm'";
            Db.LoadComboBoxData(cb_template, query, "name", "id");
            cb_template.Text = "Chọn biểu mẫu";
        }

        private void dtgv_exam_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                var diagnosis = row.Cells["diagnosis"].Value?.ToString();
                txb_reason1.Text = diagnosis;
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
            // Only process this if it's not being triggered during result loading
            if (isLoadingResults) return;

            dtgv_result.Rows.Clear();
            if (cb_template.SelectedIndex > 0)
            {
                LoadDataToDataGridViewResult();
                int selectedTemplateId = Convert.ToInt32(cb_template.SelectedValue);
                string sql = "SELECT `template_content`,`result_content` FROM `templates` WHERE `id` = @template_id;";
                Db.ResetConnection();
                Db.cmd = new MySqlCommand(sql, Db.conn);
                Db.cmd.Parameters.AddWithValue("@template_id", selectedTemplateId);
                Db.dr = Db.cmd.ExecuteReader();

                if (Db.dr.Read())
                {
                    txb_final_result.Text = Db.dr["result_content"].ToString();
                }

                Db.dr.Close();
                Db.ResetConnection();
            }
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
                try
                {
                    var items = JsonConvert.DeserializeObject<List<TemplateItem>>(jsonData);
                    dtgv_result.Rows.Clear();
                    foreach (var item in items)
                    {
                        dtgv_result.Rows.Add(item.indication, item.result, item.unit, item.normal_range);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi phân tích nội dung JSON: " + ex.Message);
                }
            }

            Db.dr.Close();
            Db.ResetConnection();
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            JArray resultArr = new JArray();

            foreach (DataGridViewRow r in dtgv_result.Rows)
            {
                if (r.IsNewRow) continue;
                resultArr.Add(new JObject
                {
                    ["indication"] = r.Cells[0].Value?.ToString(),
                    ["result"] = r.Cells[1].Value?.ToString(),
                    ["unit"] = r.Cells[2].Value?.ToString(),
                    ["normal_range"] = r.Cells[3].Value?.ToString()
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
                // Set flag to indicate we're loading results to prevent interference from other events
                isLoadingResults = true;

                DataGridViewRow row = dtgv_service.Rows[e.RowIndex];
                var name_service = row.Cells["name"].Value?.ToString();
                txb_service.Text = name_service;

                // Only clear previous results if we're clicking a different row
                if (lastClickedRowIndex != e.RowIndex)
                {
                    dtgv_result.Rows.Clear();
                    txb_final_result.Text = string.Empty;

                    // Reset template selection to avoid interference
                    isUserChangingTemplate = false;
                    cb_template.SelectedIndex = 0;
                    isUserChangingTemplate = true;
                }

                // Update the last clicked row index
                lastClickedRowIndex = e.RowIndex;

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
                                // Disable template change events temporarily
                                isUserChangingTemplate = false;

                                // Clear grid before adding new data
                                dtgv_result.Rows.Clear();

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
                                        dtgv_result.Rows.Clear();

                                        foreach (JObject result in jsonArray)
                                        {
                                            string indication = result["indication"]?.ToString() ?? "";
                                            string resultValue = result["result"]?.ToString() ?? "";
                                            string unit = result["unit"]?.ToString() ?? "";
                                            string normalRange = result["normal_range"]?.ToString() ?? "";

                                            dtgv_result.Rows.Add(indication, resultValue, unit, normalRange);
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

                                // Re-enable template change events when everything is loaded
                                isUserChangingTemplate = true;
                            }
                        }
                    }
                }
                else
                {
                    btn_save.Enabled = true;
                    btn_edit.Enabled = false;

                    // Need to reset the combo box and clear final result
                    isUserChangingTemplate = false;
                    cb_template.SelectedIndex = 0;
                    txb_final_result.Text = "";
                    isUserChangingTemplate = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                // Always reset this flag
                isLoadingResults = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgv_service.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dịch vụ để chỉnh sửa!");
                    return;
                }

                JArray resultArr = new JArray();
                foreach (DataGridViewRow r in dtgv_result.Rows)
                {
                    if (r.IsNewRow) continue;
                    resultArr.Add(new JObject
                    {
                        ["indication"] = r.Cells[0].Value?.ToString(),
                        ["result"] = r.Cells[1].Value?.ToString(),
                        ["unit"] = r.Cells[2].Value?.ToString(),
                        ["normal_range"] = r.Cells[3].Value?.ToString()
                    });
                }

                string sql = @"UPDATE examination_results 
                      SET template_id = @template_id, 
                          result = @result, 
                          final_result = @final_result 
                      WHERE examination_service_id = @examination_service_id";

                var param = new Dictionary<string, object>
        {
            { "@examination_service_id", Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value) },
            { "@template_id", Convert.ToInt32(cb_template.SelectedValue) },
            { "@result", resultArr.ToString(Newtonsoft.Json.Formatting.None) },
            { "@final_result", txb_final_result.Text }
        };

                Db.Update(sql, param);
                MessageBox.Show("Cập nhật kết quả thành công!");
                LoadDTGV_Service();

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

            var mabn = txb_id_patient.Text;
            var tenbn = txb_name.Text;
            //  var ngaysinh = txb_dob.Text;
            var ngaysinh = txb_age.Text;
            var chandoan = txb_reason1.Text;
            var chandoanphu = txb_reason.Text;
            var diachi = txb_address.Text;
            var ketqua = txb_final_result.Text;
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");
            var gioitinh = txb_gender.Text;
            var chidinh=txb_service.Text;


            var sdt = txb_phone.Text;
            DataTable dt = GetDataTableFromDataGridView(dtgv_result);
            frm_report_test frm = new frm_report_test(dt, mabn, tenbn, ngaysinh, chandoan, chandoanphu, diachi, ketqua, ngaykham, sdt,gioitinh,chidinh);

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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgv_result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}

       