using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public class LoadExam
    {
        // Phương thức khởi tạo DataGridView
        public static void InitialDTGVCommon(DataGridView dtgv_exam)
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
            dtgv_exam.Columns.Add("time_exam", "Cấp phiếu lúc");

            dtgv_exam.Columns["id_patient"].Width = 50;
            dtgv_exam.Columns["id_exam"].Width = 50;
            dtgv_exam.Columns["name"].Width = 180;
            dtgv_exam.Columns["time_exam"].Width = 130;
            string[] columnsToHide = {
        "gender", "date_of_birth", "phone",
        "address", "updated_at", "reason", "diagnosis", "note"
    };
            foreach (string columnName in columnsToHide)
                dtgv_exam.Columns[columnName].Visible = false;

        }


		public static void LoadDTGVCommon(DataGridView dtgv_exam, string type, string search = "")
		{
			dtgv_exam.Rows.Clear(); // Xóa dữ liệu cũ trước khi load lại

			string sql = @"
        SELECT 
            DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i') AS time_exam,
            DATE_FORMAT(p.date_of_birth, '%d/%m/%Y') AS date_of_birth,
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
            e.note,
            GROUP_CONCAT(DISTINCT s.id) AS service_ids,
            GROUP_CONCAT(DISTINCT s.name SEPARATOR ', ') AS service_names,
            GROUP_CONCAT(DISTINCT 
                CASE 
                    WHEN er.id IS NOT NULL THEN 'Đã có KQ'
                    ELSE 'Chưa có KQ'
                END
                SEPARATOR ', '
            ) AS states
        FROM examinations e
        JOIN patients p ON e.patient_id = p.id
        JOIN diagnoses d ON e.diagnosis_id = d.id
        JOIN examination_services es ON e.id = es.examination_id
        JOIN services s ON es.service_id = s.id
        LEFT JOIN examination_results er ON er.examination_service_id = es.id
        WHERE DATE(e.updated_at) = CURDATE()
            AND s.type = @type
    ";

			if (!string.IsNullOrEmpty(search))
			{
				sql += @" AND (
                    p.id LIKE @search OR 
                    p.name LIKE @search OR 
                    e.id LIKE @search
                )";
			}

			sql += " GROUP BY e.id";

			Db.conn = new MySqlConnection(Db.connectionString);
			Db.ResetConnection();
			Db.cmd = new MySqlCommand(sql, Db.conn);
			Db.cmd.Parameters.AddWithValue("@type", type);
			if (!string.IsNullOrEmpty(search))
			{
				Db.cmd.Parameters.AddWithValue("@search", "%" + search + "%");
			}

			Db.dr = Db.cmd.ExecuteReader();

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


	}
}
