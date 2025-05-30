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
        private string mabn, tenbn, ngaysinh, diachi, sdt, chandoan, chandoanphu, mota, ketqua, chidinh,gioitinh;

        public frm_report_xray(string mabn, string tenbn, string ngaysinh, string diachi, string sdt, string chandoan, string chandoanphu, string mota, string ketqua, string chidinh,string gioitinh)
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
            this.gioitinh = gioitinh;
        }
        public frm_report_xray()
        {
            InitializeComponent();
        }

        private void frm_report_xray_Load(object sender, EventArgs e)
        {
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");

            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyPhongKham.Report1.rdlc";
            ReportParameter[] parameters = new ReportParameter[]
            {
        new ReportParameter("txb_mabn", mabn),
        new ReportParameter("txb_tenbn", tenbn),
        new ReportParameter("txb_ngaysinh", ngaysinh),
        new ReportParameter("txb_diachi", diachi),
        new ReportParameter("txb_sdt", sdt),
        new ReportParameter("txb_chandoan", chandoan),
        new ReportParameter("txb_chandoanphu", chandoanphu),
        new ReportParameter("txb_mota", mota),
        new ReportParameter("txb_ketluan", ketqua),
        new ReportParameter("txb_chidinh", chidinh),
             new ReportParameter("txb_ngaykham", ngaykham),
             new ReportParameter("txb_gioitinh", gioitinh)
            };
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }
    }
}
