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
            dtgv.Rows.Clear();
            Db.ResetConnection();

            string whereConditions = "e.follow_up != 'Không' AND e.type = 'toa thuốc'";
            string searchName = txb_search.Text.Trim();
            if (!string.IsNullOrEmpty(searchName))
            {
                whereConditions += $" AND p.name LIKE '%{searchName}%'";
            }

            string selectedTime = cb_time.SelectedItem?.ToString();
            if (selectedTime == "Hôm nay")
            {
                string today = DateTime.Today.ToString("dd/MM/yyyy");
                whereConditions += $" AND e.follow_up = '{today}'";
            }
            else if (selectedTime == "Ngày mai")
            {
                DateTime tomorrow = DateTime.Today.AddDays(1);

                whereConditions += $@"
        AND STR_TO_DATE(e.follow_up, '%d/%m/%Y') = 
            STR_TO_DATE('{tomorrow:dd/MM/yyyy}', '%d/%m/%Y')";
            }
            else if (selectedTime == "Trong 3 ngày tới")
            {
                DateTime today = DateTime.Today;
                DateTime to = today.AddDays(3);
                whereConditions += $" AND STR_TO_DATE(e.follow_up, '%d/%m/%Y') BETWEEN STR_TO_DATE('{today:dd/MM/yyyy}', '%d/%m/%Y') AND STR_TO_DATE('{to:dd/MM/yyyy}', '%d/%m/%Y')";
            }
            else if (selectedTime == "Đã trễ")
            {
                DateTime today = DateTime.Today;
                whereConditions += $" AND STR_TO_DATE(e.follow_up, '%d/%m/%Y') < STR_TO_DATE('{today:dd/MM/yyyy}', '%d/%m/%Y')";
            }

            string selectedState = cb_state.SelectedItem?.ToString();
            if (selectedState == "Đã gọi")
            {
                whereConditions += " AND e.state = 'Đã gọi'";
            }
            else if (selectedState == "Chưa gọi")
            {
                whereConditions += " AND (e.state IS NULL OR e.state != 'Đã gọi')";
            }

            string query = $@"
        SELECT 
            e.id, e.patient_id, p.name, p.address, p.phone,
            e.follow_up, e.state,d.name AS diagnosis_name,
            DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i') AS updated_at
        FROM examinations e
        JOIN patients p ON e.patient_id = p.id
        JOIN diagnoses d ON e.diagnosis_id = d.id
        WHERE {whereConditions}
        ORDER BY e.created_at DESC
    ";

            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();

            while (Db.dr.Read())
            {
                int i = dtgv.Rows.Add();
                var drr = dtgv.Rows[i];
                drr.Cells["c_exam_id"].Value = Db.dr["id"];
                drr.Cells["c_id"].Value = Db.dr["patient_id"];
                drr.Cells["c_name"].Value = Db.dr["name"];
                drr.Cells["c_address"].Value = Db.dr["address"];
                drr.Cells["c_phone"].Value = Db.dr["phone"];
                drr.Cells["c_diagnoses"].Value = Db.dr["diagnosis_name"];
                drr.Cells["c_day_create"].Value = Db.dr["updated_at"];
                drr.Cells["c_followup_date"].Value = Db.dr["follow_up"];
                drr.Cells["c_state"].Value = Db.dr["state"];

                // Highlight theo ngày
                string followUpStr = Db.dr["follow_up"].ToString();
                if (DateTime.TryParseExact(followUpStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime followUpDate))
                {
                    var cell = drr.Cells["c_followup_date"];
                    DateTime today = DateTime.Today;
                    TimeSpan diff = followUpDate.Date - today;

                    cell.Style.ForeColor = Color.Black;
                    cell.Style.Font = new Font(dtgv.Font, FontStyle.Bold);

                    if (diff.Days < 0)
                    {
                        cell.Style.BackColor = Color.FromArgb(153, 0, 76); // đỏ tím
                        cell.Style.ForeColor = Color.White;
                    }
          
                    else if (diff.Days == 0)
                    {
                        cell.Style.BackColor = Color.FromArgb(255, 77, 77); // đỏ
                        cell.Style.ForeColor = Color.White;
                    }
               
                    else if (diff.Days == 1)
                    
                        cell.Style.BackColor = Color.FromArgb(144, 238, 144); // xanh lá nhạt
                    
       
                    else if (diff.Days > 1 && diff.Days <= 3)
                    
                        cell.Style.BackColor = Color.FromArgb(255, 215, 0); // vàng
                    

                }


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
        }

        private void frm_followup_Load(object sender, EventArgs e)
        {

            cb_time.Items.AddRange(new string[] { "Tất cả", "Hôm nay","Ngày mai", "Trong 3 ngày tới", "Đã trễ" });
            cb_state.Items.AddRange(new string[] { "Tất cả", "Đã gọi", "Chưa gọi" });
            cb_time.SelectedIndex = 1;
            cb_state.SelectedIndex = 0;
            lb_today.BackColor = Color.FromArgb(255, 77, 77);       
            lb_3day.BackColor = Color.FromArgb(255, 215, 0);       
            lb_late.BackColor = Color.FromArgb(153, 0, 76);       
            lb_tomorrow.BackColor = Color.FromArgb(255, 0, 255, 0);

            lb_today.ForeColor = Color.White;
            lb_3day.ForeColor = Color.Black;
            lb_late.ForeColor = Color.White;

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

        private void cb_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDTGV();
        }

        private void cb_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDTGV();
        }
    }
}
