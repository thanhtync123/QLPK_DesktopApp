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
    public partial class frm_report_ultrasound : Form
    {
        string _imageUrl1, _imageUrl2;
        string mabn;
        string tenbn;
        string ngaysinh;
        string diachi;
        string sdt;
        string chandoan;
        string chandoanphu;
        string mota;
        string ketqua;
        string chidinh;
        public frm_report_ultrasound(string imageUrl1,string imageUrl2,string mabn,string tenbn,string ngaysinh,string diachi,string sdt,string chandoan,string chandoanphu,string mota,string ketqua,string chidinh)
        {
            InitializeComponent();
            _imageUrl1 = imageUrl1;
            _imageUrl2 = imageUrl2;
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

        private void frm_report_ultrasound_Load(object sender, EventArgs e)
        {
            // Các tham số ảnh
            ReportParameter image_param1 = new ReportParameter("image_param1", new Uri(_imageUrl1).AbsoluteUri);
            ReportParameter image_param2 = new ReportParameter("image_param2", new Uri(_imageUrl2).AbsoluteUri);

            // Các tham số text
            ReportParameter param_mabn = new ReportParameter("txb_mabn", mabn);
            ReportParameter param_tenbn = new ReportParameter("txb_tenbn", tenbn);
            ReportParameter param_ngaysinh = new ReportParameter("txb_ngaysinh", ngaysinh);
            ReportParameter param_diachi = new ReportParameter("txb_diachi", diachi);
            ReportParameter param_sdt = new ReportParameter("txb_sdt", sdt);
            ReportParameter param_chandoan = new ReportParameter("txb_chandoan", chandoan);
            ReportParameter param_chandoanphu = new ReportParameter("txb_chandoanphu", chandoanphu);
            ReportParameter param_mota = new ReportParameter("txb_mota", mota);
            ReportParameter param_ketqua = new ReportParameter("txb_ketluan", ketqua);
            ReportParameter param_chidinh = new ReportParameter("txb_chidinh", chidinh);

            // Bật cho phép hiển thị ảnh bên ngoài
            this.reportViewer1.LocalReport.EnableExternalImages = true;

            // Set tất cả các param cho báo cáo
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {
                image_param1,
                image_param2,
                param_mabn,
                param_tenbn,
                param_ngaysinh,
                param_diachi,
                param_sdt,
                param_chandoan,
                param_chandoanphu,
                param_mota,
                param_ketqua,
                param_chidinh
    });

            this.reportViewer1.RefreshReport();


        }
    }
}
