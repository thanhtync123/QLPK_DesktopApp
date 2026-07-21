using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace QuanLyPhongKham
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        { 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new frm_login());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Không thể kết nối tới MySQL server!\n\n" + ex.Message,
                    "Lỗi kết nối MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
      

        }
    }
}
