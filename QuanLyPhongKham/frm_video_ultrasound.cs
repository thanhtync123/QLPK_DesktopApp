using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_video_ultrasound : Form
    {
        private frm_ultrasound parentForm;
        private bool daTruyenAnh = false;

        public frm_video_ultrasound(frm_ultrasound parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        public void ShowFrame(Bitmap bmp)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowFrame(bmp)));
                return;
            }

            pb_webcam.Image?.Dispose();
            pb_webcam.Image = bmp;
        }

        private void frm_video_ultrasound_Load(object sender, EventArgs e)
        {
            btn_choosee.Enabled = false;
            btn_deleteallimage.Enabled = false;
            btn_deletethisimage.Enabled = false;
        }

        // Chụp ảnh
        private void btn_snap_Click(object sender, EventArgs e)
        {
            btn_choosee.Enabled = true;
            btn_deleteallimage.Enabled = true;
            btn_deletethisimage.Enabled = true;
            if (pb_webcam.Image == null)
                return;

            if (imageList1.Images.Count >= 4)
            {
                MessageBox.Show("Chỉ được chụp tối đa 4 ảnh.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Bitmap bmp = new Bitmap(pb_webcam.Image);

            imageList1.Images.Add(bmp);

            ListViewItem item = new ListViewItem();
            item.ImageIndex = imageList1.Images.Count - 1;
            item.Text = "Ảnh " + imageList1.Images.Count;

            lv_image.Items.Add(item);
        }

        // Truyền ảnh về form siêu âm
        private void btn_choosee_Click(object sender, EventArgs e)
        {
            if (imageList1.Images.Count == 0)
            {
                MessageBox.Show("Chưa có ảnh để truyền.");
                return;
            }

            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                parentForm.SetImage(i, imageList1.Images[i]);
            }

            daTruyenAnh = true;

            this.Close();
        }

        // Xóa ảnh đang chọn
        private void btn_deletethisimage_Click(object sender, EventArgs e)
        {
            if (lv_image.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ảnh cần xóa.");
                return;
            }

            int index = lv_image.SelectedItems[0].Index;

            imageList1.Images.RemoveAt(index);
            lv_image.Items.RemoveAt(index);

            // Cập nhật lại tên và ImageIndex
            for (int i = 0; i < lv_image.Items.Count; i++)
            {
                lv_image.Items[i].ImageIndex = i;
                lv_image.Items[i].Text = "Ảnh " + (i + 1);
            }
        }

        private void frm_video_ultrasound_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (daTruyenAnh)
                return;

            if (imageList1.Images.Count == 0)
                return;

            DialogResult result = MessageBox.Show(
                "Bạn chưa chọn \"LẤY ẢNH\".\n\nNếu đóng cửa sổ, các ảnh siêu âm đã chụp sẽ không được lưu và sẽ bị mất.\n\nBạn có chắc muốn tiếp tục?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void btn_deleteallimage_Click(object sender, EventArgs e)
        {
            imageList1.Images.Clear();
            lv_image.Items.Clear();
        }
    }
}