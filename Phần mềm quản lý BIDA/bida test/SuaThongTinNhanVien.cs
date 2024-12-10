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

namespace bida_test
{

    public partial class SuaThongTinNhanVien : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;

        public string HoTen { get; private set; }
        public string ThanhPho { get; private set; }
        public string Email { get; private set; }

        private int employeeId; // Thêm biến để lưu ID nhân viên

        public SuaThongTinNhanVien(int employeeId)
        {
            connsql = kn.conn;
            InitializeComponent();
            this.employeeId = employeeId; // Lưu ID nhân viên
            LoadEmployeeData(employeeId);
        }

        private void LoadEmployeeData(int employeeId)
        {
            try
            {
                // Mở kết nối
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"SELECT HOTEN ,THANHPHO, GMAIL
                         FROM NHANVIEN 
                         WHERE NHANVIEN.MANHANVIEN = @MANHANVIEN";

                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    cmd.Parameters.AddWithValue("@MANHANVIEN", employeeId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Gán dữ liệu vào các trường của form
                            txtHoTen_NhanVien.Text = reader["HOTEN"].ToString();
                            txtTP_NhanVien.Text = reader["THANHPHO"].ToString();

                            txtEmail_NhanVien.Text = reader["GMAIL"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên với ID đã cho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo đóng kết nối sau khi hoàn tất
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {

            HoTen = txtHoTen_NhanVien.Text;
            ThanhPho = txtTP_NhanVien.Text;
            Email = txtEmail_NhanVien.Text;

            if(kn.checkExist("NHANVIEN", "GMAIL", Email))
            {
                MessageBox.Show("Email đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (
                string.IsNullOrWhiteSpace(HoTen) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateEmployeeData(employeeId); // Gọi phương thức cập nhật
            // Đóng form và trả về DialogResult.OK nếu thành công
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateEmployeeData(int employeeId)
        {
            try
            {
                // Mở kết nối nếu chưa mở
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"
                    UPDATE NHANVIEN 
                    SET  HOTEN = @HOTEN, THANHPHO = @THANHPHO, GMAIL = @GMAIL 
                    WHERE MANHANVIEN = @MANHANVIEN ";



                // Khởi tạo SqlCommand với câu truy vấn
                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    // Thêm các tham số vào câu lệnh SQL

                    cmd.Parameters.AddWithValue("@HOTEN", HoTen);

                    cmd.Parameters.AddWithValue("@THANHPHO", ThanhPho);
                    cmd.Parameters.AddWithValue("@GMAIL", Email);

                    cmd.Parameters.AddWithValue("@MANHANVIEN", employeeId);

                    // Thực thi câu lệnh cập nhật
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Đảm bảo đóng kết nối sau khi hoàn tất
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Dashboard_backup dashboard_Backup = new Dashboard_backup();
            dashboard_Backup.ShowDialog();
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
