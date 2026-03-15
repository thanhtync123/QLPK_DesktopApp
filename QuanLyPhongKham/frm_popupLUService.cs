using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_popupLUService : Form
    {
        private int pageIndex = 1;
        private int pageSize = 23;
        private int offset = 0;
        private int totalPage = 0;
        public frm_popupLUService()
        {
            InitializeComponent();
        }
        private void LoadTotalPages()
        {

            Db.ResetConnection();
            string countQuery = "SELECT COUNT(*) FROM examinations WHERE type = 'chỉ định'";
            if (!chb_viewall.Checked)
                countQuery += $" AND patient_id = {PatientID} ";
            if (!string.IsNullOrEmpty(txb_search.Text))
                countQuery += $" AND (patient_id = {PatientID} OR id LIKE '%{txb_search.Text}%')";
            Db.cmd = new MySqlCommand(countQuery, Db.conn);
            int totalRecords = Convert.ToInt32(Db.cmd.ExecuteScalar());
            totalPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPage == 0) totalPage = 1;
            lb_totalpage.Text = totalPage.ToString();

        }
        public List<DataGridViewRow> AllRows { get; private set; } = new List<DataGridViewRow>();
        public string examId { get; set; }
        public int PatientID { get; set; }
        private void frm_popupLUService_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
            LoadDTGV_Patient_Service();
            LoadTotalPages();
            lb_page.Text = pageIndex.ToString();
            dtgv_result.Visible = false;
            txb_finalResult.Visible = false;
            txb_result.Visible = false;
            pb_1.Visible=false;
            pb_2.Visible = false;
            pb_3.Visible = false;
            pb_4.Visible = false;

        }
        private void LoadDTGV_Patient_Service()
        {

            Db.ResetConnection();
            string checkServiceP = $"SELECT 1 FROM examinations WHERE patient_id = {PatientID} AND type='chỉ định' LIMIT 1;";
            object result = Db.Scalar(checkServiceP);
            bool hasMedP = result != null;
            if (!hasMedP) lb_state.Text = "Bệnh nhân chưa có chỉ định nào";
            else lb_state.Text = "";
            string query = $@"SELECT 
                e.id AS 'Mã phiếu khám',
                p.id AS 'Mã BN',
                p.name AS 'Tên BN',
                MIN(DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i:%s')) AS 'Ngày cấp dịch vụ'
            FROM examinations e
            JOIN patients p ON e.patient_id = p.id
            JOIN examination_services es ON e.id = es.examination_id
            JOIN services s ON es.service_id = s.id
            WHERE e.type = 'chỉ định'
                        ";
            if (!chb_viewall.Checked)
                query += $" AND p.id = {PatientID} ";
            if (!string.IsNullOrEmpty(txb_search.Text))
                query += $" AND (p.name LIKE '%{txb_search.Text}%' OR e.id LIKE '%{txb_search.Text}%') ";
            query += @"
            GROUP BY e.id, p.id, p.name";
            query += $" ORDER BY e.updated_at DESC LIMIT {offset},{pageSize}";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_exam_service.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_exam_service.Rows.Add();
                DataGridViewRow drr = dtgv_exam_service.Rows[i];

                drr.Cells["id_exam"].Value = Db.dr["Mã phiếu khám"];
                drr.Cells["id_patient"].Value = Db.dr["Mã BN"];
                drr.Cells["name_patient"].Value = Db.dr["Tên BN"];
                drr.Cells["time"].Value = Db.dr["Ngày cấp dịch vụ"];

            }

            Db.dr.Close();
        }
        int id = 0;
        private void dtgv_exam_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_delete.Enabled = true;
            id = Convert.ToInt16(dtgv_exam_service.Rows[e.RowIndex].Cells[0].Value.ToString());
            string query = $@"
               SELECT distinct s.id as 'Mã CĐ',s.name as 'Tên chỉ định',es.price as 'Giá',es.percent_reduce as 'Giảm giá',s.type,s.price as 'Giá gốc',
             CASE 
                    WHEN er.examination_service_id IS NULL THEN 'Chưa có KQ'
                    ELSE 'Đã có KQ'
                END AS 'Trạng thái',es.id as 'esid',er.result,final_result
            FROM examinations e
            INNER JOIN examination_services es ON  es.examination_id=e.id
            INNER JOIN services s ON s.id=es.service_id
            LEFT JOIN examination_results er ON er.examination_service_id=es.id
                Where e.id = {id}";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_detail.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_detail.Rows.Add();
                DataGridViewRow drr = dtgv_detail.Rows[i];

                drr.Cells["id_service"].Value = Db.dr["Mã CĐ"];
                drr.Cells["name_service"].Value = Db.dr["Tên chỉ định"];
                drr.Cells["price"].Value = Db.dr["Giá"];
                drr.Cells["state"].Value = Db.dr["Trạng thái"];
                drr.Cells["type"].Value = Db.dr["type"];
                drr.Cells["examination_service_id"].Value = Db.dr["esid"];
                drr.Cells["percent_reduce"].Value = Db.dr["Giảm giá"];
                drr.Cells["original_price"].Value = Db.dr["Giá gốc"];


            }

            Db.dr.Close();
   

        }

        private void btn_choose_Click(object sender, EventArgs e)
        {

            AllRows.Clear();
            DataGridViewRow row1 = new DataGridViewRow();
            row1.CreateCells(dtgv_detail, "", "Công khám", "Miễn phí","0", "Miễn phí", "");

            AllRows.Add(row1);
            string examId = dtgv_exam_service.CurrentRow.Cells[0].Value.ToString();
            if (dtgv_exam_service.CurrentRow != null)
                this.examId = dtgv_exam_service.CurrentRow.Cells[0].Value.ToString();
            foreach (DataGridViewRow row in dtgv_detail.Rows)
            {
                if (!row.IsNewRow)
                    AllRows.Add(row);
            }



            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            LoadTotalPages();
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadDTGV_Patient_Service();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa toa thuốc này không?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    string query = $@"
                DELETE FROM examinations
                WHERE id = {id}";
                    Db.ExecuteNonQuery(query);
                    LoadDTGV_Patient_Service();
                    dtgv_detail.DataSource = null;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void chb_viewall_CheckedChanged(object sender, EventArgs e)
        {
            pageIndex = 1;
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadTotalPages();
            LoadDTGV_Patient_Service();
        }

        private void btn_firstpage_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadDTGV_Patient_Service();
        }

        private void btn_downpage_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                offset = (pageIndex - 1) * pageSize;
                lb_page.Text = pageIndex.ToString();

                LoadDTGV_Patient_Service();
            }
        }

        private void btn_uppage_Click(object sender, EventArgs e)
        {
            if (pageIndex < totalPage)
            {
                pageIndex++;
                offset = (pageIndex - 1) * pageSize;
                lb_page.Text = pageIndex.ToString();
                LoadDTGV_Patient_Service();
            }
        }

        private void btn_maxpage_Click(object sender, EventArgs e)
        {
            pageIndex = totalPage;
            offset = (pageIndex - 1) * pageSize;
            lb_page.Text = pageIndex.ToString();
            LoadDTGV_Patient_Service();

        }
        private void ClearForm()
        {
            txb_finalResult.Text = "";
            txb_result.Text = "";
            dtgv_result.Rows.Clear();
            pb_1.Image = null;
            pb_2.Image = null;
            pb_3.Image = null;
            pb_4.Image = null;
        }
        private void XRayMode()
        {
            dtgv_result.Rows.Clear();
            dtgv_result.Visible = false;
            pb_1.Image = null;
            pb_2.Image = null;
            pb_3.Image = null;
            pb_4.Image = null;
            pb_1.Visible = false;
            pb_2.Visible = false;
            pb_3.Visible = false;
            pb_4.Visible = false;
            txb_finalResult.Visible = true;
            txb_result.Visible = true;
        }
        private void UltrasoundMode()
        {
            dtgv_result.Rows.Clear();
            dtgv_result.Visible = false;
            pb_1.Visible = true;
            pb_2.Visible = true;
            pb_3.Visible = true;
            pb_4.Visible = true;
            txb_finalResult.Visible = true;
            txb_result.Visible = true;
        }
        private void TestMode()
        {
            dtgv_result.Visible = true;
            pb_1.Image = null;
            pb_2.Image = null;
            pb_3.Image = null;
            pb_4.Image = null;
            pb_1.Visible = false;
            pb_2.Visible = false;
            pb_3.Visible = false;
            pb_4.Visible = false;
            txb_finalResult.Visible = false;
            txb_result.Visible = false;
        }
        private void dtgv_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_detail.CurrentRow.Cells["state"].Value?.ToString() == "Chưa có KQ")
                ClearForm();

            int examination_service_id = 0;
            var cellValue = dtgv_detail.CurrentRow.Cells["examination_service_id"].Value;
            if (cellValue != null && cellValue != DBNull.Value)
                examination_service_id = Convert.ToInt32(cellValue);

            Db.ResetConnection();
            string query = $@"
                select result,final_result,file_path,s.type
                from examination_results er
                inner join examination_services es ON  er.examination_service_id=es.id
                inner join services s ON es.service_id=s.id
                where examination_service_id = {examination_service_id}
                            ";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            while (Db.dr.Read())
            {
                if (Db.dr["type"]?.ToString() == "X-quang")
                {
                    XRayMode();
                    txb_result.Text = Db.dr["result"]?.ToString();
                    txb_finalResult.Text = Db.dr["final_result"]?.ToString();


                }
                else if (Db.dr["type"]?.ToString() == "Siêu âm")
                {
                    UltrasoundMode();
                    txb_result.Text = Db.dr["result"]?.ToString();
                    txb_finalResult.Text = Db.dr["final_result"]?.ToString();
                    string[] file_path = Db.dr["file_path"]?.ToString().Split(',');
                    for (int i = 0; i < file_path.Length; i++)
                    {
                        string folder = Path.Combine(Application.StartupPath, file_path[i]);
                        try
                        {

                            pb_1.ImageLocation = file_path[0];
                            pb_2.ImageLocation = file_path[1];
                            pb_3.ImageLocation = file_path[2];
                            pb_4.ImageLocation = file_path[3];
                        }
                        catch (Exception ex)
                        {
                        }


                    }

                }
                else if (Db.dr["type"]?.ToString() == "Xét nghiệm")
                {
                    TestMode();
                    var list = JArray.Parse(Db.dr["result"].ToString());
                    dtgv_result.Rows.Clear();
                    foreach (var item in list)
                    {
                        int row = dtgv_result.Rows.Add();
                        dtgv_result.Rows[row].Cells["t_indication"].Value = item["indication"]?.ToString();
                        dtgv_result.Rows[row].Cells["t_result"].Value = item["result"]?.ToString();
                        dtgv_result.Rows[row].Cells["t_unit"].Value = item["unit"]?.ToString();
                        dtgv_result.Rows[row].Cells["t_normal"].Value = item["normal_range"]?.ToString();
                    }
                }
            }

            Db.dr.Close();

        }

        private void dtgv_result_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dtgv_result.Columns[e.ColumnIndex].Name == "t_result")
            {
                var row = dtgv_result.Rows[e.RowIndex];
                string ketQuaStr = row.Cells["t_result"].Value?.ToString();
                string csbt = row.Cells["t_normal"].Value?.ToString();
                string query = $@"
                        SELECT gender
                        FROM patients
                        WHERE id = {Convert.ToInt16(dtgv_exam_service.CurrentRow.Cells["id_patient"].Value.ToString())}
                    ";
                MySqlCommand cmd = new MySqlCommand(query, Db.conn);
                string gioiTinh = cmd.ExecuteScalar().ToString();
                if (KetQuaNgoaiChiSo(ketQuaStr, csbt, gioiTinh))
                    e.CellStyle.ForeColor = Color.Red;
                else
                    e.CellStyle.ForeColor = Color.Black;
            }
        }

        private bool KetQuaNgoaiChiSo(string ketQuaStr, string csbt, string gioiTinh = "")
        {
            if (string.IsNullOrEmpty(ketQuaStr) || string.IsNullOrEmpty(csbt))
                return false;
            ketQuaStr = ketQuaStr.Trim().Replace("%", "").Replace("ml", "").Replace(",", ".");
            csbt = csbt.Trim().Replace(",", ".");
            if (!double.TryParse(ketQuaStr, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double ketQua))
            {
                return !string.Equals(ketQuaStr, csbt, StringComparison.OrdinalIgnoreCase);
            }
            if (csbt.Contains("Nam:") || csbt.Contains("Nữ:"))
            {
                if (!string.IsNullOrEmpty(gioiTinh))
                {
                    string pattern = gioiTinh.StartsWith("Nam", StringComparison.OrdinalIgnoreCase) ?
                        @"Nam\s*:\s*(\d+(\.\d+)?)\s*-\s*(\d+(\.\d+)?)" :
                        @"Nữ\s*:\s*(\d+(\.\d+)?)\s*-\s*(\d+(\.\d+)?)";

                    var match = System.Text.RegularExpressions.Regex.Match(csbt, pattern);
                    if (match.Success)
                    {
                        double min = double.Parse(match.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                        double max = double.Parse(match.Groups[3].Value, System.Globalization.CultureInfo.InvariantCulture);
                        return ketQua < min || ketQua > max;
                    }
                    else
                    {
                        // Không tìm thấy pattern cho giới tính hiện tại
                        return false;
                    }
                }
                return false;
            }
            if (csbt.Contains("-"))
            {
                var parts = csbt.Split('-');
                if (parts.Length == 2 &&
                    double.TryParse(parts[0], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double min) &&
                    double.TryParse(parts[1], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double max))
                {
                    return ketQua < min || ketQua > max;
                }
            }
            csbt = csbt.Replace("≤", "<=").Replace("≥", ">=");
            if (csbt.StartsWith("<=") &&
                double.TryParse(csbt.Substring(2), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double le))
                return ketQua > le;
            if (csbt.StartsWith(">=") &&
                double.TryParse(csbt.Substring(2), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double ge))
                return ketQua < ge;
            if (csbt.StartsWith("<") &&
                double.TryParse(csbt.Substring(1), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double l))
                return ketQua >= l;
            if (csbt.StartsWith(">") &&
                double.TryParse(csbt.Substring(1), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double g))
                return ketQua <= g;
            if (csbt.StartsWith("=") &&
                double.TryParse(csbt.Substring(1), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double e))
                return ketQua != e;

            return false;
        }

        private void dtgv_exam_service_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dtgv_exam_service.Rows)
            {
                var cell = row.Cells["time"];
                cell.Style.ForeColor = Color.MediumBlue;
            }



        }

        private void dtgv_detail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dtgv_detail.Rows)
            {
                var cell = row.Cells["type"];

                switch (cell.Value?.ToString())
                {
                    case "Siêu âm":
                        cell.Style.ForeColor = Color.MediumBlue;
                        break;
                    case "X-quang":
                        cell.Style.ForeColor = Color.DarkOrange;
                        break;
                    default:
                        cell.Style.ForeColor = Color.DarkGreen;
                        break;
                }

                var cellState = row.Cells["state"];

                switch (cellState.Value?.ToString())
                {
                    case "Chưa có KQ":
                        cellState.Style.ForeColor = Color.RoyalBlue;
                        break;
                    case "Đã có KQ":
                        cellState.Style.ForeColor = Color.ForestGreen;
                        break;
                }
            }



        }
    }
}

