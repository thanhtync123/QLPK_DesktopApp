namespace QuanLyPhongKham
{
    partial class frm_video_ultrasound
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
            this.components = new System.ComponentModel.Container();
            this.pb_webcam = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lv_image = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_deletethisimage = new System.Windows.Forms.Button();
            this.btn_snap = new System.Windows.Forms.Button();
            this.btn_choosee = new System.Windows.Forms.Button();
            this.btn_deleteallimage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_webcam)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_webcam
            // 
            this.pb_webcam.ImageRotate = 0F;
            this.pb_webcam.Location = new System.Drawing.Point(12, 3);
            this.pb_webcam.Name = "pb_webcam";
            this.pb_webcam.Size = new System.Drawing.Size(500, 600);
            this.pb_webcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_webcam.TabIndex = 2;
            this.pb_webcam.TabStop = false;
            // 
            // lv_image
            // 
            this.lv_image.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_image.HideSelection = false;
            this.lv_image.LargeImageList = this.imageList1;
            this.lv_image.Location = new System.Drawing.Point(592, 3);
            this.lv_image.Name = "lv_image";
            this.lv_image.Size = new System.Drawing.Size(573, 483);
            this.lv_image.TabIndex = 3;
            this.lv_image.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(200, 200);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_deletethisimage
            // 
            this.btn_deletethisimage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deletethisimage.Location = new System.Drawing.Point(1171, 3);
            this.btn_deletethisimage.Name = "btn_deletethisimage";
            this.btn_deletethisimage.Size = new System.Drawing.Size(75, 35);
            this.btn_deletethisimage.TabIndex = 6;
            this.btn_deletethisimage.Text = "Xóa";
            this.btn_deletethisimage.UseVisualStyleBackColor = true;
            this.btn_deletethisimage.Click += new System.EventHandler(this.btn_deletethisimage_Click);
            // 
            // btn_snap
            // 
            this.btn_snap.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_snap.Location = new System.Drawing.Point(511, 12);
            this.btn_snap.Name = "btn_snap";
            this.btn_snap.Size = new System.Drawing.Size(75, 34);
            this.btn_snap.TabIndex = 7;
            this.btn_snap.Text = "Chụp";
            this.btn_snap.UseVisualStyleBackColor = true;
            this.btn_snap.Click += new System.EventHandler(this.btn_snap_Click);
            // 
            // btn_choosee
            // 
            this.btn_choosee.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choosee.Location = new System.Drawing.Point(511, 52);
            this.btn_choosee.Name = "btn_choosee";
            this.btn_choosee.Size = new System.Drawing.Size(75, 34);
            this.btn_choosee.TabIndex = 10;
            this.btn_choosee.Text = "Lấy";
            this.btn_choosee.UseVisualStyleBackColor = true;
            this.btn_choosee.Click += new System.EventHandler(this.btn_choosee_Click);
            // 
            // btn_deleteallimage
            // 
            this.btn_deleteallimage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteallimage.Location = new System.Drawing.Point(1168, 44);
            this.btn_deleteallimage.Name = "btn_deleteallimage";
            this.btn_deleteallimage.Size = new System.Drawing.Size(127, 35);
            this.btn_deleteallimage.TabIndex = 11;
            this.btn_deleteallimage.Text = "Xóa tất cả ảnh";
            this.btn_deleteallimage.UseVisualStyleBackColor = true;
            this.btn_deleteallimage.Click += new System.EventHandler(this.btn_deleteallimage_Click);
            // 
            // frm_video_ultrasound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 517);
            this.Controls.Add(this.btn_deleteallimage);
            this.Controls.Add(this.btn_choosee);
            this.Controls.Add(this.btn_snap);
            this.Controls.Add(this.btn_deletethisimage);
            this.Controls.Add(this.lv_image);
            this.Controls.Add(this.pb_webcam);
            this.Name = "frm_video_ultrasound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_video_ultrasound";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_video_ultrasound_FormClosing);
            this.Load += new System.EventHandler(this.frm_video_ultrasound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_webcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox pb_webcam;
        private System.Windows.Forms.ListView lv_image;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_deletethisimage;
        private System.Windows.Forms.Button btn_snap;
        private System.Windows.Forms.Button btn_choosee;
        private System.Windows.Forms.Button btn_deleteallimage;
    }
}