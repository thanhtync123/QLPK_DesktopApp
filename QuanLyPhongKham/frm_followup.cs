using MySql.Data.MySqlClient;
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
    public partial class frm_followup : Form
    {
        public frm_followup()
        {
            InitializeComponent();
        }

        private void frm_followup_Load(object sender, EventArgs e)
        {
            Db.ResetConnection();
            string query = $@"


                        ";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            while (Db.dr.Read())
            {
                int i = dtgv.Rows.Add();
                DataGridViewRow drr = dtgv.Rows[i];
                drr.Cells["c_id"].Value = Db.dr["id"];
                drr.Cells["c_name"].Value = Db.dr["name"];
                drr.Cells["c_address"].Value = Db.dr["address"];
                drr.Cells["c_phone"].Value = Db.dr["phone"];
                drr.Cells["c_day_create"].Value = Db.dr["updated_at"];
                drr.Cells["c_followup_date"].Value = Db.dr["follow_up"];
                drr.Cells["c_state"].Value = Db.dr["state"];
       
            }
            Db.dr.Close();

        }


    }
}
