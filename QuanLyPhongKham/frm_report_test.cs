using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public frm_report_test(DataTable dt, string mabn, string tenbn, string ngaysinh, string chandoan, string chandoanphu, string diachi, string ketqua, string ngaykham, string sdt, string gioitinh, string chidinh)
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
        }


        private void frm_report_test_Load(object sender, EventArgs e)
        {

            try
            {
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
                                new ReportParameter("txb_chidinh", chidinh ?? "")



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
    }
}
