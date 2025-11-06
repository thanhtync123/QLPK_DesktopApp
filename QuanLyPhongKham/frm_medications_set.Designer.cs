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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_preset_medications_set = new Guna.UI2.WinForms.Guna2DataGridView();
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
            this.txb_search_med = new System.Windows.Forms.TextBox();
            this.btn_choose = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_med_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.morning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afternoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days_of_use = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_quantity_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_medications_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_medications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_medications)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // dtgv_preset_medications_set
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_preset_medications_set.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_medications_set.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_preset_medications_set.ColumnHeadersHeight = 45;
            this.dtgv_preset_medications_set.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications_set.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.description});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_medications_set.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgv_preset_medications_set.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_medications_set.Location = new System.Drawing.Point(19, 234);
            this.dtgv_preset_medications_set.Name = "dtgv_preset_medications_set";
            this.dtgv_preset_medications_set.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgv_preset_medications_set.RowHeadersVisible = false;
            this.dtgv_preset_medications_set.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dtgv_preset_medications_set.Size = new System.Drawing.Size(374, 411);
            this.dtgv_preset_medications_set.TabIndex = 1;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications_set.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications_set.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications_set.ThemeStyle.HeaderStyle.Height = 45;
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
            // txb_id
            // 
            this.txb_id.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_id.Location = new System.Drawing.Point(74, 12);
            this.txb_id.Name = "txb_id";
            this.txb_id.ReadOnly = true;
            this.txb_id.Size = new System.Drawing.Size(100, 26);
            this.txb_id.TabIndex = 2;
            // 
            // dtgv_preset_medications
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgv_preset_medications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dtgv_preset_medications.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_medications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgv_preset_medications.ColumnHeadersHeight = 45;
            this.dtgv_preset_medications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_med_pm,
            this.name_pm,
            this.unit,
            this.morning,
            this.noon,
            this.afternoon,
            this.evening,
            this.days_of_use,
            this.total_quantity_med,
            this.note,
            this.del_med});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_medications.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgv_preset_medications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgv_preset_medications.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_medications.Location = new System.Drawing.Point(405, 361);
            this.dtgv_preset_medications.Name = "dtgv_preset_medications";
            this.dtgv_preset_medications.RowHeadersVisible = false;
            this.dtgv_preset_medications.Size = new System.Drawing.Size(744, 284);
            this.dtgv_preset_medications.TabIndex = 3;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_medications.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_medications.ThemeStyle.HeaderStyle.Height = 45;
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
            this.btn_add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(310, 6);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(79, 28);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txb_name_medications_set
            // 
            this.txb_name_medications_set.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_name_medications_set.Location = new System.Drawing.Point(74, 49);
            this.txb_name_medications_set.Name = "txb_name_medications_set";
            this.txb_name_medications_set.Size = new System.Drawing.Size(190, 26);
            this.txb_name_medications_set.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên toa";
            // 
            // txb_description
            // 
            this.txb_description.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_description.Location = new System.Drawing.Point(74, 85);
            this.txb_description.Multiline = true;
            this.txb_description.Name = "txb_description";
            this.txb_description.Size = new System.Drawing.Size(315, 79);
            this.txb_description.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mô tả";
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(480, 6);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(79, 28);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(395, 6);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 28);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txb_search
            // 
            this.txb_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search.Location = new System.Drawing.Point(19, 202);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(252, 26);
            this.txb_search.TabIndex = 11;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(565, 6);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(85, 28);
            this.btn_refresh.TabIndex = 12;
            this.btn_refresh.Text = "Làm mới";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // dtgv_medications
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dtgv_medications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgv_medications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dtgv_medications.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_medications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgv_medications.ColumnHeadersHeight = 45;
            this.dtgv_medications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_medications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_med,
            this.name_med,
            this.unit_med,
            this.note_med,
            this.add_med});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_medications.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgv_medications.GridColor = System.Drawing.Color.Black;
            this.dtgv_medications.Location = new System.Drawing.Point(405, 77);
            this.dtgv_medications.Name = "dtgv_medications";
            this.dtgv_medications.RowHeadersVisible = false;
            this.dtgv_medications.Size = new System.Drawing.Size(744, 250);
            this.dtgv_medications.TabIndex = 13;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_medications.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_medications.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_medications.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_medications.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_medications.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_medications.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_medications.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_medications.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_medications.ThemeStyle.HeaderStyle.Height = 45;
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
            // txb_search_med
            // 
            this.txb_search_med.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search_med.Location = new System.Drawing.Point(423, 45);
            this.txb_search_med.Name = "txb_search_med";
            this.txb_search_med.Size = new System.Drawing.Size(252, 26);
            this.txb_search_med.TabIndex = 14;
            this.txb_search_med.TextChanged += new System.EventHandler(this.txb_search_med_TextChanged);
            // 
            // btn_choose
            // 
            this.btn_choose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.Location = new System.Drawing.Point(312, 36);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(105, 35);
            this.btn_choose.TabIndex = 15;
            this.btn_choose.Text = "Chọn toa này";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // id
            // 
            this.id.HeaderText = "Mã toa";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.FillWeight = 91.37056F;
            this.name.HeaderText = "Tên toa";
            this.name.Name = "name";
            // 
            // description
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.DefaultCellStyle = dataGridViewCellStyle3;
            this.description.FillWeight = 108.6294F;
            this.description.HeaderText = "Mô tả";
            this.description.Name = "description";
            // 
            // id_med_pm
            // 
            this.id_med_pm.HeaderText = "id";
            this.id_med_pm.Name = "id_med_pm";
            this.id_med_pm.Visible = false;
            this.id_med_pm.Width = 5;
            // 
            // name_pm
            // 
            this.name_pm.FillWeight = 401.0152F;
            this.name_pm.HeaderText = "Tên thuốc";
            this.name_pm.Name = "name_pm";
            this.name_pm.Width = 200;
            // 
            // unit
            // 
            this.unit.FillWeight = 66.55386F;
            this.unit.HeaderText = "Đơn vị";
            this.unit.Name = "unit";
            this.unit.Width = 49;
            // 
            // morning
            // 
            this.morning.FillWeight = 66.55386F;
            this.morning.HeaderText = "Sáng";
            this.morning.Name = "morning";
            this.morning.Width = 50;
            // 
            // noon
            // 
            this.noon.FillWeight = 66.55386F;
            this.noon.HeaderText = "Trưa";
            this.noon.Name = "noon";
            this.noon.Width = 49;
            // 
            // afternoon
            // 
            this.afternoon.FillWeight = 66.55386F;
            this.afternoon.HeaderText = "Chiều";
            this.afternoon.Name = "afternoon";
            this.afternoon.Width = 50;
            // 
            // evening
            // 
            this.evening.FillWeight = 66.55386F;
            this.evening.HeaderText = "Tối";
            this.evening.Name = "evening";
            this.evening.Width = 49;
            // 
            // days_of_use
            // 
            this.days_of_use.FillWeight = 66.55386F;
            this.days_of_use.HeaderText = "Số ngày";
            this.days_of_use.Name = "days_of_use";
            this.days_of_use.Width = 50;
            // 
            // total_quantity_med
            // 
            this.total_quantity_med.FillWeight = 66.55386F;
            this.total_quantity_med.HeaderText = "Số lượng";
            this.total_quantity_med.Name = "total_quantity_med";
            this.total_quantity_med.Width = 49;
            // 
            // note
            // 
            this.note.FillWeight = 66.55386F;
            this.note.HeaderText = "Ghi chú";
            this.note.Name = "note";
            this.note.Width = 145;
            // 
            // del_med
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            this.del_med.DefaultCellStyle = dataGridViewCellStyle7;
            this.del_med.FillWeight = 66.55386F;
            this.del_med.HeaderText = "Thao tác";
            this.del_med.Name = "del_med";
            this.del_med.Width = 49;
            // 
            // id_med
            // 
            this.id_med.HeaderText = "ID";
            this.id_med.Name = "id_med";
            this.id_med.Visible = false;
            this.id_med.Width = 5;
            // 
            // name_med
            // 
            this.name_med.FillWeight = 142.132F;
            this.name_med.HeaderText = "Tên thuốc";
            this.name_med.Name = "name_med";
            this.name_med.Width = 264;
            // 
            // unit_med
            // 
            this.unit_med.FillWeight = 51.23585F;
            this.unit_med.HeaderText = "Đơn vị";
            this.unit_med.Name = "unit_med";
            this.unit_med.Width = 95;
            // 
            // note_med
            // 
            this.note_med.FillWeight = 154.3202F;
            this.note_med.HeaderText = "Ghi chú";
            this.note_med.Name = "note_med";
            this.note_med.Width = 287;
            // 
            // add_med
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.add_med.DefaultCellStyle = dataGridViewCellStyle11;
            this.add_med.FillWeight = 52.31194F;
            this.add_med.HeaderText = "Thao tác";
            this.add_med.Name = "add_med";
            this.add_med.Width = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(165, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 22);
            this.label4.TabIndex = 16;
            this.label4.Text = "TOA MẪU";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(766, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "THUỐC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(705, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "CHI TIẾT TOA MẪU";
            // 
            // frm_medications_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 657);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_choose);
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
        private System.Windows.Forms.Button btn_refresh;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_medications;
        private System.Windows.Forms.TextBox txb_search_med;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_med_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn morning;
        private System.Windows.Forms.DataGridViewTextBoxColumn noon;
        private System.Windows.Forms.DataGridViewTextBoxColumn afternoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn evening;
        private System.Windows.Forms.DataGridViewTextBoxColumn days_of_use;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_quantity_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn note_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_med;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}