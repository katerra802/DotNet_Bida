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

namespace bida_test
{
    public partial class DangKy : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;

        public DangKy()
        {
            InitializeComponent();
            connsql = kn.conn;
            load_comboBox_MANV();
            CenterToScreen();

            ;       }
            //this.Hide();
            //DangNhap dangNhap = new DangNhap();
            //dangNhap.ShowDialog();

        private void btn_DK_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemtra_nhapTT(this))
                {
                    if (!kiemtraKhoa(txtbox_DK_TK.Text))
                    {
                        if (txtbox_DK_MK.Text == txtbox_DK_XacNhanMK.Text)
                        {

                            if (connsql.State == ConnectionState.Closed)
                            {
                                connsql.Open();
                            }

                            string querydk = @"INSERT INTO TAIKHOAN_NHANVIEN(TENTAIKHOAN, MATKHAU, MANHANVIEN, LOAITAIKHOAN) VALUES (@TENTAIKHOAN, @MATKHAU, @MANHANVIEN, @LOAITAIKHOAN)";
                            SqlCommand cmd = new SqlCommand(querydk, connsql);

                            cmd.Parameters.AddWithValue("@TENTAIKHOAN", txtbox_DK_TK.Text);
                            cmd.Parameters.AddWithValue("@MATKHAU", txtbox_DK_MK.Text);
                            cmd.Parameters.AddWithValue("@MANHANVIEN", int.Parse(cmbMaNV.SelectedItem.ToString()));
                            cmd.Parameters.AddWithValue("@LOAITAIKHOAN", cboChucVu.Text);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Đăng ký tài khoản mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            connsql.Close();
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Mật khẩu xác nhận không trùng với Mật khẩu.");
                        }
                    }
                    else
                    {
                        throw new Exception("Tài khoản đã tồn tại");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đẩy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void load_comboBox_MANV()
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string querycb_ban = @"SELECT MANHANVIEN FROM NhANVIEN";
                SqlCommand cmdcb = new SqlCommand(querycb_ban, connsql);
                SqlDataReader reader = cmdcb.ExecuteReader();

                cmbMaNV.Items.Clear();

                while (reader.Read())
                {
                    cmbMaNV.Items.Add(reader["MANHANVIEN"].ToString());
                }


                reader.Close();
                connsql.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private bool kiemtraKhoa(string keyValue)
        {
            DBConnect db = new DBConnect();
            return db.checkExist("TAIKHOAN_NHANVIEN", "TENTAIKHOAN", keyValue);
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
                        textBox.Focus();
                        return false;
                    }
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)ctrl;
                    if (comboBox.SelectedIndex == -1)
                    {
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
    }
}
