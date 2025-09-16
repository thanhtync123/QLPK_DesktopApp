using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_users : Form
    {
        string newFileName = "";
        string folder = Path.Combine(Application.StartupPath, "images");
        public frm_users()
        {
            InitializeComponent();
        }
        private void LoadDTGV()
        {
            string sql = $@"SELECT id,
                            name as 'Tên người dùng',
                            username as 'Tài khoản',
                            password as 'Mật khẩu',
                            role as 'Quyền', 
                            sig_img as 'Hình ảnh'FROM users";
            Db.LoadDTGV(dtgv, sql);
        }
        private void frm_users_Load(object sender, EventArgs e)
        {
            LoadDTGV();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (cb_role.Text == "" || txb_username.Text == "" || txb_password.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            string sql = $@"INSERT INTO users (name,username, password, role,sig_img) 
                    VALUES ('{txb_name.Text}', '{txb_username.Text}', '{txb_password.Text}', '{cb_role.Text}','{newFileName}')";
            Db.ExecuteNonQuery(sql);
            LoadDTGV();



        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string sql = $@"DELETE FROM users WHERE username = '{txb_username.Text}'";
            Db.ExecuteNonQuery(sql);
            LoadDTGV();
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_id.Text = dtgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txb_name.Text = dtgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txb_username.Text = dtgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txb_password.Text = dtgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            string file = dtgv.CurrentRow.Cells[5].Value?.ToString();
            pb_sig.Image = File.Exists(Path.Combine(folder, file)) ? new Bitmap(Path.Combine(folder, file)) : null;
            pb_sig.SizeMode = PictureBoxSizeMode.Zoom;
            btn_them.Enabled = false;
            string role_value = dtgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            cb_role.SelectedItem = role_value;
            btn_edit.Enabled = true;
            






        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif" };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string ext = Path.GetExtension(ofd.FileName);
            newFileName = Guid.NewGuid().ToString() + ext;
            string destPath = Path.Combine(folder, newFileName);
            File.Copy(ofd.FileName, destPath);
            pb_sig.Image = Image.FromFile(destPath);
            pb_sig.SizeMode = PictureBoxSizeMode.Zoom;



        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (cb_role.Text == "" || txb_username.Text == "" || txb_password.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            try
            {
                string currentFile = dtgv.CurrentRow.Cells[5].Value?.ToString();
                string fileNameToSave = string.IsNullOrEmpty(newFileName) ? currentFile : newFileName;

                string sql = $@"
        UPDATE users 
        SET 
            name = '{txb_name.Text}', 
            password = '{txb_password.Text}', 
            role = '{cb_role.Text}', 
            sig_img = '{fileNameToSave}',
            username = '{txb_username.Text}'
        WHERE id = {Convert.ToInt16(txb_id.Text)}";

                  Db.ExecuteNonQuery(sql);
                LoadDTGV();

                MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                btn_them.Enabled = true;
                btn_edit.Enabled = false;
                newFileName = ""; 
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }
    }
}
