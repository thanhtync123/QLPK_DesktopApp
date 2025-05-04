namespace QuanLyPhongKham
{
    partial class frm_dtnote
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.txb_content = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lời dặn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // txb_id
            // 
            this.txb_id.Location = new System.Drawing.Point(159, 119);
            this.txb_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_id.Name = "txb_id";
            this.txb_id.Size = new System.Drawing.Size(115, 22);
            this.txb_id.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tìm kiếm";
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(375, 212);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(100, 28);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(267, 212);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(100, 28);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "Sửa";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(159, 212);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(100, 28);
            this.btn_add.TabIndex = 6;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txb_search
            // 
            this.txb_search.Location = new System.Drawing.Point(740, 18);
            this.txb_search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(344, 22);
            this.txb_search.TabIndex = 7;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // dtgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv.ColumnHeadersHeight = 15;
            this.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.Location = new System.Drawing.Point(663, 50);
            this.dtgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgv.Name = "dtgv";
            this.dtgv.RowHeadersVisible = false;
            this.dtgv.RowHeadersWidth = 51;
            this.dtgv.Size = new System.Drawing.Size(1000, 686);
            this.dtgv.TabIndex = 8;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv.ThemeStyle.HeaderStyle.Height = 15;
            this.dtgv.ThemeStyle.ReadOnly = false;
            this.dtgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_CellClick);
            // 
            // txb_content
            // 
            this.txb_content.Location = new System.Drawing.Point(159, 164);
            this.txb_content.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_content.Name = "txb_content";
            this.txb_content.Size = new System.Drawing.Size(457, 22);
            this.txb_content.TabIndex = 9;
            // 
            // frm_dtnote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 753);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.dtgv);
            this.Controls.Add(this.txb_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_dtnote";
            this.Text = "Lời dặn";
            this.Load += new System.EventHandler(this.frm_dtnote_Load);
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
        private System.Windows.Forms.TextBox txb_content;
    }
}
