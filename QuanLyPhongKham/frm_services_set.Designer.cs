namespace QuanLyPhongKham
{
    partial class frm_services_set
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgv_services = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_choose = new System.Windows.Forms.Button();
            this.txb_search_services = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_name_services_set = new System.Windows.Forms.TextBox();
            this.dtgv_preset_services_set = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_preset_services = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note_preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.lb_total_price = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_services)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_services_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_services)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(455, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 40;
            this.label7.Text = "Tìm kiếm";
            // 
            // dtgv_services
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgv_services.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_services.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_services.ColumnHeadersHeight = 45;
            this.dtgv_services.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_services.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_service,
            this.name_service,
            this.type_service,
            this.price_service,
            this.add});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_services.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgv_services.GridColor = System.Drawing.Color.Black;
            this.dtgv_services.Location = new System.Drawing.Point(404, 104);
            this.dtgv_services.Name = "dtgv_services";
            this.dtgv_services.RowHeadersVisible = false;
            this.dtgv_services.Size = new System.Drawing.Size(744, 250);
            this.dtgv_services.TabIndex = 34;
            this.dtgv_services.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_services.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_services.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_services.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_services.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_services.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_services.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_services.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_services.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_services.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_services.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_services.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_services.ThemeStyle.HeaderStyle.Height = 45;
            this.dtgv_services.ThemeStyle.ReadOnly = false;
            this.dtgv_services.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_services.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_services.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_services.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_services.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_services.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_services.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_services.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_services_CellClick);
            // 
            // id_service
            // 
            this.id_service.HeaderText = "ID";
            this.id_service.Name = "id_service";
            this.id_service.Visible = false;
            // 
            // name_service
            // 
            this.name_service.HeaderText = "Tên chỉ định";
            this.name_service.Name = "name_service";
            this.name_service.Width = 250;
            // 
            // type_service
            // 
            this.type_service.HeaderText = "Loại";
            this.type_service.Name = "type_service";
            // 
            // price_service
            // 
            dataGridViewCellStyle3.Format = "N0";
            this.price_service.DefaultCellStyle = dataGridViewCellStyle3;
            this.price_service.HeaderText = "Giá";
            this.price_service.Name = "price_service";
            // 
            // add
            // 
            this.add.HeaderText = "Thao tác";
            this.add.Name = "add";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(564, 33);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(85, 28);
            this.btn_refresh.TabIndex = 33;
            this.btn_refresh.Text = "Làm mới";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // txb_search
            // 
            this.txb_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search.Location = new System.Drawing.Point(119, 145);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(252, 26);
            this.txb_search.TabIndex = 32;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(394, 33);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 28);
            this.btn_delete.TabIndex = 31;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(479, 33);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(79, 28);
            this.btn_edit.TabIndex = 30;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(698, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 22);
            this.label6.TabIndex = 39;
            this.label6.Text = "CHI TIẾT CHỈ ĐỊNH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(784, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 22);
            this.label5.TabIndex = 38;
            this.label5.Text = "CHỈ ĐỊNH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(158, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "GÓI CHỈ ĐỊNH";
            // 
            // btn_choose
            // 
            this.btn_choose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.Location = new System.Drawing.Point(311, 63);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(105, 35);
            this.btn_choose.TabIndex = 36;
            this.btn_choose.Text = "Chọn toa này";
            this.btn_choose.UseVisualStyleBackColor = true;
            // 
            // txb_search_services
            // 
            this.txb_search_services.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search_services.Location = new System.Drawing.Point(526, 72);
            this.txb_search_services.Name = "txb_search_services";
            this.txb_search_services.Size = new System.Drawing.Size(252, 26);
            this.txb_search_services.TabIndex = 35;
            this.txb_search_services.TextChanged += new System.EventHandler(this.txb_search_services_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(48, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tìm kiếm";
            // 
            // txb_name_services_set
            // 
            this.txb_name_services_set.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_name_services_set.Location = new System.Drawing.Point(73, 76);
            this.txb_name_services_set.Name = "txb_name_services_set";
            this.txb_name_services_set.Size = new System.Drawing.Size(190, 26);
            this.txb_name_services_set.TabIndex = 27;
            // 
            // dtgv_preset_services_set
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services_set.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_services_set.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgv_preset_services_set.ColumnHeadersHeight = 45;
            this.dtgv_preset_services_set.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_services_set.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_services_set.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgv_preset_services_set.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_services_set.Location = new System.Drawing.Point(12, 174);
            this.dtgv_preset_services_set.Name = "dtgv_preset_services_set";
            this.dtgv_preset_services_set.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgv_preset_services_set.RowHeadersVisible = false;
            this.dtgv_preset_services_set.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dtgv_preset_services_set.Size = new System.Drawing.Size(374, 476);
            this.dtgv_preset_services_set.TabIndex = 22;
            this.dtgv_preset_services_set.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services_set.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_services_set.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_services_set.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_services_set.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_services_set.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services_set.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_services_set.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_services_set.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_services_set.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_services_set.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_services_set.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_services_set.ThemeStyle.HeaderStyle.Height = 45;
            this.dtgv_preset_services_set.ThemeStyle.ReadOnly = false;
            this.dtgv_preset_services_set.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services_set.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_preset_services_set.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_services_set.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_services_set.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_preset_services_set.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_services_set.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_services_set.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_preset_services_set_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.FillWeight = 91.37056F;
            this.name.HeaderText = "Tên gói";
            this.name.Name = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "ID";
            // 
            // dtgv_preset_services
            // 
            this.dtgv_preset_services.AllowUserToAddRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgv_preset_services.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgv_preset_services.ColumnHeadersHeight = 45;
            this.dtgv_preset_services.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_services.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_preset,
            this.name_preset,
            this.price_preset,
            this.note_preset,
            this.del_preset});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_services.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgv_preset_services.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgv_preset_services.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_services.Location = new System.Drawing.Point(404, 382);
            this.dtgv_preset_services.Name = "dtgv_preset_services";
            this.dtgv_preset_services.RowHeadersVisible = false;
            this.dtgv_preset_services.Size = new System.Drawing.Size(744, 290);
            this.dtgv_preset_services.TabIndex = 24;
            this.dtgv_preset_services.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_services.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_services.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_services.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_services.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_services.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_services.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_services.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_services.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_services.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_services.ThemeStyle.HeaderStyle.Height = 45;
            this.dtgv_preset_services.ThemeStyle.ReadOnly = false;
            this.dtgv_preset_services.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_services.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_preset_services.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_services.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_services.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_preset_services.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_services.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_services.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_preset_services_CellClick);
            // 
            // id_preset
            // 
            this.id_preset.HeaderText = "ID";
            this.id_preset.Name = "id_preset";
            this.id_preset.Visible = false;
            // 
            // name_preset
            // 
            this.name_preset.HeaderText = "Tên chỉ định";
            this.name_preset.Name = "name_preset";
            this.name_preset.Width = 250;
            // 
            // price_preset
            // 
            dataGridViewCellStyle10.Format = "N0";
            this.price_preset.DefaultCellStyle = dataGridViewCellStyle10;
            this.price_preset.HeaderText = "Giá";
            this.price_preset.Name = "price_preset";
            // 
            // note_preset
            // 
            this.note_preset.HeaderText = "Ghi chú";
            this.note_preset.Name = "note_preset";
            // 
            // del_preset
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red;
            this.del_preset.DefaultCellStyle = dataGridViewCellStyle11;
            this.del_preset.FillWeight = 66.55386F;
            this.del_preset.HeaderText = "Thao tác";
            this.del_preset.Name = "del_preset";
            this.del_preset.Width = 49;
            // 
            // txb_id
            // 
            this.txb_id.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_id.Location = new System.Drawing.Point(73, 39);
            this.txb_id.Name = "txb_id";
            this.txb_id.ReadOnly = true;
            this.txb_id.Size = new System.Drawing.Size(100, 26);
            this.txb_id.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tên gói";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(309, 33);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(79, 28);
            this.btn_add.TabIndex = 25;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lb_total_price
            // 
            this.lb_total_price.AutoSize = true;
            this.lb_total_price.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total_price.ForeColor = System.Drawing.Color.Red;
            this.lb_total_price.Location = new System.Drawing.Point(419, 360);
            this.lb_total_price.Name = "lb_total_price";
            this.lb_total_price.Size = new System.Drawing.Size(56, 22);
            this.lb_total_price.TabIndex = 42;
            this.lb_total_price.Text = "Label";
            // 
            // frm_services_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 671);
            this.Controls.Add(this.lb_total_price);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtgv_services);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.txb_search_services);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_name_services_set);
            this.Controls.Add(this.dtgv_preset_services_set);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgv_preset_services);
            this.Controls.Add(this.txb_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_services_set";
            this.Text = "frm_services_set";
            this.Load += new System.EventHandler(this.frm_services_set_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_services)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_services_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_services)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_services;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TextBox txb_search;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.TextBox txb_search_services;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_name_services_set;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_preset_services_set;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_preset_services;
        private System.Windows.Forms.TextBox txb_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn add;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_preset;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_preset;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_preset;
        private System.Windows.Forms.DataGridViewTextBoxColumn note_preset;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_preset;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Label lb_total_price;
    }
}