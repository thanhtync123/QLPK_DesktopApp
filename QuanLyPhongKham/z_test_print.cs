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
    public partial class z_test_print : Form
    {
        string _imageUrl;
        public z_test_print(string imageUrl)
        {
            InitializeComponent();
            _imageUrl = imageUrl;
        }

        private void z_test_print_Load(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(_imageUrl);
            ReportParameter pName = new ReportParameter("pName", fi.Name);
            ReportParameter pImageUrl = new ReportParameter("pImageUrl", new Uri(_imageUrl).AbsoluteUri);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pName, pImageUrl });
            this.reportViewer1.RefreshReport();
        }
    }
}
