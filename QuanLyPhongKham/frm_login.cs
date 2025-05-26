using MySql.Data.MySqlClient;
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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                Db.ResetConnection();

                string query = "SELECT role FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, Db.conn);
                cmd.Parameters.AddWithValue("@username", txb_username.Text);
                cmd.Parameters.AddWithValue("@password", txb_password.Text);

                object role = cmd.ExecuteScalar();
                Db.conn.Close();

                if (role != null)
                {
                    frm_nav frm = new frm_nav(role.ToString());
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
