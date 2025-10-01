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

                    new ReportParameter("image_logo", logoUri ?? ""),
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
                    new ReportParameter("txb_businesstype", AppConfig.businesstype),
                    new ReportParameter("txb_businessname", AppConfig.businessname),
                    new ReportParameter("txb_businessservice", AppConfig.businessservice),
                    new ReportParameter("txb_businessaddress", AppConfig.businessaddress),
                    new ReportParameter("txb_businessphone", AppConfig.businessphone),
                    new ReportParameter("txb_businessfb", AppConfig.businessfb),





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
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void AddImageParameter(System.Collections.Generic.List<ReportParameter> parameters, string paramName, string imageUrl)
        {
            // Nếu đường dẫn rỗng hoặc null, sử dụng hình ảnh trống
            if (string.IsNullOrEmpty(imageUrl))
            {
                // Đường dẫn ảnh trống mặc định hoặc để trống
                parameters.Add(new ReportParameter(paramName, ""));
                return;
            }

            try
            {
                // Kiểm tra xem đường dẫn có phải là file thực tế không
                if (File.Exists(imageUrl))
                {
                    // Chuyển đổi đường dẫn file thành URI hợp lệ
                    Uri uri = new Uri(imageUrl);
                    parameters.Add(new ReportParameter(paramName, uri.AbsoluteUri));
                }
                else
                {
                    // Nếu không phải file, thử chuyển đổi trực tiếp thành URI
                    Uri uri = new Uri(imageUrl);
                    parameters.Add(new ReportParameter(paramName, uri.AbsoluteUri));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xử lý ảnh {imageUrl}: {ex.Message}");
                parameters.Add(new ReportParameter(paramName, ""));
            }
        }
    }
}
