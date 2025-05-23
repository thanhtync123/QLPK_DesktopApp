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
        }

        private void LoadDTGV()
        {
            string query = @"SELECT id, name, unit, dosage, route, times_per_day, note, price FROM medications";
            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã thuốc";
            dtgv.Columns["name"].HeaderText = "Tên thuốc";
            dtgv.Columns["unit"].HeaderText = "Đơn vị";
            dtgv.Columns["dosage"].HeaderText = "Liều dùng";
            dtgv.Columns["route"].HeaderText = "Đường dùng";
            dtgv.Columns["times_per_day"].HeaderText = "Số lần/ngày";
            dtgv.Columns["note"].HeaderText = "Ghi chú";
            dtgv.Columns["price"].HeaderText = "Giá";
        }

        private Dictionary<string, object> GetFormData()
        {
            return new Dictionary<string, object>
            {
                { "@name", txb_name.Text.Trim() },
                { "@unit", txb_unit.Text.Trim() },
                { "@dosage", txb_dosage.Text.Trim() },
                { "@route", txb_route.Text.Trim() },
                { "@times_per_day", txb_times.Text.Trim() },
                { "@note", txb_note.Text.Trim() },
                { "@price", txb_price.Text.Trim() }
            };
        }

        private void ClearForm()
        {
            txb_id.Clear();
            txb_name.Clear();
            txb_unit.Clear();
            txb_dosage.Clear();
            txb_route.Clear();
            txb_times.Clear();
            txb_note.Clear();
            txb_price.Clear();

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
                txb_unit.Text = row.Cells["unit"].Value.ToString();
                txb_dosage.Text = row.Cells["dosage"].Value.ToString();
                txb_route.Text = row.Cells["route"].Value.ToString();
                txb_times.Text = row.Cells["times_per_day"].Value.ToString();
                txb_note.Text = row.Cells["note"].Value.ToString();
                txb_price.Text = row.Cells["price"].Value.ToString();

                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO medications (name, unit, dosage, route, times_per_day, note, price) 
                             VALUES (@name, @unit, @dosage, @route, @times_per_day, @note, @price)";
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
                             SET name = @name, unit = @unit, dosage = @dosage, route = @route, 
                                 times_per_day = @times_per_day, note = @note, price = @price 
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
                SELECT id, name, unit, dosage, route, times_per_day, note, price 
                FROM medications 
                WHERE id LIKE '%{keyword}%' OR name LIKE '%{keyword}%'";
            Db.LoadDTGV(dtgv, query);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txb_id.Text = "";
            txb_name.Text = "";
            txb_note.Text = "";
            txb_price.Text = "";
            txb_route.Text = "";
            txb_search.Text = "";
            txb_search.Text = "";
            txb_times.Text = "";
            txb_unit.Text = "";
            txb_id.Text = "";
            btn_add.Enabled = true;
            btn_delete.Enabled = false;
            
        }
    }
}
