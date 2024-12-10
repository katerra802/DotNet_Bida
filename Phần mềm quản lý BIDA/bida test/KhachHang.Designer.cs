using System;

namespace bida_test
{
    partial class KhachHang
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
            this.BangUudai = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiUD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bangKH = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Mak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenkh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solanchoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoivien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadBangUD = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteMember = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditMember = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddMember = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemUudai = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuaUudai = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaUD = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.BangUudai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangKH)).BeginInit();
            this.SuspendLayout();
            // 
            // BangUudai
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.BangUudai.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BangUudai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.BangUudai.ColumnHeadersHeight = 24;
            this.BangUudai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.loaiUD,
            this.dk,
            this.UD});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BangUudai.DefaultCellStyle = dataGridViewCellStyle3;
            this.BangUudai.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.BangUudai.Location = new System.Drawing.Point(680, 86);
            this.BangUudai.Name = "BangUudai";
            this.BangUudai.ReadOnly = true;
            this.BangUudai.RowHeadersVisible = false;
            this.BangUudai.RowHeadersWidth = 51;
            this.BangUudai.Size = new System.Drawing.Size(607, 415);
            this.BangUudai.TabIndex = 5;
            this.BangUudai.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.BangUudai.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.BangUudai.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.BangUudai.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.BangUudai.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.BangUudai.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.BangUudai.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.BangUudai.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.BangUudai.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.BangUudai.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BangUudai.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.BangUudai.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.BangUudai.ThemeStyle.HeaderStyle.Height = 24;
            this.BangUudai.ThemeStyle.ReadOnly = true;
            this.BangUudai.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.BangUudai.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.BangUudai.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BangUudai.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.BangUudai.ThemeStyle.RowsStyle.Height = 22;
            this.BangUudai.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.BangUudai.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.BangUudai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BangUudai_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Mã ưu đãi";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // loaiUD
            // 
            this.loaiUD.HeaderText = "Loại Ưu đãi";
            this.loaiUD.MinimumWidth = 6;
            this.loaiUD.Name = "loaiUD";
            this.loaiUD.ReadOnly = true;
            // 
            // dk
            // 
            this.dk.HeaderText = "Điều kiện";
            this.dk.MinimumWidth = 6;
            this.dk.Name = "dk";
            this.dk.ReadOnly = true;
            // 
            // UD
            // 
            this.UD.HeaderText = "Ưu đãi";
            this.UD.MinimumWidth = 6;
            this.UD.Name = "UD";
            this.UD.ReadOnly = true;
            // 
            // bangKH
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.bangKH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bangKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.bangKH.ColumnHeadersHeight = 24;
            this.bangKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mak,
            this.sdt,
            this.tenkh,
            this.solanchoi,
            this.Hoivien});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bangKH.DefaultCellStyle = dataGridViewCellStyle6;
            this.bangKH.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.bangKH.Location = new System.Drawing.Point(29, 86);
            this.bangKH.Name = "bangKH";
            this.bangKH.ReadOnly = true;
            this.bangKH.RowHeadersVisible = false;
            this.bangKH.RowHeadersWidth = 51;
            this.bangKH.Size = new System.Drawing.Size(616, 415);
            this.bangKH.TabIndex = 9;
            this.bangKH.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.bangKH.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.bangKH.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.bangKH.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.bangKH.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.bangKH.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.bangKH.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.bangKH.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.bangKH.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bangKH.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bangKH.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.bangKH.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bangKH.ThemeStyle.HeaderStyle.Height = 24;
            this.bangKH.ThemeStyle.ReadOnly = true;
            this.bangKH.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.bangKH.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bangKH.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bangKH.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.bangKH.ThemeStyle.RowsStyle.Height = 22;
            this.bangKH.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.bangKH.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.bangKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bangKH_CellClick);
            // 
            // Mak
            // 
            this.Mak.HeaderText = "Mã khách hàng";
            this.Mak.MinimumWidth = 6;
            this.Mak.Name = "Mak";
            this.Mak.ReadOnly = true;
            // 
            // sdt
            // 
            this.sdt.HeaderText = "Số điện thoại";
            this.sdt.MinimumWidth = 6;
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            // 
            // tenkh
            // 
            this.tenkh.HeaderText = "Tên khách hàng";
            this.tenkh.MinimumWidth = 6;
            this.tenkh.Name = "tenkh";
            this.tenkh.ReadOnly = true;
            // 
            // solanchoi
            // 
            this.solanchoi.HeaderText = "Số lần chơi";
            this.solanchoi.MinimumWidth = 6;
            this.solanchoi.Name = "solanchoi";
            this.solanchoi.ReadOnly = true;
            // 
            // Hoivien
            // 
            this.Hoivien.HeaderText = "Hội viên";
            this.Hoivien.MinimumWidth = 6;
            this.Hoivien.Name = "Hoivien";
            this.Hoivien.ReadOnly = true;
            this.Hoivien.Visible = false;
            // 
            // btnLoadBangUD
            // 
            this.btnLoadBangUD.BorderRadius = 10;
            this.btnLoadBangUD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadBangUD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadBangUD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoadBangUD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoadBangUD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBangUD.ForeColor = System.Drawing.Color.White;
            this.btnLoadBangUD.Image = global::bida_test.Properties.Resources.renew_removebg_preview__1_;
            this.btnLoadBangUD.ImageSize = new System.Drawing.Size(40, 40);
            this.btnLoadBangUD.Location = new System.Drawing.Point(1093, 518);
            this.btnLoadBangUD.Name = "btnLoadBangUD";
            this.btnLoadBangUD.Size = new System.Drawing.Size(194, 55);
            this.btnLoadBangUD.TabIndex = 10;
            this.btnLoadBangUD.Text = "Load ưu đãi";
            this.btnLoadBangUD.Click += new System.EventHandler(this.btnLoadBangUD_Click);
            // 
            // btnDeleteMember
            // 
            this.btnDeleteMember.BorderRadius = 10;
            this.btnDeleteMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMember.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMember.Image = global::bida_test.Properties.Resources.cancel_50px;
            this.btnDeleteMember.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDeleteMember.Location = new System.Drawing.Point(440, 12);
            this.btnDeleteMember.Name = "btnDeleteMember";
            this.btnDeleteMember.Size = new System.Drawing.Size(177, 55);
            this.btnDeleteMember.TabIndex = 4;
            this.btnDeleteMember.Text = "Xóa KH";
            this.btnDeleteMember.Click += new System.EventHandler(this.btnDeleteMember_Click);
            // 
            // btnEditMember
            // 
            this.btnEditMember.BorderRadius = 10;
            this.btnEditMember.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMember.ForeColor = System.Drawing.Color.White;
            this.btnEditMember.Image = global::bida_test.Properties.Resources.Chinhsua;
            this.btnEditMember.ImageSize = new System.Drawing.Size(40, 40);
            this.btnEditMember.Location = new System.Drawing.Point(211, 12);
            this.btnEditMember.Name = "btnEditMember";
            this.btnEditMember.Size = new System.Drawing.Size(223, 55);
            this.btnEditMember.TabIndex = 3;
            this.btnEditMember.Text = "Sửa thông tin KH";
            this.btnEditMember.Click += new System.EventHandler(this.btnEditMember_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.BorderRadius = 10;
            this.btnAddMember.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMember.ForeColor = System.Drawing.Color.White;
            this.btnAddMember.Image = global::bida_test.Properties.Resources.icons8_plus_501;
            this.btnAddMember.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddMember.Location = new System.Drawing.Point(28, 12);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(177, 55);
            this.btnAddMember.TabIndex = 2;
            this.btnAddMember.Text = "Thêm KH";
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // btnThemUudai
            // 
            this.btnThemUudai.BorderRadius = 10;
            this.btnThemUudai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemUudai.ForeColor = System.Drawing.Color.White;
            this.btnThemUudai.Image = global::bida_test.Properties.Resources.icons8_plus_501;
            this.btnThemUudai.ImageSize = new System.Drawing.Size(40, 40);
            this.btnThemUudai.Location = new System.Drawing.Point(623, 12);
            this.btnThemUudai.Name = "btnThemUudai";
            this.btnThemUudai.Size = new System.Drawing.Size(177, 55);
            this.btnThemUudai.TabIndex = 6;
            this.btnThemUudai.Text = "Thêm ưu đãi";
            this.btnThemUudai.Click += new System.EventHandler(this.btnThemUudai_Click);
            // 
            // btnSuaUudai
            // 
            this.btnSuaUudai.BorderRadius = 10;
            this.btnSuaUudai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaUudai.ForeColor = System.Drawing.Color.White;
            this.btnSuaUudai.Image = global::bida_test.Properties.Resources.Chinhsua;
            this.btnSuaUudai.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSuaUudai.Location = new System.Drawing.Point(806, 12);
            this.btnSuaUudai.Name = "btnSuaUudai";
            this.btnSuaUudai.Size = new System.Drawing.Size(177, 55);
            this.btnSuaUudai.TabIndex = 8;
            this.btnSuaUudai.Text = "Sửa ưu đãi";
            this.btnSuaUudai.Click += new System.EventHandler(this.btnSuaUudai_Click);
            // 
            // btnXoaUD
            // 
            this.btnXoaUD.BorderRadius = 10;
            this.btnXoaUD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaUD.ForeColor = System.Drawing.Color.White;
            this.btnXoaUD.Location = new System.Drawing.Point(989, 12);
            this.btnXoaUD.Name = "btnXoaUD";
            this.btnXoaUD.Size = new System.Drawing.Size(177, 55);
            this.btnXoaUD.TabIndex = 11;
            this.btnXoaUD.Text = "Xóa ưu đãi";
            this.btnXoaUD.Click += new System.EventHandler(this.btnXoaUD_Click);
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1321, 585);
            this.Controls.Add(this.btnXoaUD);
            this.Controls.Add(this.btnLoadBangUD);
            this.Controls.Add(this.bangKH);
            this.Controls.Add(this.btnSuaUudai);
            this.Controls.Add(this.btnThemUudai);
            this.Controls.Add(this.BangUudai);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.btnEditMember);
            this.Controls.Add(this.btnDeleteMember);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KhachHang";
            this.Text = "KhachHang";
            ((System.ComponentModel.ISupportInitialize)(this.BangUudai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView BangUudai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dk;
        private System.Windows.Forms.DataGridViewTextBoxColumn UD;
        private Guna.UI2.WinForms.Guna2DataGridView bangKH;
        private Guna.UI2.WinForms.Guna2Button btnLoadBangUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mak;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenkh;
        private System.Windows.Forms.DataGridViewTextBoxColumn solanchoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoivien;
        private Guna.UI2.WinForms.Guna2Button btnDeleteMember;
        private Guna.UI2.WinForms.Guna2Button btnEditMember;
        private Guna.UI2.WinForms.Guna2Button btnAddMember;
        private Guna.UI2.WinForms.Guna2Button btnThemUudai;
        private Guna.UI2.WinForms.Guna2Button btnSuaUudai;
        private Guna.UI2.WinForms.Guna2Button btnXoaUD;
    }
}