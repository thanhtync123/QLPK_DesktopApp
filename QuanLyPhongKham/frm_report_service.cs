using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_report_service : Form
    {
         private DataTable _dtService;
        public frm_report_service(DataTable dtService)
        {
            InitializeComponent();
            _dtService = dtService;
        }

        private void frm_report_service_Load(object sender, EventArgs e)
        {

            try
            {

                MessageBox.Show("Số dòng dữ liệu: " + _dtService.Rows.Count, "Debug dữ liệu");

           

                string columns = string.Join(", ", _dtService.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                MessageBox.Show("Các cột trong DataTable: " + columns, "Debug cột");

                foreach (DataRow row in _dtService.Rows)
                {
                    string rowData = string.Join(", ", _dtService.Columns.Cast<DataColumn>().Select(c => row[c.ColumnName]?.ToString()));
                    MessageBox.Show(rowData, "Debug dòng dữ liệu");
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", _dtService);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
