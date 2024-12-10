using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace bida_test
{
    public partial class SuaBan : Form
    {
        string maGiaBanCu;
        string maKhuVucCu;
        string loaiBanCu;
        string trangThaiBanCu;

        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        string maBan;
        public SuaBan(string maBan)
        {
            InitializeComponent();
            connsql = kn.conn;
            LoadMaGiaBanComboBox();
            LoadKhuVucComboBox();
            LoadLoaiBanComboBox();
            this.maBan = maBan;
            LoadTableDetails();
            txtMaBan.ReadOnly = true;
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
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
            LoadDataToComboBox(cbMagiaBan, query, "TENGIA", "MAGIABAN");
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
        private void LoadTableDetails()
        {
            string query = "SELECT * FROM BAN WHERE MABAN = @MABAN";
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                SqlCommand cmd = new SqlCommand(query, connsql);
                cmd.Parameters.AddWithValue("@MABAN", maBan);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtMaBan.Text = reader["MABAN"].ToString();
                    cbMagiaBan.SelectedValue = reader["MAGIABAN"].ToString();
                    cmbKhuVuc.SelectedValue = reader["MAKHUVUC"].ToString();
                    cmbLoaiBan.SelectedValue = reader["LOAIBAN"].ToString();
                    txtTrangThai.Text = reader["TRANGTHAI"].ToString();
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

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            bool isChanged = false;

            string maGiaBanMoi = cbMagiaBan.SelectedValue?.ToString();
            string maKhuVucMoi = cmbKhuVuc.SelectedValue?.ToString();
            string loaiBanMoi = cmbLoaiBan.SelectedValue?.ToString();
            string trangThaiMoi = txtTrangThai.Text; 

            if (maGiaBanMoi != maGiaBanCu || loaiBanMoi != loaiBanCu || trangThaiBanCu != trangThaiMoi || maKhuVucCu != maKhuVucMoi)
            {
                isChanged = true;
            }
            if (kiemtra_nhapTT(this))
            {
                if (isChanged)
                {
                    try
                    {
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }

                        string updateQuery = @"UPDATE BAN SET 
                            MAGIABAN = @GiaBan, 
                            MAKHUVUC = @KhuVuc, 
                            LOAIBAN = @LoaiBan, 
                            TRANGTHAI = @TrangThai 
                           WHERE MABAN = @MaBan";
                        SqlCommand cmd = new SqlCommand(updateQuery, connsql);

                        cmd.Parameters.AddWithValue("@GiaBan", maGiaBanMoi);
                        cmd.Parameters.AddWithValue("@KhuVuc", maKhuVucMoi);
                        cmd.Parameters.AddWithValue("@LoaiBan", loaiBanMoi);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                        cmd.Parameters.AddWithValue("@MaBan", maBan);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!");

                            maGiaBanCu = maGiaBanMoi;
                            maKhuVucCu = maKhuVucMoi;
                            loaiBanCu = loaiBanMoi;
                            trangThaiBanCu = trangThaiMoi;
                        }
                        else
                        {
                            MessageBox.Show("Không có thay đổi nào được thực hiện.");
                        }
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
                {
                    MessageBox.Show("Không có thay đổi nào để cập nhật.");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void SuaBan_Load(object sender, EventArgs e)
        {
            maGiaBanCu = cbMagiaBan.SelectedValue.ToString();
            maKhuVucCu = cmbKhuVuc.SelectedValue.ToString();
            loaiBanCu = cmbLoaiBan.SelectedValue.ToString();
            trangThaiBanCu = txtTrangThai.ToString();
        }
        private bool kiemtra_nhapTT(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)ctrl;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("TextBox '" + textBox.Name + "' không được để trống.");
                        textBox.Focus();
                        return false;
                    }
                }
                else if (ctrl is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)ctrl;
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

    }
}
