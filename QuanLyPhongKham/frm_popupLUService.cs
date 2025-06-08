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
            string sql = $@"SELECT 
                            e.id AS 'Mã phiếu khám',
                            p.id AS 'Mã BN',
                            p.name AS 'Tên BN',
                            MIN(DATE_FORMAT(e.updated_at, '%d/%m/%Y %H:%i:%s')) AS 'Ngày cấp dịch vụ'
                        FROM examinations e
                        JOIN patients p ON e.patient_id = p.id
                        JOIN examination_services es ON e.id = es.examination_id
                        JOIN services s ON es.service_id = s.id
                        GROUP BY e.id, p.id, p.name;
                        ";
            Db.LoadDTGV(dtgv_exam_service, sql);
            dtgv_exam_service.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void dtgv_exam_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dtgv_exam_service.Rows[e.RowIndex].Cells[0].Value.ToString();
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
    }
}
