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
    public partial class ThemBanMoi : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        public ThemBanMoi()
        {
            InitializeComponent();
            connsql = kn.conn;
            LoadMaGiaBanComboBox();
            LoadKhuVucComboBox();
            LoadLoaiBanComboBox();
            CenterToScreen();
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (kiemtra_nhapTT(this))
            {
                

                    try
                    {
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }
                        
                        string qThemban = @"INSERT INTO BAN (MAGIABAN, MAKHUVUC, LOAIBAN, TRANGTHAI) VALUES (@MAGIABAN, @MAKHUVUC, @LOAIBAN, @TRANGTHAI)";

                        SqlCommand cmdAddBan = new SqlCommand(qThemban, connsql);

                        cmdAddBan.Parameters.AddWithValue("@MAGIABAN", cmbMagiaBan.SelectedValue);
                        cmdAddBan.Parameters.AddWithValue("@MAKHUVUC", cmbKhuVuc.SelectedValue);
                        cmdAddBan.Parameters.AddWithValue("@LOAIBAN", cmbLoaiBan.SelectedValue.ToString());
                        cmdAddBan.Parameters.AddWithValue("@TRANGTHAI", txtTrangThai.Text);

                        cmdAddBan.ExecuteNonQuery();

                        MessageBox.Show("Thêm bàn mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        connsql.Close();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi" + ex.Message);
                    }
                    this.Close();

                
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void LoadLoaiBanComboBox()
        {
            string query = "SELECT DISTINCT LOAIBAN FROM BAN";
            LoadDataToComboBox(cmbLoaiBan, query, "LOAIBAN", "LOAIBAN");
        }
        private void LoadKhuVucComboBox()
        {
            string query = "SELECT DISTINCT MAKHUVUC, LOAIKHUVUC FROM KHUVUC";
            LoadDataToComboBox(cmbKhuVuc, query, "LOAIKHUVUC", "MAKHUVUC");
        }
        private void LoadMaGiaBanComboBox()
        {
            string query = "SELECT MAGIABAN, TENGIA FROM GIABAN";
            LoadDataToComboBox(cmbMagiaBan, query, "TENGIA", "MAGIABAN");
        }
        private void LoadDataToComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                SqlCommand cmd = new SqlCommand(query, connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox.DataSource = dt;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;

                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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

        private void txtTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép nhập chữ cái và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        
    }
}
