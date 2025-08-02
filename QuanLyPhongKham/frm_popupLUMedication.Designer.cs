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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.c2_examination_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_medication_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_medname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_morning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_afternoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_days_of_use = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2_total_quantity_med = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgv_patient_medication.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_patient_medication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dtgv_patient_medication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_patient_medication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_patient_medication.ColumnHeadersHeight = 40;
            this.dtgv_patient_medication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_patient_medication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1_examination_id,
            this.c1_id,
            this.c1_name,
            this.c1_update_day});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_patient_medication.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv_patient_medication.GridColor = System.Drawing.Color.Black;
            this.dtgv_patient_medication.Location = new System.Drawing.Point(12, 57);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_detail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgv_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dtgv_detail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgv_detail.ColumnHeadersHeight = 40;
            this.dtgv_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c2_examination_id,
            this.c2_medication_id,
            this.c2_medname,
            this.c2_unit,
            this.c2_morning,
            this.c2_afternoon,
            this.c2_days_of_use,
            this.c2_total_quantity_med,
            this.c2_note});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_detail.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgv_detail.GridColor = System.Drawing.Color.Black;
            this.dtgv_detail.Location = new System.Drawing.Point(446, 56);
            this.dtgv_detail.Name = "dtgv_detail";
            this.dtgv_detail.RowHeadersVisible = false;
            this.dtgv_detail.Size = new System.Drawing.Size(792, 602);
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
            // c2_examination_id
            // 
            this.c2_examination_id.HeaderText = "Mã phiếu khám";
            this.c2_examination_id.Name = "c2_examination_id";
            this.c2_examination_id.Visible = false;
            this.c2_examination_id.Width = 86;
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
            this.c2_medname.Width = 300;
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
            // c2_afternoon
            // 
            this.c2_afternoon.HeaderText = "Chiều";
            this.c2_afternoon.Name = "c2_afternoon";
            this.c2_afternoon.Width = 50;
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
            // c2_note
            // 
            this.c2_note.HeaderText = "Ghi chú";
            this.c2_note.Name = "c2_note";
            this.c2_note.Width = 230;
            // 
            // frm_popupLUMedication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1250, 736);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_examination_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_medication_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_medname;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_morning;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_afternoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_days_of_use;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_total_quantity_med;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2_note;
    }
}