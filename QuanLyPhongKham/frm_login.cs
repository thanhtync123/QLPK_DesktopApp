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
            //1
            try
            {
                Db.ResetConnection();

                string query = "SELECT role, name FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, Db.conn);
                cmd.Parameters.AddWithValue("@username", txb_username.Text);
                cmd.Parameters.AddWithValue("@password", txb_password.Text);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string role = reader["role"].ToString();
                    string name = reader["name"].ToString();

                    CurrentUser.UserName = name;

                    reader.Close();
                    Db.conn.Close();

                    frm_nav frm = new frm_nav(role);
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    reader.Close();
                    Db.conn.Close();
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }
    }
}
