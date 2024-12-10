using MyLibrary;
using System;
using System.Collections;
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
    public partial class DichVu : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        private resetIdentity _autoIncrementHelper;

        public DichVu()
        {
            InitializeComponent();
            connsql = kn.conn;
            load_dv();
            _autoIncrementHelper = new resetIdentity(kn.strConnect);
        }
        private void load_dv()
        {
            bangDV1.Rows.Clear();
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qDV = @"SELECT * FROM DICHVU";

                SqlCommand cmd = new SqlCommand(qDV, connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    bangDV1.Rows.Add(row[0], row[1], row[2], row[3]);
                }
                bangDV1.ClearSelection();

                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Them_QLDV_Click(object sender, EventArgs e)
        {
            if (Kiemtra_textboxRong())
            {
                string tinhTrang = XacDinhTinhTrang(int.Parse(txtSoLuong.Text));

                try
                {
                    DBConnect dB = new DBConnect();
                    if (!dB.checkExist("DICHVU", "TENDICHVU", txtTenDichVu.Text)) throw new Exception("Dịch vụ đã có");
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }
                        
                        string queryDV = @"INSERT INTO DICHVU VALUES(@TENDICHVU, @TINHTRANG, @SOLUONG)";
                        SqlCommand cmdTHEM = new SqlCommand(queryDV, connsql);

                        cmdTHEM.Parameters.AddWithValue("@TENDICHVU", txtTenDichVu.Text);
                        cmdTHEM.Parameters.AddWithValue("@TINHTRANG", tinhTrang);
                        cmdTHEM.Parameters.AddWithValue("@SOLUONG", txtSoLuong.Text);

                        cmdTHEM.ExecuteNonQuery();

                        

                        MessageBox.Show("Thêm dịch vụ mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        connsql.Close();

                        load_dv();
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

        private void bangDV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = bangDV1.Rows[e.RowIndex];
                txtTenDichVu.Clear();
                txtSoLuong.Clear();
                txtTenDichVu.Text = selectedRow.Cells[1].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells[3].Value.ToString();
                btn_Them_QLDV.Enabled = false;
                txtTenDichVu.ReadOnly = true;   
            }
        }
        public string XacDinhTinhTrang(int soLuong)
        {
            if (soLuong > 10)
            {
                return "Đủ";
            }
            else if (soLuong > 0 && soLuong <= 9)
            {
                return "Sắp hết";
            }
            else 
            {
                return "Hết hàng";
            }
        }
        private bool Kiemtra_textboxRong()
        {
            Guna.UI2.WinForms.Guna2TextBox[] textBoxes = { txtTenDichVu, txtSoLuong };

            foreach (Guna.UI2.WinForms.Guna2TextBox tb in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    return false;
                }
            }
            return true;
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

        

        private void btn_Sua_QLDV_Click(object sender, EventArgs e)
        {
            if (bangDV1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = bangDV1.SelectedRows[0];
                string tinhTrang = XacDinhTinhTrang(int.Parse(txtSoLuong.Text));
                try
                {
                    if (connsql.State == ConnectionState.Closed)
                    {
                        connsql.Open();
                    }
                    

                    string queryUpdate = @"UPDATE DICHVU SET 
                                   TENDICHVU = @TENDICHVU, 
                                    TINHTRANG = @TINHTRANG,
                                    SOLUONG = @SOLUONG 
                                   WHERE MADICHVU = @MADICHVU";

                    
                     SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connsql);

                     cmdUpdate.Parameters.AddWithValue("@MADICHVU", selectedRow.Cells[0].Value.ToString());
                     cmdUpdate.Parameters.AddWithValue("@TENDICHVU", txtTenDichVu.Text);
                     cmdUpdate.Parameters.AddWithValue("@TINHTRANG", tinhTrang);
                     cmdUpdate.Parameters.AddWithValue("@SOLUONG", txtSoLuong.Text);

                     cmdUpdate.ExecuteNonQuery();
                     MessageBox.Show("Cập nhật thông tin dịch vụ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    connsql.Close();
                    load_dv();

                    txtTenDichVu.Clear();
                    txtSoLuong.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            else
                MessageBox.Show("Chọn 1 dịch vụ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txt_SoLuong_QLDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenDichVu.Clear();
            txtSoLuong.Clear();
            bangDV1.ClearSelection();
            btn_Them_QLDV.Enabled = true;
            txtTenDichVu.ReadOnly = false;
        }
    }
}
