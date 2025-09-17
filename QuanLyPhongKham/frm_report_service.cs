using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_report_service : Form
    {
        private string mabn;
        private string tenbn;
        private string diachi;
        private string ngaysinh;
        private string gioitinh;
        private string loidan;
        private string chandoan;
        private string chandoanphu;
        private string ngaykham;
        private string tongtien;
        private string sdt;
        //     mabn, tenbn, diachi, ngaysinh, gioitinh, loidan, chandoan, chandoanphu, ngaykham, tongtien
        private DataTable _dtService;

        public frm_report_service(
            DataTable dtService,
            string mabn,
            string tenbn,
            string diachi,
            string ngaysinh,
            string gioitinh,
            string loidan,
            string chandoan,
            string chandoanphu,
            string ngaykham,
            string tongtien,
            string sdt)
        {
            InitializeComponent();
            _dtService = dtService;
            this.mabn = mabn;
            this.tenbn = tenbn;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.loidan = loidan;
            this.chandoan = chandoan;
            this.chandoanphu = chandoanphu;
            this.ngaykham = ngaykham;
            this.tongtien = tongtien;
            this.sdt = sdt;
        }
      //  mabn, tenbn, diachi, ngaysinh, gioitinh, loidan, chandoan, chandoanphu, ngaykham, tongtien
        private void frm_report_service_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.EnableExternalImages = true;
            string folder = Path.Combine(Application.StartupPath, "images");
            string file = CurrentUser.Signature;
            string fullPath = Path.Combine(folder, file);

            string filepath = "";
            if (File.Exists(fullPath))
                filepath = "file:///" + fullPath.Replace("\\", "/");
            try
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", _dtService);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                var parameters = new ReportParameter[]
                {
                    new ReportParameter("txb_mabn", mabn ?? ""),
                    new ReportParameter("txb_tenbn", tenbn ?? ""),
                    new ReportParameter("txb_ngaysinh", ngaysinh ?? ""),
                    new ReportParameter("txb_chandoan", chandoan ?? ""),
                    new ReportParameter("txb_chandoanphu", chandoanphu ?? ""),
                    new ReportParameter("txb_diachi", diachi ?? ""),
                    new ReportParameter("txb_sdt",  sdt?? ""),
                    new ReportParameter("txb_ngaykham", ngaykham ?? ""),
                    new ReportParameter("txb_loidan", loidan ?? ""),
                    new ReportParameter("txb_tongtien", tongtien ?? ""),
                    new ReportParameter("txb_gioitinh", gioitinh??""),
                    new ReportParameter("txb_dtname", CurrentUser.UserName ?? ""),
                    new ReportParameter("pr_sign", filepath ?? ""),
                    new ReportParameter("txb_businesstype", "PHÒNG KHÁM Y KHOA"),
                    new ReportParameter("txb_businessname", "THÚY NGA"),
                    new ReportParameter("txb_businessservice","SIÊU ÂM MÀU - KHÁM BỆNH")

                };
                reportViewer1.LocalReport.SetParameters(parameters);

                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                reportViewer1.ZoomPercent = 75;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
