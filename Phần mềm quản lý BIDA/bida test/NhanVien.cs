using MyLibrary;
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
    public partial class NhanVien : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        private resetIdentity _autoIncrementHelper;
        public NhanVien()
        {
            InitializeComponent();
            connsql = kn.conn;
            Loadgv_NhanVien();
            _autoIncrementHelper = new resetIdentity(kn.strConnect);
        }
        private void Loadgv_NhanVien()
        {

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                // Xóa dữ liệu cũ trong DataGridView trước khi tải dữ liệu mới
                DataGridView_NhanVien.Rows.Clear();

                // Truy vấn dữ liệu từ cơ sở dữ liệu
                string query = "SELECT * FROM NHANVIEN";
                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Thêm từng dòng dữ liệu mới vào DataGridView
                        while (reader.Read())
                        {
                            DataGridView_NhanVien.Rows.Add(
                                reader["MANHANVIEN"],
                                reader["HOTEN"],
                                reader["THANHPHO"],
                                reader["GMAIL"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối sau khi hoàn tất
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }
        private void LoadPasswords(int employeeId)
        {
            // Lấy danh sách tài khoản và mật khẩu của nhân viên từ cơ sở dữ liệu
            var passwords = GetPasswords_NhanVien(employeeId);
        }
        public DataTable GetPasswords_NhanVien(int MaNv)
        {
            DataGridView_TaiKhoanNhanVien.Rows.Clear();
            // Tạo DataTable để chứa dữ liệu lấy được
            DataTable dtPasswords = new DataTable();


            // Câu truy vấn SQL để lấy danh sách tài khoản và mật khẩu dựa vào MaNv
            string query = "SELECT TENTAIKHOAN, MATKHAU, LOAITAIKHOAN FROM TAIKHOAN_NHANVIEN WHERE MANHANVIEN = @MaNv";

            // Sử dụng kết nối tới cơ sở dữ liệu

            // Mở kết nối


            // Tạo đối tượng SqlCommand để thực hiện truy vấn
            using (SqlCommand cmd = new SqlCommand(query, connsql))
            {
                // Thêm tham số cho câu lệnh SQL
                cmd.Parameters.AddWithValue("@MaNv", MaNv);

                // Tạo SqlDataAdapter để điền dữ liệu vào DataTable
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Điền dữ liệu từ cơ sở dữ liệu vào DataTable
                    da.Fill(dtPasswords);
                    foreach (DataRow row in dtPasswords.Rows)
                    {
                        DataGridView_TaiKhoanNhanVien.Rows.Add(row[0], row[1], row[2]);
                    }
                }
            }

            // Trả về DataTable chứa danh sách tài khoản và mật khẩu
            return dtPasswords;
        }


        private void DataGridView_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉ số hàng hợp lệ (không nhấp vào header hoặc vùng trống)
            if (e.RowIndex >= 0)
            {
                // Lấy EmployeeID của nhân viên được chọn
                int employeeId = Convert.ToInt32(DataGridView_NhanVien.Rows[e.RowIndex].Cells["MANHANVIEN"].Value);

                // Gọi phương thức LoadPasswords để hiển thị tài khoản và mật khẩu của nhân viên này
                LoadPasswords(employeeId);
            }
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            using (ThemNhanVien formThemNhanVien = new ThemNhanVien())
            {
                if (formThemNhanVien.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if(kn.checkExist("NHANVIEN", "GMAIL", formThemNhanVien.Email))
                        {
                            MessageBox.Show("Email đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // Kiểm tra nếu kết nối chưa mở, mới mở kết nối
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }

                        string qThemban = @"INSERT INTO NHANVIEN ( HOTEN, THANHPHO, GMAIL)
                            VALUES ( @HOTEN,  @THANHPHO, @GMAIL)";
                        SqlCommand cmdAddBan = new SqlCommand(qThemban, connsql);


                        cmdAddBan.Parameters.AddWithValue("@HOTEN", formThemNhanVien.HoTen);
                        cmdAddBan.Parameters.AddWithValue("@THANHPHO", formThemNhanVien.ThanhPho);
                        cmdAddBan.Parameters.AddWithValue("@GMAIL", formThemNhanVien.Email);

                        int rowsAffected = cmdAddBan.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhân viên mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loadgv_NhanVien(); // Tải lại dữ liệu nhân viên
                            //int newEmployeeId = GetLastInsertedEmployeeId(); // Phương thức lấy ID nhân viên vừa thêm
                            //AddAccountForEmployee(newEmployeeId, formThemNhanVien.TaiKhoan, formThemNhanVien.MatKhau); // Thêm tài khoản
                        }
                        else
                        {
                            MessageBox.Show("Không thêm được nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }

        //THÊM TÀI KHOẢN
        private int GetLastInsertedEmployeeId()
        {
            int lastId = 0;
            string query = "SELECT MAX(MANHANVIEN) FROM NHANVIEN"; // Giả sử MANHANVIEN là ID của nhân viên

            using (SqlCommand cmd = new SqlCommand(query, connsql))
            {
                // Mở kết nối nếu chưa mở
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                lastId = (int)cmd.ExecuteScalar(); // Lấy ID nhân viên vừa thêm
            }

            return lastId;
        }

        private void AddAccountForEmployee(int employeeId, string accountName, string password)
        {
            string query = "INSERT INTO TAIKHOAN_NHANVIEN (MANHANVIEN, TENTAIKHOAN, MATKHAU) VALUES (@MANHANVIEN, @TENTAIKHOAN, @MATKHAU)";

            using (SqlCommand command = new SqlCommand(query, connsql))
            {
                command.Parameters.AddWithValue("@MANHANVIEN", employeeId);
                command.Parameters.AddWithValue("@TENTAIKHOAN", accountName);
                command.Parameters.AddWithValue("@MATKHAU", password);

                // Mở kết nối và thực thi câu lệnh INSERT
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                command.ExecuteNonQuery(); // Thực thi câu lệnh INSERT
            }
        }

        //XÓA NHÂN VIÊN
        private void XoaTaiKhoan(int employeeId)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                if (Dashboard_backup.nhanVien_Class.tenDangNhap == DataGridView_NhanVien.SelectedRows[0].Cells[0].Value)
                    throw new Exception("Không thể xóa tài khoản đang đăng nhập");

                // Câu lệnh SQL để xóa tài khoản của nhân viên
                string query = "DELETE FROM TAIKHOAN_NHANVIEN WHERE MANHANVIEN = @MANV";

                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    cmd.Parameters.AddWithValue("@MANV", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }

        private void XoaNhanVien(int employeeId)
        {
            try
            {
                // Xóa tài khoản trước khi xóa nhân viên
                XoaTaiKhoan(employeeId);

                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                DBConnect db = new DBConnect();
                db.updateToDataBase("UPDATE DATBAN SET MANHANVIEN = 1 WHERE MANHANVIEN = " + employeeId);

                // Câu lệnh SQL để xóa nhân viên
                string query = "DELETE FROM NHANVIEN WHERE MANHANVIEN = @MANV";

                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    cmd.Parameters.AddWithValue("@MANV", employeeId);

                    // Thực thi câu lệnh DELETE
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa nhân viên và tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loadgv_NhanVien(); // Tải lại dữ liệu nhân viên
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên với ID đã cho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (DataGridView_NhanVien.SelectedRows.Count > 0)
                {
                    // Lấy ID của nhân viên được chọn
                    int employeeId = Convert.ToInt32(DataGridView_NhanVien.SelectedRows[0].Cells["MANHANVIEN"].Value);

                    if (Convert.ToInt32(Dashboard_backup.nhanVien_Class.idNhanVien) == employeeId)
                    {
                        throw new Exception("Không thể xóa nhân viên khi đang làm việc.");
                    }
                        // Gọi phương thức để xóa nhân viên và tài khoản
                        XoaNhanVien(employeeId);
                    DataGridView_TaiKhoanNhanVien.Rows.Clear();
                }
                else
                {
                    throw new Exception("Vui lòng chọn một nhân viên để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridView_NhanVien.SelectedRows.Count > 0) // Kiểm tra xem có hàng nào được chọn không
                {
                    // Lấy ID của nhân viên được chọn từ DataGridView
                    int employeeId = Convert.ToInt32(DataGridView_NhanVien.SelectedRows[0].Cells["MANHANVIEN"].Value);

                    // Mở form sửa thông tin nhân viên, truyền employeeId vào constructor
                    using (SuaThongTinNhanVien formSuaNhanVien = new SuaThongTinNhanVien(employeeId))
                    {
                        // Nếu người dùng nhấn OK sau khi sửa, tải lại dữ liệu
                        if (formSuaNhanVien.ShowDialog() == DialogResult.OK)
                        {
                            Loadgv_NhanVien(); // Tải lại dữ liệu sau khi sửa
                        }
                    }
                }
                else
                {
                    throw new Exception("Vui lòng chọn một nhân viên để sửa.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DataGridView_NhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra rằng hàng được chọn hợp lệ
            {
                int employeeId = Convert.ToInt32(DataGridView_NhanVien.Rows[e.RowIndex].Cells["MANHANVIEN"].Value);
                int selectedRowIndex = e.RowIndex; // Lưu lại vị trí dòng được chọn

                using (SuaThongTinNhanVien formSuaNhanVien = new SuaThongTinNhanVien(employeeId))
                {
                    if (formSuaNhanVien.ShowDialog() == DialogResult.OK)
                    {
                        // Tải lại dữ liệu nhân viên sau khi sửa
                        Loadgv_NhanVien();

                        // Đặt lại dòng được chọn
                        if (selectedRowIndex >= 0 && selectedRowIndex < DataGridView_NhanVien.Rows.Count)
                        {
                            DataGridView_NhanVien.Rows[selectedRowIndex].Selected = true;
                            DataGridView_NhanVien.FirstDisplayedScrollingRowIndex = selectedRowIndex; // Đảm bảo rằng dòng này được cuộn tới
                        }
                    }
                }
            }
        }

        private void btn_DoiMK_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridView_TaiKhoanNhanVien.SelectedRows.Count > 0) // Đảm bảo đã chọn một dòng
                {
                    int employeeId = Convert.ToInt32(DataGridView_NhanVien.SelectedRows[0].Cells["MANHANVIEN"].Value);


                    using (DoiMatKhauNhanVien formChangePassword = new DoiMatKhauNhanVien(employeeId))
                    {
                        if (formChangePassword.ShowDialog() == DialogResult.OK)
                        {
                            LoadPasswords(employeeId); // Tải lại mật khẩu sau khi đã cập nhật
                        }
                    }
                }
                else
                {
                    throw new Exception("Vui lòng chọn một tài khoản để đổi mật khẩu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_taoTaiKhoan_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.ShowDialog();
        }
    }
}
