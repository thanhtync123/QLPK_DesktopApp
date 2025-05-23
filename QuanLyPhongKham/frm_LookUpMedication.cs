using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_LookUpMedication : Form
    {
        public frm_LookUpMedication()
        {
            InitializeComponent();
        }

        // Load danh sách khám với 3 cột
        private void LoadDTGV(string keyword = "")
        {
            string query = $@"
    SELECT
        e.id AS examination_id,
        p.name AS patient_name,
        e.created_at AS ngay_tao,
        SUM(CAST(em.price AS UNSIGNED) * em.quantity) AS total_price
    FROM examinations e
    JOIN patients p ON e.patient_id = p.id
    JOIN examination_medications em ON e.id = em.examination_id
    WHERE p.name LIKE '%{keyword}%'
    GROUP BY e.id, p.name, e.created_at
    ORDER BY e.id DESC;
";

            Db.LoadDTGV(dtgv, query); // Load dữ liệu vào DataGridView

            // Đặt header text sau khi load dữ liệu
            dtgv.Columns["examination_id"].HeaderText = "Mã khám";
            dtgv.Columns["patient_name"].HeaderText = "Tên bệnh nhân";
            dtgv.Columns["ngay_tao"].HeaderText = "Ngày tạo";
            dtgv.Columns["total_price"].HeaderText = "Tổng tiền";
            dtgv.Columns["total_price"].DefaultCellStyle.Format = "N0"; // Định dạng số

            // Thiết lập auto size và wrap sau khi load dữ liệu và đặt header
            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Refresh DataGridView để chắc chắn cập nhật giao diện
            dtgv.Refresh();
        }

        // Load chi tiết phiếu thuốc theo examination_id
        private void LoadChiTietPhieuThuoc(int examinationId)
        {
            string query = $@"
                SELECT
                    m.name AS 'Tên thuốc',
                    em.dosage AS 'Liều dùng',
                    em.route AS 'Đường dùng',
                    em.times AS 'Số lần uống',
                    em.quantity AS 'Số lượng',
                    IFNULL(em.note, 'Không có ghi chú') AS 'Ghi chú',
                    em.price AS 'Đơn giá'
                FROM examination_medications em
                JOIN medications m ON em.medication_id = m.id
                WHERE em.examination_id = {examinationId};
            ";

            Db.LoadDTGV(dtgv_chitietphieuthuoc, query);
            dtgv.Columns["examination_id"].HeaderText = "Mã khám";
            dtgv.Columns["patient_name"].HeaderText = "Tên bệnh nhân";
            dtgv.Columns["ngay_tao"].HeaderText = "Ngày tạo";
            dtgv.Columns["total_price"].HeaderText = "Tổng tiền";

            dtgv_chitietphieuthuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_chitietphieuthuoc.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv_chitietphieuthuoc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = MySql.Data.MySqlClient.MySqlHelper.EscapeString(txb_search.Text.Trim());
            LoadDTGV(keyword);
        }

        private void frm_LookUpMedication_Load(object sender, EventArgs e)
        {
            LoadDTGV();
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int examinationId = Convert.ToInt32(dtgv.Rows[e.RowIndex].Cells["examination_id"].Value);
                LoadChiTietPhieuThuoc(examinationId);
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

            int examinationId = Convert.ToInt32(dtgv.SelectedRows[0].Cells["examination_id"].Value);
            string query = "DELETE FROM examination_medications WHERE examination_id = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@id", examinationId }
            };

            Db.Delete(query, parameters);
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDTGV();
            dtgv_chitietphieuthuoc.DataSource = null; // Xóa chi tiết sau khi xóa
        }


    }
}
