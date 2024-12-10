namespace bida_test
{
    partial class XacNhanDatBan
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
            this.txt_gioKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.txt_gioBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_tenBan = new System.Windows.Forms.Label();
            this.btn_xacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txt_gioKetThuc
            // 
            this.txt_gioKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gioKetThuc.Location = new System.Drawing.Point(280, 110);
            this.txt_gioKetThuc.Mask = "00:00";
            this.txt_gioKetThuc.Name = "txt_gioKetThuc";
            this.txt_gioKetThuc.Size = new System.Drawing.Size(155, 34);
            this.txt_gioKetThuc.TabIndex = 2;
            this.txt_gioKetThuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_gioKetThuc_KeyPress);
            // 
            // txt_gioBatDau
            // 
            this.txt_gioBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gioBatDau.Location = new System.Drawing.Point(70, 110);
            this.txt_gioBatDau.Mask = "00:00";
            this.txt_gioBatDau.Name = "txt_gioBatDau";
            this.txt_gioBatDau.Size = new System.Drawing.Size(155, 34);
            this.txt_gioBatDau.TabIndex = 1;
            this.txt_gioBatDau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_gioKetThuc_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Giờ kết thúc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Giờ bắt đầu";
            // 
            // lab_tenBan
            // 
            this.lab_tenBan.AutoSize = true;
            this.lab_tenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_tenBan.Location = new System.Drawing.Point(154, 9);
            this.lab_tenBan.Name = "lab_tenBan";
            this.lab_tenBan.Size = new System.Drawing.Size(0, 38);
            this.lab_tenBan.TabIndex = 27;
            // 
            // btn_xacNhan
            // 
            this.btn_xacNhan.BorderRadius = 20;
            this.btn_xacNhan.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacNhan.ForeColor = System.Drawing.Color.White;
            this.btn_xacNhan.ImageSize = new System.Drawing.Size(70, 70);
            this.btn_xacNhan.Location = new System.Drawing.Point(104, 174);
            this.btn_xacNhan.Name = "btn_xacNhan";
            this.btn_xacNhan.Size = new System.Drawing.Size(298, 61);
            this.btn_xacNhan.TabIndex = 30;
            this.btn_xacNhan.Text = "Xác nhận";
            this.btn_xacNhan.Click += new System.EventHandler(this.btn_xacNhan_Click);
            // 
            // XacNhanDatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 260);
            this.Controls.Add(this.btn_xacNhan);
            this.Controls.Add(this.txt_gioKetThuc);
            this.Controls.Add(this.txt_gioBatDau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_tenBan);
            this.Controls.Add(this.label1);
            this.Name = "XacNhanDatBan";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.XacNhanDatBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txt_gioKetThuc;
        private System.Windows.Forms.MaskedTextBox txt_gioBatDau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_tenBan;
        private Guna.UI2.WinForms.Guna2Button btn_xacNhan;
    }
}