using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_report_med : Form
    {
        private readonly DataTable _dtMed;
        private readonly string _mabn;
        private readonly string _tenbn;
        private readonly string _diachi;
        private readonly string _ngaysinh;
        private readonly string _gioitinh;
        private readonly string _loidan;
        private readonly string _chandoan;
        private readonly string _chandoanphu;
        private readonly string _ngaykham;
        private readonly string _tongtien;
        private readonly string _sdt;

        // Constructor nhận DataTable và các thông tin bệnh nhân (nếu cần)
        public frm_report_med(
            DataTable dtMed,
            string mabn = "",
            string tenbn = "",
            string ngaysinh = "",
            string diachi = "",
            string gioitinh = "",
            string loidan = "",
            string chandoan = "",
            string chandoanphu = "",
            string ngaykham = "",
            string tongtien = "",
            string sdt = ""

        )
        {
            InitializeComponent();
            _dtMed = dtMed;
            _mabn = mabn;
            _tenbn = tenbn;
            _ngaysinh = ngaysinh;
            _diachi = diachi;
            _gioitinh = gioitinh;
            _loidan = loidan;
            _chandoan = chandoan;
            _chandoanphu = chandoanphu;
            _ngaykham = ngaykham;
            _tongtien = tongtien;
            _sdt = sdt;
        }

        private void frm_report_med_Load(object sender, EventArgs e)
        {
            try
            {
                // Gán nguồn dữ liệu cho report

                var rds = new ReportDataSource("DataSet1", _dtMed);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Nếu Report3.rdlc có các ReportParameter, truyền vào ở đây
                var parameters = new ReportParameter[]
                {
                    new ReportParameter("txb_mabn", _mabn ?? ""),
                    new ReportParameter("txb_tenbn", _tenbn ?? ""),
                    new ReportParameter("txb_ngaysinh", _ngaysinh ?? ""),
                    new ReportParameter("txb_diachi", _diachi ?? ""),
                    //new ReportParameter("", _gioitinh ?? ""),
                    new ReportParameter("txb_loidan", _loidan ?? ""),
                    new ReportParameter("txb_chandoan", _chandoan ?? ""),
                    new ReportParameter("txb_chandoanphu", _chandoanphu ?? ""),
                    new ReportParameter("txb_ngaykham", _ngaykham ?? ""),
                    new ReportParameter("txb_tongtien", _tongtien ?? "")    ,
                        new ReportParameter("txb_sdt", _sdt ?? "")
                };
                reportViewer1.LocalReport.SetParameters(parameters);

                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
