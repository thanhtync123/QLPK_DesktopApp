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
    e.id AS 'Mã phiếu khám',
    p.id AS 'Mã BN',
    p.name AS 'Tên BN',
    DATE_FORMAT(s.created_at, '%d/%m/%Y %H:%i') AS 'Ngày cấp dịch vụ'
FROM examinations e
JOIN patients p ON e.patient_id = p.id
JOIN examination_services es ON e.id = es.examination_id
JOIN services s ON es.service_id = s.id
WHERE p.name LIKE '%{keyword}%' or p.id LIKE '%{keyword}%' or e.id LIKE '%{keyword}%'

             

            ";

            Db.LoadDTGV(dtgv_patient, query);

            dtgv_patient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_patient.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv_patient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            var id_examination = dtgv_patient.SelectedRows[0].Cells["Mã phiếu khám"].Value;
            string sql = $@"
                Select s.name as 'Tên chỉ định',
                es.price as 'Giá'
                from 
                examinations e, services s, 
                examination_services es
                where es.examination_id = e.id
                and es.service_id = s.id
                and e.id = {id_examination}";
            Db.LoadDTGV(dtgv, sql);
            decimal total = 0;
            foreach (DataGridViewRow row in dtgv.Rows)
            
                if (row.Cells["Giá"].Value != null && decimal.TryParse(row.Cells["Giá"].Value.ToString(), out decimal price))
                
                    total += price;
                
            
            label1.Text = $"Tổng tiền: {total:N0} đ"; // định dạng có dấu phân cách hàng nghìn


        }


        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dtgv_patient.SelectedRows.Count == 0)
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
                var selectedRow = dtgv_patient.SelectedRows[0];
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
        
    

