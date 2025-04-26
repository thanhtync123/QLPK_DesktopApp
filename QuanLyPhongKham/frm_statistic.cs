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
            string query1 = $"SELECT COUNT(*) FROM patients WHERE updated_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_1.Text = Db.Scalar(query1).ToString();

            // Doanh thu thuốc
            string query2 = $"SELECT IFNULL(SUM(price * quantity), 0) FROM examination_medications WHERE created_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_2.Text = string.Format("{0:N0} VND", Db.Scalar(query2));

            // Doanh thu dịch vụ
            string query3 = $"SELECT IFNULL(SUM(price), 0) FROM examination_services WHERE created_at BETWEEN '{fromDate}' AND '{toDate}'";
            label_3.Text = string.Format("{0:N0} VND", Db.Scalar(query3));

            // Tổng doanh thu
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
        }


        private void frm_statistic_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            LoadThongKe();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
    }
}








