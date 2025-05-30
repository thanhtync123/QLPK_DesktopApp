namespace QuanLyPhongKham
{
    partial class frm_login
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
            this.btn_login = new System.Windows.Forms.Button();
            this.txb_username = new System.Windows.Forms.TextBox();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton2 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton3 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_login.Location = new System.Drawing.Point(103, 201);
            this.btn_login.Margin = new System.Windows.Forms.Padding(6);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(206, 44);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "          Đăng nhập";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txb_username
            // 
            this.txb_username.Location = new System.Drawing.Point(103, 52);
            this.txb_username.Margin = new System.Windows.Forms.Padding(6);
            this.txb_username.Name = "txb_username";
            this.txb_username.Size = new System.Drawing.Size(253, 26);
            this.txb_username.TabIndex = 1;
            // 
            // txb_password
            // 
            this.txb_password.Location = new System.Drawing.Point(103, 140);
            this.txb_password.Margin = new System.Windows.Forms.Padding(6);
            this.txb_password.Name = "txb_password";
            this.txb_password.Size = new System.Drawing.Size(253, 26);
            this.txb_password.TabIndex = 2;
            this.txb_password.UseSystemPasswordChar = true;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::QuanLyPhongKham.Properties.Resources.user;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.Location = new System.Drawing.Point(22, 31);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(72, 79);
            this.guna2ImageButton1.TabIndex = 3;
            this.guna2ImageButton1.UseTransparentBackground = true;
            // 
            // guna2ImageButton2
            // 
            this.guna2ImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton2.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.Image = global::QuanLyPhongKham.Properties.Resources._lock;
            this.guna2ImageButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton2.ImageRotate = 0F;
            this.guna2ImageButton2.Location = new System.Drawing.Point(13, 116);
            this.guna2ImageButton2.Name = "guna2ImageButton2";
            this.guna2ImageButton2.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.Size = new System.Drawing.Size(91, 86);
            this.guna2ImageButton2.TabIndex = 3;
            this.guna2ImageButton2.UseTransparentBackground = true;
            // 
            // guna2ImageButton3
            // 
            this.guna2ImageButton3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton3.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton3.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton3.Image = global::QuanLyPhongKham.Properties.Resources.login__1_;
            this.guna2ImageButton3.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton3.ImageRotate = 0F;
            this.guna2ImageButton3.Location = new System.Drawing.Point(112, 196);
            this.guna2ImageButton3.Name = "guna2ImageButton3";
            this.guna2ImageButton3.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton3.Size = new System.Drawing.Size(64, 54);
            this.guna2ImageButton3.TabIndex = 4;
            this.guna2ImageButton3.UseTransparentBackground = true;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyPhongKham.Properties.Resources.edit;
            this.ClientSize = new System.Drawing.Size(686, 397);
            this.Controls.Add(this.guna2ImageButton3);
            this.Controls.Add(this.guna2ImageButton2);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.txb_password);
            this.Controls.Add(this.txb_username);
            this.Controls.Add(this.btn_login);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_login";
            this.Load += new System.EventHandler(this.frm_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txb_username;
        private System.Windows.Forms.TextBox txb_password;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton2;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton3;
    }
}