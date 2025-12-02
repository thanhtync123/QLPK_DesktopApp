using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace QuanLyPhongKham
{

    public partial class frm_statistic : Form
    {
        public frm_statistic()
        {
            InitializeComponent();

        }


        private void LoadThongKe()
        {
            string fromDate = dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00");
            string toDate = dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59");
            string query1 = $@"
            SELECT COUNT(*) 
            FROM patients 
            WHERE updated_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_1.Text = Db.Scalar(query1).ToString();

 
            string query2 = $@"
            SELECT IFNULL(SUM(price), 0) as total
            FROM `examinations`
            WHERE type='toa thuốc' AND created_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_2.Text = string.Format("{0:N0} VND", Db.Scalar(query2));

            string query3 = $@"
            SELECT IFNULL(SUM(price), 0) as total
            FROM `examinations`
            WHERE type='chỉ định' AND created_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_3.Text = string.Format("{0:N0} VND", Db.Scalar(query3));

            // Tổng doanh thu = thuốc + dịch vụ
            double tong = Convert.ToDouble(Db.Scalar(query2)) + Convert.ToDouble(Db.Scalar(query3));
            lb_4.Text = string.Format("{0:N0} VND", tong);

            // Số ca X-quang
            string query5 = $@"
                SELECT COUNT(*) 
                FROM examination_services es
                JOIN services s ON es.service_id = s.id
                WHERE s.type = 'X-quang' AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'";
            lb_5.Text = Db.Scalar(query5).ToString();

            // Số ca Điện tim
            string query6 = $@"
    SELECT COUNT(*) 
    FROM examination_services es
    JOIN services s ON es.service_id = s.id
    WHERE s.type = 'Điện tim' AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'";
            lb_6.Text = Db.Scalar(query6).ToString();

            // Số ca Siêu âm
            string query7 = $@"
    SELECT COUNT(*) 
    FROM examination_services es
    JOIN services s ON es.service_id = s.id
    WHERE s.type = 'Siêu âm' AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'";
            lb_7.Text = Db.Scalar(query7).ToString();

            // Số ca Xét nghiệm
            string query8 = $@"
            SELECT COUNT(*) 
            FROM examination_services es
            JOIN services s ON es.service_id = s.id
            WHERE s.type = 'Xét nghiệm' AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'";
            lb_8.Text = Db.Scalar(query8).ToString();
       
            string queryTestVGB = $@"SELECT COUNT(*)
                   from examination_services es
                    join services s ON s.id = es.service_id
                    WHERE LOWER(s.name) LIKE '%test %viêm gan b%'
                      AND LOWER(s.name) NOT LIKE '%kháng thể viêm gan b%'
                      AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                                    ";
            lb_vgb.Text = Db.Scalar(queryTestVGB).ToString();
            string queryTestKhangTheVGB = $@"SELECT COUNT(*)
                                from examination_services es
                                join services s ON s.id = es.service_id
                    WHERE LOWER(s.name) LIKE '%kháng thể viêm gan b%'
                    AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                                    ";
            lb_ktvgb.Text = Db.Scalar(queryTestKhangTheVGB).ToString();
            string queryTestVGC = $@"SELECT COUNT(*)
                                    from examination_services es
                                    join services s ON s.id = es.service_id
                    WHERE LOWER(s.name) LIKE '%test %viêm gan c%'
                    AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                                    ";
            lb_vgc.Text = Db.Scalar(queryTestVGC).ToString();
            string queryTestHuyetHoc = $@"Select count(*)
                                        from examination_services es
                                        join services s ON s.id = es.service_id
                                        Where LOWER(s.name) LIKE '%Huyết học%'
                                        AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                                        ";
            lb_huyethoc.Text = Db.Scalar(queryTestHuyetHoc).ToString();
            string queryTestHbA1C = $@"SELECT COUNT(*)
                                        from examination_services es
                                        join services s ON s.id = es.service_id
                                        Where LOWER(s.name) LIKE '%HbA1C%'
                                        AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                                        ";
            lb_hba1c.Text = Db.Scalar(queryTestHbA1C).ToString();
            string queryTestHP = $@"SELECT COUNT(*)
                                       from examination_services es
                                        join services s ON s.id = es.service_id
                                        Where LOWER(s.name) LIKE '%HP%' OR LOWER(s.name) LIKE '%H.pylori%'
                                        AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                                        ";
            lb_testhp.Text = Db.Scalar(queryTestHP).ToString();
            string queryTestNuocTieu = $@"SELECT COUNT(*)
                                        from examination_services es
                                        join services s ON s.id = es.service_id
                                        Where LOWER(s.name) LIKE '%Xét nghiệm nước tiểu%'
                                        AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                                        ";
            lb_nuoctieu.Text = Db.Scalar(queryTestNuocTieu).ToString();

            string querySinhHoa = $@"SELECT COUNT(*)
                       from examination_services es
                        join services s ON s.id = es.service_id
                        WHERE s.type = 'Xét nghiệm'
                          AND LOWER(s.name) NOT LIKE '%test %viêm gan b%'
                          AND LOWER(s.name) NOT LIKE '%kháng thể viêm gan b%'
                          AND LOWER(s.name) NOT LIKE '%test %viêm gan c%'
                          AND LOWER(s.name) NOT LIKE '%huyết học%'
                          AND LOWER(s.name) NOT LIKE '%hba1c%'
                          AND LOWER(s.name) NOT LIKE '%hp%'
                          AND LOWER(s.name) NOT LIKE '%h.pylori%'
                          AND LOWER(s.name) NOT LIKE '%xét nghiệm nước tiểu%'
                          AND LOWER(s.name) NOT LIKE '%ion đồ%'
                          AND LOWER(s.name) NOT LIKE '%NS1 Ag%'
                            AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                        ";
            lb_sinhhoa.Text = Db.Scalar(querySinhHoa).ToString();
            string queryTroponin = $@"SELECT COUNT(*)
                       from examination_services es
                        join services s ON s.id = es.service_id
                        WHERE LOWER(s.name) LIKE '%troponin%'
                          AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                        ";
            lb_troponin.Text = Db.Scalar(queryTroponin).ToString();
            string queryToxocara = $@"SELECT COUNT(*)
                       from examination_services es
                        join services s ON s.id = es.service_id
                        WHERE LOWER(s.name) LIKE '%toxocara%'
                          AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                        ";
            lb_toxocara.Text = Db.Scalar(queryToxocara).ToString();
            string querystrongyloides = $@"SELECT COUNT(*)
                       from examination_services es
                        join services s ON s.id = es.service_id
                        WHERE LOWER(s.name) LIKE '%stronggyloides%'
                          AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                        ";
            lb_stronggyloides.Text = Db.Scalar(querystrongyloides).ToString();

            string queryion = $@"SELECT COUNT(*)
                       from examination_services es
                        join services s ON s.id = es.service_id
                        WHERE LOWER(s.name) LIKE '%ion đồ%'
                          AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                        ";
            lb_iondo.Text = Db.Scalar(queryion).ToString();

            string testns1ag = $@"SELECT COUNT(*)
                       from examination_services es
                        join services s ON s.id = es.service_id
                        WHERE LOWER(s.name) LIKE '%ns1 ag%'
                          AND es.created_at BETWEEN '{fromDate}' AND '{toDate}'
                        ";
            lb_testns1ag.Text = Db.Scalar(testns1ag).ToString();

            //string query = $@"
            //SELECT
            //    p.id, 
            //    p.name,
            //    SUM(e.price) as total_per_customer
            //FROM examinations e
            //INNER JOIN patients p ON e.patient_id = p.id
            //WHERE DATE(e.updated_at) BETWEEN '{fromDate}' AND '{toDate}'
            //GROUP BY p.id, p.name;
            //                ";
            string query = $@"
             SELECT
                p.id,
                p.name,
                SUM(
                    CASE
                        WHEN e.price IS NOT NULL THEN e.price
                        WHEN e.type = 'toa thuốc' THEN
                            (SELECT IFNULL(MAX(em.days_of_use) * 50000,0)
                             FROM examination_medications em
                             WHERE em.examination_id = e.id)
                        ELSE
                            (SELECT IFNULL(SUM(s.price),0)
                             FROM examination_services es
                             INNER JOIN services s ON es.service_id = s.id
                             WHERE es.examination_id = e.id)
                    END
                ) AS total_per_customer
            FROM examinations e
            INNER JOIN patients p ON e.patient_id = p.id
            WHERE DATE(e.updated_at) BETWEEN '{fromDate}' AND '{toDate}'
            GROUP BY p.id, p.name
                            ";
            Db.ResetConnection();
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_detail.Rows.Clear();
            int stt = 1;
            while (Db.dr.Read())
            {

                int i = dtgv_detail.Rows.Add();
                DataGridViewRow drr = dtgv_detail.Rows[i];
                drr.Cells["stt_patient"].Value = stt++;
                drr.Cells["id_patient"].Value = Db.dr["id"];
                drr.Cells["name_patient"].Value = Db.dr["name"];
                drr.Cells["revenue_patient"].Value = Db.dr["total_per_customer"];

            }

            Db.dr.Close();
            textBox1.Text = query;

        }

        private void frm_statistic_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Value = DateTime.Today;

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            //dateTimePicker1.Value = new DateTime(2025, 6, 1);


            //dateTimePicker2.Format = DateTimePickerFormat.Custom;
            //dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            //dateTimePicker2.Value = new DateTime(2025, 6, 30);

            dtgv_detail_service.Visible = false;
            dtgv_detail_service_med.Visible = false;

            if (AppConfig.AppMode == "Ultrasound")
            {
                pn_detail_test.Visible = false;
                pn_egg.Visible = false;
                pn_test.Visible = false;
                pn_xray.Visible = false;

            }    
            if(AppConfig.AppMode=="All")
            
              
               
               

            LoadThongKe();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
        
        }

        private void dtgv_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string fromDate = dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00");
            string toDate = dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59");
            //string query = $@"
            //    SELECT e.id,e.type,e.price,e.updated_at
            //    FROM examinations e 
            //    INNER JOIN patients p ON p.id = e.patient_id
            //    WHERE p.id = {Convert.ToInt16(dtgv_detail.CurrentRow.Cells["id_patient"].Value.ToString())}
            //    and DATE(e.updated_at) BETWEEN '{fromDate}' AND '{toDate}'
            //                ";
            string query = $@"
                    SELECT 
            e.id,
            e.type,
            CASE
                WHEN e.price IS NOT NULL THEN e.price
                WHEN e.type = 'toa thuốc' THEN
                    (SELECT MAX(em.days_of_use) * 50000
                     FROM examination_medications em
                     WHERE em.examination_id = e.id)
                ELSE 
                    (SELECT SUM(s.price)
                     FROM examination_services es
                     INNER JOIN services s ON es.service_id = s.id
                     WHERE es.examination_id = e.id)
            END AS price,
            e.updated_at
        FROM examinations e
        INNER JOIN patients p ON e.patient_id = p.id
     WHERE p.id = {Convert.ToInt16(dtgv_detail.CurrentRow.Cells["id_patient"].Value.ToString())}
          AND DATE(e.updated_at) BETWEEN '{fromDate}' AND '{toDate}'
                                ";
          
            Db.ResetConnection();
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_service.Rows.Clear();
            int stt = 1;
            while (Db.dr.Read())
            {

                int i = dtgv_service.Rows.Add();
                DataGridViewRow drr = dtgv_service.Rows[i];
                drr.Cells["stt_service"].Value = stt++;
                drr.Cells["id_exam_service"].Value = Db.dr["id"];
                drr.Cells["type_service"].Value = Db.dr["type"];
                drr.Cells["revenue_service"].Value = Db.dr["price"];
                drr.Cells["time_service"].Value = Db.dr["updated_at"];

            }

            Db.dr.Close();
            dtgv_detail_service.Rows.Clear();
            dtgv_detail_service_med.Rows.Clear();
            textBox2.Text = query;
        }

        private void dtgv_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_detail_service.Visible = false;
            dtgv_detail_service_med.Visible = false;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            int idExam = Convert.ToInt32(dtgv_service.Rows[e.RowIndex].Cells["id_exam_service"].Value);
            if (dtgv_service.Columns[e.ColumnIndex].Name == "del_service")
            {

                int? selectedPatientId = null;
                if (dtgv_detail.CurrentRow != null)
                    selectedPatientId = Convert.ToInt32(dtgv_detail.CurrentRow.Cells["id_patient"].Value);

                string queryDelete = $"DELETE FROM examinations WHERE id = {idExam}";
                Db.cmd = new MySqlCommand(queryDelete, Db.conn);
                try
                {
                    bool haveResult = false;
                    foreach (DataGridViewRow row in dtgv_detail_service.Rows)
                        if (row.Cells["state_detail"].Value.ToString() == "Đã có KQ")
                            haveResult = true;
                    if (haveResult)
                    {
                        var confirm = MessageBox.Show(
                            "Phiếu này đã có kết quả. Bạn có chắc chắn muốn xóa không?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );
                        if (confirm == DialogResult.No) return;
                    }
                    Db.cmd.ExecuteNonQuery();
                    dtgv_service.Rows.RemoveAt(e.RowIndex);
                    LoadThongKe();     
                    if (selectedPatientId.HasValue)
                        foreach (DataGridViewRow row in dtgv_detail.Rows)
                        
                            if (row.Cells["id_patient"].Value != null &&
                                Convert.ToInt32(row.Cells["id_patient"].Value) == selectedPatientId.Value)
                            {
                                row.Selected = true;
                                dtgv_detail.FirstDisplayedScrollingRowIndex = row.Index;
                                dtgv_detail.CurrentCell = row.Cells["stt_patient"];
                                break;
                            }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            if (dtgv_service.Columns[e.ColumnIndex].Name != "del_service" )
            {
                if(dtgv_service.CurrentRow.Cells["type_service"].Value.ToString() == "chỉ định")
                {
                    dtgv_detail_service.Visible = true;
                    dtgv_detail_service_med.Visible = false;
                    Db.ResetConnection();
                    string query = $@"
                 SELECT distinct e.id, s.name, s.price,            
                    CASE 
                            WHEN er.examination_service_id IS NULL THEN 'Chưa có KQ'
                            ELSE 'Đã có KQ'
                        END AS 'state'
                 FROM examinations e
                 INNER JOIN examination_services es ON e.id = es.examination_id
                 INNER JOIN services s ON s.id = es.service_id
                 LEFT JOIN examination_results er ON es.id = er.examination_service_id
                 WHERE e.id = {idExam}";
                    textBox3.Text = query;

                    Db.ResetConnection();
                    Db.cmd = new MySqlCommand(query, Db.conn);
                    Db.dr = Db.cmd.ExecuteReader();

                    dtgv_detail_service.Rows.Clear();
                    int stt = 1;
                    while (Db.dr.Read())
                    {
                        int i = dtgv_detail_service.Rows.Add();
                        var drr = dtgv_detail_service.Rows[i];
                        drr.Cells["price_service_detail"].Value = Db.dr["price"];
                        drr.Cells["service_detail"].Value = Db.dr["name"];
                        drr.Cells["stt_detail"].Value = stt++;
                        drr.Cells["state_detail"].Value = Db.dr["state"];
                    }

                    Db.dr.Close();
                }
                else if (dtgv_service.CurrentRow.Cells["type_service"].Value.ToString() == "toa thuốc")
                {
                    dtgv_detail_service_med.Visible = true;
                    dtgv_detail_service.Visible = false;
                    int id_exam = Convert.ToInt32(dtgv_service.CurrentRow.Cells["id_exam_service"].Value.ToString());
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
                AND em.examination_id = {idExam}
            ";
                    textBox4.Text = query;
                    Db.cmd = new MySqlCommand(query, Db.conn);
                    Db.dr = Db.cmd.ExecuteReader();
                    dtgv_detail_service_med.Rows.Clear(); 
                    int stt = 1;
                    while (Db.dr.Read())
                    {
                        int i = dtgv_detail_service_med.Rows.Add();
                        DataGridViewRow drr = dtgv_detail_service_med.Rows[i];
                        drr.Cells["stt"].Value = stt++;
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


            }    

               
        }

        private void dtgv_detail_service_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgv_detail_service.Columns[e.ColumnIndex].Name == "state_detail")
                if (e.Value != null && e.Value.ToString() == "Đã có KQ")
                {
                    e.CellStyle.ForeColor = Color.Green;  
                    e.CellStyle.BackColor = Color.LightYellow; 
                }
                else
                {
                    e.CellStyle.ForeColor = dtgv_detail_service.DefaultCellStyle.ForeColor;
                    e.CellStyle.BackColor = dtgv_detail_service.DefaultCellStyle.BackColor;
                }
            
        }
    }
}
