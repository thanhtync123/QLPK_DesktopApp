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
    public partial class z_test_1 : Form
    {
        public z_test_1()
        {
            InitializeComponent();
        }
        string imageUrl = null;
        private void btn_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(imageUrl);
                }
            }
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                using (z_test_print printForm = new z_test_print(imageUrl))
                {
                    printForm.ShowDialog();
                }
            }
        }
    }
}
