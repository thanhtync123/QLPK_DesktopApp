using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_med : Form
    {
        public frm_med()
        {
            InitializeComponent();
        }

        private void frm_med_Load(object sender, EventArgs e)
        {
            LoadDTGV();
            txb_id.ReadOnly = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;

            txb_search.TextChanged += txb_search_TextChanged;

            dtgv.Columns["id"].Width = 60;
            dtgv.Columns["name"].Width = 150;
            dtgv.Columns["unit"].Width = 80;
            dtgv.Columns["note"].Width = 150;
        }

        private void LoadDTGV()
        {
            string query = @"SELECT id, name, unit, note FROM medications ORDER BY name";
            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã thuốc";
            dtgv.Columns["name"].HeaderText = "Tên thuốc";
            dtgv.Columns["unit"].HeaderText = "Đơn vị";
            dtgv.Columns["note"].HeaderText = "Ghi chú";
        }

        private void ClearForm()
        {
            txb_id.Clear();
            txb_name.Clear();
            txb_unit.Clear();
            txb_note.Clear();
            btn_add.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgv.Rows[e.RowIndex];
                txb_id.Text = row.Cells["id"].Value.ToString();
                txb_name.Text = row.Cells["name"].Value.ToString();
                txb_unit.Text = row.Cells["unit"].Value.ToString();
                txb_note.Text = row.Cells["note"].Value.ToString();

                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO medications 
                             (id, name, unit, note, price, created_at, updated_at) 
                             VALUES (NULL, @name, @unit, @note, NULL, CURRENT_TIMESTAMP(), CURRENT_TIMESTAMP())";
            Db.Add(query, GetFormData());
            LoadDTGV();
            ClearForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn thuốc để cập nhật.");
                return;
            }

            string query = @"UPDATE medications 
                             SET name = @name, unit = @unit, note = @note, updated_at = CURRENT_TIMESTAMP()
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
                MessageBox.Show("Vui lòng chọn thuốc để xóa.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM medications WHERE id = @id";
                var data = new Dictionary<string, object> { { "@id", txb_id.Text.Trim() } };
                Db.Delete(query, data);
                LoadDTGV();
                ClearForm();
            }
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = MySql.Data.MySqlClient.MySqlHelper.EscapeString(txb_search.Text.Trim());
            string query = $@"
                SELECT id, name, unit, note 
                FROM medications 
                WHERE id LIKE '%{keyword}%' OR name LIKE '%{keyword}%'";
            Db.LoadDTGV(dtgv, query);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private Dictionary<string, object> GetFormData()
        {
            return new Dictionary<string, object>
            {
                { "@name", txb_name.Text.Trim() },
                { "@unit", txb_unit.Text.Trim() },
                { "@note", txb_note.Text.Trim() }
            };
        }
    }
}
