using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyLibrary;
namespace bida_test
{
    public partial class DangNhap : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        public DangNhap()
        {
            InitializeComponent();
            connsql = kn.conn;
            txtMatKhau.UseSystemPasswordChar = true;
            txtbox_DN_TenTaiKhoan.Focus();
            CenterToScreen();
        }

        private void dangNhap()
        {
            if (!CheckTextBoxes())
            {
                MessageBox.Show("Vui lòng nhập tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (connsql.State == ConnectionState.Closed)
                    {
                        connsql.Open();
                    }
                    string query = "SELECT LOAITAIKHOAN FROM TAIKHOAN_NHANVIEN WHERE TENTAIKHOAN = @TENTAIKHOAN AND MATKHAU = @MATKHAU";
                    SqlCommand command = new SqlCommand(query, connsql);
                    command.Parameters.AddWithValue("@TENTAIKHOAN", txtbox_DN_TenTaiKhoan.Text);
                    command.Parameters.AddWithValue("@MATKHAU", txtMatKhau.Text);

                    object result = command.ExecuteScalar();

                    DBConnect db = new DBConnect();
                    SqlDataReader tmp = db.showOneTable("SELECT NHANVIEN.MANHANVIEN, NHANVIEN.HOTEN, TAIKHOAN_NHANVIEN.TENTAIKHOAN FROM NHANVIEN, TAIKHOAN_NHANVIEN WHERE NHANVIEN.MANHANVIEN = TAIKHOAN_NHANVIEN.MANHANVIEN AND TENTAIKHOAN = '" + txtbox_DN_TenTaiKhoan.Text + "' AND MATKHAU = '" + txtMatKhau.Text + "'");
                    nhanVien_class nv = new nhanVien_class();
                    while(tmp.Read())
                    {
                        nv.idNhanVien = tmp["MANHANVIEN"].ToString();
                        nv.tenNhanVien = tmp["HOTEN"].ToString();
                        nv.tenDangNhap = tmp["TENTAIKHOAN"].ToString();
                    };

                    if (result != null)
                    {
                        string loaiTaiKhoan = result.ToString();

                        if (loaiTaiKhoan == "Admin")
                        {
                            Dashboard_backup formAdmin = new Dashboard_backup();
                            formAdmin.LoaiTaiKhoan = loaiTaiKhoan;
                            Dashboard_backup.nhanVien_Class = nv;
                            formAdmin.Show();
                            this.Hide();
                        }
                        else
                        {
                            Dashboard_backup formNhanVien = new Dashboard_backup();
                            formNhanVien.HideButtonsForNhanVien();
                            Dashboard_backup.nhanVien_Class = nv;
                            formNhanVien.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (connsql.State == ConnectionState.Open)
                    {
                        connsql.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            dangNhap();
        }
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool CheckTextBoxes()
        {
            // Lấy tất cả các TextBox trên form
            var textBoxes = this.Controls.OfType<TextBox>();

            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Focus();
                    return false;
                }
            }
            return true;
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                dangNhap();
            }
        }

        private void checkBox_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_showPassword.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
