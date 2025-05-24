using Microsoft.Reporting.WinForms;
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
    public partial class frm_report_xray : Form
    {
        private string mabn, tenbn, ngaysinh, diachi, sdt, chandoan, chandoanphu, mota, ketqua, chidinh;

        public frm_report_xray(string mabn, string tenbn, string ngaysinh, string diachi, string sdt, string chandoan, string chandoanphu, string mota, string ketqua, string chidinh)
        {
            InitializeComponent();
            this.mabn = mabn;
            this.tenbn = tenbn;
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.chandoan = chandoan;
            this.chandoanphu = chandoanphu;
            this.mota = mota;
            this.ketqua = ketqua;
            this.chidinh = chidinh;
        }
        public frm_report_xray()
        {
            InitializeComponent();
        }

        private void frm_report_xray_Load(object sender, EventArgs e)
        {
            MessageBox.Show(tenbn+"");
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyPhongKham.Report1.rdlc";
            // hoặc nếu dùng file path cụ thể (thường không nên hardcode đường dẫn)
            // reportViewer1.LocalReport.ReportPath = @"C:\QLPK\QuanLyPhongKham\Report1.rdlc";

            // Tạo mảng parameters
            ReportParameter[] parameters = new ReportParameter[]
            {
        new ReportParameter("txb_mabn", mabn),
        new ReportParameter("txb_tenbn", "Nguyễn văn a"),
        new ReportParameter("txb_ngaysinh", ngaysinh),
        new ReportParameter("txb_diachi", diachi),
        new ReportParameter("txb_sdt", sdt),
        new ReportParameter("txb_chandoan", "123"),
        new ReportParameter("txb_chandoanphu", "123"),
        new ReportParameter("txb_mota", "123"),
        new ReportParameter("txb_ketluan", "123"),
        new ReportParameter("txb_chidinh", "123")
            };

            // Gán parameters cho báo cáo
            reportViewer1.LocalReport.SetParameters(parameters);

            // Refresh report để áp dụng
            reportViewer1.RefreshReport();
        }
    }
}
