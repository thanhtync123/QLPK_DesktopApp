using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace QuanLyPhongKham
{
    public partial class frm_test : Form
    {
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
            string query = "SELECT id, name, template_content FROM templates";
            Db.LoadComboBoxData(cb_template, query, "name", "id");
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
        JOIN services s ON s.id = es.service_id AND s.type = 'Xét nghiệm'
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
            if (Db.dr.Read())
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
                            previousTestName = testName;  // Cập nhật tên xét nghiệm đã điền
                        }
                        else
                            // Nếu tên xét nghiệm không thay đổi, thì chỉ điền kết quả vào các cột còn lại
                            dtgv_result.Rows.Add("", resultTestName, resultValue, unit, normalRange);
                        
                    }
                }
            }

            Db.dr.Close();
            Db.ResetConnection();
        }
    }
}
