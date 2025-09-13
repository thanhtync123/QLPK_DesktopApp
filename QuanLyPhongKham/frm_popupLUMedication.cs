using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QuanLyPhongKham
{
    public partial class frm_popupLUMedication : Form
    {
        private int pageIndex=1;
        private int pageSize = 23;
        private int offset=0;
        private int totalPage = 0;
        public frm_popupLUMedication()
        {
            InitializeComponent();



        }
        public List<object[]> selectedMedications = new List<object[]>();
        public int PatientID { get; set; }
        private void LoadTotalPages()
        {

            Db.ResetConnection();
            string countQuery = "SELECT COUNT(*) FROM examinations WHERE type = 'toa thuốc'";
            if (!chb_viewall.Checked)
                countQuery += $" AND patient_id = {PatientID} ";
            if (!string.IsNullOrEmpty(txb_search.Text))
                countQuery += $" AND (patient_id = {PatientID} OR id LIKE '%{txb_search.Text}%')";
            Db.cmd = new MySqlCommand(countQuery, Db.conn);
            int totalRecords = Convert.ToInt32(Db.cmd.ExecuteScalar());
            totalPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPage == 0) totalPage = 1;
            lb_totalpage.Text = totalPage.ToString();


        }
        private void frm_popupLUMedication_Load(object sender, EventArgs e)
        {
            LoadDTGV_Patient_Medication();
            btn_delete.Enabled = false;
            LoadTotalPages();
            lb_page.Text = pageIndex.ToString();


        }
        private void LoadDTGV_Patient_Medication()
        {
         
            Db.ResetConnection();
            string checkMedP = $"SELECT 1 FROM examinations WHERE patient_id = {PatientID} AND type='toa thuốc' LIMIT 1;";
            object result = Db.Scalar(checkMedP);
            bool hasMedP = result != null;
            if (!hasMedP) lb_state.Text = "Bệnh nhân chưa có toa thuốc nào";
            else lb_state.Text = "";

            string query = $@"
             SELECT 
            e.id,
            e.patient_id,
            p.name,
            DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i') AS updated_at
        FROM examinations e
        JOIN patients p ON e.patient_id = p.id
        WHERE e.type = 'toa thuốc'
           ";
            if (!chb_viewall.Checked)
                query += $" AND e.patient_id = {PatientID} ";
            if (!string.IsNullOrEmpty(txb_search.Text))
                query += $" AND (p.name LIKE '%{txb_search.Text}%' OR e.id LIKE '%{txb_search.Text}%')";
            query += $" ORDER BY e.updated_at DESC LIMIT {offset},{pageSize}";

            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_patient_medication.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView
            while (Db.dr.Read())
            {
                int i = dtgv_patient_medication.Rows.Add();
                DataGridViewRow drr = dtgv_patient_medication.Rows[i];
                drr.Cells["c1_examination_id"].Value = Db.dr["id"];             // Mã phiếu khám
                drr.Cells["c1_id"].Value = Db.dr["patient_id"];                 // ID bệnh nhân
                drr.Cells["c1_name"].Value = Db.dr["name"];                     // Tên bệnh nhân
                drr.Cells["c1_update_day"].Value = Db.dr["updated_at"];         // Ngày cập nhật (đã định dạng)
            }

            Db.dr.Close();


        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            LoadTotalPages();
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadDTGV_Patient_Medication();
        }
        int id_exam = 0;
        private void dtgv_patient_medication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_delete.Enabled = true;
            id_exam = Convert.ToInt32(dtgv_patient_medication.CurrentRow.Cells["c1_examination_id"].Value);

            Db.ResetConnection();
            string query = $@"
               SELECT 
                em.id AS id,
                em.examination_id AS examination_id,
                m.id AS med_id,
                m.name,
                REPLACE(CAST(em.morning AS CHAR), '.', ',') AS morning,
                REPLACE(CAST(em.noon AS CHAR), '.', ',') AS noon,
                REPLACE(CAST(em.afternoon AS CHAR), '.', ',') AS afternoon,
                REPLACE(CAST(em.evening AS CHAR), '.', ',') AS evening,
                em.unit,
                em.days_of_use,
                em.total_quantity_med,
                em.note
            FROM 
                examination_medications em, examinations e, medications m
            WHERE 
                em.examination_id = e.id
                AND em.medication_id = m.id
                AND em.examination_id = {id_exam}
            ";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_detail.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView
            while (Db.dr.Read())
            {
                int i = dtgv_detail.Rows.Add();
                DataGridViewRow drr = dtgv_detail.Rows[i];

                drr.Cells["c2_examination_id"].Value = Db.dr["examination_id"];
                drr.Cells["c2_medication_id"].Value = Db.dr["med_id"];
                drr.Cells["c2_medname"].Value = Db.dr["name"];
                drr.Cells["c2_morning"].Value = Db.dr["morning"].ToString().Replace(".", ",");
                drr.Cells["c2_noon"].Value = Db.dr["noon"].ToString().Replace(".", ",");
                drr.Cells["c2_afternoon"].Value = Db.dr["afternoon"].ToString().Replace(".", ",");
                drr.Cells["c2_evening"].Value = Db.dr["evening"].ToString().Replace(".", ",");
                drr.Cells["c2_unit"].Value = Db.dr["unit"];
                drr.Cells["c2_days_of_use"].Value = Db.dr["days_of_use"];
                drr.Cells["c2_total_quantity_med"].Value = Db.dr["total_quantity_med"];
                drr.Cells["c2_note"].Value = Db.dr["note"];
            }


            Db.dr.Close();


        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgv_detail.Rows)
            {
                if (row.IsNewRow) continue; 

                object[] rowData = new object[]
                {
                    row.Cells["c2_medication_id"].Value,
                    row.Cells["c2_medname"].Value,
                    row.Cells["c2_unit"].Value,
                    row.Cells["c2_morning"].Value,
                    row.Cells["c2_noon"].Value,
                    row.Cells["c2_afternoon"].Value,
                    row.Cells["c2_evening"].Value,
                    row.Cells["c2_days_of_use"].Value,
                    row.Cells["c2_total_quantity_med"].Value,
                    row.Cells["c2_note"].Value
                };

                selectedMedications.Add(rowData);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa toa thuốc này không?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    string query = $@"
                DELETE FROM examinations
                WHERE id = {id_exam}";
                    Db.ExecuteNonQuery(query);
                    LoadDTGV_Patient_Medication();
                    dtgv_detail.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pageIndex = 1;
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadTotalPages();
            LoadDTGV_Patient_Medication();
        }

        private void btn_firstpage_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadDTGV_Patient_Medication();
        }

        private void btn_downpage_Click(object sender, EventArgs e)
        {
            if(pageIndex>1)
            {
                pageIndex--;
                offset = (pageIndex - 1) * pageSize;
                lb_page.Text = pageIndex.ToString();
            
                LoadDTGV_Patient_Medication();
            }
        }

        private void btn_uppage_Click(object sender, EventArgs e)
        {
            if(pageIndex<totalPage)
            {
                pageIndex++;
                offset = (pageIndex - 1) * pageSize;
                lb_page.Text = pageIndex.ToString();
                LoadDTGV_Patient_Medication();
            }
        }

        private void btn_maxpage_Click(object sender, EventArgs e)
        {
            pageIndex = totalPage;
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadDTGV_Patient_Medication();
            
        }
    }
}
