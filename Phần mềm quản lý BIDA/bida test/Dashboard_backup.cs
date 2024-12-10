using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bida_test
{
    public partial class Dashboard_backup : Form
    {
        private string loaiTaiKhoan;
        public static nhanVien_class nhanVien_Class;
        public string LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }

        public Dashboard_backup()
        {
            InitializeComponent();
            load_frm(new DanhSachBan());
            CenterToScreen();
        }
        public void load_frm(object form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }
        public void HideButtonsForNhanVien()
        {
            btnNhanVien.Visible = false;
            btnThongke.Visible = false;
            btnQuanlyGia.Visible = false;
        }
        private void btnDSDichvu_Click(object sender, EventArgs e)
        {
            panelMove.Left = btnDSDichvu.Left;
            load_frm(new DichVu());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            panelMove.Left = btnHoiVien.Left;
            load_frm(new KhachHang());
        }
        private void btnDSBan_Click(object sender, EventArgs e)
        {
            panelMove.Left = btnDSBan.Left;
            load_frm(new DanhSachBan());        
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            panelMove.Left = btnDatBan.Left;
            load_frm(new Datban());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            panelMove.Left = btnNhanVien.Left;
            load_frm(new NhanVien());
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            panelMove.Left = btnThongke.Left;
            load_frm(new ThongKe());
        }

        private void btnQuanlyGia_Click(object sender, EventArgs e)
        {
            panelMove.Left = btnQuanlyGia.Left;
            load_frm(new Gia());
        }
    }
}
