using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QuanLyPhongKham
{
    public partial class frm_popupLUMedication : Form
    {
        public frm_popupLUMedication()
        {
            InitializeComponent();
            btn_choose.Enabled = false; // Disable the button initially
        }
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
            m.id AS 'Mã Phiếu khám',
            m.name AS 'Tên thuốc',
            em.unit AS 'Đơn vị',
            em.dosage as 'Liều dùng',
            em.route as 'Đường dùng',
            em.times as 'Số lần uống / ngày',
            IFNULL(em.note, '') 'AS Ghi chú',
            em.quantity as 'Số lượng',
            em.price as 'Đơn giá',
            ROUND(em.quantity * em.price, 0) AS 'Tổng tiền'
        FROM examination_medications em
        JOIN medications m ON em.medication_id = m.id
        WHERE em.examination_id = {examinationId};
    ";
            dtgv_med.Columns.Clear();

            // Load dữ liệu vào DataGridView chi tiết
            Db.LoadDTGV(dtgv_med, query);

            // Tùy chỉnh hiển thị
            dtgv_med.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_med.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv_med.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Định dạng số nếu cần
            if (dtgv_med.Columns.Contains("price"))
                dtgv_med.Columns["price"].DefaultCellStyle.Format = "N0";
            if (dtgv_med.Columns.Contains("totalpricepermed"))
                dtgv_med.Columns["totalpricepermed"].DefaultCellStyle.Format = "N0";
            btn_choose.Enabled = true; // Enable the button when a row is selected
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = MySql.Data.MySqlClient.MySqlHelper.EscapeString(txb_search.Text.Trim());
            LoadDTGV(keyword);
        }

        private void frm_popupLUMedication_Load(object sender, EventArgs e)
        {
            LoadDTGV();
            dtgv.ColumnHeadersHeight = 50;

            dtgv.Columns["examination_id"].HeaderText = "Mã khám";
            dtgv.Columns["patient_name"].HeaderText = "Tên bệnh nhân";
            dtgv.Columns["ngay_tao"].HeaderText = "Ngày tạo";
            dtgv.Columns["total_price"].HeaderText = "Tổng tiền";

        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int examinationId = Convert.ToInt32(dtgv.Rows[e.RowIndex].Cells["examination_id"].Value);
                LoadChiTietPhieuThuoc(examinationId);
            }
        }
        public List<DataGridViewRow> AllRows
        {
            get
            {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dtgv_med.Rows)
                {
                    if (!row.IsNewRow)  // loại bỏ dòng mới (dòng trắng để nhập)
                        rows.Add(row);
                }
                return rows;
            }
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
 
            this.Close();
        }
    }
}
