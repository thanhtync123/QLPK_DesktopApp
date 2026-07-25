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
    public partial class frm_preview_ultrasound_image : Form
    {
        public frm_preview_ultrasound_image(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = (Image)img.Clone();
        }
    }
}
