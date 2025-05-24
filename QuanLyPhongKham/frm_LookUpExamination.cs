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

namespace QuanLyPhongKham
{
    public partial class lb_chitietphieukham : Form
    {
        public lb_chitietphieukham()
        {
            InitializeComponent();
        }

        private void frm_LookUpExamination_Load(object sender, EventArgs e)
        {
            LoadDTGV();
        }
        private void LoadDTGV()
        {

            string query = @"
        SELECT 
            e.id as 'Mã phiếu khám',
            p.id AS 'Mã bệnh nhân',  
            p.name AS 'Tên bệnh nhân',
            e.type AS 'Loại phiếu',
            DATE_FORMAT(e.created_at, '%d/%m/%Y %H:%i') AS 'Ngày khám'
        FROM 
            examinations e
        JOIN 
            patients p ON e.patient_id = p.id
        JOIN 
            diagnoses d ON e.diagnosis_id = d.id
        JOIN 
            doctor_notes dn ON e.doctor_note_id = dn.id
         ORDER BY e.id DESC
        
    ";
            Db.LoadDTGV(dtgv_patient, query);

        }


        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = MySql.Data.MySqlClient.MySqlHelper.EscapeString(txb_search.Text.Trim());
            string query = $@"
        SELECT 
            e.id as 'Mã phiếu khám',
            p.id AS 'Mã bệnh nhân',  
            p.name AS 'Tên bệnh nhân',
            e.type AS 'Loại phiếu',
            DATE_FORMAT(e.created_at, '%d/%m/%Y %H:%i') AS 'Ngày khám'
        FROM 
            examinations e
        JOIN 
            patients p ON e.patient_id = p.id
        JOIN 
            diagnoses d ON e.diagnosis_id = d.id
        JOIN 
            doctor_notes dn ON e.doctor_note_id = dn.id
        WHERE 
            (    p.id LIKE '%{keyword}%' OR
                p.name LIKE '%{keyword}%' OR
                e.id LIKE '%{keyword}%'; )";

            Db.LoadDTGV(dtgv_patient, query);
        }





        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (dtgv_patient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var selectedRow = dtgv_patient.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string query = "DELETE FROM examinations WHERE id = @id";
            var data = new Dictionary<string, object>
                {
                    { "@id", id }
                };
            Db.Delete(query, data);
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDTGV();
        }

        private void dtgv_patient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dtgv_patient.Rows[e.RowIndex].Cells["Mã phiếu khám"].Value.ToString();
            string query = $@"
    SELECT 
        e.pulse AS 'Mạch',
        e.blood_pressure AS 'Huyết áp',
        e.respiratory_rate AS 'Nhịp thở',
        e.temperature AS 'Nhiệt độ',
        e.weight AS 'Cân nặng',
        e.height AS 'Chiều cao',
        d.name AS 'Chẩn đoán chính',
        e.reason AS 'Chẩn đoán phụ',
        dn.content AS 'Lời dặn bác sĩ',
        e.note AS 'Chú thích',
        e.type AS 'Loại phiếu',
        e.updated_at AS 'Ngày cập nhật'
    FROM examinations e
    JOIN diagnoses d ON e.diagnosis_id = d.id
    JOIN doctor_notes dn ON e.doctor_note_id = dn.id
    WHERE e.id = {id};
";

            using (var reader = Db.GetReader(query))
            {
                if (reader.Read())
                {
                    txb_mach.Text = reader["Mạch"].ToString();
                    txb_huyetap.Text = reader["Huyết áp"].ToString();
                    txb_nhiptho.Text = reader["Nhịp thở"].ToString();
                    txb_nhietdo.Text = reader["Nhiệt độ"].ToString();
                    txb_cannang.Text = reader["Cân nặng"].ToString();
                    txb_chieucao.Text = reader["Chiều cao"].ToString();
                    txb_chandoanchinh.Text = reader["Chẩn đoán chính"].ToString();
                    txb_chandoanphu.Text = reader["Chẩn đoán phụ"].ToString();
                    txb_loidanbacsi.Text = reader["Lời dặn bác sĩ"].ToString();
                    txb_ghichu.Text = reader["Chú thích"].ToString();
                    txb_loaiphieu.Text = reader["Loại phiếu"].ToString();
                    txb_ngaycapnhat.Text = Convert.ToDateTime(reader["Ngày cập nhật"]).ToString("dd/MM/yyyy HH:mm");
                }




            }
        }
    }
}
