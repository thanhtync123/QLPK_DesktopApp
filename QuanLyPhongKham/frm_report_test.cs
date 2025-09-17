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
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_report_test : Form
    {
        DataTable _dt;
        string mabn;
        string tenbn;
        string ngaysinh;
        string chandoan;
        string chandoanphu;
        string diachi;
        string ketqua;
        string ngaykham;
        string sdt;
        string gioitinh;
        string chidinh;
        string nhanvien;
        public frm_report_test(DataTable dt, string mabn, string tenbn, string ngaysinh, string chandoan, string chandoanphu, string diachi, string ketqua, string ngaykham, string sdt, string gioitinh, string chidinh, string nhanvien)
        {
            InitializeComponent();

            _dt = dt;
            this.mabn = mabn;
            this.tenbn = tenbn;
            this.ngaysinh = ngaysinh;
            this.chandoan = chandoan;
            this.chandoanphu = chandoanphu;
            this.diachi = diachi;
            this.ketqua = ketqua;
            this.ngaykham = ngaykham;
            this.sdt = sdt;
            this.gioitinh = gioitinh;
            this.chidinh = chidinh;
            this.nhanvien = nhanvien;
        }


        private void frm_report_test_Load(object sender, EventArgs e)
        {
            string folder = Path.Combine(Application.StartupPath, "images");
            string file = CurrentUser.Signature;
            string fullPath = Path.Combine(folder, file);

            string filepath = "";
            if (File.Exists(fullPath))
                filepath = "file:///" + fullPath.Replace("\\", "/");
            string logoPath = Path.Combine(Application.StartupPath, "images", "logo.png");
            string logoUri = File.Exists(logoPath) ? "file:///" + logoPath.Replace("\\", "/") : "";

            try
            {
                reportViewer1.LocalReport.EnableExternalImages = true;

                ReportDataSource rds = new ReportDataSource("DataSet1", _dt);
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
                    new ReportParameter("txb_ngaykham", ngaykham ?? ""),
                    new ReportParameter("txb_ketluan", ketqua ?? ""),
                    new ReportParameter("txb_sdt", sdt ?? ""),
                    new ReportParameter("txb_gioitinh", gioitinh ?? ""),
                    new ReportParameter("txb_chidinh", chidinh ?? ""),
                    new ReportParameter("txb_nhanvien", nhanvien ?? ""),
                    new ReportParameter("pr_sign", filepath??""),
                    new ReportParameter("txb_businesstype", "PHÒNG KHÁM ĐA KHOA"),
                    new ReportParameter("txb_businessname", "THÚY NGA"),
                    new ReportParameter("txb_businessservice", "SIÊU ÂM MÀU - KHÁM BỆNH"),
                    new ReportParameter("txb_businessaddress", "123 Lê Lợi, Quận 1, TP. HCM"),
                    new ReportParameter("txb_businessphone", "0931111222"),
                    new ReportParameter("txb_businessfb", "Phòng khám đa khoa ABC")



                };
                reportViewer1.LocalReport.SetParameters(parameters);


                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
