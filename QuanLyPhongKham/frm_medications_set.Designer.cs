namespace QuanLyPhongKham
{
    partial class frm_medications_set
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_preset_medications_set = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.dtgv_preset_medications = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btn_add = new System.Windows.Forms.Button();
            this.txb_name_medications_set = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.dtgv_medications = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txb_search_med = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.id_med_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.morning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afternoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days_of_use = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_quantity_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_medications_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_medications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_medications)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // dtgv_preset_medications_set
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_medications_set.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_preset_medications_set.ColumnHeadersHeight = 15;
            this.dtgv_preset_medications_set.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications_set.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.description});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_medications_set.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv_preset_medications_set.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications_set.Location = new System.Drawing.Point(1, 155);
            this.dtgv_preset_medications_set.Name = "dtgv_preset_medications_set";
            this.dtgv_preset_medications_set.RowHeadersVisible = false;
            this.dtgv_preset_medications_set.Size = new System.Drawing.Size(346, 474);
            this.dtgv_preset_medications_set.TabIndex = 1;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications_set.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.Height = 15;
            this.dtgv_preset_medications_set.ThemeStyle.ReadOnly = false;
            this.dtgv_preset_medications_set.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_preset_medications_set.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_medications_set.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_medications_set.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_preset_medications_set.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications_set.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_medications_set.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_preset_medications_set_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "Mã toa";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.HeaderText = "Tên toa";
            this.name.Name = "name";
            // 
            // description
            // 
            this.description.HeaderText = "Mô tả";
            this.description.Name = "description";
            // 
            // txb_id
            // 
            this.txb_id.Location = new System.Drawing.Point(74, 12);
            this.txb_id.Name = "txb_id";
            this.txb_id.ReadOnly = true;
            this.txb_id.Size = new System.Drawing.Size(100, 20);
            this.txb_id.TabIndex = 2;
            // 
            // dtgv_preset_medications
            // 
            this.dtgv_preset_medications.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_medications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgv_preset_medications.ColumnHeadersHeight = 28;
            this.dtgv_preset_medications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_med_pm,
            this.name_pm,
            this.morning,
            this.noon,
            this.afternoon,
            this.evening,
            this.days_of_use,
            this.total_quantity_med,
            this.unit,
            this.note,
            this.del_med});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_medications.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgv_preset_medications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgv_preset_medications.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications.Location = new System.Drawing.Point(353, 268);
            this.dtgv_preset_medications.Name = "dtgv_preset_medications";
            this.dtgv_preset_medications.RowHeadersVisible = false;
            this.dtgv_preset_medications.Size = new System.Drawing.Size(657, 361);
            this.dtgv_preset_medications.TabIndex = 3;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.Height = 28;
            this.dtgv_preset_medications.ThemeStyle.ReadOnly = false;
            this.dtgv_preset_medications.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_preset_medications.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_medications.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_medications.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_preset_medications.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_medications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_preset_medications_CellClick);
            this.dtgv_preset_medications.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_preset_medications_CellValueChanged);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(196, 12);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(79, 21);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txb_name_medications_set
            // 
            this.txb_name_medications_set.Location = new System.Drawing.Point(74, 38);
            this.txb_name_medications_set.Name = "txb_name_medications_set";
            this.txb_name_medications_set.Size = new System.Drawing.Size(100, 20);
            this.txb_name_medications_set.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên toa";
            // 
            // txb_description
            // 
            this.txb_description.Location = new System.Drawing.Point(74, 65);
            this.txb_description.Multiline = true;
            this.txb_description.Name = "txb_description";
            this.txb_description.Size = new System.Drawing.Size(190, 41);
            this.txb_description.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mô tả";
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(366, 12);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(79, 21);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(281, 12);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 21);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txb_search
            // 
            this.txb_search.Location = new System.Drawing.Point(12, 129);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(252, 20);
            this.txb_search.TabIndex = 11;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(451, 12);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(79, 21);
            this.btn_refresh.TabIndex = 12;
            this.btn_refresh.Text = "Làm mới";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // dtgv_medications
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dtgv_medications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_medications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgv_medications.ColumnHeadersHeight = 15;
            this.dtgv_medications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_medications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_med,
            this.name_med,
            this.unit_med,
            this.note_med,
            this.add_med});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_medications.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgv_medications.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_medications.Location = new System.Drawing.Point(353, 85);
            this.dtgv_medications.Name = "dtgv_medications";
            this.dtgv_medications.RowHeadersVisible = false;
            this.dtgv_medications.Size = new System.Drawing.Size(537, 177);
            this.dtgv_medications.TabIndex = 13;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_medications.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_medications.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_medications.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_medications.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_medications.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_medications.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_medications.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_medications.ThemeStyle.HeaderStyle.Height = 15;
            this.dtgv_medications.ThemeStyle.ReadOnly = false;
            this.dtgv_medications.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_medications.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_medications.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_medications.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_medications.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_medications.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_medications.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_medications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_medications_CellClick);
            // 
            // id_med
            // 
            this.id_med.HeaderText = "ID";
            this.id_med.Name = "id_med";
            // 
            // name_med
            // 
            this.name_med.HeaderText = "Tên thuốc";
            this.name_med.Name = "name_med";
            // 
            // unit_med
            // 
            this.unit_med.HeaderText = "Đơn vị";
            this.unit_med.Name = "unit_med";
            // 
            // note_med
            // 
            this.note_med.HeaderText = "Ghi chú";
            this.note_med.Name = "note_med";
            // 
            // add_med
            // 
            this.add_med.HeaderText = "Thao tác";
            this.add_med.Name = "add_med";
            // 
            // txb_search_med
            // 
            this.txb_search_med.Location = new System.Drawing.Point(353, 56);
            this.txb_search_med.Name = "txb_search_med";
            this.txb_search_med.Size = new System.Drawing.Size(252, 20);
            this.txb_search_med.TabIndex = 14;
            this.txb_search_med.TextChanged += new System.EventHandler(this.txb_search_med_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 21);
            this.button1.TabIndex = 15;
            this.button1.Text = "Chọn toa này";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // id_med_pm
            // 
            this.id_med_pm.HeaderText = "id";
            this.id_med_pm.Name = "id_med_pm";
            this.id_med_pm.Visible = false;
            // 
            // name_pm
            // 
            this.name_pm.HeaderText = "Tên thuốc";
            this.name_pm.Name = "name_pm";
            // 
            // morning
            // 
            this.morning.HeaderText = "Sáng";
            this.morning.Name = "morning";
            // 
            // noon
            // 
            this.noon.HeaderText = "Trưa";
            this.noon.Name = "noon";
            // 
            // afternoon
            // 
            this.afternoon.HeaderText = "Chiều";
            this.afternoon.Name = "afternoon";
            // 
            // evening
            // 
            this.evening.HeaderText = "Tối";
            this.evening.Name = "evening";
            // 
            // days_of_use
            // 
            this.days_of_use.HeaderText = "Số ngày";
            this.days_of_use.Name = "days_of_use";
            // 
            // total_quantity_med
            // 
            this.total_quantity_med.HeaderText = "Tổng cộng";
            this.total_quantity_med.Name = "total_quantity_med";
            // 
            // unit
            // 
            this.unit.HeaderText = "Đơn vị";
            this.unit.Name = "unit";
            // 
            // note
            // 
            this.note.HeaderText = "Ghi chú";
            this.note.Name = "note";
            // 
            // del_med
            // 
            this.del_med.HeaderText = "Thao tác";
            this.del_med.Name = "del_med";
            // 
            // frm_medications_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 699);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txb_search_med);
            this.Controls.Add(this.dtgv_medications);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.txb_description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_name_medications_set);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dtgv_preset_medications);
            this.Controls.Add(this.txb_id);
            this.Controls.Add(this.dtgv_preset_medications_set);
            this.Controls.Add(this.label1);
            this.Name = "frm_medications_set";
            this.Text = "frm_medications_set";
            this.Load += new System.EventHandler(this.frm_medications_set_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_medications_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_medications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_medications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_preset_medications_set;
        private System.Windows.Forms.TextBox txb_id;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_preset_medications;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txb_name_medications_set;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txb_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Button btn_refresh;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_medications;
        private System.Windows.Forms.TextBox txb_search_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn note_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_med_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn morning;
        private System.Windows.Forms.DataGridViewTextBoxColumn noon;
        private System.Windows.Forms.DataGridViewTextBoxColumn afternoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn evening;
        private System.Windows.Forms.DataGridViewTextBoxColumn days_of_use;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_quantity_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_med;
        private System.Windows.Forms.Button button1;
    }
}