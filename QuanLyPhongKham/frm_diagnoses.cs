using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_diagnoses : Form
    {
        public frm_diagnoses()
        {
            InitializeComponent();
        }

        private void LoadDTGV()
        {
            string query = @"SELECT id, name FROM diagnoses";
            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã Chẩn đoán";
            dtgv.Columns["name"].HeaderText = "Tên Chẩn đoán";
        }

        private void frm_diagnoses_Load(object sender, EventArgs e)
        {
            LoadDTGV();
            txb_id.ReadOnly = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;

            txb_search.TextChanged += txb_search_TextChanged;
        }

        private Dictionary<string, object> GetFormData()
        {
            return new Dictionary<string, object>
            {
                { "@name", txb_name.Text.Trim() }
            };
        }

        private void ClearForm()
        {
            txb_id.Clear();
            txb_name.Clear();
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

                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_name.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chẩn đoán.");
                return;
            }

            string query = "INSERT INTO diagnoses (name) VALUES (@name)";
            Db.Add(query, GetFormData());
            LoadDTGV();
            ClearForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn chẩn đoán để cập nhật.");
                return;
            }

            string query = "UPDATE diagnoses SET name = @name WHERE id = @id";
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
                MessageBox.Show("Vui lòng chọn chẩn đoán để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM diagnoses WHERE id = @id";
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
                SELECT id, name 
                FROM diagnoses 
                WHERE id LIKE '%{keyword}%' OR name LIKE '%{keyword}%'";
            Db.LoadDTGV(dtgv, query);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            btn_add.Enabled = true;
            txb_id.Text = "";
            txb_name.Text = "";
            txb_search.Text = "";

        }
    }
}