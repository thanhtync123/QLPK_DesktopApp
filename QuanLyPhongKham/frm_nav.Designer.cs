namespace QuanLyPhongKham
{
    partial class frm_nav
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.khámNộiKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậnLâmSàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xQuangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(1, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2000, 2000);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.khámNộiKhoaToolStripMenuItem,
            this.cậnLâmSàngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // khámNộiKhoaToolStripMenuItem
            // 
            this.khámNộiKhoaToolStripMenuItem.Name = "khámNộiKhoaToolStripMenuItem";
            this.khámNộiKhoaToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.khámNộiKhoaToolStripMenuItem.Text = "Khám nội khoa";
            this.khámNộiKhoaToolStripMenuItem.Click += new System.EventHandler(this.khámNộiKhoaToolStripMenuItem_Click);
            // 
            // cậnLâmSàngToolStripMenuItem
            // 
            this.cậnLâmSàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xQuangToolStripMenuItem});
            this.cậnLâmSàngToolStripMenuItem.Name = "cậnLâmSàngToolStripMenuItem";
            this.cậnLâmSàngToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.cậnLâmSàngToolStripMenuItem.Text = "Cận lâm sàng";
            // 
            // xQuangToolStripMenuItem
            // 
            this.xQuangToolStripMenuItem.Name = "xQuangToolStripMenuItem";
            this.xQuangToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xQuangToolStripMenuItem.Text = "X - quang";
            this.xQuangToolStripMenuItem.Click += new System.EventHandler(this.xQuangToolStripMenuItem_Click);
            // 
            // frm_nav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 650);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_nav";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem khámNộiKhoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cậnLâmSàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xQuangToolStripMenuItem;
    }
}

