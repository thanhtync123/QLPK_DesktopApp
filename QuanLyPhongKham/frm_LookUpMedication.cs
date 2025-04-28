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

        private void LoadDTGV(string keyword = "")
        {
            string query = $@"
                SELECT
                    e.id AS examination_id,
                    p.id AS patient_id,
                    p.name AS patient_name,
                    DATE_FORMAT(MIN(em.created_at), '%d/%m/%Y') AS ngay_cap_thuoc,
                    GROUP_CONCAT(
                        CONCAT(
                            'Tên thuốc: ', m.name, '\n',
                            'Liều dùng: ', em.dosage, ' ', em.unit, '\n',
                            'Đường dùng: ', em.route, '\n',
                            'Số lần uống: ', em.times, '\n',
                            'Số lượng: ', em.quantity, '\n',
                            'Đơn giá: ', em.price, '\n',
                            'Ghi chú: ', IFNULL(em.note, 'Không có ghi chú'), '\n',
                            '-----------------------------'
                        )
                        ORDER BY em.id
                        SEPARATOR '\n'
                    ) AS medication_info,
                    SUM(CAST(em.price AS UNSIGNED) * em.quantity) AS total_price
                FROM examinations e
                JOIN patients p ON e.patient_id = p.id
                JOIN examination_medications em ON e.id = em.examination_id
                JOIN medications m ON em.medication_id = m.id
                WHERE p.name LIKE '%{keyword}%'
                GROUP BY e.id, p.id
                ORDER BY e.id DESC;
            ";




            Db.LoadDTGV(dtgv, query);



            Db.LoadDTGV(dtgv, query);

            dtgv.Columns["examination_id"].HeaderText = "Mã khám";
            dtgv.Columns["patient_id"].HeaderText = "Mã BN";
            dtgv.Columns["patient_name"].HeaderText = "Tên bệnh nhân";
            dtgv.Columns["medication_info"].HeaderText = "Thông tin thuốc";
            dtgv.Columns["total_price"].HeaderText = "Tổng tiền";
            dtgv.Columns["ngay_cap_thuoc"].HeaderText = "Ngày cấp thuốc";

            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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
                var selectedRow = dtgv.Rows[e.RowIndex];
            }
        }


        private void btn_delete_Click(object sender, EventArgs e)
        {
            //dsg
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

            var selectedRow = dtgv.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["examination_id"].Value); // Sửa thành examination_id thay vì id
            string query = "DELETE FROM examination_medications WHERE examination_id = @id"; // Sửa truy vấn để xóa theo examination_id
            var data = new Dictionary<string, object>
    {
        { "@id", id }
    };
            Db.Delete(query, data);
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDTGV(); // Tải lại dữ liệu sau khi xóa
        }


    }
}
