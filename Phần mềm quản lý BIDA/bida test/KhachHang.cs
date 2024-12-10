using Guna.UI2.WinForms;
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
    public partial class KhachHang : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        private resetIdentity _autoIncrementHelper;
        int maKH = 0;
        int maUD = 0;
        public KhachHang()
        {
            InitializeComponent();
            connsql = kn.conn;
            load_kh();
            _autoIncrementHelper = new resetIdentity(kn.strConnect);
        }
        private void load_kh()
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qkh = @"SELECT * FROM KHACHHANG";

                SqlCommand cmd = new SqlCommand(qkh, connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    bangKH.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
                }

                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.Message);
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            ThemKH addkh = new ThemKH();
            addkh.ShowDialog();

            bangKH.DataSource = null;
            bangKH.Rows.Clear();
            load_kh();
        }

        private void bangKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = bangKH.Rows[e.RowIndex];
                maKH = Convert.ToInt32(selectedRow.Cells[0].Value);

                loadUuDai_theoKH(maKH);
            }
        }
        private void loadUuDai_theoKH(int maKH)
        {
            BangUudai.Rows.Clear();
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qUD = @"SELECT UD.MAUUDAI, UD.TENUUDAI, UD.DIEUKIENUUDAI, UD.UUDAI 
                       FROM UUDAIHOIVIEN AS UD
                       JOIN KHACHHANG AS KH ON UD.MAUUDAI = KH.MAUUDAI
                       WHERE KH.MAKHACHHANG = @MAKHACHHANG";
                SqlCommand cmd = new SqlCommand(qUD, connsql);

                cmd.Parameters.AddWithValue("@MAKHACHHANG", maKH);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    BangUudai.Rows.Add(row[0], row[1], row[2], row[3]);
                }
                connsql.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            if (bangKH.SelectedRows.Count > 0)
            {
                SuaKH sua = new SuaKH(maKH.ToString());
                sua.ShowDialog();

                bangKH.Rows.Clear();
                load_kh();
            }
            else
                MessageBox.Show("Chọn 1 khách hàng cần sửa thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {

            if (bangKH.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = bangKH.SelectedRows[0];

                var r = MessageBox.Show("Chắc chắn muốn xóa khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    try
                    {
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }
                        DBConnect db =  new DBConnect();
                        db.updateToDataBase("UPDATE DATBAN SET MAKHACHHANG = 1 WHERE MAKHACHHANG = " + selectedRow.Cells[0].Value.ToString());

                        string querryXoa = @"DELETE FROM KHACHHANG WHERE MAKHACHHANG = @MAKHACHHANG";
                        SqlCommand cmdXoa = new SqlCommand(querryXoa, connsql);

                        cmdXoa.Parameters.AddWithValue("@MAKHACHHANG", int.Parse(selectedRow.Cells[0].Value.ToString()));

                        cmdXoa.ExecuteNonQuery();

                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _autoIncrementHelper.ResetAutoIncrement("KHACHHANG", "MAKHACHHANG");

                        connsql.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 khách hàng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bangKH.Rows.Clear();
            load_kh();
        }

        private void btnThemUudai_Click(object sender, EventArgs e)
        {
            ThemUD addUD = new ThemUD();
            addUD.ShowDialog();

            btnLoadBangUD_Click(sender, e);
        }

        private void btnSuaUudai_Click(object sender, EventArgs e)
        {
            SuaUD sua = new SuaUD(maUD);
            sua.ShowDialog();

            btnLoadBangUD_Click(sender, e);
        }

        private void BangUudai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = BangUudai.Rows[e.RowIndex];
                maUD = Convert.ToInt32(selectedRow.Cells[0].Value);

                
            }
        }

        private void btnLoadBangUD_Click(object sender, EventArgs e)
        {
            BangUudai.Rows.Clear();
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qDV = @"SELECT * FROM UUDAIHOIVIEN";

                SqlCommand cmd = new SqlCommand(qDV, connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    BangUudai.Rows.Add(row[0], row[1], row[2], row[3]);
                }

                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaUD_Click(object sender, EventArgs e)
        {
            if (BangUudai.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = BangUudai.SelectedRows[0];
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa ưu đãi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }
                        string querryXoa = @"DELETE FROM UUDAIHOIVIEN WHERE MAUUDAI = @MAUUDAI";
                        SqlCommand cmdXoa = new SqlCommand(querryXoa, connsql);

                        cmdXoa.Parameters.AddWithValue("@MAUUDAI", selectedRow.Cells[0].Value.ToString());

                        cmdXoa.ExecuteNonQuery();
                        MessageBox.Show("Xóa 1 ưu đãi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _autoIncrementHelper.ResetAutoIncrement("UUDAIHOIVIEN", "MAUUDAI");

                        connsql.Close();

                        btnLoadBangUD_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message);
                    }
                }
            }
        }
    }
}

