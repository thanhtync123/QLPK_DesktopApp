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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
            string sql = $@"
                    SELECT id,
                            name as 'Tên người dùng',
                            username as 'Tài khoản',
                            password as 'Mật khẩu',
                            role as 'Quyền', 
                            sig_img as 'Hình ảnh',
                            bank_account as 'Số tài khoản',
                            bank_code as 'Mã Ngân hàng',
                            bank_name as 'Tên ngân hàng'
                           FROM users

";
                            
            
            Db.LoadDTGV(dtgv, sql);
        }
        private void frm_users_Load(object sender, EventArgs e)
        {
            LoadDTGV();
            cb_bankcode.DataSource = GetPopularBanks();
            cb_bankcode.DisplayMember = "Name";
            cb_bankcode.ValueMember = "Code";

            cb_bankcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_bankcode.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public static DataTable GetPopularBanks()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");

            dt.Rows.Add("", "--Chọn ngân hàng--");

            dt.Rows.Add("970416", "ACB");
            dt.Rows.Add("970425", "ABBank");
            dt.Rows.Add("970405", "Agribank");
            dt.Rows.Add("970409", "Bac A Bank");
            dt.Rows.Add("970428", "BaoViet Bank");
            dt.Rows.Add("970418", "BIDV");
            dt.Rows.Add("970444", "CBBank");
            dt.Rows.Add("970446", "Co-opBank");
            dt.Rows.Add("970431", "Eximbank");
            dt.Rows.Add("970437", "HDBank");
            dt.Rows.Add("970442", "Hong Leong Bank");
            dt.Rows.Add("970438", "KienlongBank");
            dt.Rows.Add("970433", "LienVietPostBank");
            dt.Rows.Add("970449", "LPBank");
            dt.Rows.Add("970422", "MB Bank");
            dt.Rows.Add("970426", "MSB");
            dt.Rows.Add("970424", "Nam A Bank");
            dt.Rows.Add("970419", "NCB");
            dt.Rows.Add("970448", "OCB");
            dt.Rows.Add("970414", "OceanBank");
            dt.Rows.Add("970430", "PGBank");
            dt.Rows.Add("970439", "Public Bank Vietnam");
            dt.Rows.Add("970429", "SCB");
            dt.Rows.Add("970440", "SeABank");
            dt.Rows.Add("970400", "SaigonBank");
            dt.Rows.Add("970443", "SHB");
            dt.Rows.Add("970403", "Sacombank");
            dt.Rows.Add("970407", "Techcombank");
            dt.Rows.Add("970423", "TPBank");
            dt.Rows.Add("970427", "VietABank");
            dt.Rows.Add("970434", "VietBank");
            dt.Rows.Add("970436", "Vietcombank");
            dt.Rows.Add("970415", "VietinBank");
            dt.Rows.Add("970441", "VIB");
            dt.Rows.Add("970432", "VPBank");

            return dt;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (cb_role.Text == "" || txb_username.Text == "" || txb_password.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            string sql = $@"INSERT INTO users 
            (name, username, password, role, sig_img, bank_account, bank_code, bank_name) 
            VALUES 
            ('{txb_name.Text}', 
             '{txb_username.Text}', 
             '{txb_password.Text}', 
             '{cb_role.Text}',
             '{newFileName}',
             {(string.IsNullOrEmpty(txb_bankaccount.Text) ? "NULL" : $"'{txb_bankaccount.Text}'")},
             {(cb_bankcode.Text == "--Chọn ngân hàng--" ? "NULL" : $"'{cb_bankcode.SelectedValue}'")},
             {(cb_bankcode.Text == "--Chọn ngân hàng--" ? "NULL" : $"'{cb_bankcode.Text}'")}
            )";
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
            txb_bankaccount.Text = dtgv.Rows[e.RowIndex].Cells[6].Value.ToString();
            cb_bankcode.Text = dtgv.Rows[e.RowIndex].Cells[8].Value.ToString();







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
                username = '{txb_username.Text}',
           bank_account =  {(string.IsNullOrEmpty(txb_bankaccount.Text) ? "NULL" : $"'{txb_bankaccount.Text}'")},
           bank_code =  {(cb_bankcode.Text == "--Chọn ngân hàng--" ? "NULL" : $"'{cb_bankcode.SelectedValue}'")},
           bank_name =  {(cb_bankcode.Text == "--Chọn ngân hàng--" ? "NULL" : $"'{cb_bankcode.Text}'")}
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
