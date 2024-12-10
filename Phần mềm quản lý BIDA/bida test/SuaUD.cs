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
    public partial class SuaUD : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        public string TenUuDai { get; private set; }
        public string DieuKienUuDai { get; private set; }
        public float UuDai { get; private set; }


        private int UuDaiId; // Thêm biến để lưu ID nhân viên
        public SuaUD(int UuDaiId)
        {
            InitializeComponent();
            connsql = kn.conn;
            this.UuDaiId = UuDaiId; // Lưu ID nhân viên
            LoadEmployeeData(UuDaiId);
        }


        private void btnSuaUD_Click(object sender, EventArgs e)
        {

            TenUuDai = txtTenUD.Text;
            DieuKienUuDai = txtDieukienUD.Text;
            UuDai = float.Parse(txtUudai.Text.ToString());



            UpdateEmployeeData(UuDaiId); // Gọi phương thức cập nhật
            // Đóng form và trả về DialogResult.OK nếu thành công
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void LoadEmployeeData(int UuDaiId)
        {
            try
            {
                // Mở kết nối
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"SELECT TENUUDAI, DIEUKIENUUDAI, UUDAI
                         FROM UUDAIHOIVIEN 
                         WHERE MAUUDAI = @MAUUDAI";

                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    cmd.Parameters.AddWithValue("@MAUUDAI", UuDaiId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Gán dữ liệu vào các trường của form
                            txtTenUD.Text = reader["TENUUDAI"].ToString();
                            txtDieukienUD.Text = reader["DIEUKIENUUDAI"].ToString();
                            txtUudai.Text = reader["UUDAI"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy ưu đãi với ID đã cho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ưu đãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void UpdateEmployeeData(int UuDaiId)
        {
            try
            {
                // Mở kết nối nếu chưa mở
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"
                    UPDATE  UUDAIHOIVIEN
                    SET  TENUUDAI = @TENUUDAI, DIEUKIENUUDAI = @DIEUKIENUUDAI, UUDAI = @UUDAI 
                    WHERE MAUUDAI = @MAUUDAI";

                // Khởi tạo SqlCommand với câu truy vấn
                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    // Thêm các tham số vào câu lệnh SQL

                    cmd.Parameters.AddWithValue("@TENUUDAI", TenUuDai);
                    cmd.Parameters.AddWithValue("@DIEUKIENUUDAI", DieuKienUuDai);
                    cmd.Parameters.AddWithValue("@UUDAI", UuDai);

                    cmd.Parameters.AddWithValue("@MAUUDAI", UuDaiId);

                    // Thực thi câu lệnh cập nhật
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin ưu đãi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ưu đãi để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        private void SuaUD_Load(object sender, EventArgs e)
        {

        }

        private void txtTenUD_KeyPress(object sender, KeyPressEventArgs e)
        {

            int selectionStart = txtTenUD.SelectionStart;


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


            if (e.KeyChar == ' ' && selectionStart > 0 && txtTenUD.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDieukienUD_KeyPress(object sender, KeyPressEventArgs e)
        {

            int selectionStart = txtDieukienUD.SelectionStart;


            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập số và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectionStart == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập khoảng trắng ở đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == ' ' && selectionStart > 0 && txtDieukienUD.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtUudai_KeyPress(object sender, KeyPressEventArgs e)
        {

            int selectionStart = txtDieukienUD.SelectionStart;


            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b' && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập số và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == '.' && txtDieukienUD.Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được phép nhập một dấu chấm thập phân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectionStart == 0 && e.KeyChar == ' ' && e.KeyChar == '.')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập khoảng trắng ở đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (e.KeyChar == ' ' && e.KeyChar == '.' && selectionStart > 0 && txtDieukienUD.Text[selectionStart - 1] == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập nhiều khoảng trắng liên tiếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
