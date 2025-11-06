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
    public partial class frm_medications_set : Form
    {
        public frm_medications_set()
        {
            InitializeComponent();
        }

        private void frm_medications_set_Load(object sender, EventArgs e)
        {
            LoadDTGV_Preset_medications_set("");
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;

        }
        private void LoadDTGV_Preset_medications_set(string keyword)
        {
            Db.ResetConnection();
            string query = $@"SELECT * FROM preset_medications_set where name like '%{txb_search.Text}%'";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_preset_medications_set.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_preset_medications_set.Rows.Add();
                DataGridViewRow row = dtgv_preset_medications_set.Rows[i];
                row.Cells["id"].Value = Db.dr["id"];
                row.Cells["name"].Value = Db.dr["name"];
                row.Cells["description"].Value = Db.dr["description"];


            }

            Db.dr.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_name_medications_set.Text))
            {
                MessageBox.Show("Vui lòng nhập tên toa thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = $@"
            INSERT INTO preset_medications_set (id, name, description)
            VALUES (NULL, '{txb_name_medications_set.Text}', 
            {(string.IsNullOrWhiteSpace(txb_description.Text) ? "NULL" : $"'{txb_description.Text}'")})";
            Db.ExecuteNonQuery(query);
            LoadDTGV_Preset_medications_set("");

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string query = $@"DELETE FROM preset_medications_set WHERE id = {txb_id.Text}";
            Db.ExecuteNonQuery(query);
            LoadDTGV_Preset_medications_set("");
   
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_name_medications_set.Text))
            {
                MessageBox.Show("Vui lòng nhập tên toa thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = $@"
            UPDATE preset_medications_set
            SET 
                name = '{txb_name_medications_set.Text}',
                description = {(string.IsNullOrWhiteSpace(txb_description.Text) ? "NULL" : $"'{txb_description.Text}'")}
            WHERE id = {txb_id.Text}";

            Db.ExecuteNonQuery(query);
   
            LoadDTGV_Preset_medications_set("");
        }

        private void dtgv_preset_medications_set_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_id.Text = dtgv_preset_medications_set.CurrentRow.Cells["id"].Value.ToString();
            txb_name_medications_set.Text = dtgv_preset_medications_set.CurrentRow.Cells["name"].Value.ToString();
            txb_description.Text = dtgv_preset_medications_set.CurrentRow.Cells["description"].Value.ToString();
            btn_add.Enabled = false;
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txb_id.Text = "";
            txb_name_medications_set.Text = "";
            txb_description.Text = "";
            btn_add.Enabled = true;

        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            LoadDTGV_Preset_medications_set(txb_search.Text);
        }
    }
}
