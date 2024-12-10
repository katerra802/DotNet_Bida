namespace bida_test
{
    partial class SuaThongTinNhanVien
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
            this.llblBack = new System.Windows.Forms.LinkLabel();
            this.btnSuaNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTP_NhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHoTen_NhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail_NhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // llblBack
            // 
            this.llblBack.AutoSize = true;
            this.llblBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBack.Location = new System.Drawing.Point(80, 356);
            this.llblBack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llblBack.Name = "llblBack";
            this.llblBack.Size = new System.Drawing.Size(48, 19);
            this.llblBack.TabIndex = 55;
            this.llblBack.TabStop = true;
            this.llblBack.Text = "Trở về";
            this.llblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // btnSuaNhanVien
            // 
            this.btnSuaNhanVien.BorderRadius = 10;
            this.btnSuaNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuaNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuaNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnSuaNhanVien.Location = new System.Drawing.Point(204, 339);
            this.btnSuaNhanVien.Name = "btnSuaNhanVien";
            this.btnSuaNhanVien.Size = new System.Drawing.Size(200, 45);
            this.btnSuaNhanVien.TabIndex = 54;
            this.btnSuaNhanVien.Text = "Sửa thông tin nhân viên";
            this.btnSuaNhanVien.Click += new System.EventHandler(this.btnSuaNhanVien_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 53;
            this.label5.Text = "Thành phố :";
            // 
            // txtTP_NhanVien
            // 
            this.txtTP_NhanVien.BorderRadius = 18;
            this.txtTP_NhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTP_NhanVien.DefaultText = "";
            this.txtTP_NhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTP_NhanVien.Location = new System.Drawing.Point(210, 111);
            this.txtTP_NhanVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTP_NhanVien.Name = "txtTP_NhanVien";
            this.txtTP_NhanVien.PasswordChar = '\0';
            this.txtTP_NhanVien.PlaceholderText = "";
            this.txtTP_NhanVien.SelectedText = "";
            this.txtTP_NhanVien.Size = new System.Drawing.Size(202, 29);
            this.txtTP_NhanVien.TabIndex = 52;
            this.txtTP_NhanVien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTP_NhanVien_KeyPress);
            // 
            // txtHoTen_NhanVien
            // 
            this.txtHoTen_NhanVien.BorderRadius = 18;
            this.txtHoTen_NhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoTen_NhanVien.DefaultText = "";
            this.txtHoTen_NhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHoTen_NhanVien.Location = new System.Drawing.Point(210, 58);
            this.txtHoTen_NhanVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHoTen_NhanVien.Name = "txtHoTen_NhanVien";
            this.txtHoTen_NhanVien.PasswordChar = '\0';
            this.txtHoTen_NhanVien.PlaceholderText = "";
            this.txtHoTen_NhanVien.SelectedText = "";
            this.txtHoTen_NhanVien.Size = new System.Drawing.Size(198, 29);
            this.txtHoTen_NhanVien.TabIndex = 45;
            this.txtHoTen_NhanVien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_NhanVien_KeyPress);
            // 
            // txtEmail_NhanVien
            // 
            this.txtEmail_NhanVien.BorderRadius = 18;
            this.txtEmail_NhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail_NhanVien.DefaultText = "";
            this.txtEmail_NhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail_NhanVien.Location = new System.Drawing.Point(210, 159);
            this.txtEmail_NhanVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEmail_NhanVien.Name = "txtEmail_NhanVien";
            this.txtEmail_NhanVien.PasswordChar = '\0';
            this.txtEmail_NhanVien.PlaceholderText = "";
            this.txtEmail_NhanVien.SelectedText = "";
            this.txtEmail_NhanVien.Size = new System.Drawing.Size(202, 29);
            this.txtEmail_NhanVien.TabIndex = 42;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(117, 71);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 17);
            this.lblName.TabIndex = 43;
            this.lblName.Text = "Họ Tên:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(119, 172);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 17);
            this.lblEmail.TabIndex = 44;
            this.lblEmail.Text = "Email :";
            // 
            // SuaThongTinNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 450);
            this.Controls.Add(this.llblBack);
            this.Controls.Add(this.btnSuaNhanVien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTP_NhanVien);
            this.Controls.Add(this.txtHoTen_NhanVien);
            this.Controls.Add(this.txtEmail_NhanVien);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblEmail);
            this.Name = "SuaThongTinNhanVien";
            this.Text = "SuaThongTinNhanVien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel llblBack;
        private Guna.UI2.WinForms.Guna2Button btnSuaNhanVien;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtTP_NhanVien;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTen_NhanVien;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail_NhanVien;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
    }
}