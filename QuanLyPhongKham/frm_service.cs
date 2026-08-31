using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_service : Form
    {
        public frm_service()
        {
            InitializeComponent();
        }

        private void frm_service_Load(object sender, EventArgs e)
        {
            loadComboboxTypeService();
            cb_type.SelectedIndex = 0;
            txb_id.ReadOnly = true;
            LoadDTGV();

            btn_update.Enabled = false;
            btn_delete.Enabled = false;
            LoadDTGV_TypeService();

        }
        private void loadComboboxTypeService()
        {

            Db.ResetConnection();

            string sql = "SELECT id, name FROM type_service ORDER BY name";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, Db.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_type.DataSource = dt;
            cb_type.DisplayMember = "name";
            cb_type.ValueMember = "id";
        }
        private void LoadDTGV_TypeService()
        {
            Db.ResetConnection();
            string query = @"SELECT `id`, `name` FROM `type_service` order by name";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
 
            while (Db.dr.Read())
            {
                int i = dtgv_typeService.Rows.Add();
                DataGridViewRow drr = dtgv_typeService.Rows[i];
                drr.Cells["id"].Value = Db.dr["id"];
                drr.Cells["name"].Value = Db.dr["name"];

            }

            Db.dr.Close();
        }
        private void LoadDTGV()
        {
            string query = @"SELECT id, name, type, price FROM services ORDER BY type";

            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã dịch vụ";
            dtgv.Columns["name"].HeaderText = "Tên dịch vụ";
            dtgv.Columns["type"].HeaderText = "Loại";
            dtgv.Columns["price"].HeaderText = "Giá";

            dtgv.Columns["id"].Width = 80;       // Mã dịch vụ – ngắn
            dtgv.Columns["name"].Width = 200;    // Tên dịch vụ – dài hơn
            dtgv.Columns["type"].Width = 100;    // Loại – trung bình
            dtgv.Columns["price"].Width = 80;    // Giá – ngắn

        }

        private Dictionary<string, object> GetFormData()
        {
            return new Dictionary<string, object>
            {
                { "@name", txb_name.Text.Trim() },
                { "@type", cb_type.Text },
                { "@price", txb_price.Text.Trim() }
            };
        }

        private void ClearForm()
        {
            txb_id.Clear();
            txb_name.Clear();
            txb_price.Clear();
            cb_type.SelectedIndex = 0;

            btn_add.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv.Rows[e.RowIndex];
                txb_id.Text = row.Cells["id"].Value.ToString();
                txb_name.Text = row.Cells["name"].Value.ToString();
                cb_type.SelectedItem = row.Cells["type"].Value.ToString();
                txb_price.Text = row.Cells["price"].Value.ToString();

                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO services (name, type, price) 
                             VALUES (@name, @type, @price)";
            Db.Add(query, GetFormData());
            LoadDTGV();
            ClearForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để cập nhật.");
                return;
            }

            string query = @"UPDATE services 
                             SET name = @name, type = @type, price = @price 
                             WHERE id = @id";
            var data = GetFormData();
            data.Add("@id", txb_id.Text.Trim());

            Db.Update(query, data);
            LoadDTGV();
            ClearForm();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM services WHERE id = @id";
                var data = new Dictionary<string, object>
                {
                    { "@id", txb_id.Text.Trim() }
                };
                Db.Delete(query, data);
                LoadDTGV();
                ClearForm();
            }
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = MySql.Data.MySqlClient.MySqlHelper.EscapeString(txb_search.Text.Trim());
            string query = $@"
                SELECT id, name, type, price 
                FROM services 
                WHERE id LIKE '%{keyword}%' OR name LIKE '%{keyword}%' OR type LIKE '%{keyword}%'";
            Db.LoadDTGV(dtgv, query);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txb_search.Text = "";
            txb_id.Text = "";
            txb_name.Text = "";
            txb_price.Text = "";
           
        }

        private void txb_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_saveTypeService_Click(object sender, EventArgs e)
        {
            string sql = $@"INSERT INTO type_service (name) VALUES ('{txb_nameService.Text}')";
            Db.ExecuteNonQuery(sql);
            dtgv_typeService.Rows.Clear();
            LoadDTGV_TypeService();
            loadComboboxTypeService();
        }

        private void btn_deleteTypeService_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(
               dtgv_typeService.CurrentRow.Cells["id"].Value
           );
            string sql = $"DELETE FROM type_service WHERE id = {id}";
            Db.ExecuteNonQuery(sql);
            dtgv_typeService.Rows.Clear();
            LoadDTGV_TypeService();
            loadComboboxTypeService();
        }
    }
}
