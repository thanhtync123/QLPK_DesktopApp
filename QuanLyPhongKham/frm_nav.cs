using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class frm_nav : Form
    {
        Image closeImage, closeImageAct;

        public frm_nav()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
            Size mysize = new Size(20, 20);

          
            using (MemoryStream ms = new MemoryStream(Properties.Resources.close)) 
            {
                Bitmap bt = new Bitmap(ms);
                closeImageAct = new Bitmap(bt, mysize);
            }

            // Load ảnh đóng màu đen (tab không được chọn)
            using (MemoryStream ms2 = new MemoryStream(Properties.Resources.closeBlack)) 
            {
                Bitmap bt2 = new Bitmap(ms2);
                closeImage = new Bitmap(bt2, mysize);
            }

            tabControl1.Padding = new Point(30);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle rect = tabControl1.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                rect.Top + (rect.Height - closeImage.Height) / 2,
                closeImage.Width, closeImage.Height);

            rect.Size = new Size(rect.Width + 20, 38);

            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);

            if (tabControl1.SelectedTab == tabControl1.TabPages[e.Index])
            {
                e.Graphics.DrawImage(closeImageAct, imageRec);
                f = new Font("Arial", 10, FontStyle.Bold);
            }
            else
            {
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Arial", 9, FontStyle.Regular);
            }

            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, f, br, rect, strF);
        }

  

        private int KiemTraFormTonTai(Form frm)
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                if (tabControl1.TabPages[i].Text == frm.Text.Trim())
                    return i;
            }
            return -1;
        }

        private void mn_test_Click(object sender, EventArgs e)
        {
            //AddTab(new frm_examination());
            //AddTab(new frm_xray());
               
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                Rectangle rect = tabControl1.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                    rect.Top + (rect.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);

                if (imageRec.Contains(e.Location))
                {
                    tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }



        private void xQuangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_xray());
        }

        private void khámNộiKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_examination());
        }

        private void xétNghiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_test());
        }

        private void điệnTimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_ecg());
        }

        private void siêuÂmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_ultrasound());
        }

        private void tiếpNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_patients());
        }

        private void chẩnĐoánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_diagnoses());
        }

        private void lờiDặnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_dtnote());
        }

        private void thuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_med());
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_service());
        }

        private void biểuMẫuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new frm_template()); 
        }

        private void AddTab(Form frm)
        {
            int t = KiemTraFormTonTai(frm);
            if (t >= 0)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[t];
            }
            else
            {
                TabPage newTab = new TabPage(frm.Text.Trim());
                tabControl1.TabPages.Add(newTab);
                frm.TopLevel = false;
                frm.Parent = newTab;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                tabControl1.SelectedTab = newTab;
            }
        }



    }
}
