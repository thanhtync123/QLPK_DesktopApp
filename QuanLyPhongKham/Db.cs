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
        public static string connectionString = "Server=localhost;Database=clinic_db2;Uid=root;Pwd=;";
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
    }
}
