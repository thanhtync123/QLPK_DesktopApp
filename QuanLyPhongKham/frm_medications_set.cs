using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace QuanLyPhongKham
{
    public partial class frm_medications_set : Form
    {
        public frm_medications_set()
        {
            InitializeComponent();
        }
        public List<object[]> selectedMedications = new List<object[]>();
        private void frm_medications_set_Load(object sender, EventArgs e)
        {
            LoadDTGV_Preset_medications_set("");
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
            btn_choose.Enabled = false;
            LoadDTGV_Med("");

        }
        private void LoadDTGV_Preset_medications_set(string keyword)
        {
            Db.ResetConnection();
            string query = $@"SELECT * FROM preset_medications_set where name like '%{txb_search.Text}%' order by name asc";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_preset_medications_set.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_preset_medications_set.Rows.Add();
                DataGridViewRow row = dtgv_preset_medications_set.Rows[i];
                row.Cells["id"].Value = Db.dr["id"];
                row.Cells["name"].Value = Db.dr["name"];
                row.Cells["description"].Value = Db.dr["description"];


            }

            Db.dr.Close();
        }
        private void LoadDTGV_Med(string keyword)
        {
            string query = $@"SELECT id, name, unit, note  from medications where name like '%{txb_search_med.Text}%' order by name asc";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_medications.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_medications.Rows.Add();
                DataGridViewRow row = dtgv_medications.Rows[i];
                row.Cells["id_med"].Value = Db.dr["id"];
                row.Cells["name_med"].Value = Db.dr["name"];
                row.Cells["unit_med"].Value = Db.dr["unit"];
                row.Cells["note_med"].Value = Db.dr["note"];
                row.Cells["add_med"].Value = "+";

            }

            Db.dr.Close();
        }
        private void AddPresetMedications(int id_set)
        {


            foreach (DataGridViewRow row in dtgv_preset_medications.Rows)
            {
                string id_med = row.Cells["id_med_pm"].Value?.ToString();
                string morning = row.Cells["morning"].Value?.ToString();
                string noon = row.Cells["noon"].Value?.ToString();
                string afternoon = row.Cells["afternoon"].Value?.ToString();
                string evening = row.Cells["evening"].Value?.ToString();
                string unit = row.Cells["unit"].Value?.ToString() ?? "";
                string note = row.Cells["note"].Value?.ToString();
                int days_of_use = 0;
                int total_quantity_med = 0;

                int.TryParse(row.Cells["days_of_use"].Value?.ToString(), out days_of_use);
                int.TryParse(row.Cells["total_quantity_med"].Value?.ToString(), out total_quantity_med);




                string query = $@"
                    INSERT INTO preset_medications
                    (id_preset_medications_set, id_medications, morning, noon, afternoon, evening, unit, days_of_use, total_quantity_med, note)
                    VALUES
                    ({id_set},
                    {Convert.ToInt16(id_med)},
                    {(string.IsNullOrEmpty(morning) ? "NULL" : morning)},
                    {(string.IsNullOrEmpty(noon) ? "NULL" : noon)},
                    {(string.IsNullOrEmpty(afternoon) ? "NULL" : afternoon)},
                    {(string.IsNullOrEmpty(evening) ? "NULL" : evening)},
                    '{unit}',
                     {(days_of_use == 0 ? "NULL" : days_of_use.ToString())},
                    {(total_quantity_med == 0 ? "NULL" : total_quantity_med.ToString())},
                    {(string.IsNullOrEmpty(note) ? "NULL" : $"'{note}'")});
                    ";
     
                Db.ExecuteNonQuery(query);


            }

        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_name_medications_set.Text))
            {
                MessageBox.Show("Vui lòng nhập tên toa thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgv_preset_medications.RowCount == 0)
            {
                MessageBox.Show("Vui lòng thêm thuốc vào toa thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = $@"
            INSERT INTO preset_medications_set (id, name, description)
            VALUES (NULL, '{txb_name_medications_set.Text}', 
            {(string.IsNullOrWhiteSpace(txb_description.Text) ? "NULL" : $"'{txb_description.Text}'")})";
            Db.ExecuteNonQuery(query);
            LoadDTGV_Preset_medications_set("");

            query = $@"SELECT LAST_INSERT_ID()";
            var cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn);
            int id_set = Convert.ToInt32(cmd.ExecuteScalar());
            AddPresetMedications(id_set);
            MessageBox.Show("Thêm toa thuốc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);







        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string query = $@"DELETE FROM preset_medications_set WHERE id = {txb_id.Text}";
            Db.ExecuteNonQuery(query);
            LoadDTGV_Preset_medications_set("");

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_name_medications_set.Text))
            {
                MessageBox.Show("Vui lòng nhập tên toa thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = $@"
            UPDATE preset_medications_set
            SET 
                name = '{txb_name_medications_set.Text}',
                description = {(string.IsNullOrWhiteSpace(txb_description.Text) ? "NULL" : $"'{txb_description.Text}'")}
            WHERE id = {txb_id.Text}";

            Db.ExecuteNonQuery(query);
            LoadDTGV_Preset_medications_set("");

            query = $@"delete from PRESET_MEDICATIONS where id_preset_medications_set = {txb_id.Text}";
            Db.ExecuteNonQuery(query);
            AddPresetMedications(Convert.ToInt16(txb_id.Text));
            MessageBox.Show("Sửa toa thuốc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtgv_preset_medications_set_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_id.Text = dtgv_preset_medications_set.CurrentRow.Cells["id"].Value.ToString();
            txb_name_medications_set.Text = dtgv_preset_medications_set.CurrentRow.Cells["name"].Value.ToString();
            txb_description.Text = dtgv_preset_medications_set.CurrentRow.Cells["description"].Value.ToString();
            btn_add.Enabled = false;
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
            btn_choose.Enabled = true;

            string query = $@"
            SELECT  
                m.id AS id_med, 
                m.name AS name_med, 
                pm.morning, 
                pm.noon, 
                pm.afternoon, 
                pm.evening, 
                pm.unit, 
                pm.days_of_use, 
                pm.total_quantity_med, 
                pm.note
            FROM preset_medications pm
            INNER JOIN medications m ON pm.id_medications = m.id
            WHERE pm.id_preset_medications_set = {txb_id.Text};
                            ";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_preset_medications.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_preset_medications.Rows.Add();
                DataGridViewRow row = dtgv_preset_medications.Rows[i];

                row.Cells["id_med_pm"].Value = Db.dr["id_med"];
                row.Cells["name_pm"].Value = Db.dr["name_med"];
                row.Cells["morning"].Value = Db.dr["morning"];
                row.Cells["noon"].Value = Db.dr["noon"];
                row.Cells["afternoon"].Value = Db.dr["afternoon"];
                row.Cells["evening"].Value = Db.dr["evening"];
                row.Cells["unit"].Value = Db.dr["unit"];
                row.Cells["days_of_use"].Value = Db.dr["days_of_use"];
                row.Cells["total_quantity_med"].Value = Db.dr["total_quantity_med"];
                row.Cells["note"].Value = Db.dr["note"];
                row.Cells["del_med"].Value = "-";
            }
            Db.dr.Close();



        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txb_id.Text = "";
            txb_name_medications_set.Text = "";
            txb_description.Text = "";
            btn_add.Enabled = true;
            dtgv_preset_medications.Rows.Clear();

        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            LoadDTGV_Preset_medications_set(txb_search.Text);
        }

        private void txb_search_med_TextChanged(object sender, EventArgs e)
        {
            LoadDTGV_Med(txb_search_med.Text);
        }

        private void dtgv_medications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_medications.Columns[e.ColumnIndex].Name != "add_med") return;
            int rowIndex = dtgv_preset_medications.Rows.Add();
            dtgv_preset_medications.Rows[rowIndex].Cells["id_med_pm"].Value = dtgv_medications.CurrentRow.Cells["id_med"].Value;
            dtgv_preset_medications.Rows[rowIndex].Cells["name_pm"].Value = dtgv_medications.CurrentRow.Cells["name_med"].Value;
            dtgv_preset_medications.Rows[rowIndex].Cells["unit"].Value = dtgv_medications.CurrentRow.Cells["unit_med"].Value;
            dtgv_preset_medications.Rows[rowIndex].Cells["note"].Value = dtgv_medications.CurrentRow.Cells["note_med"].Value;
            dtgv_preset_medications.Rows[rowIndex].Cells["del_med"].Value = "-";


        }

        private void dtgv_preset_medications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_preset_medications.Columns[e.ColumnIndex].Name == "del_med") dtgv_preset_medications.Rows.RemoveAt(e.RowIndex);
        }

        private void dtgv_preset_medications_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtgv_preset_medications.Rows)
            {
                if (row.IsNewRow) continue;

                int days_of_use = 0;
                float morning = 0f, noon = 0f, afternoon = 0f, evening = 0f;

                int.TryParse(row.Cells["days_of_use"].Value?.ToString(), out days_of_use);
                float.TryParse(row.Cells["morning"].Value?.ToString(), out morning);
                float.TryParse(row.Cells["noon"].Value?.ToString(), out noon);
                float.TryParse(row.Cells["afternoon"].Value?.ToString(), out afternoon);
                float.TryParse(row.Cells["evening"].Value?.ToString(), out evening);

                float total_med = days_of_use * (morning + noon + afternoon + evening);
                float total_rounded = (float)Math.Ceiling(total_med);

                row.Cells["total_quantity_med"].Value = total_med > 0
                    ? total_rounded.ToString("0")
                    : "";
            }




        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            int stt = 1;
            foreach (DataGridViewRow row in dtgv_preset_medications.Rows)
            {
                if (row.IsNewRow) continue;

                object[] rowData = new object[]
                {
                  row.Cells["id_med_pm"].Value,
                    stt++,
                  row.Cells["name_pm"].Value,
                  row.Cells["unit"].Value,
                  row.Cells["morning"].Value,
                  row.Cells["noon"].Value,
                  row.Cells["afternoon"].Value,
                  row.Cells["evening"].Value,
                  row.Cells["days_of_use"].Value,
                  row.Cells["total_quantity_med"].Value,
                  row.Cells["note"].Value
                };

                selectedMedications.Add(rowData);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
