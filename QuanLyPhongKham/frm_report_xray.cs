using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_report_xray : Form
    {
        private string mabn, tenbn, ngaysinh, diachi, sdt, chandoan, chandoanphu, mota, ketqua, chidinh, gioitinh;

        public frm_report_xray(string mabn, string tenbn, string ngaysinh, string diachi, string sdt, string chandoan, string chandoanphu, string mota, string ketqua, string chidinh, string gioitinh)
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
            reportViewer1.LocalReport.EnableExternalImages = true;
            string folder = Path.Combine(Application.StartupPath, "images");
            string file = CurrentUser.Signature;
            string fullPath = Path.Combine(folder, file);

            string filepath = "";
            if (File.Exists(fullPath))
                filepath = "file:///" + fullPath.Replace("\\", "/");
            string logoPath = Path.Combine(Application.StartupPath, "images", "logo.png");
            string logoUri = File.Exists(logoPath) ? "file:///" + logoPath.Replace("\\", "/") : "";
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");

    
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyPhongKham.Report1.rdlc";
            var dtFake = new DataTable("DataSet1");
            dtFake.Columns.Add("t_fake", typeof(string));
            dtFake.Rows.Add(" "); 

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtFake));

            // Gán các tham số
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("image_logo", logoUri ?? ""),
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
                new ReportParameter("txb_gioitinh", gioitinh),
                new ReportParameter("txb_dtname", CurrentUser.UserName ?? ""),
                new ReportParameter("pr_sign", filepath ?? ""),
                new ReportParameter("image_logo", logoUri),
                new ReportParameter("txb_businesstype", AppConfig.businesstype),
                new ReportParameter("txb_businessname", AppConfig.businessname),
                new ReportParameter("txb_businessservice", AppConfig.businessservice),
                new ReportParameter("txb_businessaddress", AppConfig.businessaddress),
                new ReportParameter("txb_businessphone", AppConfig.businessphone),
                new ReportParameter("txb_businessfb", AppConfig.businessfb)

            };

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 75;
        }
    }
}

