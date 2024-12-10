using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bida_test
{
    public partial class Gia : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        private resetIdentity _autoIncrementHelper;
        public Gia()
        {
            InitializeComponent();
            connsql = kn.conn;
            load_giaBan();
            load_giaDV();
            load_cbb_dv();
            _autoIncrementHelper = new resetIdentity(kn.strConnect);
        }
        private void load_giaBan()
        {
            bangGiaBan.Rows.Clear();
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qDV = @"SELECT * FROM GIABAN";

                SqlCommand cmd = new SqlCommand(qDV, connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    bangGiaBan.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
                }

                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.Message);
            }
        }
        private void load_giaDV()
        {
            bangGiaDV.Rows.Clear(); 
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qDV = @"SELECT * FROM GIADICHVU";

                SqlCommand cmd = new SqlCommand(qDV, connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    bangGiaDV.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
                }
                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.Message);
            }
        }

        private void bangGiaBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = bangGiaBan.Rows[e.RowIndex];

                txtTenGia.Text = selectedRow.Cells[1].Value.ToString();
                mtxtNgayBDban.Text = selectedRow.Cells[2].Value.ToString();
                mtxtNgayKTban.Text = selectedRow.Cells[3].Value.ToString();
                txtDongia.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void bangGiaDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = bangGiaDV.Rows[e.RowIndex];

                cbDV.SelectedValue = selectedRow.Cells[0].Value.ToString();
                mtxtNgayBDdv.Text = selectedRow.Cells[2].Value.ToString();    
                mtxtNgayKTdv.Text = selectedRow.Cells[3].Value.ToString();
                txtdongiadv.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
        private void load_cbb_dv()
        {
            string query = "SELECT MADICHVU, TENDICHVU FROM DICHVU";
            LoadDataToComboBox(cbDV, query, "TENDICHVU", "MADICHVU");
        }
        private void LoadDataToComboBox(Guna2ComboBox comboBox, string query, string displayMember, string valueMember)
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

        private void btnThemGiaBan_Click(object sender, EventArgs e)
        {
            bool isValid = KiemTraRong(txtTenGia, mtxtNgayBDban, mtxtNgayKTban, txtDongia);

            if (isValid)
            {
                try
                {
                    if (connsql.State == ConnectionState.Closed)
                    {
                        connsql.Open();
                    }

                    string queryDV = @"INSERT INTO GIABAN (TENGIA, NGAYBATDAU, NGAYKETTHUC, DONGIA) VALUES (@TENGIA, @NGAYBATDAU, @NGAYKETTHUC, @DONGIA)";
                    SqlCommand cmdTHEM = new SqlCommand(queryDV, connsql);

                    // Add parameters
                    cmdTHEM.Parameters.AddWithValue("@TENGIA", txtTenGia.Text);

                    // Handle nullable and invalid date fields
                    DateTime ngayBatDau;
                    if (DateTime.TryParse(mtxtNgayBDban.Text, out ngayBatDau))
                    {
                        cmdTHEM.Parameters.AddWithValue("@NGAYBATDAU", ngayBatDau);
                    }
                    else
                    {
                        cmdTHEM.Parameters.AddWithValue("@NGAYBATDAU", DBNull.Value);
                    }

                    DateTime ngayKetThuc;
                    if (DateTime.TryParse(mtxtNgayKTban.Text, out ngayKetThuc))
                    {
                        cmdTHEM.Parameters.AddWithValue("@NGAYKETTHUC", ngayKetThuc);
                    }
                    else
                    {
                        cmdTHEM.Parameters.AddWithValue("@NGAYKETTHUC", DBNull.Value);
                    }

                    cmdTHEM.Parameters.AddWithValue("@DONGIA", txtDongia.Text);

                    // Execute the query
                    cmdTHEM.ExecuteNonQuery();
                    MessageBox.Show("Thêm giá bàn mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connsql.Close();

                    // Reload data
                    load_giaBan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        //private void btnXoaGiaban_Click(object sender, EventArgs e)
        //{
        //    if (bangGiaBan.CurrentRow != null)
        //    {
        //        try
        //        {
        //            if (connsql.State == ConnectionState.Closed)
        //            {
        //                connsql.Open();
        //            }
        //            string query = "DELETE FROM GIABAN WHERE MAGIABAN = @MAGIABAN";

        //            var r = MessageBox.Show("Có chắn chắn muốn xóa.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

        //            if (r == DialogResult.Yes)
        //            {
        //                SqlCommand cmd = new SqlCommand(query, connsql);

        //                cmd.Parameters.AddWithValue("@MAGIABAN", int.Parse(bangGiaBan.CurrentRow.Cells[0].Value.ToString()));

        //                cmd.ExecuteNonQuery();
        //                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                _autoIncrementHelper.ResetAutoIncrement("GIABAN", "MAGIABAN");

        //                connsql.Close();
        //            }

        //            load_giaBan();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi: " + ex.Message);
        //        }
        //    }
        //}

        private void btnSuagiaban_Click(object sender, EventArgs e)
        {
            bool isValid = KiemTraRong(txtTenGia, txtDongia);

            if (isValid)
            {
                try
                {
                    if (bangGiaBan.CurrentRow != null)
                    {
                        int maGiaBan = int.Parse(bangGiaBan.CurrentRow.Cells[0].Value.ToString());
                        string tengia = txtTenGia.Text;
                        float donGia = float.Parse(txtDongia.Text);

                        DateTime? ngayBatDau = null;
                        DateTime? ngayKetThuc = null;

                        // Sử dụng TryParse để kiểm tra ngày tháng hợp lệ
                        if (DateTime.TryParse(mtxtNgayBDban.Text, out DateTime resultBD))
                        {
                            ngayBatDau = resultBD;
                        }

                        if (DateTime.TryParse(mtxtNgayKTban.Text, out DateTime resultKT))
                        {
                            ngayKetThuc = resultKT;
                        }

                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }

                        string query = @"UPDATE GIABAN 
                                 SET TENGIA = @TENGIA, NGAYBATDAU = @NGAYBATDAU, NGAYKETTHUC = @NGAYKETTHUC, DONGIA = @DONGIA 
                                 WHERE MAGIABAN = @MAGIABAN";

                        SqlCommand cmd = new SqlCommand(query, connsql);

                        // Thêm tham số vào câu lệnh
                        cmd.Parameters.AddWithValue("@TENGIA", tengia);
                        cmd.Parameters.AddWithValue("@DONGIA", donGia);
                        cmd.Parameters.AddWithValue("@MAGIABAN", maGiaBan);

                        // Kiểm tra và thêm ngày bắt đầu
                        if (ngayBatDau.HasValue)
                            cmd.Parameters.AddWithValue("@NGAYBATDAU", ngayBatDau.Value);
                        else
                            cmd.Parameters.AddWithValue("@NGAYBATDAU", DBNull.Value);

                        // Kiểm tra và thêm ngày kết thúc
                        if (ngayKetThuc.HasValue)
                            cmd.Parameters.AddWithValue("@NGAYKETTHUC", ngayKetThuc.Value);
                        else
                            cmd.Parameters.AddWithValue("@NGAYKETTHUC", DBNull.Value);

                        // Thực thi câu lệnh UPDATE
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        connsql.Close();

                        // Tải lại dữ liệu
                        load_giaBan();
                    }
                    else
                    {
                        MessageBox.Show("Chọn 1 giá dịch vụ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnThemgiaDV_Click(object sender, EventArgs e)
        {
            bool isValid = KiemTraRong(txtdongiadv);

            if (isValid)
            {
                if (cbDV.SelectedIndex != -1)
                {
                    int maDV = int.Parse(cbDV.SelectedValue.ToString());
                    float donGia = float.Parse(txtdongiadv.Text);

                    // Sử dụng TryParse để kiểm tra và chuyển đổi ngày
                    DateTime? ngayBatDau = null;
                    DateTime? ngayKetThuc = null;

                    if (DateTime.TryParse(mtxtNgayBDdv.Text, out DateTime resultBD))
                        ngayBatDau = resultBD;
                    if (DateTime.TryParse(mtxtNgayKTdv.Text, out DateTime resultKT))
                        ngayKetThuc = resultKT;

                    string query = "INSERT INTO GIADICHVU (MADICHVU, NGAYBATDAU, NGAYKETTHUC, DONGIA) VALUES (@MADICHVU, @NGAYBATDAU, @NGAYKETTHUC, @DONGIA)";

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connsql))
                        {
                            cmd.Parameters.AddWithValue("@MADICHVU", maDV);
                            cmd.Parameters.AddWithValue("@DONGIA", donGia);

                            // Thêm tham số ngày tháng
                            cmd.Parameters.AddWithValue("@NGAYBATDAU", ngayBatDau.HasValue ? (object)ngayBatDau.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@NGAYKETTHUC", ngayKetThuc.HasValue ? (object)ngayKetThuc.Value : DBNull.Value);

                            if (connsql.State == ConnectionState.Closed)
                            {
                                connsql.Open();
                            }

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm giá dịch vụ mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connsql.Close();
                        }

                        load_giaDV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Chọn 1 dịch vụ để thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        //private void btnXoagiaDV_Click(object sender, EventArgs e)
        //{
        //    if (bangGiaDV.CurrentRow != null)
        //    {
        //        int maGiaDV = int.Parse(bangGiaDV.CurrentRow.Cells[1].Value.ToString());
        //        string query = "DELETE FROM GIADICHVU WHERE MAGIADICHVU = @MAGIADICHVU";

        //        var r = MessageBox.Show("Có chắn chắn muốn xóa.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

        //        if (r == DialogResult.Yes)
        //        {

        //            using (SqlCommand cmd = new SqlCommand(query, connsql))
        //            {
        //                cmd.Parameters.AddWithValue("@MAGIADICHVU", maGiaDV);

        //                connsql.Open();
        //                cmd.ExecuteNonQuery();
        //                MessageBox.Show("Xóa giá dịch vụ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                _autoIncrementHelper.ResetAutoIncrement("GIADICHVU", "MAGIADICHVU");

        //                connsql.Close();
        //            }
        //        }
        //        load_giaDV(); 
        //    }
        //    else
        //        MessageBox.Show("Chọn 1 giá dịch vụ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        private void btnSuagiaDV_Click(object sender, EventArgs e)
        {
            bool isValid = KiemTraRong(txtdongiadv);

            if (isValid)
            {
                if (bangGiaDV.CurrentRow != null)
                {
                    int maGiaDV = int.Parse(bangGiaDV.CurrentRow.Cells[1].Value.ToString());
                    int maDV = int.Parse(cbDV.SelectedValue.ToString());
                    float donGia = float.Parse(txtdongiadv.Text);

                    // Sử dụng TryParse để kiểm tra và chuyển đổi ngày
                    DateTime? ngayBatDau = null;
                    DateTime? ngayKetThuc = null;

                    if (DateTime.TryParse(mtxtNgayBDdv.Text, out DateTime resultBD))
                        ngayBatDau = resultBD;
                    if (DateTime.TryParse(mtxtNgayKTdv.Text, out DateTime resultKT))
                        ngayKetThuc = resultKT;

                    try
                    {
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }

                        string query = "UPDATE GIADICHVU SET MADICHVU = @MADICHVU, NGAYBATDAU = @NGAYBATDAU, NGAYKETTHUC = @NGAYKETTHUC, DONGIA = @DONGIA WHERE MAGIADICHVU = @MAGIADICHVU";
                        SqlCommand cmd = new SqlCommand(query, connsql);

                        cmd.Parameters.AddWithValue("@MADICHVU", maDV);
                        cmd.Parameters.AddWithValue("@DONGIA", donGia);
                        cmd.Parameters.AddWithValue("@MAGIADICHVU", maGiaDV);

                        // Thêm tham số ngày tháng
                        cmd.Parameters.AddWithValue("@NGAYBATDAU", ngayBatDau.HasValue ? (object)ngayBatDau.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@NGAYKETTHUC", ngayKetThuc.HasValue ? (object)ngayKetThuc.Value : DBNull.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        connsql.Close();
                        load_giaDV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Chọn 1 giá dịch vụ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool KiemTraRong(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is Guna2TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show($"Vui lòng nhập giá trị cho {control.Name}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                    return false; // Trả về false nếu TextBox trống
                }
                else if (control is MaskedTextBox maskedTextBox && string.IsNullOrWhiteSpace(maskedTextBox.Text))
                {
                    MessageBox.Show($"Vui lòng nhập giá trị cho {control.Name}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox.Focus();
                    return false; // Trả về false nếu MaskedTextBox trống
                }
            }

            return true; // Trả về true nếu tất cả các trường đều có giá trị
        }
        private void txtdongiadv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void mtxtNgayKTban_Leave(object sender, EventArgs e)
        {
            DateTime ngayBatDau, ngayKetThuc;

            // Only proceed if both fields are not empty (since null checks are done in add/edit methods)
            if (!string.IsNullOrWhiteSpace(mtxtNgayBDban.Text) && !string.IsNullOrWhiteSpace(mtxtNgayKTban.Text))
            {
                // Parse and validate the dates
                bool isNgayBatDauValid = DateTime.TryParse(mtxtNgayBDban.Text, out ngayBatDau);
                bool isNgayKetThucValid = DateTime.TryParse(mtxtNgayKTban.Text, out ngayKetThuc);

                if (!isNgayBatDauValid || !isNgayKetThucValid)
                {
                    MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Compare dates: start date must be less than the end date
                if (ngayBatDau >= ngayKetThuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtNgayKTban.Focus();
                }
            }
        }

        private void mtxtNgayKTdv_Leave(object sender, EventArgs e)
        {
            DateTime ngayBatDau, ngayKetThuc;

            // Only proceed if both fields are not empty (since null checks are done in add/edit methods)
            if (!string.IsNullOrWhiteSpace(mtxtNgayBDdv.Text) && !string.IsNullOrWhiteSpace(mtxtNgayKTdv.Text))
            {
                // Parse and validate the dates
                bool isNgayBatDauValid = DateTime.TryParse(mtxtNgayBDdv.Text, out ngayBatDau);
                bool isNgayKetThucValid = DateTime.TryParse(mtxtNgayKTdv.Text, out ngayKetThuc);

                if (!isNgayBatDauValid || !isNgayKetThucValid)
                {
                    MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Compare dates: start date must be less than the end date
                if (ngayBatDau >= ngayKetThuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtNgayKTdv.Focus();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenGia.Clear();
            mtxtNgayBDban.Clear();
            mtxtNgayKTban.Clear();
            txtDongia.Clear();
            cbDV.SelectedIndex = 0;
            mtxtNgayBDdv.Clear();
            mtxtNgayKTdv.Clear();
            txtdongiadv.Clear();
        }
    }
}
