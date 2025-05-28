using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace QuanLyPhongKham
{
    public static class Db
    {
        public static string connectionString = "Server=192.168.1.100;Database=clinic_db2;Uid=root;Pwd=123456;";
        public static MySqlConnection conn = new MySqlConnection(connectionString);
        public static MySqlCommand cmd;
        public static MySqlDataReader dr;
        public static MySqlCommand CreateCommand(string query)
        {
            return new MySqlCommand(query, conn);
        }
        public static void ResetConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            if (conn.State != ConnectionState.Open)
                conn.Open();

        }
        public static void LoadComboBoxData(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            ResetConnection();  
            MySqlCommand cmd = CreateCommand(query);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            comboBox.DataSource = dt; 
            comboBox.DisplayMember = displayMember;  
            comboBox.ValueMember = valueMember;  

            conn.Close();  
        }
        public static void Add(string query, Dictionary<string, object> parameters)
        {
            try
            {
                ResetConnection(); // Mở lại kết nối nếu cần
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    cmd.ExecuteNonQuery(); // Thực thi lệnh thêm
                }
                conn.Close(); // Đóng kết nối sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
        }
        public static void Update(string query, Dictionary<string, object> parameters)
        {
            try
            {
                ResetConnection(); // Mở lại kết nối nếu cần
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Thêm các tham số vào câu lệnh SQL
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    cmd.ExecuteNonQuery(); // Thực thi lệnh cập nhật
                }
                conn.Close(); // Đóng kết nối sau khi cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
        }
        public static void SetTextAndMoveCursorToEnd(TextBox textBox, string text)
        {
            textBox.Text = text;
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }
        public static void LoadDTGV(DataGridView dtgv, string query)
        {
            try
            {
                ResetConnection(); // Đảm bảo kết nối được mở
                MySqlCommand cmd = CreateCommand(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dtgv.DataSource = dt; // Gán dữ liệu cho DataGridView
                conn.Close(); // Đóng kết nối sau khi hoàn tất
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu vào DataGridView: " + ex.Message);
            }
        }
        public static void Delete(string query, Dictionary<string, object> parameters)
        {
            try
            {
                ResetConnection(); // Mở lại kết nối nếu cần
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Thêm các tham số vào câu lệnh SQL
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    cmd.ExecuteNonQuery(); // Thực thi lệnh xóa
                }
                conn.Close(); // Đóng kết nối sau khi xóa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }
        public static object Scalar(string query)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                return cmd.ExecuteScalar();
            }
        }
        public static MySqlDataReader GetReader(string query)
        {
            ResetConnection();
            MySqlCommand cmd = CreateCommand(query);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static void ExecuteNonQuery(string query)
        {
            try
            {
                ResetConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }


    }
}
