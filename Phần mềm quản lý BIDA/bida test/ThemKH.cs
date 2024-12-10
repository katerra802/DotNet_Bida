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
    public partial class ThemKH : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;

        public ThemKH()
        {
            InitializeComponent();
            connsql = kn.conn;
            CenterToScreen();
        }
        
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            if (Kiemtra_textboxRong())
            {
                try
                {
                    if(txtSdt.Text.Length != 10)
                    {
                        MessageBox.Show("Số điện thoại phải có 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if(kn.checkExist("KHACHHANG", "SODIENTHOAI", txtSdt.Text))
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (connsql.State == ConnectionState.Closed)
                    {
                        connsql.Open();
                    }

                    

                    string queryKH = @"INSERT INTO KHACHHANG (SODIENTHOAI, TENKHACHHANG, SOLANCHOI, MAUUDAI) VALUES (@SODIENTHOAI, @TENKHACHHANG, @SOLANCHOI, @MAUUDAI)";
                    SqlCommand cmdTHEM = new SqlCommand(queryKH, connsql);

                    cmdTHEM.Parameters.AddWithValue("@TENKHACHHANG", txtTenKhachHang.Text);
                    cmdTHEM.Parameters.AddWithValue("@SODIENTHOAi", txtSdt.Text);
                    cmdTHEM.Parameters.AddWithValue("@SOLANCHOI", 0);
                    cmdTHEM.Parameters.AddWithValue("@MAUUDAI", 2);

                    cmdTHEM.ExecuteNonQuery();

                    MessageBox.Show("Thêm khách hàng mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connsql.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool Kiemtra_textboxRong()
        {
            Guna.UI2.WinForms.Guna2TextBox[] textBoxes = { txtTenKhachHang, txtSdt };

            foreach (Guna.UI2.WinForms.Guna2TextBox tb in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

    }
}
