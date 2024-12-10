namespace bida_test
{
    partial class Datban
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Button btn_MoBan;

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
            this.cbMakh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblmakh = new System.Windows.Forms.Label();
            this.lblManv = new System.Windows.Forms.Label();
            this.lab_nhanVien = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_ngayThaoTac = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_MoBan = new Guna.UI2.WinForms.Guna2Button();
            this.btn_datBan = new Guna.UI2.WinForms.Guna2Button();
            this.cbNgayDaDatBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLoadbanDaDat = new Guna.UI2.WinForms.Guna2Button();
            this.btn_loadBan = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lab_time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_banBD = new System.Windows.Forms.Label();
            this.lab_banKT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbMakh
            // 
            this.cbMakh.BackColor = System.Drawing.Color.Transparent;
            this.cbMakh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMakh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMakh.FocusedColor = System.Drawing.Color.Empty;
            this.cbMakh.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMakh.ForeColor = System.Drawing.Color.Black;
            this.cbMakh.ItemHeight = 30;
            this.cbMakh.Location = new System.Drawing.Point(53, 149);
            this.cbMakh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMakh.Name = "cbMakh";
            this.cbMakh.Size = new System.Drawing.Size(361, 36);
            this.cbMakh.TabIndex = 13;
            // 
            // lblmakh
            // 
            this.lblmakh.AutoSize = true;
            this.lblmakh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmakh.Location = new System.Drawing.Point(49, 112);
            this.lblmakh.Name = "lblmakh";
            this.lblmakh.Size = new System.Drawing.Size(128, 25);
            this.lblmakh.TabIndex = 14;
            this.lblmakh.Text = "Khách hàng";
            // 
            // lblManv
            // 
            this.lblManv.AutoSize = true;
            this.lblManv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManv.Location = new System.Drawing.Point(49, 196);
            this.lblManv.Name = "lblManv";
            this.lblManv.Size = new System.Drawing.Size(150, 25);
            this.lblManv.TabIndex = 16;
            this.lblManv.Text = "Tên nhân viên";
            // 
            // lab_nhanVien
            // 
            this.lab_nhanVien.BackColor = System.Drawing.Color.White;
            this.lab_nhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_nhanVien.Location = new System.Drawing.Point(56, 234);
            this.lab_nhanVien.Name = "lab_nhanVien";
            this.lab_nhanVien.Size = new System.Drawing.Size(361, 45);
            this.lab_nhanVien.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(502, 88);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 523);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // txt_ngayThaoTac
            // 
            this.txt_ngayThaoTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ngayThaoTac.Location = new System.Drawing.Point(53, 67);
            this.txt_ngayThaoTac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ngayThaoTac.Mask = "00/00/0000";
            this.txt_ngayThaoTac.Name = "txt_ngayThaoTac";
            this.txt_ngayThaoTac.Size = new System.Drawing.Size(361, 34);
            this.txt_ngayThaoTac.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ngày thao tác";
            // 
            // btn_MoBan
            // 
            this.btn_MoBan.BorderRadius = 20;
            this.btn_MoBan.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MoBan.ForeColor = System.Drawing.Color.White;
            this.btn_MoBan.Image = global::bida_test.Properties.Resources.icons8_plus_50;
            this.btn_MoBan.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_MoBan.Location = new System.Drawing.Point(60, 294);
            this.btn_MoBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_MoBan.Name = "btn_MoBan";
            this.btn_MoBan.Size = new System.Drawing.Size(356, 64);
            this.btn_MoBan.TabIndex = 4;
            this.btn_MoBan.Text = "Mở bàn";
            this.btn_MoBan.Click += new System.EventHandler(this.btn_MoBan_Click);
            // 
            // btn_datBan
            // 
            this.btn_datBan.BorderRadius = 20;
            this.btn_datBan.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_datBan.ForeColor = System.Drawing.Color.White;
            this.btn_datBan.Image = global::bida_test.Properties.Resources.đặt_bàn;
            this.btn_datBan.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_datBan.Location = new System.Drawing.Point(60, 372);
            this.btn_datBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_datBan.Name = "btn_datBan";
            this.btn_datBan.Size = new System.Drawing.Size(356, 63);
            this.btn_datBan.TabIndex = 4;
            this.btn_datBan.Text = "Đặt bàn";
            this.btn_datBan.Click += new System.EventHandler(this.btn_DatBan_Click);
            // 
            // cbNgayDaDatBan
            // 
            this.cbNgayDaDatBan.BackColor = System.Drawing.Color.Transparent;
            this.cbNgayDaDatBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNgayDaDatBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNgayDaDatBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbNgayDaDatBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbNgayDaDatBan.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNgayDaDatBan.ForeColor = System.Drawing.Color.Black;
            this.cbNgayDaDatBan.ItemHeight = 30;
            this.cbNgayDaDatBan.Location = new System.Drawing.Point(53, 462);
            this.cbNgayDaDatBan.Margin = new System.Windows.Forms.Padding(4);
            this.cbNgayDaDatBan.Name = "cbNgayDaDatBan";
            this.cbNgayDaDatBan.Size = new System.Drawing.Size(361, 36);
            this.cbNgayDaDatBan.TabIndex = 26;
            // 
            // btnLoadbanDaDat
            // 
            this.btnLoadbanDaDat.BorderRadius = 10;
            this.btnLoadbanDaDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadbanDaDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadbanDaDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoadbanDaDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoadbanDaDat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadbanDaDat.ForeColor = System.Drawing.Color.White;
            this.btnLoadbanDaDat.Location = new System.Drawing.Point(53, 528);
            this.btnLoadbanDaDat.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadbanDaDat.Name = "btnLoadbanDaDat";
            this.btnLoadbanDaDat.Size = new System.Drawing.Size(171, 44);
            this.btnLoadbanDaDat.TabIndex = 27;
            this.btnLoadbanDaDat.Text = "Load bàn đã đặt";
            this.btnLoadbanDaDat.Click += new System.EventHandler(this.btnLoadbanDaDat_Click);
            // 
            // btn_loadBan
            // 
            this.btn_loadBan.BorderRadius = 10;
            this.btn_loadBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_loadBan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_loadBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_loadBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_loadBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadBan.ForeColor = System.Drawing.Color.White;
            this.btn_loadBan.Location = new System.Drawing.Point(243, 528);
            this.btn_loadBan.Margin = new System.Windows.Forms.Padding(4);
            this.btn_loadBan.Name = "btn_loadBan";
            this.btn_loadBan.Size = new System.Drawing.Size(171, 44);
            this.btn_loadBan.TabIndex = 27;
            this.btn_loadBan.Text = "Load bàn";
            this.btn_loadBan.Click += new System.EventHandler(this.ReloadDatBanTables);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lab_time
            // 
            this.lab_time.AutoSize = true;
            this.lab_time.Location = new System.Drawing.Point(1054, 67);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(44, 16);
            this.lab_time.TabIndex = 28;
            this.lab_time.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(511, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Thời gian bắt đầu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(511, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Thời gian kết thúc:";
            // 
            // lab_banBD
            // 
            this.lab_banBD.AutoSize = true;
            this.lab_banBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_banBD.Location = new System.Drawing.Point(677, 18);
            this.lab_banBD.Name = "lab_banBD";
            this.lab_banBD.Size = new System.Drawing.Size(71, 20);
            this.lab_banBD.TabIndex = 29;
            this.lab_banBD.Text = "Chưa có";
            // 
            // lab_banKT
            // 
            this.lab_banKT.AutoSize = true;
            this.lab_banKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_banKT.Location = new System.Drawing.Point(677, 63);
            this.lab_banKT.Name = "lab_banKT";
            this.lab_banKT.Size = new System.Drawing.Size(71, 20);
            this.lab_banKT.TabIndex = 30;
            this.lab_banKT.Text = "Chưa có";
            // 
            // Datban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 653);
            this.Controls.Add(this.lab_banKT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_banBD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_time);
            this.Controls.Add(this.btn_loadBan);
            this.Controls.Add(this.btnLoadbanDaDat);
            this.Controls.Add(this.cbNgayDaDatBan);
            this.Controls.Add(this.txt_ngayThaoTac);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lab_nhanVien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblManv);
            this.Controls.Add(this.lblmakh);
            this.Controls.Add(this.cbMakh);
            this.Controls.Add(this.btn_datBan);
            this.Controls.Add(this.btn_MoBan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Datban";
            this.Text = "Datban";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cbMakh;
        private System.Windows.Forms.Label lblmakh;
        private System.Windows.Forms.Label lblManv;
        private System.Windows.Forms.Label lab_nhanVien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MaskedTextBox txt_ngayThaoTac;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btn_datBan;
        private Guna.UI2.WinForms.Guna2ComboBox cbNgayDaDatBan;
        private Guna.UI2.WinForms.Guna2Button btnLoadbanDaDat;
        private Guna.UI2.WinForms.Guna2Button btn_loadBan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lab_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_banBD;
        private System.Windows.Forms.Label lab_banKT;
    }
}