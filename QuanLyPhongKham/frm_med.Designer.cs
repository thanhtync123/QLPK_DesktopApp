namespace QuanLyPhongKham
{
    partial class frm_med
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.dtgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txb_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_unit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_dosage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_times = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_route = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_note = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tên thuốc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "ID";
            // 
            // txb_id
            // 
            this.txb_id.Location = new System.Drawing.Point(97, 130);
            this.txb_id.Name = "txb_id";
            this.txb_id.Size = new System.Drawing.Size(87, 20);
            this.txb_id.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Tìm kiếm";
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(232, 371);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 34;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(151, 371);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 33;
            this.btn_update.Text = "Sửa";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(70, 371);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 32;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txb_search
            // 
            this.txb_search.Location = new System.Drawing.Point(492, 47);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(259, 20);
            this.txb_search.TabIndex = 31;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // dtgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv.ColumnHeadersHeight = 15;
            this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.Location = new System.Drawing.Point(434, 73);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.RowHeadersWidth = 51;
            this.dtgv.Size = new System.Drawing.Size(750, 557);
            this.dtgv.TabIndex = 30;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv.ThemeStyle.HeaderStyle.Height = 15;
            this.dtgv.ThemeStyle.ReadOnly = false;
            this.dtgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_CellClick);
            // 
            // txb_name
            // 
            this.txb_name.Location = new System.Drawing.Point(95, 166);
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(290, 20);
            this.txb_name.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Đơn vị";
            // 
            // txb_unit
            // 
            this.txb_unit.Location = new System.Drawing.Point(95, 205);
            this.txb_unit.Name = "txb_unit";
            this.txb_unit.Size = new System.Drawing.Size(109, 20);
            this.txb_unit.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Liều lượng";
            // 
            // txb_dosage
            // 
            this.txb_dosage.Location = new System.Drawing.Point(276, 205);
            this.txb_dosage.Name = "txb_dosage";
            this.txb_dosage.Size = new System.Drawing.Size(109, 20);
            this.txb_dosage.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Số lần/ngày";
            // 
            // txb_times
            // 
            this.txb_times.Location = new System.Drawing.Point(276, 240);
            this.txb_times.Name = "txb_times";
            this.txb_times.Size = new System.Drawing.Size(109, 20);
            this.txb_times.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Đường dùng";
            // 
            // txb_route
            // 
            this.txb_route.Location = new System.Drawing.Point(95, 240);
            this.txb_route.Name = "txb_route";
            this.txb_route.Size = new System.Drawing.Size(109, 20);
            this.txb_route.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Ghi chú";
            // 
            // txb_note
            // 
            this.txb_note.Location = new System.Drawing.Point(95, 316);
            this.txb_note.Name = "txb_note";
            this.txb_note.Size = new System.Drawing.Size(290, 20);
            this.txb_note.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Giá";
            // 
            // txb_price
            // 
            this.txb_price.Location = new System.Drawing.Point(95, 276);
            this.txb_price.Name = "txb_price";
            this.txb_price.Size = new System.Drawing.Size(109, 20);
            this.txb_price.TabIndex = 49;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(313, 371);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh.TabIndex = 51;
            this.btn_refresh.Text = "Làm mới";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // frm_med
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1425, 740);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txb_price);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_note);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_times);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_route);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_dosage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_unit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.dtgv);
            this.Controls.Add(this.txb_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_med";
            this.Text = "Thuốc";
            this.Load += new System.EventHandler(this.frm_med_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txb_search;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv;
        private System.Windows.Forms.TextBox txb_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_unit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_dosage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_times;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_route;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_note;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.Button btn_refresh;
    }
}