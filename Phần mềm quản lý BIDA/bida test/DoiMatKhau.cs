using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace bida_test
{
    public partial class DoiMatKhauNhanVien : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;

        private int employeeId;

        public DoiMatKhauNhanVien(int employeeId)
        {
            connsql = kn.conn;
            InitializeComponent();
            this.employeeId = employeeId;
            LoadEmployeeAccount(employeeId);
        }

        private void LoadEmployeeAccount(int employeeId)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"SELECT TENTAIKHOAN, MATKHAU 
                                 FROM TAIKHOAN_NHANVIEN 
                                 WHERE MANHANVIEN = @MANHANVIEN";

                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    cmd.Parameters.AddWithValue("@MANHANVIEN", employeeId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTenTaiKhoan_NhanVien.Text = reader["TENTAIKHOAN"].ToString();
                            txtMKCu_NhanVien.Text = reader["MATKHAU"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }

        private void btnSuaMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void UpdateEmployeePassword(int employeeId, string newPassword)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"
                    UPDATE TAIKHOAN_NHANVIEN 
                    SET MATKHAU = @MATKHAU 
                    WHERE MANHANVIEN = @MANHANVIEN";

                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    cmd.Parameters.AddWithValue("@MATKHAU", newPassword);
                    cmd.Parameters.AddWithValue("@MANHANVIEN", employeeId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }

        private void btnDoiMKNhanVien_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTenTaiKhoan_NhanVien.Text;
            string matKhauMoi = txtMKMoi_NhanVien.Text;

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateEmployeePassword(employeeId, matKhauMoi);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtTenTaiKhoan_NhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selectionStart = txtTenTaiKhoan_NhanVien.SelectionStart;


            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập chữ cái, số  và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectionStart == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập khoảng trắng ở đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == ' ' && selectionStart > 0 && txtTenTaiKhoan_NhanVien.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtMKCu_NhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selectionStart = txtMKCu_NhanVien.SelectionStart;


            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập chữ cái, số, @ ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectionStart == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == ' ' && selectionStart > 0 && txtMKCu_NhanVien.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtMKMoi_NhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selectionStart = txtMKMoi_NhanVien.SelectionStart;


            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập chữ cái, số, @ ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectionStart == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == ' ' && selectionStart > 0 && txtMKMoi_NhanVien.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
