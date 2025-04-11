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
                 e.note
               FROM 
                 examinations e
               JOIN 
                 patients p ON e.patient_id = p.id
               JOIN 
                 diagnoses d ON e.diagnosis_id = d.id";

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
                   
        

                }
            }   
        }

        private void cb_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_template.SelectedIndex > 0)
            {
                int selectedTemplateId = Convert.ToInt32(cb_template.SelectedValue);
                string sql = "SELECT `template_content` FROM `templates` WHERE `id` = @template_id;";
                conn = new MySqlConnection(connectionString);
                ResetConnection();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@template_id", selectedTemplateId);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    txb_result.Text = dr["template_content"].ToString()
                                         .Replace("\\n", "\r\n")   
                                         .Replace("\n", "\r\n");  
                dr.Close();
                ResetConnection();
            }




        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var examination_service_id = Convert.ToInt32(dtgv_service.CurrentRow.Cells["examination_service_id"].Value);
            var template_id = Convert.ToInt32(cb_template.SelectedValue);
            string result = txb_result.Text;

            string query = @"INSERT INTO examination_results 
                (examination_service_id, template_id, result) 
                VALUES (@examination_service_id, @template_id, @result);";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@examination_service_id", examination_service_id);
            cmd.Parameters.AddWithValue("@template_id", template_id);
            cmd.Parameters.AddWithValue("@result", result);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm kết quả thành công.");
                LoadDTGV_Service();
            }    
               
            else
                MessageBox.Show("Không có dữ liệu nào được thêm.");
            





        }
    }
}
