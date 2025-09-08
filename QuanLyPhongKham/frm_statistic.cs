using System;
using System.Windows.Forms;

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

            // Tổng bệnh nhân
            string query1 = $@"
    SELECT COUNT(*) 
    FROM patients 
    WHERE updated_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_1.Text = Db.Scalar(query1).ToString();

            // Doanh thu thuốc: Mỗi đơn có nhiều thuốc, nhưng `price` trùng nhau ⇒ lấy MAX(price) theo examination_id, rồi tính tổng
            string query2 = $@"
            SELECT IFNULL(SUM(price), 0) as total
            FROM `examinations`
            WHERE type='toa thuốc' AND created_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_2.Text = string.Format("{0:N0} VND", Db.Scalar(query2));

            // Doanh thu dịch vụ
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
                    FROM examination_services es
                    JOIN services s ON es.service_id = s.id
                    JOIN examination_results er ON es.id = er.examination_service_id
                    WHERE LOWER(s.name) LIKE '%test %viêm gan b%'
                      AND LOWER(s.name) NOT LIKE '%kháng thể viêm gan b%';
                                    ";
            lb_vgb.Text = Db.Scalar(queryTestVGB).ToString();
            string queryTestKhangTheVGB = $@"SELECT COUNT(*)
                    FROM examination_services es
                    JOIN services s ON es.service_id = s.id
                    JOIN examination_results er ON es.id = er.examination_service_id
                    WHERE LOWER(s.name) LIKE '%kháng thể viêm gan b%';
                                    ";
            lb_ktvgb.Text = Db.Scalar(queryTestKhangTheVGB).ToString();
            string queryTestVGC = $@"SELECT COUNT(*)
                    FROM examination_services es
                    JOIN services s ON es.service_id = s.id
                    JOIN examination_results er ON es.id = er.examination_service_id
                    WHERE LOWER(s.name) LIKE '%test %viêm gan c%';
                                    ";
            lb_vgc.Text = Db.Scalar(queryTestVGC).ToString();
            string queryTestHuyetHoc = $@"SELECT COUNT(*)
                                        FROM examination_services es 
                                        JOIN services s ON es.service_id = s.id
                                        JOIN examination_results er ON es.id = examination_service_id
                                        Where LOWER(s.name) LIKE '%Huyết học%'
                                        ";
            lb_huyethoc.Text = Db.Scalar(queryTestHuyetHoc).ToString();
            string queryTestHbA1C = $@"SELECT COUNT(*)
                                        FROM examination_services es 
                                        JOIN services s ON es.service_id = s.id
                                        JOIN examination_results er ON es.id = examination_service_id
                                        Where LOWER(s.name) LIKE '%HbA1C%'
                                        ";
            lb_hba1c.Text = Db.Scalar(queryTestHbA1C).ToString();
            string queryTestHP = $@"SELECT COUNT(*)
                                        FROM examination_services es 
                                        JOIN services s ON es.service_id = s.id
                                        JOIN examination_results er ON es.id = examination_service_id
                                        Where LOWER(s.name) LIKE '%HP%' OR LOWER(s.name) LIKE '%H.pylori%'
                                        ";
            lb_testhp.Text = Db.Scalar(queryTestHP).ToString();
            string queryTestNuocTieu = $@"SELECT COUNT(*)
                                        FROM examination_services es 
                                        JOIN services s ON es.service_id = s.id
                                        JOIN examination_results er ON es.id = examination_service_id
                                        Where LOWER(s.name) LIKE '%Xét nghiệm nước tiểu%'
                                        ";
            lb_nuoctieu.Text = Db.Scalar(queryTestNuocTieu).ToString();
            string querySinhHoa = $@"SELECT COUNT(*)
                        FROM examination_services es
                        JOIN services s ON es.service_id = s.id
                        JOIN examination_results er ON es.id = er.examination_service_id
                        WHERE s.type = 'Xét nghiệm'
                          AND LOWER(s.name) NOT LIKE '%test %viêm gan b%'
                          AND LOWER(s.name) NOT LIKE '%kháng thể viêm gan b%'
                          AND LOWER(s.name) NOT LIKE '%test %viêm gan c%'
                          AND LOWER(s.name) NOT LIKE '%huyết học%'
                          AND LOWER(s.name) NOT LIKE '%hba1c%'
                          AND LOWER(s.name) NOT LIKE '%hp%'
                          AND LOWER(s.name) NOT LIKE '%h.pylori%'
                          AND LOWER(s.name) NOT LIKE '%xét nghiệm nước tiểu%';
                        ";
            lb_sinhhoa.Text = Db.Scalar(querySinhHoa).ToString();

        }

        private void frm_statistic_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Value = DateTime.Today; // 👈 Mặc định là hôm nay

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Value = DateTime.Today; // 👈 Mặc định là hôm nay

            LoadThongKe();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            // Có thể xử lý thêm ở đây nếu cần
        }

        private void guna2ImageButton8_Click(object sender, EventArgs e)
        {
            // Có thể xử lý thêm ở đây nếu cần
        }
    }
}
