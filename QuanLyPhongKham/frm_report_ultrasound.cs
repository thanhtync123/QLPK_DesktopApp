using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using System.IO;

namespace QuanLyPhongKham
{
    public partial class frm_report_ultrasound : Form
    {
        string _imageUrl1, _imageUrl2, _imageUrl3, _imageUrl4;
        string mabn, tenbn, ngaysinh, diachi, sdt;
        string chandoan, chandoanphu, mota, ketqua, chidinh,gioitinh;

        public frm_report_ultrasound(
            string imageUrl1, string imageUrl2, string imageUrl3, string imageUrl4,
            string mabn, string tenbn, string ngaysinh, string diachi, string sdt,
            string chandoan, string chandoanphu, string mota, string ketqua, string chidinh,string gioitinh)
        {
            InitializeComponent();
            _imageUrl1 = imageUrl1;
            _imageUrl2 = imageUrl2;
            _imageUrl3 = imageUrl3;
            _imageUrl4 = imageUrl4;
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

        private void frm_report_ultrasound_Load(object sender, EventArgs e)
        {
            var ngaykham = DateTime.Now.ToString("'Ngày' dd 'tháng' MM 'năm' yyyy");


            try
            {
                // Bật hiển thị ảnh từ ngoài
                this.reportViewer1.LocalReport.EnableExternalImages = true;

                // Tạo danh sách các tham số để thêm vào sau
                var reportParams = new System.Collections.Generic.List<ReportParameter>();

                // Các tham số ảnh - chỉ thêm khi đường dẫn hợp lệ
                AddImageParameter(reportParams, "image_param1", _imageUrl1);
                AddImageParameter(reportParams, "image_param2", _imageUrl2);
                AddImageParameter(reportParams, "image_param3", _imageUrl3);
                AddImageParameter(reportParams, "image_param4", _imageUrl4);

                // Các tham số text
                reportParams.Add(new ReportParameter("txb_mabn", mabn ?? ""));
                reportParams.Add(new ReportParameter("txb_tenbn", tenbn ?? ""));
                reportParams.Add(new ReportParameter("txb_ngaysinh", ngaysinh ?? ""));
                reportParams.Add(new ReportParameter("txb_diachi", diachi ?? ""));
                reportParams.Add(new ReportParameter("txb_sdt", sdt ?? ""));
                reportParams.Add(new ReportParameter("txb_chandoan", chandoan ?? ""));
                reportParams.Add(new ReportParameter("txb_chandoanphu", chandoanphu ?? ""));
                reportParams.Add(new ReportParameter("txb_mota", mota ?? ""));
                reportParams.Add(new ReportParameter("txb_ketluan", ketqua ?? ""));
                reportParams.Add(new ReportParameter("txb_chidinh", chidinh ?? ""));
                reportParams.Add(new ReportParameter("txb_ngaykham", ngaykham ??""));
                reportParams.Add(new ReportParameter("txb_gioitinh", gioitinh ?? ""));

                // Set tất cả các tham số
                this.reportViewer1.LocalReport.SetParameters(reportParams);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức để thêm tham số ảnh an toàn
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