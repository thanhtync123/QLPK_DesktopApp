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
    public partial class frm_users : Form
    {
        public frm_users()
        {
            InitializeComponent();
        }
        private void LoadDTGV()
                    {
            string sql = "SELECT name,username,password,role FROM users";
            Db.LoadDTGV(dtgv, sql);
        }
        private void frm_users_Load(object sender, EventArgs e)
        {
            LoadDTGV();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(cb_role.Text == ""||txb_username.Text==""||txb_password.Text=="")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            string sql = $@"INSERT INTO users (name,username, password, role) 
                    VALUES ('{txb_name.Text}', '{txb_username.Text}', '{txb_password.Text}', '{cb_role.Text}')";
                Db.ExecuteNonQuery(sql);
                LoadDTGV();



        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string sql = $@"DELETE FROM users WHERE username = '{txb_username.Text}'";
            Db.ExecuteNonQuery(sql);
            LoadDTGV();
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_name.Text = dtgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txb_username.Text = dtgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txb_password.Text = dtgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }
    }
}
