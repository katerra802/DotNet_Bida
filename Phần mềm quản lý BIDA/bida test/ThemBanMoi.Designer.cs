namespace bida_test
{
    partial class ThemBanMoi
    {
        private Guna.UI2.WinForms.Guna2ComboBox cmbLoaiBan;
        private Guna.UI2.WinForms.Guna2ComboBox cmbKhuVuc;
        private Guna.UI2.WinForms.Guna2TextBox txtTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnAddTable;

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
            this.cmbLoaiBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbKhuVuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTrangThai = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddTable = new Guna.UI2.WinForms.Guna2Button();
            this.lblMaGiaban = new System.Windows.Forms.Label();
            this.cmbMagiaBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.llblBack = new System.Windows.Forms.LinkLabel();
            this.LblKhuvuc = new System.Windows.Forms.Label();
            this.lblLoaiBan = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.cmbLoaiBan.Location = new System.Drawing.Point(187, 152);
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
            this.cmbKhuVuc.Location = new System.Drawing.Point(187, 91);
            this.cmbKhuVuc.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKhuVuc.Name = "cmbKhuVuc";
            this.cmbKhuVuc.Size = new System.Drawing.Size(265, 36);
            this.cmbKhuVuc.TabIndex = 2;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrangThai.DefaultText = "Trống";
            this.txtTrangThai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtTrangThai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTrangThai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTrangThai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTrangThai.ForeColor = System.Drawing.Color.Black;
            this.txtTrangThai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTrangThai.Location = new System.Drawing.Point(185, 202);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.PasswordChar = '\0';
            this.txtTrangThai.PlaceholderText = "Nhập trạng thái bàn";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.SelectedText = "";
            this.txtTrangThai.Size = new System.Drawing.Size(267, 44);
            this.txtTrangThai.TabIndex = 3;
            this.txtTrangThai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrangThai_KeyPress);
            // 
            // btnAddTable
            // 
            this.btnAddTable.BorderRadius = 10;
            this.btnAddTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddTable.ForeColor = System.Drawing.Color.White;
            this.btnAddTable.Location = new System.Drawing.Point(185, 263);
            this.btnAddTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(267, 55);
            this.btnAddTable.TabIndex = 4;
            this.btnAddTable.Text = "Thêm bàn";
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // lblMaGiaban
            // 
            this.lblMaGiaban.AutoSize = true;
            this.lblMaGiaban.Location = new System.Drawing.Point(43, 34);
            this.lblMaGiaban.Name = "lblMaGiaban";
            this.lblMaGiaban.Size = new System.Drawing.Size(76, 16);
            this.lblMaGiaban.TabIndex = 9;
            this.lblMaGiaban.Text = "Mã Giá bàn";
            // 
            // cmbMagiaBan
            // 
            this.cmbMagiaBan.BackColor = System.Drawing.Color.Transparent;
            this.cmbMagiaBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMagiaBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagiaBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMagiaBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMagiaBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMagiaBan.ForeColor = System.Drawing.Color.Black;
            this.cmbMagiaBan.ItemHeight = 30;
            this.cmbMagiaBan.Location = new System.Drawing.Point(185, 34);
            this.cmbMagiaBan.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMagiaBan.Name = "cmbMagiaBan";
            this.cmbMagiaBan.Size = new System.Drawing.Size(265, 36);
            this.cmbMagiaBan.TabIndex = 10;
            // 
            // llblBack
            // 
            this.llblBack.AutoSize = true;
            this.llblBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBack.Location = new System.Drawing.Point(20, 284);
            this.llblBack.Name = "llblBack";
            this.llblBack.Size = new System.Drawing.Size(63, 22);
            this.llblBack.TabIndex = 11;
            this.llblBack.TabStop = true;
            this.llblBack.Text = "Trở về";
            this.llblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // LblKhuvuc
            // 
            this.LblKhuvuc.AutoSize = true;
            this.LblKhuvuc.Location = new System.Drawing.Point(43, 91);
            this.LblKhuvuc.Name = "LblKhuvuc";
            this.LblKhuvuc.Size = new System.Drawing.Size(53, 16);
            this.LblKhuvuc.TabIndex = 13;
            this.LblKhuvuc.Text = "Khu vực";
            // 
            // lblLoaiBan
            // 
            this.lblLoaiBan.AutoSize = true;
            this.lblLoaiBan.Location = new System.Drawing.Point(43, 152);
            this.lblLoaiBan.Name = "lblLoaiBan";
            this.lblLoaiBan.Size = new System.Drawing.Size(59, 16);
            this.lblLoaiBan.TabIndex = 14;
            this.lblLoaiBan.Text = "Loại bàn";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(43, 211);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(67, 16);
            this.lblTrangThai.TabIndex = 15;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // ThemBanMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 342);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblLoaiBan);
            this.Controls.Add(this.LblKhuvuc);
            this.Controls.Add(this.llblBack);
            this.Controls.Add(this.cmbMagiaBan);
            this.Controls.Add(this.lblMaGiaban);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.cmbKhuVuc);
            this.Controls.Add(this.cmbLoaiBan);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThemBanMoi";
            this.Text = "Thêm bàn mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaGiaban;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMagiaBan;
        private System.Windows.Forms.LinkLabel llblBack;
        private System.Windows.Forms.Label LblKhuvuc;
        private System.Windows.Forms.Label lblLoaiBan;
        private System.Windows.Forms.Label lblTrangThai;
    }
}