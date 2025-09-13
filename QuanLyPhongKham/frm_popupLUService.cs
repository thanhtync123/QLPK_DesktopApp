using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            string countQuery = "SELECT COUNT(*) FROM examinations WHERE type = 'toa thuốc'";
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
        public int PatientID{ get; set; }
        private void frm_popupLUService_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
            LoadDTGV_Patient_Service();
            LoadTotalPages();
            lb_page.Text = pageIndex.ToString();


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
            if(!string.IsNullOrEmpty(txb_search.Text))
                query += $" AND (p.name LIKE '%{txb_search.Text}%' OR e.id LIKE '%{txb_search.Text}%') ";
            query += @"
            GROUP BY e.id, p.id, p.name";
            query += $" ORDER BY e.updated_at DESC LIMIT {offset},{pageSize}";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_exam_service.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView
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
            string query = $@"SELECT s.id as 'Mã CĐ',s.name as 'Tên chỉ định',s.price as 'Giá'
                        FROM examinations e, services s, examination_services es
                        WHERE s.id = es.service_id
                        and e.id = es.examination_id
                        and e.id = {id}";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_detail.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView
            while (Db.dr.Read())
            {
                int i = dtgv_detail.Rows.Add();
                DataGridViewRow drr = dtgv_detail.Rows[i];

                drr.Cells["id_service"].Value = Db.dr["Mã CĐ"];
                drr.Cells["name_service"].Value = Db.dr["Tên chỉ định"];
                drr.Cells["price"].Value = Db.dr["Giá"];


            }

            Db.dr.Close();


        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            AllRows.Clear();
            DataGridViewRow row1 = new DataGridViewRow();
            row1.CreateCells(dtgv_detail,  "", "Công khám", "Miễn phí", "", "-");
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
    }
}
