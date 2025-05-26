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
using Microsoft.Reporting.WinForms;
using MySqlX.XDevAPI.Common;

namespace QuanLyPhongKham
{
    public partial class frm_report_med : Form
    {
        private DataTable _dtMed;
        public frm_report_med(DataTable dt)
        {
            InitializeComponent();
            _dtMed = dt;

        }
       
        private void frm_report_med_Load(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show("Số dòng dữ liệu: " + _dtMed.Rows.Count, "Debug dữ liệu");

                // Hiển thị tên các cột trong DataTable
                string columns = string.Join(", ", _dtMed.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                MessageBox.Show("Các cột trong DataTable: " + columns, "Debug cột");
               
                    foreach (DataRow row in _dtMed.Rows)
                    {
                        string rowData = string.Join(", ", _dtMed.Columns.Cast<DataColumn>().Select(c => row[c.ColumnName]?.ToString()));
                        MessageBox.Show(rowData, "Debug dòng dữ liệu");
                    }

                ReportDataSource rds = new ReportDataSource("DataSet1",_dtMed);
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
