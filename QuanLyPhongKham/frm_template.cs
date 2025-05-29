using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace QuanLyPhongKham
{
    public partial class frm_template : Form
    {
        public frm_template()
        {
            InitializeComponent();
        }

        private void frm_template_Load(object sender, EventArgs e)
        {
            cb_type.SelectedIndex = 0;
            dtgv_content.Visible = false;
            txb_id.ReadOnly = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
            LoadDTGV();
        }

        private void LoadDTGV()
        {
            string query = "SELECT id, name, type, template_content, result_content FROM templates ORDER BY type";
            Db.LoadDTGV(dtgv, query);
            dtgv.Columns["id"].HeaderText = "Mã mẫu";
            dtgv.Columns["name"].HeaderText = "Tên mẫu";
            dtgv.Columns["type"].HeaderText = "Loại";
            dtgv.Columns["template_content"].HeaderText = "Nội dung mẫu";

            dtgv.Columns["id"].Width = 80;                  // Mã mẫu – ngắn
            dtgv.Columns["name"].Width = 150;               // Tên mẫu – vừa
            dtgv.Columns["type"].Width = 100;               // Loại – vừa
            dtgv.Columns["template_content"].Width = 180;   // Nội dung mẫu – vừa phải

        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_type.Text == "Xét nghiệm")
            {
                dtgv_content.Visible = true;
                txb_content.Visible = false;
            }
            else
            {
                dtgv_content.Visible = false;
                txb_content.Visible = true;
            }
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv.Rows[e.RowIndex];
                txb_id.Text = row.Cells["id"].Value.ToString();
                txb_name.Text = row.Cells["name"].Value.ToString();
                cb_type.Text = row.Cells["type"].Value.ToString();
                txb_result_content.Text = row.Cells["result_content"].Value?.ToString() ?? "";

                string type = cb_type.Text;
                string content = row.Cells["template_content"].Value.ToString();

                if (type == "Xét nghiệm")
                {
                    LoadJsonToDtgvContent(content);
                }
                else
                {
                    txb_content.Text = content;
                }

                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private string GetContent()
        {
            if (cb_type.Text == "Xét nghiệm")
            {
                var groupedResults = new Dictionary<string, List<TemplateItem>>();

                foreach (DataGridViewRow row in dtgv_content.Rows)
                {
                    if (row.IsNewRow) continue;

                    string name = row.Cells[0].Value?.ToString();
                    string testName = row.Cells[1].Value?.ToString();
                    string resultValue = row.Cells[2].Value?.ToString();
                    string unit = row.Cells[3].Value?.ToString();
                    string normalRange = row.Cells[4].Value?.ToString();

                    if (!groupedResults.ContainsKey(name))
                        groupedResults[name] = new List<TemplateItem>();

                    groupedResults[name].Add(new TemplateItem
                    {
                        test_name = testName,
                        result = resultValue,
                        unit = unit,
                        normal_range = normalRange
                    });
                }

                var templateGroups = new List<TemplateGroup>();
                foreach (var pair in groupedResults)
                {
                    templateGroups.Add(new TemplateGroup
                    {
                        name = pair.Key,
                        results = pair.Value
                    });
                }

                return JsonConvert.SerializeObject(templateGroups, Formatting.Indented);
            }
            else
            {
                return txb_content.Text.Trim();
            }
        }

        private void LoadJsonToDtgvContent(string json)
        {
            dtgv_content.Rows.Clear();

            if (string.IsNullOrWhiteSpace(json) || !json.TrimStart().StartsWith("["))
                return;

            try
            {
                var list = JsonConvert.DeserializeObject<List<TemplateGroup>>(json);
                foreach (var group in list)
                {
                    foreach (var item in group.results)
                    {
                        dtgv_content.Rows.Add(group.name, item.test_name, item.result, item.unit, item.normal_range);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc nội dung xét nghiệm: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txb_id.Clear();
            txb_name.Clear();
            txb_content.Clear();
            txb_result_content.Clear();
            dtgv_content.Rows.Clear();
            cb_type.SelectedIndex = 0;
            btn_add.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_name.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mẫu.");
                return;
            }

            string query = "INSERT INTO templates (name, type, template_content, result_content) VALUES (@name, @type, @content, @result_content)";
            var data = new Dictionary<string, object>
            {
                { "@name", txb_name.Text.Trim() },
                { "@type", cb_type.Text },
                { "@content", GetContent() },
                { "@result_content", txb_result_content.Text.Trim() }
            };

            Db.Add(query, data);
            LoadDTGV();
            ClearForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn mẫu để cập nhật.");
                return;
            }

            string query = "UPDATE templates SET name = @name, type = @type, template_content = @content, result_content = @result_content WHERE id = @id";
            var data = new Dictionary<string, object>
            {
                { "@id", txb_id.Text.Trim() },
                { "@name", txb_name.Text.Trim() },
                { "@type", cb_type.Text },
                { "@content", GetContent() },
                { "@result_content", txb_result_content.Text.Trim() }
            };

            Db.Update(query, data);
            LoadDTGV();
            ClearForm();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_id.Text))
            {
                MessageBox.Show("Vui lòng chọn mẫu để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM templates WHERE id = @id";
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
                SELECT id, name, type, template_content, result_content 
                FROM templates 
                WHERE id LIKE '%{keyword}%' 
                   OR name LIKE '%{keyword}%' 
                   OR type LIKE '%{keyword}%'";
            Db.LoadDTGV(dtgv, query);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    public class TemplateItem
    {
        public string test_name { get; set; }
        public string result { get; set; }
        public string unit { get; set; }
        public string normal_range { get; set; }
    }

    public class TemplateGroup
    {
        public string name { get; set; }
        public List<TemplateItem> results { get; set; }
    }
}
