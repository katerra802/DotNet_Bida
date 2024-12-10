namespace bida_test
{
    partial class SuaBan
    {
        private Guna.UI2.WinForms.Guna2TextBox txtMaBan;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLoaiBan;
        private Guna.UI2.WinForms.Guna2ComboBox cmbKhuVuc;
        private Guna.UI2.WinForms.Guna2TextBox txtTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnUpdateTable;

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
            this.txtMaBan = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbLoaiBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbKhuVuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTrangThai = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnUpdateTable = new Guna.UI2.WinForms.Guna2Button();
            this.lblMaGiaban = new System.Windows.Forms.Label();
            this.cbMagiaBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.llblBack = new System.Windows.Forms.LinkLabel();
            this.lblMaban = new System.Windows.Forms.Label();
            this.LblKhuvuc = new System.Windows.Forms.Label();
            this.lblLoaiBan = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMaBan
            // 
            this.txtMaBan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaBan.DefaultText = "";
            this.txtMaBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtMaBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaBan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaBan.ForeColor = System.Drawing.Color.Black;
            this.txtMaBan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaBan.Location = new System.Drawing.Point(213, 23);
            this.txtMaBan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.PasswordChar = '\0';
            this.txtMaBan.PlaceholderText = "Nhập mã bàn";
            this.txtMaBan.SelectedText = "";
            this.txtMaBan.Size = new System.Drawing.Size(267, 44);
            this.txtMaBan.TabIndex = 0;
            // 
            // cmbLoaiBan
            // 
            this.cmbLoaiBan.BackColor = System.Drawing.Color.Transparent;
            this.cmbLoaiBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLoaiBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLoaiBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLoaiBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLoaiBan.ForeColor = System.Drawing.Color.Black;
            this.cmbLoaiBan.ItemHeight = 30;
            this.cmbLoaiBan.Location = new System.Drawing.Point(213, 146);
            this.cmbLoaiBan.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLoaiBan.Name = "cmbLoaiBan";
            this.cmbLoaiBan.Size = new System.Drawing.Size(265, 36);
            this.cmbLoaiBan.TabIndex = 1;
            // 
            // cmbKhuVuc
            // 
            this.cmbKhuVuc.BackColor = System.Drawing.Color.Transparent;
            this.cmbKhuVuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhuVuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbKhuVuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbKhuVuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKhuVuc.ForeColor = System.Drawing.Color.Black;
            this.cmbKhuVuc.ItemHeight = 30;
            this.cmbKhuVuc.Items.AddRange(new object[] {
            "Thường",
            "Cao cấp",
            "VIP"});
            this.cmbKhuVuc.Location = new System.Drawing.Point(213, 207);
            this.cmbKhuVuc.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKhuVuc.Name = "cmbKhuVuc";
            this.cmbKhuVuc.Size = new System.Drawing.Size(265, 36);
            this.cmbKhuVuc.TabIndex = 2;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrangThai.DefaultText = "";
            this.txtTrangThai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtTrangThai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTrangThai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTrangThai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTrangThai.ForeColor = System.Drawing.Color.Black;
            this.txtTrangThai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTrangThai.Location = new System.Drawing.Point(213, 257);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.PasswordChar = '\0';
            this.txtTrangThai.PlaceholderText = "Nhập trạng thái bàn";
            this.txtTrangThai.SelectedText = "";
            this.txtTrangThai.Size = new System.Drawing.Size(267, 44);
            this.txtTrangThai.TabIndex = 3;
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.BorderRadius = 10;
            this.btnUpdateTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdateTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdateTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdateTable.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTable.Location = new System.Drawing.Point(213, 318);
            this.btnUpdateTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(267, 55);
            this.btnUpdateTable.TabIndex = 4;
            this.btnUpdateTable.Text = "Lưu";
            this.btnUpdateTable.Click += new System.EventHandler(this.btnUpdateTable_Click);
            // 
            // lblMaGiaban
            // 
            this.lblMaGiaban.AutoSize = true;
            this.lblMaGiaban.Location = new System.Drawing.Point(71, 89);
            this.lblMaGiaban.Name = "lblMaGiaban";
            this.lblMaGiaban.Size = new System.Drawing.Size(76, 16);
            this.lblMaGiaban.TabIndex = 9;
            this.lblMaGiaban.Text = "Mã Giá bàn";
            // 
            // cbMagiaBan
            // 
            this.cbMagiaBan.BackColor = System.Drawing.Color.Transparent;
            this.cbMagiaBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMagiaBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMagiaBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMagiaBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMagiaBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMagiaBan.ForeColor = System.Drawing.Color.Black;
            this.cbMagiaBan.ItemHeight = 30;
            this.cbMagiaBan.Location = new System.Drawing.Point(213, 89);
            this.cbMagiaBan.Margin = new System.Windows.Forms.Padding(4);
            this.cbMagiaBan.Name = "cbMagiaBan";
            this.cbMagiaBan.Size = new System.Drawing.Size(265, 36);
            this.cbMagiaBan.TabIndex = 10;
            // 
            // llblBack
            // 
            this.llblBack.AutoSize = true;
            this.llblBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBack.Location = new System.Drawing.Point(48, 339);
            this.llblBack.Name = "llblBack";
            this.llblBack.Size = new System.Drawing.Size(63, 22);
            this.llblBack.TabIndex = 11;
            this.llblBack.TabStop = true;
            this.llblBack.Text = "Trở về";
            this.llblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // lblMaban
            // 
            this.lblMaban.AutoSize = true;
            this.lblMaban.Location = new System.Drawing.Point(71, 33);
            this.lblMaban.Name = "lblMaban";
            this.lblMaban.Size = new System.Drawing.Size(52, 16);
            this.lblMaban.TabIndex = 12;
            this.lblMaban.Text = "Mã bàn";
            // 
            // LblKhuvuc
            // 
            this.LblKhuvuc.AutoSize = true;
            this.LblKhuvuc.Location = new System.Drawing.Point(71, 217);
            this.LblKhuvuc.Name = "LblKhuvuc";
            this.LblKhuvuc.Size = new System.Drawing.Size(53, 16);
            this.LblKhuvuc.TabIndex = 13;
            this.LblKhuvuc.Text = "Khu vực";
            // 
            // lblLoaiBan
            // 
            this.lblLoaiBan.AutoSize = true;
            this.lblLoaiBan.Location = new System.Drawing.Point(71, 156);
            this.lblLoaiBan.Name = "lblLoaiBan";
            this.lblLoaiBan.Size = new System.Drawing.Size(59, 16);
            this.lblLoaiBan.TabIndex = 14;
            this.lblLoaiBan.Text = "Loại bàn";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(71, 266);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(67, 16);
            this.lblTrangThai.TabIndex = 15;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // SuaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 395);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblLoaiBan);
            this.Controls.Add(this.LblKhuvuc);
            this.Controls.Add(this.lblMaban);
            this.Controls.Add(this.llblBack);
            this.Controls.Add(this.cbMagiaBan);
            this.Controls.Add(this.lblMaGiaban);
            this.Controls.Add(this.btnUpdateTable);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.cmbKhuVuc);
            this.Controls.Add(this.cmbLoaiBan);
            this.Controls.Add(this.txtMaBan);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SuaBan";
            this.Text = "Sửa bàn";
            this.Load += new System.EventHandler(this.SuaBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaGiaban;
        private Guna.UI2.WinForms.Guna2ComboBox cbMagiaBan;
        private System.Windows.Forms.LinkLabel llblBack;
        private System.Windows.Forms.Label lblMaban;
        private System.Windows.Forms.Label LblKhuvuc;
        private System.Windows.Forms.Label lblLoaiBan;
        private System.Windows.Forms.Label lblTrangThai;
    }
}