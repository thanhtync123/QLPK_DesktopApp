namespace QuanLyPhongKham
{
    partial class frm_service_set
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgv_service = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_description = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_choose = new System.Windows.Forms.Button();
            this.txb_search_service = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_name_service_set = new System.Windows.Forms.TextBox();
            this.dtgv_preset_service_set = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_preset_service = new Guna.UI2.WinForms.Guna2DataGridView();
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
            this.txb_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_service_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_service)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(438, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 40;
            this.label7.Text = "Tìm kiếm";
            // 
            // dtgv_service
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dtgv_service.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dtgv_service.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_service.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dtgv_service.ColumnHeadersHeight = 45;
            this.dtgv_service.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_service.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_med,
            this.name_med,
            this.unit_med,
            this.note_med,
            this.add_med});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_service.DefaultCellStyle = dataGridViewCellStyle16;
            this.dtgv_service.GridColor = System.Drawing.Color.Black;
            this.dtgv_service.Location = new System.Drawing.Point(387, 77);
            this.dtgv_service.Name = "dtgv_service";
            this.dtgv_service.RowHeadersVisible = false;
            this.dtgv_service.Size = new System.Drawing.Size(744, 250);
            this.dtgv_service.TabIndex = 34;
            this.dtgv_service.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_service.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_service.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_service.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_service.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_service.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_service.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_service.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_service.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_service.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_service.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_service.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_service.ThemeStyle.HeaderStyle.Height = 45;
            this.dtgv_service.ThemeStyle.ReadOnly = false;
            this.dtgv_service.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_service.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_service.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_service.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_service.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_service.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_service.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.add_med.DefaultCellStyle = dataGridViewCellStyle15;
            this.add_med.FillWeight = 52.31194F;
            this.add_med.HeaderText = "Thao tác";
            this.add_med.Name = "add_med";
            this.add_med.Width = 97;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(547, 6);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(85, 28);
            this.btn_refresh.TabIndex = 33;
            this.btn_refresh.Text = "Làm mới";
            this.btn_refresh.UseVisualStyleBackColor = true;
            // 
            // txb_search
            // 
            this.txb_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search.Location = new System.Drawing.Point(108, 205);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(252, 26);
            this.txb_search.TabIndex = 32;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(377, 6);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 28);
            this.btn_delete.TabIndex = 31;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(462, 6);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(79, 28);
            this.btn_edit.TabIndex = 30;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mô tả";
            // 
            // txb_description
            // 
            this.txb_description.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_description.Location = new System.Drawing.Point(56, 85);
            this.txb_description.Multiline = true;
            this.txb_description.Name = "txb_description";
            this.txb_description.Size = new System.Drawing.Size(315, 79);
            this.txb_description.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(681, 330);
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
            this.label5.Location = new System.Drawing.Point(767, 49);
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
            this.label4.Location = new System.Drawing.Point(147, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "CHỈ ĐỊNH MẪU";
            // 
            // btn_choose
            // 
            this.btn_choose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.Location = new System.Drawing.Point(294, 36);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(105, 35);
            this.btn_choose.TabIndex = 36;
            this.btn_choose.Text = "Chọn toa này";
            this.btn_choose.UseVisualStyleBackColor = true;
            // 
            // txb_search_service
            // 
            this.txb_search_service.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search_service.Location = new System.Drawing.Point(509, 45);
            this.txb_search_service.Name = "txb_search_service";
            this.txb_search_service.Size = new System.Drawing.Size(252, 26);
            this.txb_search_service.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tìm kiếm";
            // 
            // txb_name_service_set
            // 
            this.txb_name_service_set.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_name_service_set.Location = new System.Drawing.Point(56, 49);
            this.txb_name_service_set.Name = "txb_name_service_set";
            this.txb_name_service_set.Size = new System.Drawing.Size(190, 26);
            this.txb_name_service_set.TabIndex = 27;
            // 
            // dtgv_preset_service_set
            // 
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service_set.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_service_set.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgv_preset_service_set.ColumnHeadersHeight = 45;
            this.dtgv_preset_service_set.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_service_set.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.description});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_service_set.DefaultCellStyle = dataGridViewCellStyle20;
            this.dtgv_preset_service_set.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_service_set.Location = new System.Drawing.Point(1, 234);
            this.dtgv_preset_service_set.Name = "dtgv_preset_service_set";
            this.dtgv_preset_service_set.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgv_preset_service_set.RowHeadersVisible = false;
            this.dtgv_preset_service_set.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dtgv_preset_service_set.Size = new System.Drawing.Size(374, 411);
            this.dtgv_preset_service_set.TabIndex = 22;
            this.dtgv_preset_service_set.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service_set.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_service_set.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_service_set.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_service_set.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_service_set.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service_set.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_service_set.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_service_set.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_service_set.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_service_set.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_service_set.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_service_set.ThemeStyle.HeaderStyle.Height = 45;
            this.dtgv_preset_service_set.ThemeStyle.ReadOnly = false;
            this.dtgv_preset_service_set.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service_set.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_preset_service_set.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_service_set.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_service_set.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_preset_service_set.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_service_set.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.DefaultCellStyle = dataGridViewCellStyle19;
            this.description.FillWeight = 108.6294F;
            this.description.HeaderText = "Mô tả";
            this.description.Name = "description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "ID";
            // 
            // dtgv_preset_service
            // 
            this.dtgv_preset_service.AllowUserToAddRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dtgv_preset_service.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_preset_service.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dtgv_preset_service.ColumnHeadersHeight = 45;
            this.dtgv_preset_service.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_service.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_preset_service.DefaultCellStyle = dataGridViewCellStyle24;
            this.dtgv_preset_service.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgv_preset_service.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_service.Location = new System.Drawing.Point(387, 355);
            this.dtgv_preset_service.Name = "dtgv_preset_service";
            this.dtgv_preset_service.RowHeadersVisible = false;
            this.dtgv_preset_service.Size = new System.Drawing.Size(744, 290);
            this.dtgv_preset_service.TabIndex = 24;
            this.dtgv_preset_service.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_preset_service.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_service.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_preset_service.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_preset_service.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtgv_preset_service.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_preset_service.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_preset_service.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_service.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_preset_service.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_preset_service.ThemeStyle.HeaderStyle.Height = 45;
            this.dtgv_preset_service.ThemeStyle.ReadOnly = false;
            this.dtgv_preset_service.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_preset_service.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_preset_service.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_preset_service.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_preset_service.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_preset_service.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_preset_service.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Red;
            this.del_med.DefaultCellStyle = dataGridViewCellStyle23;
            this.del_med.FillWeight = 66.55386F;
            this.del_med.HeaderText = "Thao tác";
            this.del_med.Name = "del_med";
            this.del_med.Width = 49;
            // 
            // txb_id
            // 
            this.txb_id.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_id.Location = new System.Drawing.Point(56, 12);
            this.txb_id.Name = "txb_id";
            this.txb_id.ReadOnly = true;
            this.txb_id.Size = new System.Drawing.Size(100, 26);
            this.txb_id.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tên toa";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(292, 6);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(79, 28);
            this.btn_add.TabIndex = 25;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // frm_service_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 693);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtgv_service);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_description);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.txb_search_service);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_name_service_set);
            this.Controls.Add(this.dtgv_preset_service_set);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgv_preset_service);
            this.Controls.Add(this.txb_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_add);
            this.Name = "frm_service_set";
            this.Text = "frm_service_set";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_service_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_preset_service)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn note_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_med;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TextBox txb_search;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_description;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.TextBox txb_search_service;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_name_service_set;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_preset_service_set;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_preset_service;
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
        private System.Windows.Forms.TextBox txb_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
    }
}