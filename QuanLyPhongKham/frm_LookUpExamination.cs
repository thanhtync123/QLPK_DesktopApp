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
    public partial class frm_LookUpExamination : Form
    {
        public frm_LookUpExamination()
        {
            InitializeComponent();
        }

        private void frm_LookUpExamination_Load(object sender, EventArgs e)
        {
            LoadDTGV();
        }
        private void LoadDTGV()
        {
            string query = @"SELECT 
            e.id,
            p.id AS patient_id,  -- Thêm mã bệnh nhân
            p.name AS patient_name,
            e.reason,
            d.name AS diagnosis,
            dn.content AS doctor_note,
            e.pulse,
            e.blood_pressure,
            e.respiratory_rate,
            e.weight,
            e.height,
            e.temperature,
            e.type,
            DATE_FORMAT(e.created_at, '%d/%m/%Y %H:%i') AS examination_date
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
            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã Phiếu Khám";
            dtgv.Columns["patient_id"].HeaderText = "Mã Bệnh Nhân";  // Hiển thị Mã Bệnh Nhân
            dtgv.Columns["patient_name"].HeaderText = "Tên Bệnh Nhân";
            dtgv.Columns["reason"].HeaderText = "Lý Do Khám";
            dtgv.Columns["diagnosis"].HeaderText = "Chẩn Đoán";
            dtgv.Columns["doctor_note"].HeaderText = "Ghi chú Bác sĩ";
            dtgv.Columns["pulse"].HeaderText = "Mạch";
            dtgv.Columns["blood_pressure"].HeaderText = "Huyết áp";
            dtgv.Columns["respiratory_rate"].HeaderText = "Nhịp thở";
            dtgv.Columns["weight"].HeaderText = "Cân nặng";
            dtgv.Columns["height"].HeaderText = "Chiều cao";
            dtgv.Columns["temperature"].HeaderText = "Nhiệt độ";
            dtgv.Columns["type"].HeaderText = "Loại Phiếu";
            dtgv.Columns["examination_date"].HeaderText = "Ngày Khám";
        }


        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = MySql.Data.MySqlClient.MySqlHelper.EscapeString(txb_search.Text.Trim());
            string query = $@"
        SELECT 
            e.id,
            p.name AS patient_name,
             p.id AS patient_id,  
            e.reason,
            d.name AS diagnosis,
            dn.content AS doctor_note,
            e.pulse,
            e.blood_pressure,
            e.respiratory_rate,
            e.weight,
            e.height,
            e.temperature,
            e.type,
            DATE_FORMAT(e.created_at, '%d/%m/%Y %H:%i') AS examination_date
        FROM 
            examinations e
        JOIN 
            patients p ON e.patient_id = p.id
        JOIN 
            diagnoses d ON e.diagnosis_id = d.id
        JOIN 
            doctor_notes dn ON e.doctor_note_id = dn.id
        WHERE 
            (p.name LIKE '%{keyword}%' OR e.id LIKE '%{keyword}%')";

            Db.LoadDTGV(dtgv, query);
        }

    }
}
