using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_LookUpService : Form
    {
        public frm_LookUpService()
        {
            InitializeComponent();
        }


        private void LoadDTGV(string keyword = "")
        {
            string query = $@"
                SELECT 
                    e.id AS examination_id,
                    p.id AS patient_id,
                    p.name AS patient_name,
                    DATE_FORMAT(MIN(s.created_at), '%d/%m/%Y') AS service_date,
                    GROUP_CONCAT(
                        CONCAT(
                            'Tên dịch vụ: ', s.name, '\n',
                            'Đơn giá: ', es.price, '\n',
                            '-----------------------------'
                        )
                        ORDER BY s.name
                        SEPARATOR '\n'
                    ) AS service_info,
                    SUM(CAST(es.price AS UNSIGNED)) AS total_price
                FROM examinations e
                JOIN patients p ON e.patient_id = p.id
                JOIN examination_services es ON e.id = es.examination_id
                JOIN services s ON es.service_id = s.id
                WHERE p.name LIKE '%{keyword}%'
                GROUP BY e.id, p.id
                ORDER BY e.id DESC;
            ";

            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["examination_id"].HeaderText = "Mã phiếu khám";
            dtgv.Columns["patient_id"].HeaderText = "Mã BN";
            dtgv.Columns["patient_name"].HeaderText = "Tên bệnh nhân";
            dtgv.Columns["service_info"].HeaderText = "Thông tin dịch vụ";
            dtgv.Columns["total_price"].HeaderText = "Tổng tiền";
            dtgv.Columns["service_date"].HeaderText = "Ngày cấp dịch vụ";

            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = MySql.Data.MySqlClient.MySqlHelper.EscapeString(txb_search.Text.Trim());
            LoadDTGV(keyword);
        }

        private void frm_LookUpService_Load(object sender, EventArgs e)
        {
            LoadDTGV();
        }

        private void dtgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dtgv.Rows[e.RowIndex];
            }
        }


        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dtgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            try
            {
                var selectedRow = dtgv.SelectedRows[0];
                int examinationId = Convert.ToInt32(selectedRow.Cells["examination_id"].Value);

                // Xóa dữ liệu từ bảng examination_services
                string query = "DELETE FROM examination_services WHERE examination_id = @examination_id";
                var data = new Dictionary<string, object>
        {
            { "@examination_id", examinationId }
        };

                // Giả sử Db.Delete thực hiện xóa với câu lệnh SQL này.
                Db.Delete(query, data);

                // Thông báo xóa thành công và tải lại dữ liệu
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDTGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
        
    

