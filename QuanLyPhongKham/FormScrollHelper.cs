using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public static class FormScrollHelper
    {
        private const int Step = 50; // khoảng cách scroll mỗi lần

        public static bool HandleArrowKey(Form form, Keys keyData)
        {
            // Nếu control đang focus là DataGridView hoặc con của nó -> để DGV xử lý
            if (form.ActiveControl is DataGridView ||
                (form.ActiveControl != null && form.ActiveControl.Parent is DataGridView))
            {
                return false; // không can thiệp
            }

            //if (keyData == Keys.Up)
            //{
            //    form.AutoScrollPosition = new Point(
            //        Math.Abs(form.AutoScrollPosition.X),
            //        Math.Max(0, Math.Abs(form.AutoScrollPosition.Y) - Step)
            //    );
            //    return true;
            //}
            //else if (keyData == Keys.Down)
            //{
            //    form.AutoScrollPosition = new Point(
            //        Math.Abs(form.AutoScrollPosition.X),
            //        Math.Abs(form.AutoScrollPosition.Y) + Step
            //    );
            //    return true;
            //}
            else if (keyData == Keys.Left)
            {
                form.AutoScrollPosition = new Point(
                    Math.Max(0, Math.Abs(form.AutoScrollPosition.X) - Step),
                    Math.Abs(form.AutoScrollPosition.Y)
                );
                return true;
            }
            else if (keyData == Keys.Right)
            {
                form.AutoScrollPosition = new Point(
                    Math.Abs(form.AutoScrollPosition.X) + Step,
                    Math.Abs(form.AutoScrollPosition.Y)
                );
                return true;
            }

            return false;
        }
    }
}
