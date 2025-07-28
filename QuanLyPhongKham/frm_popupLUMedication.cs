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
        public frm_popupLUMedication()
        {
            InitializeComponent();

        }
        public List<object[]> selectedMedications = new List<object[]>();

        private void frm_popupLUMedication_Load(object sender, EventArgs e)
        {
            LoadDTGV_Patient_Medication();
        }
        private void LoadDTGV_Patient_Medication()
        {
            Db.ResetConnection();
            string query = $@"
            SELECT 
                e.id,
                e.patient_id,
                p.name,
                DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i') AS updated_at
            FROM 
                examinations e, patients p
            WHERE 
                e.patient_id = p.id
                AND p.name LIKE '%{txb_search.Text}%'
                AND e.type = 'toa thuốc'
            ORDER BY e.updated_at desc
";
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
            LoadDTGV_Patient_Medication();
        }

        private void dtgv_patient_medication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_exam = Convert.ToInt32(dtgv_patient_medication.CurrentRow.Cells["c1_examination_id"].Value);

            Db.ResetConnection();
            string query = $@"
                SELECT 
                em.id AS id,
                em.examination_id AS examination_id,
                m.id AS med_id,
                m.name,
                em.morning,
                em.afternoon,
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
                drr.Cells["c2_morning"].Value = Db.dr["morning"];
                drr.Cells["c2_afternoon"].Value = Db.dr["afternoon"];
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
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối cùng

                object[] rowData = new object[]
                {
        row.Cells["c2_medication_id"].Value,
        row.Cells["c2_medname"].Value,
        row.Cells["c2_morning"].Value,
        row.Cells["c2_afternoon"].Value,
        row.Cells["c2_unit"].Value,
        row.Cells["c2_days_of_use"].Value,
        row.Cells["c2_total_quantity_med"].Value,
        row.Cells["c2_note"].Value
                };

                selectedMedications.Add(rowData);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void dtgv_patient_medication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
