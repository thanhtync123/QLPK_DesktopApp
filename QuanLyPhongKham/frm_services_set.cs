using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
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
    public partial class frm_services_set : Form
    {
        public frm_services_set()
        {
            InitializeComponent();
        }

        private void frm_services_set_Load(object sender, EventArgs e)
        {
            LoadDTGVService("");
            LoadDTGVServicesSet("");
        }
        private void LoadDTGVService(String keyword)
        {
            Db.ResetConnection();
            string query = $@"SELECT * FROM services where name like '%{txb_search.Text}%' order by type asc";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_services.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_services.Rows.Add();
                DataGridViewRow row = dtgv_services.Rows[i];
                row.Cells["id_service"].Value = Db.dr["id"];
                row.Cells["name_service"].Value = Db.dr["name"];
                row.Cells["type_service"].Value = Db.dr["type"];
                row.Cells["price_service"].Value = Db.dr["price"];
                row.Cells["add"].Value = "+";


            }

            Db.dr.Close();
        }
        private void LoadDTGVServicesSet(String keyword)
        {
            Db.ResetConnection();
            string query = $@"SELECT * FROM preset_services_set where name like '%{txb_search.Text}%' order by name asc";
            Db.cmd = new MySqlCommand(query, Db.conn);
            Db.dr = Db.cmd.ExecuteReader();
            dtgv_preset_services_set.Rows.Clear();
            while (Db.dr.Read())
            {
                int i = dtgv_preset_services_set.Rows.Add();
                DataGridViewRow row = dtgv_preset_services_set.Rows[i];
                row.Cells["id"].Value = Db.dr["id"];
                row.Cells["name"].Value = Db.dr["name"];


            }

            Db.dr.Close();
        }

        private void dtgv_services_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_services.Columns[e.ColumnIndex].Name != "add") return;
            int rowIndex = dtgv_preset_services.Rows.Add();
            dtgv_preset_services.Rows[rowIndex].Cells["id_preset"].Value = dtgv_services.CurrentRow.Cells["id_service"].Value;
            dtgv_preset_services.Rows[rowIndex].Cells["name_preset"].Value = dtgv_services.CurrentRow.Cells["name_service"].Value;
            dtgv_preset_services.Rows[rowIndex].Cells["price_preset"].Value = dtgv_services.CurrentRow.Cells["price_service"].Value;
            dtgv_preset_services.Rows[rowIndex].Cells["del_preset"].Value = "-";
        }

        private void dtgv_preset_services_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_preset_services.Columns[e.ColumnIndex].Name == "del_preset") dtgv_preset_services.Rows.RemoveAt(e.RowIndex);
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            LoadDTGVServicesSet(txb_name_services_set.Text);
        }

        private void txb_search_services_TextChanged(object sender, EventArgs e)
        {
            LoadDTGVService(txb_search_services.Text);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txb_name_services_set.Text))
            {
                MessageBox.Show("Vui lòng nhập tên gói dịch vụ");
                return;
            }

            string query = $@"INSERT INTO preset_services_set (id, name) VALUES (NULL, '{txb_name_services_set.Text}')";
            Db.ExecuteNonQuery(query);
            query = $@"SELECT LAST_INSERT_ID()";
            var cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", Db.conn);
            int id_set = Convert.ToInt32(cmd.ExecuteScalar());
            AddPreset(id_set);
            LoadDTGVServicesSet("");

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string query = $@" DELETE FROM preset_services_set where id = {txb_id.Text} ";
            Db.ExecuteNonQuery(query);
            LoadDTGVServicesSet("");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string query = $@"UPDATE preset_services_set SET name='{txb_name_services_set.Text}' WHERE id={txb_id.Text}";
            Db.ExecuteNonQuery(query);
            AddPreset(Convert.ToInt16(txb_id.Text));
            LoadDTGVServicesSet("");
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txb_id.Text = "";
            txb_name_services_set.Text = "";

        }
        private void AddPreset(int id_set)
        {
          
            string  query = $@" DELETE FROM preset_services where preset_services_set_id = {txb_id.Text} ";
            Db.ExecuteNonQuery(query);
            foreach (DataGridViewRow row in dtgv_preset_services.Rows)
            {

                query = $@"
                    INSERT INTO preset_services (id, id_preset_services, id_preset_services_set, note)
                    VALUES (
                        NULL,
                        {row.Cells["id_preset"].Value.ToString()},
                        {id_set},
                        {(string.IsNullOrWhiteSpace(row.Cells["note_preset"].Value?.ToString())
                              ? "NULL"
                              : $"'{row.Cells["note_preset"].Value.ToString()}'")}
                    );
                    ";
                Db.ExecuteNonQuery(query);

            }
        }
        private void dtgv_preset_services_set_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_id.Text = dtgv_preset_services_set.CurrentRow.Cells["id"].Value.ToString();
            txb_name_services_set.Text = dtgv_preset_services_set.CurrentRow.Cells["name"].Value.ToString();
        }
    }
}
