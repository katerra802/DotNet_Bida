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
    public partial class SuaKH : Form
    {
        

        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        string maKH;
        public SuaKH(string maKH)
        {
            InitializeComponent();
            connsql = kn.conn;
            this.maKH = maKH;
            LoadKHDetails();
            txtmaKH.ReadOnly = true;
            CenterToScreen();
        }
        
        
        private void LoadKHDetails()
        {
            string query = "SELECT * FROM KHACHHANG WHERE MAKHACHHANG = @MAKHACHHANG";
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                SqlCommand cmd = new SqlCommand(query, connsql);
                cmd.Parameters.AddWithValue("@MAKHACHHANG", maKH);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtmaKH.Text = reader["MAKHACHHANG"].ToString();
                    txtSoDienThoai.Text = reader["SODIENTHOAI"].ToString();
                    txtTenKhachHang.Text = reader["TENKHACHHANG"].ToString();
                    txtSoLanChoi.Text = reader["SOLANCHOI"].ToString();
                    txtMaUD.Text = reader["MAUUDAI"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connsql.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (kiemtra_nhapTT(this))
            {
                
               try
               {
                    if (connsql.State == ConnectionState.Closed)
                    {
                        connsql.Open();
                    }

                    string queryKH = @"UPDATE KHACHHANG SET SODIENTHOAI = @SODIENTHOAI, TENKHACHHANG = @TENKHACHHANG WHERE MAKHACHHANG = @MAKHACHHANG";
                    SqlCommand cmdUPDATE = new SqlCommand(queryKH, connsql);

                    cmdUPDATE.Parameters.AddWithValue("@SODIENTHOAI", txtSoDienThoai.Text);
                    cmdUPDATE.Parameters.AddWithValue("@TENKHACHHANG", txtTenKhachHang.Text);
                    cmdUPDATE.Parameters.AddWithValue("@MAKHACHHANG", txtmaKH.Text);
                        
                    cmdUPDATE.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

               }
               catch (SqlException sqlEx)
               {
                        MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
               }
               catch (Exception ex)
               {
                        MessageBox.Show("Lỗi: " + ex.Message);
               }
               finally
               {
                    if (connsql.State == ConnectionState.Open)
                    {
                    connsql.Close();
                    }
               }
                
                
            }
            else
                MessageBox.Show("Vui lòng nhập đủ các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool kiemtra_nhapTT(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = (TextBox)ctrl;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("TextBox '" + textBox.Name + "' không được để trống.");
                        textBox.Focus();
                        return false;
                    }
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)ctrl;
                    if (comboBox.SelectedIndex == -1)
                    {
                        MessageBox.Show("ComboBox '" + comboBox.Name + "' chưa được chọn.");
                        comboBox.Focus();
                        return false;
                    }
                }
                else if (ctrl.HasChildren)
                {
                    if (!kiemtra_nhapTT(ctrl))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void txtSoLanChoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
    }
}
