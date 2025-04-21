using System;
using System.Collections.Generic;
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
            cb_type.Items.AddRange(new string[] { "Xét nghiệm", "X-quang", "Siêu âm", "Điện tim" });
            cb_type.SelectedIndex = 0;
            txb_id.ReadOnly = true;
            LoadDTGV();

            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void LoadDTGV()
        {
            string query = @"SELECT id, name, type, price FROM services ORDER BY type";

            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã dịch vụ";
            dtgv.Columns["name"].HeaderText = "Tên dịch vụ";
            dtgv.Columns["type"].HeaderText = "Loại";
            dtgv.Columns["price"].HeaderText = "Giá";
        }

        private Dictionary<string, object> GetFormData()
        {
            return new Dictionary<string, object>
            {
                { "@name", txb_name.Text.Trim() },
                { "@type", cb_type.SelectedItem.ToString() },
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
    }
}
