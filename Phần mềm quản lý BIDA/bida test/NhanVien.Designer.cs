namespace bida_test
{
    partial class NhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd_NV = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridView_NhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MANHANVIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dchi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView_TaiKhoanNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.TK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_DoiMK = new Guna.UI2.WinForms.Guna2Button();
            this.btn_taoTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_NhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TaiKhoanNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd_NV
            // 
            this.btnAdd_NV.BorderRadius = 20;
            this.btnAdd_NV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd_NV.ForeColor = System.Drawing.Color.White;
            this.btnAdd_NV.Image = global::bida_test.Properties.Resources.icons8_plus_50;
            this.btnAdd_NV.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAdd_NV.Location = new System.Drawing.Point(12, 385);
            this.btnAdd_NV.Name = "btnAdd_NV";
            this.btnAdd_NV.Size = new System.Drawing.Size(204, 60);
            this.btnAdd_NV.TabIndex = 1;
            this.btnAdd_NV.Text = "Thêm nhân viên mới";
            this.btnAdd_NV.Click += new System.EventHandler(this.btnAddNV_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 20;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::bida_test.Properties.Resources.Chinhsua;
            this.btnEdit.ImageSize = new System.Drawing.Size(40, 40);
            this.btnEdit.Location = new System.Drawing.Point(380, 385);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(145, 60);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa thông tin";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 20;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::bida_test.Properties.Resources.cancel_50px;
            this.btnDelete.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDelete.Location = new System.Drawing.Point(222, 385);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 60);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa nhân viên";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Bảng Nhân Viên";
            // 
            // DataGridView_NhanVien
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.DataGridView_NhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_NhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DataGridView_NhanVien.ColumnHeadersHeight = 18;
            this.DataGridView_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_NhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MANHANVIEN,
            this.TEN,
            this.dchi,
            this.GMAIL});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_NhanVien.DefaultCellStyle = dataGridViewCellStyle15;
            this.DataGridView_NhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_NhanVien.Location = new System.Drawing.Point(12, 75);
            this.DataGridView_NhanVien.Name = "DataGridView_NhanVien";
            this.DataGridView_NhanVien.RowHeadersVisible = false;
            this.DataGridView_NhanVien.RowHeadersWidth = 51;
            this.DataGridView_NhanVien.RowTemplate.Height = 24;
            this.DataGridView_NhanVien.Size = new System.Drawing.Size(513, 304);
            this.DataGridView_NhanVien.TabIndex = 12;
            this.DataGridView_NhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_NhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_NhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_NhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_NhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_NhanVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_NhanVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_NhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_NhanVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_NhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_NhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_NhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_NhanVien.ThemeStyle.HeaderStyle.Height = 18;
            this.DataGridView_NhanVien.ThemeStyle.ReadOnly = false;
            this.DataGridView_NhanVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_NhanVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_NhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_NhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_NhanVien.ThemeStyle.RowsStyle.Height = 24;
            this.DataGridView_NhanVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_NhanVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_NhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_NhanVien_CellClick);
            this.DataGridView_NhanVien.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_NhanVien_CellDoubleClick);
            // 
            // MANHANVIEN
            // 
            this.MANHANVIEN.HeaderText = "Mã Nhân Viên";
            this.MANHANVIEN.MinimumWidth = 6;
            this.MANHANVIEN.Name = "MANHANVIEN";
            // 
            // TEN
            // 
            this.TEN.HeaderText = "TÊN";
            this.TEN.MinimumWidth = 6;
            this.TEN.Name = "TEN";
            // 
            // dchi
            // 
            this.dchi.HeaderText = "Địa chỉ";
            this.dchi.MinimumWidth = 6;
            this.dchi.Name = "dchi";
            // 
            // GMAIL
            // 
            this.GMAIL.HeaderText = "GMAIL";
            this.GMAIL.MinimumWidth = 6;
            this.GMAIL.Name = "GMAIL";
            // 
            // DataGridView_TaiKhoanNhanVien
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.DataGridView_TaiKhoanNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_TaiKhoanNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DataGridView_TaiKhoanNhanVien.ColumnHeadersHeight = 34;
            this.DataGridView_TaiKhoanNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_TaiKhoanNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TK,
            this.MK,
            this.CV});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_TaiKhoanNhanVien.DefaultCellStyle = dataGridViewCellStyle18;
            this.DataGridView_TaiKhoanNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_TaiKhoanNhanVien.Location = new System.Drawing.Point(531, 75);
            this.DataGridView_TaiKhoanNhanVien.Name = "DataGridView_TaiKhoanNhanVien";
            this.DataGridView_TaiKhoanNhanVien.RowHeadersVisible = false;
            this.DataGridView_TaiKhoanNhanVien.RowHeadersWidth = 51;
            this.DataGridView_TaiKhoanNhanVien.RowTemplate.Height = 24;
            this.DataGridView_TaiKhoanNhanVien.Size = new System.Drawing.Size(458, 304);
            this.DataGridView_TaiKhoanNhanVien.TabIndex = 13;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.Height = 34;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.ReadOnly = false;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.RowsStyle.Height = 24;
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_TaiKhoanNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // TK
            // 
            this.TK.HeaderText = "Tài khoản";
            this.TK.MinimumWidth = 6;
            this.TK.Name = "TK";
            // 
            // MK
            // 
            this.MK.HeaderText = "Mật khẩu";
            this.MK.MinimumWidth = 6;
            this.MK.Name = "MK";
            // 
            // CV
            // 
            this.CV.HeaderText = "Chức vụ";
            this.CV.MinimumWidth = 6;
            this.CV.Name = "CV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(629, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Bảng Tài Khoản Nhân Viên";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(318, 6);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(434, 39);
            this.guna2HtmlLabel1.TabIndex = 15;
            this.guna2HtmlLabel1.Text = "Quản Lí Tài Khoản Nhân Viên";
            // 
            // btn_DoiMK
            // 
            this.btn_DoiMK.BorderRadius = 20;
            this.btn_DoiMK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_DoiMK.ForeColor = System.Drawing.Color.White;
            this.btn_DoiMK.Image = global::bida_test.Properties.Resources.DoiBan;
            this.btn_DoiMK.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_DoiMK.Location = new System.Drawing.Point(758, 385);
            this.btn_DoiMK.Name = "btn_DoiMK";
            this.btn_DoiMK.Size = new System.Drawing.Size(231, 60);
            this.btn_DoiMK.TabIndex = 16;
            this.btn_DoiMK.Text = "Đổi mật khẩu ";
            this.btn_DoiMK.Click += new System.EventHandler(this.btn_DoiMK_Click);
            // 
            // btn_taoTaiKhoan
            // 
            this.btn_taoTaiKhoan.BorderRadius = 20;
            this.btn_taoTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_taoTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btn_taoTaiKhoan.Image = global::bida_test.Properties.Resources.user_25px;
            this.btn_taoTaiKhoan.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_taoTaiKhoan.Location = new System.Drawing.Point(531, 385);
            this.btn_taoTaiKhoan.Name = "btn_taoTaiKhoan";
            this.btn_taoTaiKhoan.Size = new System.Drawing.Size(221, 60);
            this.btn_taoTaiKhoan.TabIndex = 16;
            this.btn_taoTaiKhoan.Text = "Tạo tài khoản";
            this.btn_taoTaiKhoan.Click += new System.EventHandler(this.btn_taoTaiKhoan_Click);
            // 
            // NhanVien
            // 
            this.ClientSize = new System.Drawing.Size(1090, 585);
            this.Controls.Add(this.btn_taoTaiKhoan);
            this.Controls.Add(this.btn_DoiMK);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataGridView_TaiKhoanNhanVien);
            this.Controls.Add(this.DataGridView_NhanVien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd_NV);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NhanVien";
            this.Text = "Employee Management";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_NhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TaiKhoanNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnAdd_NV;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_NhanVien;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_TaiKhoanNhanVien;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANHANVIEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dchi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CV;
        private Guna.UI2.WinForms.Guna2Button btn_DoiMK;
        private Guna.UI2.WinForms.Guna2Button btn_taoTaiKhoan;
    }
}