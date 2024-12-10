using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bida_test
{
    public partial class ThemNhanVien : Form
    {
        public string MaNhanVien { get; private set; }

        public string HoTen { get; private set; }

        public string ThanhPho { get; private set; }
        public string Email { get; private set; }


        public ThemNhanVien()
        {
            InitializeComponent();
            CenterToScreen();
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddNhanVien_Click(object sender, EventArgs e)
        {


            HoTen = txtHoTen_NhanVien.Text;
            ThanhPho = txtTP_NhanVien.Text;
            Email = txtEmail_NhanVien.Text;

            // Kiểm tra thông tin hợp lệ
            if (
                string.IsNullOrWhiteSpace(HoTen) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đóng form và trả về DialogResult.OK nếu thành công
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtHoTen_NhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selectionStart = txtHoTen_NhanVien.SelectionStart;


            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập chữ cái và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectionStart == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập khoảng trắng ở đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == ' ' && selectionStart > 0 && txtHoTen_NhanVien.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTP_NhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selectionStart = txtTP_NhanVien.SelectionStart;


            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập chữ cái và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectionStart == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập khoảng trắng ở đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == ' ' && selectionStart > 0 && txtTP_NhanVien.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtEmail_NhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int selectionStart = txtTenTaiKhoan_NhanVien.SelectionStart;


            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '@'
                && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập chữ cái, số, dấu '.' (chấm), '@' (@).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
