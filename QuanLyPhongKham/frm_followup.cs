using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_followup : Form
    {
        public frm_followup()
        {
            InitializeComponent();
        }
        private void LoadDTGV()
        {
            dtgv.Rows.Clear(); //
            Db.ResetConnection();

            string query = $@"
                SELECT 
                    e.id,
                    e.patient_id, 
                    p.name, 
                    p.address, 
                    p.phone, 
                    e.follow_up, 
                    e.state,
                    DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i') AS updated_at
                FROM examinations e
                JOIN patients p ON e.patient_id = p.id
                WHERE e.follow_up != 'Không' AND e.type = 'toa thuốc' and p.name LIKE '%{txb_search.Text}%'
                ORDER BY e.updated_at DESC
            ";

            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();

            while (Db.dr.Read())
            {
                int i = dtgv.Rows.Add();
                DataGridViewRow drr = dtgv.Rows[i];
                drr.Cells["c_exam_id"].Value = Db.dr["id"];
                drr.Cells["c_id"].Value = Db.dr["patient_id"];
                drr.Cells["c_name"].Value = Db.dr["name"];
                drr.Cells["c_address"].Value = Db.dr["address"];
                drr.Cells["c_phone"].Value = Db.dr["phone"];
                drr.Cells["c_day_create"].Value = Db.dr["updated_at"];
                drr.Cells["c_followup_date"].Value = Db.dr["follow_up"];
                drr.Cells["c_state"].Value = Db.dr["state"];

                // Xử lý highlight cột follow_up theo ngày
                string followUpStr = Db.dr["follow_up"].ToString();
                if (DateTime.TryParseExact(followUpStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime followUpDate))
                {
                    DateTime today = DateTime.Today;
                    TimeSpan diff = followUpDate.Date - today;

                    var cell = drr.Cells["c_followup_date"];
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.Font = new Font(dtgv.Font, FontStyle.Bold);
                    if (diff.Days == 0)
                    {
                        // Hôm nay: đỏ nhạt
                        cell.Style.BackColor = Color.FromArgb(255, 204, 204);
                    }
                    else if (diff.Days > 0 && diff.Days <= 3)
                    {
                        // Trong 3 ngày tới: vàng nhạt
                        cell.Style.BackColor = Color.FromArgb(255, 255, 192);
                    }
                    else if (diff.Days < 0)
                    {
                        // Trễ hẹn: cam nhạt
                        cell.Style.BackColor = Color.FromArgb(255, 229, 204);
                    }

                }

                // Xử lý trạng thái
                string state = Db.dr["state"].ToString().Trim().ToLower();
                if (state == "đã gọi")
                {
                    drr.Cells["c_action"].Value = "✔ Đã gọi";
                    drr.Cells["c_action"].Style.ForeColor = Color.Green;
                }
                else
                {
                    drr.Cells["c_action"].Value = "📞 Gọi";
                    drr.Cells["c_action"].Style.ForeColor = Color.Blue;
                }
            }

            Db.dr.Close();
            Db.dr.Close();
        }
        private void frm_followup_Load(object sender, EventArgs e)
        {
            LoadDTGV();
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dtgv.Columns[e.ColumnIndex].Name != "c_action") return;

            string id = dtgv.Rows[e.RowIndex].Cells["c_id"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            string query = $"UPDATE examinations SET state = 'Đã gọi' WHERE patient_id = '{id}' AND type = 'toa thuốc' AND follow_up != 'Không'";
            Db.ExecuteNonQuery(query);
            dtgv.Rows[e.RowIndex].Cells["c_state"].Value = "Đã gọi";
            dtgv.Rows[e.RowIndex].Cells["c_action"].Value = "✅";

        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            LoadDTGV();

        }
    }
}
