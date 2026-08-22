namespace QuanLyPhongKham
{
    partial class frm_popupLUMedication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.txb_search = new Guna.UI2.WinForms.Guna2TextBox();
            this.mySqlDataAdapter2 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.btn_choose = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton2 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.dtgv_patient_medication = new Guna.UI2.WinForms.Guna2DataGridView();
            this.c1_examination_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_update_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgv_detail = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lb_state = new System.Windows.Forms.Label();
            this.chb_viewall = new System.Windows.Forms.CheckBox();
            this.btn_maxpage = new System.Windows.Forms.Button();
            this.btn_firstpage = new System.Windows.Forms.Button();
            this.btn_downpage = new System.Windows.Forms.Button();
            this.btn_uppage = new System.Windows.Forms.Button();
            this.lb_page = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_totalpage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_dayofuse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_totalprice = new System.Windows.Forms.TextBox();
            this.c2_examination_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_medication_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_medname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_morning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_noon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_afternoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_evening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_days_of_use = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_total_quantity_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_patient_medication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
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
            this.txb_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_search.Location = new System.Drawing.Point(12, 14);
            this.txb_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_search.Name = "txb_search";
            this.txb_search.PlaceholderText = "";
            this.txb_search.SelectedText = "";
            this.txb_search.Size = new System.Drawing.Size(282, 36);
            this.txb_search.TabIndex = 8;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // mySqlDataAdapter2
            // 
            this.mySqlDataAdapter2.DeleteCommand = null;
            this.mySqlDataAdapter2.InsertCommand = null;
            this.mySqlDataAdapter2.SelectCommand = null;
            this.mySqlDataAdapter2.UpdateCommand = null;
            // 
            // btn_choose
            // 
            this.btn_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.Location = new System.Drawing.Point(381, 14);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(160, 36);
            this.btn_choose.TabIndex = 11;
            this.btn_choose.Text = "   Chọn toa thuốc";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(300, 14);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 37);
            this.btn_delete.TabIndex = 9;
            this.btn_delete.Text = "   Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
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
            this.guna2ImageButton1.Location = new System.Drawing.Point(392, 19);
            this.guna2ImageButton1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(19, 26);
            this.guna2ImageButton1.TabIndex = 24;
            this.guna2ImageButton1.UseTransparentBackground = true;
            // 
            // guna2ImageButton2
            // 
            this.guna2ImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton2.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.Image = global::QuanLyPhongKham.Properties.Resources.trash;
            this.guna2ImageButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton2.ImageRotate = 0F;
            this.guna2ImageButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton2.Location = new System.Drawing.Point(308, 19);
            this.guna2ImageButton2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2ImageButton2.Name = "guna2ImageButton2";
            this.guna2ImageButton2.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.Size = new System.Drawing.Size(19, 26);
            this.guna2ImageButton2.TabIndex = 24;
            this.guna2ImageButton2.UseTransparentBackground = true;
            // 
            // dtgv_patient_medication
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgv_patient_medication.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgv_patient_medication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dtgv_patient_medication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_patient_medication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgv_patient_medication.ColumnHeadersHeight = 40;
            this.dtgv_patient_medication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_patient_medication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1_examination_id,
            this.c1_id,
            this.c1_name,
            this.c1_update_day});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_patient_medication.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgv_patient_medication.GridColor = System.Drawing.Color.Black;
            this.dtgv_patient_medication.Location = new System.Drawing.Point(12, 93);
            this.dtgv_patient_medication.Name = "dtgv_patient_medication";
            this.dtgv_patient_medication.RowHeadersVisible = false;
            this.dtgv_patient_medication.Size = new System.Drawing.Size(428, 601);
            this.dtgv_patient_medication.TabIndex = 25;
            this.dtgv_patient_medication.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_patient_medication.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_patient_medication.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_patient_medication.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_patient_medication.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_patient_medication.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_patient_medication.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_patient_medication.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_patient_medication.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_patient_medication.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_patient_medication.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_patient_medication.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_patient_medication.ThemeStyle.HeaderStyle.Height = 40;
            this.dtgv_patient_medication.ThemeStyle.ReadOnly = false;
            this.dtgv_patient_medication.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_patient_medication.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_patient_medication.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_patient_medication.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_patient_medication.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_patient_medication.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_patient_medication.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_patient_medication.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_patient_medication_CellClick);
            // 
            // c1_examination_id
            // 
            this.c1_examination_id.HeaderText = "Mã P Khám";
            this.c1_examination_id.Name = "c1_examination_id";
            this.c1_examination_id.Width = 50;
            // 
            // c1_id
            // 
            this.c1_id.HeaderText = "Mã BN";
            this.c1_id.Name = "c1_id";
            this.c1_id.Width = 50;
            // 
            // c1_name
            // 
            this.c1_name.HeaderText = "Tên BN";
            this.c1_name.Name = "c1_name";
            this.c1_name.Width = 180;
            // 
            // c1_update_day
            // 
            this.c1_update_day.HeaderText = "Ngày cấp toa";
            this.c1_update_day.Name = "c1_update_day";
            this.c1_update_day.Width = 140;
            // 
            // dtgv_detail
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_detail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgv_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dtgv_detail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgv_detail.ColumnHeadersHeight = 40;
            this.dtgv_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c2_examination_id,
            this.stt,
            this.c2_medication_id,
            this.c2_medname,
            this.c2_unit,
            this.c2_morning,
            this.c2_noon,
            this.c2_afternoon,
            this.c2_evening,
            this.c2_days_of_use,
            this.c2_total_quantity_med,
            this.unit_price,
            this.total_price,
            this.c2_note});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_detail.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgv_detail.GridColor = System.Drawing.Color.Black;
            this.dtgv_detail.Location = new System.Drawing.Point(446, 92);
            this.dtgv_detail.Name = "dtgv_detail";
            this.dtgv_detail.RowHeadersVisible = false;
            this.dtgv_detail.Size = new System.Drawing.Size(826, 393);
            this.dtgv_detail.TabIndex = 26;
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
            this.dtgv_detail.ThemeStyle.HeaderStyle.Height = 40;
            this.dtgv_detail.ThemeStyle.ReadOnly = false;
            this.dtgv_detail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_detail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_detail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_detail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_detail.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_detail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_detail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_state.ForeColor = System.Drawing.Color.Red;
            this.lb_state.Location = new System.Drawing.Point(603, 55);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(49, 19);
            this.lb_state.TabIndex = 27;
            this.lb_state.Text = "label1";
            // 
            // chb_viewall
            // 
            this.chb_viewall.AutoSize = true;
            this.chb_viewall.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_viewall.Location = new System.Drawing.Point(452, 54);
            this.chb_viewall.Name = "chb_viewall";
            this.chb_viewall.Size = new System.Drawing.Size(154, 23);
            this.chb_viewall.TabIndex = 28;
            this.chb_viewall.Text = "Xem tất cả toa thuốc";
            this.chb_viewall.UseVisualStyleBackColor = true;
            this.chb_viewall.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btn_maxpage
            // 
            this.btn_maxpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_maxpage.Location = new System.Drawing.Point(339, 54);
            this.btn_maxpage.Name = "btn_maxpage";
            this.btn_maxpage.Size = new System.Drawing.Size(48, 32);
            this.btn_maxpage.TabIndex = 59;
            this.btn_maxpage.Text = "Max";
            this.btn_maxpage.UseVisualStyleBackColor = true;
            this.btn_maxpage.Click += new System.EventHandler(this.btn_maxpage_Click);
            // 
            // btn_firstpage
            // 
            this.btn_firstpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_firstpage.Location = new System.Drawing.Point(219, 54);
            this.btn_firstpage.Name = "btn_firstpage";
            this.btn_firstpage.Size = new System.Drawing.Size(35, 32);
            this.btn_firstpage.TabIndex = 56;
            this.btn_firstpage.Text = "1";
            this.btn_firstpage.UseVisualStyleBackColor = true;
            this.btn_firstpage.Click += new System.EventHandler(this.btn_firstpage_Click);
            // 
            // btn_downpage
            // 
            this.btn_downpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_downpage.Location = new System.Drawing.Point(260, 54);
            this.btn_downpage.Name = "btn_downpage";
            this.btn_downpage.Size = new System.Drawing.Size(35, 32);
            this.btn_downpage.TabIndex = 57;
            this.btn_downpage.Text = "<";
            this.btn_downpage.UseVisualStyleBackColor = true;
            this.btn_downpage.Click += new System.EventHandler(this.btn_downpage_Click);
            // 
            // btn_uppage
            // 
            this.btn_uppage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_uppage.Location = new System.Drawing.Point(298, 54);
            this.btn_uppage.Name = "btn_uppage";
            this.btn_uppage.Size = new System.Drawing.Size(35, 32);
            this.btn_uppage.TabIndex = 58;
            this.btn_uppage.Text = ">";
            this.btn_uppage.UseVisualStyleBackColor = true;
            this.btn_uppage.Click += new System.EventHandler(this.btn_uppage_Click);
            // 
            // lb_page
            // 
            this.lb_page.AutoSize = true;
            this.lb_page.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_page.Location = new System.Drawing.Point(118, 69);
            this.lb_page.Name = "lb_page";
            this.lb_page.Size = new System.Drawing.Size(17, 19);
            this.lb_page.TabIndex = 60;
            this.lb_page.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 61;
            this.label1.Text = "Trang";
            // 
            // lb_totalpage
            // 
            this.lb_totalpage.AutoSize = true;
            this.lb_totalpage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalpage.Location = new System.Drawing.Point(160, 69);
            this.lb_totalpage.Name = "lb_totalpage";
            this.lb_totalpage.Size = new System.Drawing.Size(17, 19);
            this.lb_totalpage.TabIndex = 62;
            this.lb_totalpage.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 19);
            this.label3.TabIndex = 63;
            this.label3.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 64;
            this.label2.Text = "Số ngày thuốc:";
            // 
            // txb_dayofuse
            // 
            this.txb_dayofuse.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_dayofuse.Location = new System.Drawing.Point(594, 496);
            this.txb_dayofuse.Name = "txb_dayofuse";
            this.txb_dayofuse.Size = new System.Drawing.Size(195, 29);
            this.txb_dayofuse.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(508, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 68;
            this.label5.Text = "Tổng tiền:";
            // 
            // txb_totalprice
            // 
            this.txb_totalprice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_totalprice.Location = new System.Drawing.Point(594, 533);
            this.txb_totalprice.Name = "txb_totalprice";
            this.txb_totalprice.Size = new System.Drawing.Size(195, 29);
            this.txb_totalprice.TabIndex = 69;
            // 
            // c2_examination_id
            // 
            this.c2_examination_id.HeaderText = "Mã phiếu khám";
            this.c2_examination_id.Name = "c2_examination_id";
            this.c2_examination_id.Visible = false;
            this.c2_examination_id.Width = 86;
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.Name = "stt";
            this.stt.Width = 40;
            // 
            // c2_medication_id
            // 
            this.c2_medication_id.HeaderText = "Mã thuốc";
            this.c2_medication_id.Name = "c2_medication_id";
            this.c2_medication_id.Visible = false;
            this.c2_medication_id.Width = 97;
            // 
            // c2_medname
            // 
            this.c2_medname.HeaderText = "Tên thuốc";
            this.c2_medname.Name = "c2_medname";
            this.c2_medname.Width = 200;
            // 
            // c2_unit
            // 
            this.c2_unit.HeaderText = "ĐV";
            this.c2_unit.Name = "c2_unit";
            this.c2_unit.Width = 70;
            // 
            // c2_morning
            // 
            this.c2_morning.HeaderText = "Sáng";
            this.c2_morning.Name = "c2_morning";
            this.c2_morning.Width = 50;
            // 
            // c2_noon
            // 
            this.c2_noon.HeaderText = "Trưa";
            this.c2_noon.Name = "c2_noon";
            this.c2_noon.Width = 50;
            // 
            // c2_afternoon
            // 
            this.c2_afternoon.HeaderText = "Chiều";
            this.c2_afternoon.Name = "c2_afternoon";
            this.c2_afternoon.Width = 50;
            // 
            // c2_evening
            // 
            this.c2_evening.HeaderText = "Tối";
            this.c2_evening.Name = "c2_evening";
            this.c2_evening.Width = 50;
            // 
            // c2_days_of_use
            // 
            this.c2_days_of_use.HeaderText = "Số ngày";
            this.c2_days_of_use.Name = "c2_days_of_use";
            this.c2_days_of_use.Width = 50;
            // 
            // c2_total_quantity_med
            // 
            this.c2_total_quantity_med.HeaderText = "Số lượng";
            this.c2_total_quantity_med.Name = "c2_total_quantity_med";
            this.c2_total_quantity_med.Width = 50;
            // 
            // unit_price
            // 
            this.unit_price.HeaderText = "Đơn giá";
            this.unit_price.Name = "unit_price";
            // 
            // total_price
            // 
            this.total_price.HeaderText = "Tổng tiền";
            this.total_price.Name = "total_price";
            // 
            // c2_note
            // 
            this.c2_note.HeaderText = "Ghi chú";
            this.c2_note.Name = "c2_note";
            this.c2_note.Width = 250;
            // 
            // frm_popupLUMedication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1348, 736);
            this.Controls.Add(this.txb_totalprice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_dayofuse);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.dtgv_detail);
            this.Controls.Add(this.dtgv_patient_medication);
            this.Controls.Add(this.guna2ImageButton2);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.btn_delete);
            this.Name = "frm_popupLUMedication";
            this.Text = "Các toa thuốc cũ";
            this.Load += new System.EventHandler(this.frm_popupLUMedication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_patient_medication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private Guna.UI2.WinForms.Guna2TextBox txb_search;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter2;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.Button btn_delete;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton2;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_patient_medication;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_examination_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_update_day;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.CheckBox chb_viewall;
        private System.Windows.Forms.Button btn_maxpage;
        private System.Windows.Forms.Button btn_firstpage;
        private System.Windows.Forms.Button btn_downpage;
        private System.Windows.Forms.Button btn_uppage;
        private System.Windows.Forms.Label lb_page;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_totalpage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_dayofuse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_totalprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_examination_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_medication_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_medname;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_morning;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_noon;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_afternoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_evening;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_days_of_use;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_total_quantity_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_note;
    }
}