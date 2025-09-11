using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_report_med : Form
    {
        private readonly string _mabn;
        private readonly string _tenbn;
        private readonly string _ngaysinh;
        private readonly string _diachi;
        private readonly string _loidan;
        private readonly string _chandoan;
        private readonly string _chandoanphu;
        private readonly string _ngaykham;
        private readonly string _tongtien;
        private readonly string _sdt;
        private readonly string _thuoc;
        private readonly string _taikham;
        private readonly string _songaythuoc;

        public frm_report_med(
            string mabn = "",        // 1
            string tenbn = "",       // 2
            string ngaysinh = "",    // 3
            string diachi = "",      // 4
            string loidan = "",      // 5
            string chandoan = "",    // 6
            string chandoanphu = "", // 7 ← đang bị thiếu ở chỗ truyền
            string ngaykham = "",    // 8
            string tongtien = "",    // 9
            string sdt = "",         //10
            string thuoc = "",       //11
            string taikham = "",     //12
            string songaythuoc = ""  //13
        )

        {
            InitializeComponent();

            _mabn = mabn;
            _tenbn = tenbn;
            _ngaysinh = ngaysinh;
            _diachi = diachi;
            _loidan = loidan;
            _chandoan = chandoan;
            _chandoanphu = chandoanphu;
            _ngaykham = ngaykham;
            _tongtien = tongtien;
            _sdt = sdt;
            _thuoc = thuoc;
            _taikham = taikham;
            _songaythuoc = songaythuoc;
        }

        private void frm_report_med_Load(object sender, EventArgs e)
        {
            string folder = Path.Combine(Application.StartupPath, "images");
            string file = CurrentUser.Signature;
            string fullPath = Path.Combine(folder, file);

            string filepath = "";
            if (File.Exists(fullPath))
                filepath = "file:///" + fullPath.Replace("\\", "/");
            
            try
            {
                // Đảm bảo file .rdlc đã gán Build Action = Embedded Resource
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyPhongKham.Report3.rdlc";

                reportViewer1.LocalReport.DataSources.Clear();

                var parameters = new ReportParameter[]
                {
                   
                    new ReportParameter("txb_mabn", _mabn ?? ""),
                    new ReportParameter("txb_tenbn", _tenbn ?? ""),
                    new ReportParameter("txb_ngaysinh", _ngaysinh ?? ""),
                    new ReportParameter("txb_diachi", _diachi ?? ""),
                    new ReportParameter("txb_loidan", _loidan ?? ""),
                    new ReportParameter("txb_chandoan", _chandoan ?? ""),
                    new ReportParameter("txb_chandoanphu", _chandoanphu ?? ""),
                    new ReportParameter("txb_ngaykham", _ngaykham ?? ""),
                    new ReportParameter("txb_tongtien", _tongtien ?? ""),
                    new ReportParameter("txb_sdt", _sdt ?? ""),
                    new ReportParameter("txb_med", _thuoc ?? ""),
                    new ReportParameter("txb_taikham", _taikham ?? ""),
                    new ReportParameter("txb_songaythuoc", _songaythuoc ?? ""),
                    new ReportParameter("txb_dtname", CurrentUser.UserName ?? ""),
                    new ReportParameter("pr_sign", filepath ?? "")
                };

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
                // **Bật mặc định Print Layout**
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                reportViewer1.ZoomPercent = 75;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo:\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
