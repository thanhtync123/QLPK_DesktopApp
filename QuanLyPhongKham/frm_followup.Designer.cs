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
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_day_create = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_followup_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            this.SuspendLayout();
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
            this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_id,
            this.c_name,
            this.c_address,
            this.c_phone,
            this.c_day_create,
            this.c_followup_date,
            this.c_state});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.Location = new System.Drawing.Point(12, 36);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.Size = new System.Drawing.Size(827, 324);
            this.dtgv.TabIndex = 0;
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
            this.dtgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv.ThemeStyle.HeaderStyle.Height = 15;
            this.dtgv.ThemeStyle.ReadOnly = false;
            this.dtgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // c_id
            // 
            this.c_id.HeaderText = "Mã BN";
            this.c_id.Name = "c_id";
            // 
            // c_name
            // 
            this.c_name.HeaderText = "Họ tên ";
            this.c_name.Name = "c_name";
            // 
            // c_address
            // 
            this.c_address.HeaderText = "Địa chỉ";
            this.c_address.Name = "c_address";
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
            // 
            // c_followup_date
            // 
            this.c_followup_date.HeaderText = "Ngày tái khám";
            this.c_followup_date.Name = "c_followup_date";
            // 
            // c_state
            // 
            this.c_state.HeaderText = "Trạng thái";
            this.c_state.Name = "c_state";
            // 
            // frm_followup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 450);
            this.Controls.Add(this.dtgv);
            this.Name = "frm_followup";
            this.Text = "frm_followup";
            this.Load += new System.EventHandler(this.frm_followup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_day_create;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_followup_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_state;
    }
}