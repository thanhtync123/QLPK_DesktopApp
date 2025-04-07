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

        }

        private void frm_examination_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadExamID();
            LoadComboboxDiagnoses();
            LoadComboboxDoctorNote();
            LoadComboboxMed();
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

            string query = "SELECT max(id)+1 as exam_id from examinations";
            cmd = new MySqlCommand(query, conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                txb_exam_id.Text = dr["exam_id"].ToString();

            dr.Close();



        }
        private void LoadComboboxDoctorNote()
        {


            string query = "SELECT id, content FROM doctor_notes";
            cmd = new MySqlCommand(query, conn);
            adt = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adt.Fill(dt);
            cb_doctornote.DataSource = dt;
            cb_doctornote.DisplayMember = "content";
            cb_doctornote.ValueMember = "id";


        }
        private void LoadComboboxDiagnoses()
        {


            string query = "SELECT id, name FROM diagnoses";
            cmd = new MySqlCommand(query, conn);
            adt = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adt.Fill(dt);
            cb_diagnoses.DataSource = dt;
            cb_diagnoses.DisplayMember = "name";
            cb_diagnoses.ValueMember = "id";
            cb_diagnoses.SelectedIndex = 0;

        }

        private void LoadComboboxMed()
        {
            string query = "SELECT id, name FROM medications";
            cmd = new MySqlCommand(query, conn);
            adt = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adt.Fill(dt);
            cb_medname.DataSource = dt;
            cb_medname.DisplayMember = "name";
            cb_medname.ValueMember = "id";
            cb_medname.SelectedIndex = 0;



        }
        private void btn_addmed_Click(object sender, EventArgs e)
        {
            int soCot = dtgv_med.Columns.Count;
            object[] duLieuMoi = new object[soCot];
            dtgv_med.Rows.Add(duLieuMoi);
        }

        private void cb_medname_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMedID = Convert.ToInt32(cb_doctornote.SelectedIndex);
            MessageBox.Show(selectedMedID + "");

    
            //string query = "SELECT id, name, unit, dosage, route, times_per_day, note, price FROM medications WHERE id = @medID";
            //cmd = new MySqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@medID", selectedMedID);

            //conn.Open();
            //MySqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    // Populate the textboxes with the data
            //    txb_unit.Text = dr["unit"].ToString();
            //    txb_dosage.Text = dr["dosage"].ToString();
            //    txb_route.Text = dr["route"].ToString();
            //    txb_times.Text = dr["times_per_day"].ToString();
            //    txb_mednote.Text = dr["note"].ToString();
            //    txb_price.Text = dr["price"].ToString();
            //}
            //dr.Close();
            //conn.Close();
        }
    }
}

