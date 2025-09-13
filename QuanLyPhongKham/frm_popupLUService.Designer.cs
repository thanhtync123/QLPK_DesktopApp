namespace QuanLyPhongKham
{
    partial class frm_popupLUService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txb_search = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_choose = new System.Windows.Forms.Button();
            this.dtgv_exam_service = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_exam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgv_detail = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_totalpage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_page = new System.Windows.Forms.Label();
            this.btn_maxpage = new System.Windows.Forms.Button();
            this.btn_uppage = new System.Windows.Forms.Button();
            this.btn_downpage = new System.Windows.Forms.Button();
            this.btn_firstpage = new System.Windows.Forms.Button();
            this.chb_viewall = new System.Windows.Forms.CheckBox();
            this.lb_state = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_exam_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::QuanLyPhongKham.Properties.Resources.check1;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton1.Location = new System.Drawing.Point(413, 17);
            this.guna2ImageButton1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(19, 26);
            this.guna2ImageButton1.TabIndex = 29;
            this.guna2ImageButton1.UseTransparentBackground = true;
            // 
            // txb_search
            // 
            this.txb_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_search.DefaultText = "";
            this.txb_search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txb_search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_search.Location = new System.Drawing.Point(7, 12);
            this.txb_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_search.Name = "txb_search";
            this.txb_search.PlaceholderText = "";
            this.txb_search.SelectedText = "";
            this.txb_search.Size = new System.Drawing.Size(282, 36);
            this.txb_search.TabIndex = 25;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // btn_choose
            // 
            this.btn_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.Location = new System.Drawing.Point(402, 12);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(160, 36);
            this.btn_choose.TabIndex = 27;
            this.btn_choose.Text = "Chọn phiếu";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // dtgv_exam_service
            // 
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.dtgv_exam_service.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dtgv_exam_service.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_exam_service.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dtgv_exam_service.ColumnHeadersHeight = 35;
            this.dtgv_exam_service.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_exam_service.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_exam,
            this.id_patient,
            this.name_patient,
            this.time});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_exam_service.DefaultCellStyle = dataGridViewCellStyle24;
            this.dtgv_exam_service.GridColor = System.Drawing.Color.Black;
            this.dtgv_exam_service.Location = new System.Drawing.Point(7, 83);
            this.dtgv_exam_service.Name = "dtgv_exam_service";
            this.dtgv_exam_service.RowHeadersVisible = false;
            this.dtgv_exam_service.Size = new System.Drawing.Size(615, 462);
            this.dtgv_exam_service.TabIndex = 30;
            this.dtgv_exam_service.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_exam_service.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_exam_service.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_exam_service.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_exam_service.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_exam_service.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_exam_service.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_exam_service.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_exam_service.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_exam_service.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_exam_service.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_exam_service.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_exam_service.ThemeStyle.HeaderStyle.Height = 35;
            this.dtgv_exam_service.ThemeStyle.ReadOnly = false;
            this.dtgv_exam_service.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_exam_service.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_exam_service.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_exam_service.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_exam_service.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_exam_service.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_exam_service.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_exam_service.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_exam_service_CellClick);
            // 
            // id_exam
            // 
            this.id_exam.FillWeight = 101.5228F;
            this.id_exam.HeaderText = "Mã Phiếu";
            this.id_exam.Name = "id_exam";
            this.id_exam.Width = 80;
            // 
            // id_patient
            // 
            this.id_patient.FillWeight = 99.49239F;
            this.id_patient.HeaderText = "Mã KH";
            this.id_patient.Name = "id_patient";
            this.id_patient.Width = 80;
            // 
            // name_patient
            // 
            this.name_patient.FillWeight = 99.49239F;
            this.name_patient.HeaderText = "Tên KH";
            this.name_patient.Name = "name_patient";
            this.name_patient.Width = 250;
            // 
            // time
            // 
            this.time.FillWeight = 99.49239F;
            this.time.HeaderText = "Ngày cấp dịch vụ";
            this.time.Name = "time";
            this.time.Width = 200;
            // 
            // dtgv_detail
            // 
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.dtgv_detail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dtgv_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dtgv_detail.ColumnHeadersHeight = 35;
            this.dtgv_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_service,
            this.name_service,
            this.price});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_detail.DefaultCellStyle = dataGridViewCellStyle28;
            this.dtgv_detail.GridColor = System.Drawing.Color.Black;
            this.dtgv_detail.Location = new System.Drawing.Point(628, 83);
            this.dtgv_detail.Name = "dtgv_detail";
            this.dtgv_detail.RowHeadersVisible = false;
            this.dtgv_detail.Size = new System.Drawing.Size(683, 462);
            this.dtgv_detail.TabIndex = 31;
            this.dtgv_detail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_detail.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_detail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_detail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_detail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_detail.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_detail.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_detail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_detail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_detail.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_detail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_detail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_detail.ThemeStyle.HeaderStyle.Height = 35;
            this.dtgv_detail.ThemeStyle.ReadOnly = false;
            this.dtgv_detail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_detail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_detail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_detail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_detail.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_detail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_detail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // id_service
            // 
            this.id_service.HeaderText = "Mã CĐ";
            this.id_service.Name = "id_service";
            this.id_service.Width = 80;
            // 
            // name_service
            // 
            this.name_service.HeaderText = "Tên chỉ định";
            this.name_service.Name = "name_service";
            this.name_service.Width = 400;
            // 
            // price
            // 
            dataGridViewCellStyle27.Format = "N0";
            this.price.DefaultCellStyle = dataGridViewCellStyle27;
            this.price.HeaderText = "Giá";
            this.price.Name = "price";
            this.price.Width = 200;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(295, 12);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(101, 36);
            this.btn_delete.TabIndex = 32;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(108, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 19);
            this.label3.TabIndex = 73;
            this.label3.Text = "/";
            // 
            // lb_totalpage
            // 
            this.lb_totalpage.AutoSize = true;
            this.lb_totalpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalpage.Location = new System.Drawing.Point(127, 58);
            this.lb_totalpage.Name = "lb_totalpage";
            this.lb_totalpage.Size = new System.Drawing.Size(17, 19);
            this.lb_totalpage.TabIndex = 72;
            this.lb_totalpage.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 71;
            this.label1.Text = "Trang";
            // 
            // lb_page
            // 
            this.lb_page.AutoSize = true;
            this.lb_page.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_page.Location = new System.Drawing.Point(85, 58);
            this.lb_page.Name = "lb_page";
            this.lb_page.Size = new System.Drawing.Size(17, 19);
            this.lb_page.TabIndex = 70;
            this.lb_page.Text = "0";
            // 
            // btn_maxpage
            // 
            this.btn_maxpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_maxpage.Location = new System.Drawing.Point(273, 49);
            this.btn_maxpage.Name = "btn_maxpage";
            this.btn_maxpage.Size = new System.Drawing.Size(48, 32);
            this.btn_maxpage.TabIndex = 69;
            this.btn_maxpage.Text = "Max";
            this.btn_maxpage.UseVisualStyleBackColor = true;
            this.btn_maxpage.Click += new System.EventHandler(this.btn_maxpage_Click);
            // 
            // btn_uppage
            // 
            this.btn_uppage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_uppage.Location = new System.Drawing.Point(232, 49);
            this.btn_uppage.Name = "btn_uppage";
            this.btn_uppage.Size = new System.Drawing.Size(35, 32);
            this.btn_uppage.TabIndex = 68;
            this.btn_uppage.Text = ">";
            this.btn_uppage.UseVisualStyleBackColor = true;
            this.btn_uppage.Click += new System.EventHandler(this.btn_uppage_Click);
            // 
            // btn_downpage
            // 
            this.btn_downpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_downpage.Location = new System.Drawing.Point(191, 49);
            this.btn_downpage.Name = "btn_downpage";
            this.btn_downpage.Size = new System.Drawing.Size(35, 32);
            this.btn_downpage.TabIndex = 67;
            this.btn_downpage.Text = "<";
            this.btn_downpage.UseVisualStyleBackColor = true;
            this.btn_downpage.Click += new System.EventHandler(this.btn_downpage_Click);
            // 
            // btn_firstpage
            // 
            this.btn_firstpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_firstpage.Location = new System.Drawing.Point(150, 49);
            this.btn_firstpage.Name = "btn_firstpage";
            this.btn_firstpage.Size = new System.Drawing.Size(35, 32);
            this.btn_firstpage.TabIndex = 66;
            this.btn_firstpage.Text = "1";
            this.btn_firstpage.UseVisualStyleBackColor = true;
            this.btn_firstpage.Click += new System.EventHandler(this.btn_firstpage_Click);
            // 
            // chb_viewall
            // 
            this.chb_viewall.AutoSize = true;
            this.chb_viewall.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_viewall.Location = new System.Drawing.Point(327, 55);
            this.chb_viewall.Name = "chb_viewall";
            this.chb_viewall.Size = new System.Drawing.Size(130, 23);
            this.chb_viewall.TabIndex = 65;
            this.chb_viewall.Text = "Xem tất cả phiếu";
            this.chb_viewall.UseVisualStyleBackColor = true;
            this.chb_viewall.CheckedChanged += new System.EventHandler(this.chb_viewall_CheckedChanged);
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_state.ForeColor = System.Drawing.Color.Red;
            this.lb_state.Location = new System.Drawing.Point(463, 56);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(49, 19);
            this.lb_state.TabIndex = 64;
            this.lb_state.Text = "label1";
            // 
            // frm_popupLUService
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1361, 557);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_totalpage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_page);
            this.Controls.Add(this.btn_maxpage);
            this.Controls.Add(this.btn_uppage);
            this.Controls.Add(this.btn_downpage);
            this.Controls.Add(this.btn_firstpage);
            this.Controls.Add(this.chb_viewall);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.dtgv_detail);
            this.Controls.Add(this.dtgv_exam_service);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.btn_choose);
            this.Name = "frm_popupLUService";
            this.Text = "frm_popupLUService";
            this.Load += new System.EventHandler(this.frm_popupLUService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_exam_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2TextBox txb_search;
        private System.Windows.Forms.Button btn_choose;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_exam_service;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_detail;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_exam;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_totalpage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_page;
        private System.Windows.Forms.Button btn_maxpage;
        private System.Windows.Forms.Button btn_uppage;
        private System.Windows.Forms.Button btn_downpage;
        private System.Windows.Forms.Button btn_firstpage;
        private System.Windows.Forms.CheckBox chb_viewall;
        private System.Windows.Forms.Label lb_state;
    }
}