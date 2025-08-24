using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_popupLUService : Form
    {
        public frm_popupLUService()
        {
            InitializeComponent();
        }
        public List<DataGridViewRow> AllRows { get; private set; } = new List<DataGridViewRow>();


        private void frm_popupLUService_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
            LoadDTGV_Patient_Service(); 


        }
        private void LoadDTGV_Patient_Service()
        {
            string sql = $@"SELECT 
                e.id AS 'Mã phiếu khám',
                p.id AS 'Mã BN',
                p.name AS 'Tên BN',
                MIN(DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i:%s')) AS 'Ngày cấp dịch vụ'
            FROM examinations e
            JOIN patients p ON e.patient_id = p.id
            JOIN examination_services es ON e.id = es.examination_id
            JOIN services s ON es.service_id = s.id
            WHERE e.type = 'chỉ định'
            GROUP BY e.id, p.id, p.name
            ORDER BY e.id DESC;

                        ";
            Db.LoadDTGV(dtgv_exam_service, sql);
            dtgv_exam_service.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        int id = 0;
        private void dtgv_exam_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_delete.Enabled = true;
             id = Convert.ToInt16(dtgv_exam_service.Rows[e.RowIndex].Cells[0].Value.ToString());
            string sql = $@"SELECT s.id as 'Mã CĐ',s.name as 'Tên chỉ định',s.price as 'Giá'
                        FROM examinations e, services s, examination_services es
                        WHERE s.id = es.service_id
                        and e.id = es.examination_id
                        and e.id = {id}";
            Db.LoadDTGV(dtgv_detail, sql);


        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            AllRows.Clear();
            DataGridViewRow row1 = new DataGridViewRow();
            row1.CreateCells(dtgv_detail,  "1", "Công khám", "Miễn phí", "", "-");
            AllRows.Add(row1);

            DataGridViewRow row2 = new DataGridViewRow();
            row2.CreateCells(dtgv_detail, "2", "Kiểm tra", "Miễn phí", "", "-");
            AllRows.Add(row2);

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
            string sql = $@"SELECT 
                            e.id AS 'Mã phiếu khám',
                            p.id AS 'Mã BN',
                            p.name AS 'Tên BN',
                            MIN(DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i:%s')) AS 'Ngày cấp dịch vụ'
                        FROM examinations e
                        JOIN patients p ON e.patient_id = p.id
                        JOIN examination_services es ON e.id = es.examination_id
                        JOIN services s ON es.service_id = s.id
                        Where p.name LIKE '%{txb_search.Text}%' OR e.id LIKE '%{txb_search.Text}%'
                        GROUP BY e.id, p.id, p.name;
                    
                        ";
            Db.LoadDTGV(dtgv_exam_service, sql);
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
    }
}
