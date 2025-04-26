using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_dtnote : Form
    {
        public frm_dtnote()
        {
     
            InitializeComponent();
        }



        private void LoadDTGV()
        {
            string query = "SELECT id, content FROM doctor_notes";
            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["id"].HeaderText = "Mã Ghi chú";
            dtgv.Columns["content"].HeaderText = "Nội dung ghi chú";
        }

        private Dictionary<string, object> GetFormData()
        {
            return new Dictionary<string, object>
            {
                { "@content", txb_content.Text.Trim() }
            };
        }

        private void ClearForm()
        {
            txb_id.Clear();
            txb_content.Clear();
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
                txb_content.Text = row.Cells["content"].Value.ToString();

                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_content.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung ghi chú.");
                return;
            }

            string query = "INSERT INTO doctor_notes (content) VALUES (@content)";
            Db.Add(query, GetFormData());
            LoadDTGV();
            ClearForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn ghi chú để cập nhật.");
                return;
            }

            string query = "UPDATE doctor_notes SET content = @content WHERE id = @id";
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
                MessageBox.Show("Vui lòng chọn ghi chú để xóa.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa ghi chú này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM doctor_notes WHERE id = @id";
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
                SELECT id, content 
                FROM doctor_notes 
                WHERE id LIKE '%{keyword}%' OR content LIKE '%{keyword}%'";
            Db.LoadDTGV(dtgv, query);
        }

        private void frm_dtnote_Load(object sender, EventArgs e)
        {
            LoadDTGV();
            txb_id.ReadOnly = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;

            txb_search.TextChanged += txb_search_TextChanged;
        }
    }
}
