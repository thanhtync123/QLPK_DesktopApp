using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace QuanLyPhongKham
{
    
    public partial class Form1 : Form
    {
        private VideoCaptureDevice videoSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FilterInfoCollection cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo camera in cameras)
                comboBox1.Items.Add(camera.Name);

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;

                videoSource = new VideoCaptureDevice(cameras[0].MonikerString);
                videoSource.NewFrame += (s, ev) =>
                {
                    pictureBox1.Invoke(new Action(() =>
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = (Bitmap)ev.Frame.Clone();
                    }));
                };

                videoSource.Start();
            }
        }
    }
}
