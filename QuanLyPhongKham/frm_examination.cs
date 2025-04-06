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

namespace QuanLyPhongKham
{
    public partial class frm_examination : Form
    {
        int id;
        string connectionString = "Server=localhost;Database=clinic_db2;Uid=root;Pwd=;";
        MySqlConnection conn; 
        MySqlCommand cmd;   
        MySqlDataAdapter adt; 
        DataTable dt;
        MySqlDataReader dr;   

        public frm_examination()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            dtgv_patients.Columns.Add("date_of_birth", "Ngày sinh");
            dtgv_patients.Columns["date_of_birth"].Visible = false;
            dtgv_patients.Columns.Add("gender", "Giới tính");
            dtgv_patients.Columns["gender"].Visible = false;
            dtgv_patients.Columns.Add("phone", "SĐT");
            dtgv_patients.Columns["phone"].Visible = false;
            dtgv_patients.Columns.Add("address", "Địa chỉ");
            dtgv_patients.Columns["address"].Visible = false;

            dtgv_patients.Rows.Clear();
            String sql = "SELECT     " +
                "           id,     " +
                "          name," +
                "DATE_FORMAT(date_of_birth, '%d/%m/%Y') AS date_of_birth, " +
                "gender, phone, address,  created_at,  updated_at FROM patients \r\n\r\n";
            conn = new MySqlConnection(connectionString); 
            conn.Open();
            cmd = new MySqlCommand(sql, conn); 
            dr = cmd.ExecuteReader(); 
            while (dr.Read())
            {
                int i = dtgv_patients.Rows.Add();
                DataGridViewRow drr = dtgv_patients.Rows[i];
                drr.Cells["ID"].Value = dr["id"];
                drr.Cells["name"].Value = dr["name"];
                drr.Cells["date_of_birth"].Value = dr["date_of_birth"];
                drr.Cells["gender"].Value = dr["gender"];
                drr.Cells["phone"].Value = dr["phone"];
                drr.Cells["address"].Value = dr["address"];
            }
            dr.Close();
            conn.Close();
        }

        private void frm_examination_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadExamID();
            LoadComboboxDiagnoses();
            LoadComboboxDoctorNote();
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
        private void LoadExamID()
        {
            conn.Open();
            string query = "SELECT max(id)+1 as exam_id from examinations";
            cmd = new MySqlCommand(query, conn);
            dr = cmd.ExecuteReader();
            if (dr.Read()) 
              txb_exam_id.Text = dr["exam_id"].ToString();
           
            dr.Close();
            conn.Close();
            
            
        }
        private void LoadComboboxDiagnoses()
        {
            conn.Open();
            string query = "SELECT * FROM diagnoses";
            cmd = new MySqlCommand(query, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_diagnoses.Items.Add(new 
                { 
                  Text = dr["name"].ToString(), 
                  Value = Convert.ToInt32(dr["id"]) 
                });
            }    
            dr.Close();
            conn.Close();
            cb_diagnoses.DisplayMember = "Text";
            cb_diagnoses.ValueMember = "Value";
            cb_diagnoses.SelectedIndex = 0;

           
        }
        private void LoadComboboxDoctorNote()
        {
            conn.Open();
            string query = "SELECT * FROM doctor_notes";
            cmd = new MySqlCommand(query, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_doctornote.Items.Add(new
                {
                    Text = dr["content"].ToString(),
                    Value = Convert.ToInt32(dr["id"])
                });
            }
            dr.Close();
            conn.Close();
            cb_doctornote.DisplayMember = "Text";
            cb_doctornote.ValueMember = "Value";
            cb_doctornote.SelectedIndex = 0;
        }
    }
}
