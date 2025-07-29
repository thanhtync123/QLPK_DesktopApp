namespace QuanLyPhongKham
{
    partial class frm_followup
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
            this.dtgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.c_exam_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_day_create = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_followup_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.cb_time = new System.Windows.Forms.ComboBox();
            this.cb_state = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_today = new System.Windows.Forms.Label();
            this.lb_3day = new System.Windows.Forms.Label();
            this.lb_late = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv.ColumnHeadersHeight = 40;
            this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_exam_id,
            this.c_id,
            this.c_name,
            this.c_address,
            this.c_phone,
            this.c_day_create,
            this.c_followup_date,
            this.c_state,
            this.c_action});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv.GridColor = System.Drawing.Color.Black;
            this.dtgv.Location = new System.Drawing.Point(22, 109);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.Size = new System.Drawing.Size(1141, 487);
            this.dtgv.TabIndex = 0;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv.ThemeStyle.HeaderStyle.Height = 40;
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
            // c_exam_id
            // 
            this.c_exam_id.HeaderText = "Mã PK";
            this.c_exam_id.Name = "c_exam_id";
            this.c_exam_id.Visible = false;
            // 
            // c_id
            // 
            this.c_id.HeaderText = "Mã BN";
            this.c_id.Name = "c_id";
            this.c_id.Width = 50;
            // 
            // c_name
            // 
            this.c_name.HeaderText = "Họ tên ";
            this.c_name.Name = "c_name";
            this.c_name.Width = 200;
            // 
            // c_address
            // 
            this.c_address.HeaderText = "Địa chỉ";
            this.c_address.Name = "c_address";
            this.c_address.Width = 240;
            // 
            // c_phone
            // 
            this.c_phone.HeaderText = "SĐT";
            this.c_phone.Name = "c_phone";
            // 
            // c_day_create
            // 
            this.c_day_create.HeaderText = "Ngày khám";
            this.c_day_create.Name = "c_day_create";
            this.c_day_create.Width = 200;
            // 
            // c_followup_date
            // 
            this.c_followup_date.HeaderText = "Ngày tái khám";
            this.c_followup_date.Name = "c_followup_date";
            this.c_followup_date.Width = 147;
            // 
            // c_state
            // 
            this.c_state.HeaderText = "Trạng thái";
            this.c_state.Name = "c_state";
            // 
            // c_action
            // 
            this.c_action.HeaderText = "Thao tác";
            this.c_action.Name = "c_action";
            // 
            // txb_search
            // 
            this.txb_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search.Location = new System.Drawing.Point(83, 13);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(330, 26);
            this.txb_search.TabIndex = 1;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // cb_time
            // 
            this.cb_time.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_time.FormattingEnabled = true;
            this.cb_time.Items.AddRange(new object[] {
            "Tất cả",
            "Hôm nay",
            "3 ngày tới"});
            this.cb_time.Location = new System.Drawing.Point(505, 12);
            this.cb_time.Name = "cb_time";
            this.cb_time.Size = new System.Drawing.Size(234, 27);
            this.cb_time.TabIndex = 2;
            this.cb_time.SelectedIndexChanged += new System.EventHandler(this.cb_time_SelectedIndexChanged);
            // 
            // cb_state
            // 
            this.cb_state.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_state.FormattingEnabled = true;
            this.cb_state.Location = new System.Drawing.Point(505, 45);
            this.cb_state.Name = "cb_state";
            this.cb_state.Size = new System.Drawing.Size(234, 27);
            this.cb_state.TabIndex = 3;
            this.cb_state.SelectedIndexChanged += new System.EventHandler(this.cb_state_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(435, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thời gian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Họ tên";
            // 
            // lb_today
            // 
            this.lb_today.AutoSize = true;
            this.lb_today.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_today.Location = new System.Drawing.Point(784, 20);
            this.lb_today.Name = "lb_today";
            this.lb_today.Size = new System.Drawing.Size(64, 19);
            this.lb_today.TabIndex = 7;
            this.lb_today.Text = "Hôm nay";
            // 
            // lb_3day
            // 
            this.lb_3day.AutoSize = true;
            this.lb_3day.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_3day.Location = new System.Drawing.Point(784, 42);
            this.lb_3day.Name = "lb_3day";
            this.lb_3day.Size = new System.Drawing.Size(107, 19);
            this.lb_3day.TabIndex = 8;
            this.lb_3day.Text = "Trong 3 ngày tới";
            // 
            // lb_late
            // 
            this.lb_late.AutoSize = true;
            this.lb_late.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_late.Location = new System.Drawing.Point(784, 65);
            this.lb_late.Name = "lb_late";
            this.lb_late.Size = new System.Drawing.Size(54, 19);
            this.lb_late.TabIndex = 9;
            this.lb_late.Text = "Trễ hẹn";
            // 
            // frm_followup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1198, 658);
            this.Controls.Add(this.lb_late);
            this.Controls.Add(this.lb_3day);
            this.Controls.Add(this.lb_today);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_state);
            this.Controls.Add(this.cb_time);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.dtgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_followup";
            this.Text = "frm_followup";
            this.Load += new System.EventHandler(this.frm_followup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_exam_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_day_create;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_followup_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_action;
        private System.Windows.Forms.TextBox txb_search;
        private System.Windows.Forms.ComboBox cb_time;
        private System.Windows.Forms.ComboBox cb_state;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_today;
        private System.Windows.Forms.Label lb_3day;
        private System.Windows.Forms.Label lb_late;
    }
}