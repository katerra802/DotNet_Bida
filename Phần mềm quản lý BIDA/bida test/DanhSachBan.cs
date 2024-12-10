using MyLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bida_test
{
    public partial class DanhSachBan : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        private Button selectedButton = null;
        int maBan;
        int maDatBan;
        private resetIdentity _autoIncrementHelper;

        public DanhSachBan()
        {
            InitializeComponent();
            connsql = kn.conn;
            _autoIncrementHelper = new resetIdentity(kn.strConnect);
            setUpForm(false);
            lab_time.Text = DateTime.Now.ToString();
        }

        void setUpForm(bool state)
        {
            btnGoiDV.Enabled = state;
            btnThanhToan.Enabled = state;
            btnChuyenban.Enabled = state;

            txtEndTime.Enabled = state;
            txtStartTime.Enabled = state;
            cbChuyenBan.Enabled = state;
            cbGoimon.Enabled = state;
            SoluongDV.Enabled = state;
        }

        private void DanhSachBan_Load(object sender, EventArgs e)
        {
            load_comboBox_Ban();
            loadcombox_dichvu();
            LoadTableThanhToan();
        }

        private void LoabTableChuaThanhToan(string loaiKhuVuc = "", string loaiBan = "")
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LoadTable(string loaiKhuVuc = "", string loaiBan = "")
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = "SELECT BAN.MABAN, BAN.LOAIBAN, BAN.TRANGTHAI AS TRANGTHAI_BAN, KHUVUC.LOAIKHUVUC " +
                        "FROM BAN " +
                        "JOIN KHUVUC ON BAN.MAKHUVUC = KHUVUC.MAKHUVUC";


                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(loaiBan))
                {
                    conditions.Add($"BAN.LOAIBAN LIKE N'{loaiBan}'");
                }

                if (!string.IsNullOrEmpty(loaiKhuVuc))
                {
                    conditions.Add($"KHUVUC.LOAIKHUVUC LIKE N'{loaiKhuVuc}'");
                }

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(query, connsql);
                SqlDataReader reader = cmd.ExecuteReader();

                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Refresh();

                while (reader.Read())
                {
                    Button tableButton = new Button();
                    int maBan = (int)reader["MABAN"];
                    string trangThaiBan = reader["TRANGTHAI_BAN"].ToString();
                    string loaiBanText = reader["LOAIBAN"].ToString();


                    tableButton.Text = $"Bàn {maBan}\n{loaiBanText}\n{trangThaiBan}";
                    tableButton.Tag = maBan;
                    tableButton.Dock = DockStyle.Fill;

                    // Đổi màu nút theo trạng thái bàn
                    if (trangThaiBan == "Trống")
                    {
                        tableButton.BackColor = System.Drawing.Color.LightGray;
                    }
                    else if (trangThaiBan == "Đang chơi")
                    {
                        tableButton.BackColor = System.Drawing.Color.LawnGreen;
                    }
                    else if (trangThaiBan == "Đã đặt trước")
                    {
                        tableButton.BackColor = System.Drawing.Color.Orange;
                    }
                    else
                    {
                        tableButton.BackColor = System.Drawing.Color.Yellow;
                    }

                    tableButton.Click += new EventHandler(TableButton_Click);

                    tableLayoutPanel1.Controls.Add(tableButton);
                }

                reader.Close();

                connsql.Close();
                setUpForm(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LoadTableThanhToan(string loaiKhuVuc = "", string loaiBan = "")
        {
            try
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Refresh();
                LoadTable();
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"
                    SELECT BAN.MABAN, BAN.LOAIBAN,
                    KHUVUC.LOAIKHUVUC, 
                    DATBAN.NGAYDATBAN, 
                    CTDB.MABAN AS CTDB_MABAN, 
                    CTDB.TGBATDAU
                    FROM BAN
                    LEFT JOIN KHUVUC ON BAN.MAKHUVUC = KHUVUC.MAKHUVUC
                    LEFT JOIN CHITIETDATBAN CTDB ON BAN.MABAN = CTDB.MABAN
                    LEFT JOIN DATBAN ON CTDB.MADATBAN = DATBAN.MADATBAN
                    WHERE DATBAN.TRANGTHAI = N'Chưa thanh toán' AND TGKETTHUC < CAST(GETDATE() AS TIME)";   

                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(loaiBan))
                {
                    conditions.Add($"BAN.LOAIBAN LIKE N'{loaiBan}'");
                }

                if (!string.IsNullOrEmpty(loaiKhuVuc))
                {
                    conditions.Add($"KHUVUC.LOAIKHUVUC LIKE N'{loaiKhuVuc}'");
                }

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(query, connsql);
                SqlDataReader reader = cmd.ExecuteReader();

                

                while (reader.Read())
                {
                    Button tableButton = new Button();
                    int maBan = (int)reader["MABAN"];
                    string loaiBanText = reader["LOAIBAN"].ToString();
                    string ngayDatBan = reader["NGAYDATBAN"]?.ToString();
                    string tgBatDau = reader["TGBATDAU"]?.ToString();


                    tableButton.Text = $"Bàn {maBan}\n{loaiBanText}\n{"Chờ thanh toán"}";
                    tableButton.Tag = maBan;
                    tableButton.Dock = DockStyle.Fill;

                    tableButton.BackColor = System.Drawing.Color.Orange;

                    tableButton.Click += new EventHandler(TableButton_Click);

                    tableLayoutPanel1.Controls.Add(tableButton);
                }

                reader.Close();

                connsql.Close();
                setUpForm(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            maBan = (int)clickedButton.Tag;

            if(clickedButton.BackColor == System.Drawing.Color.Yellow)
                btn_huyDatBan.Visible = true;
            else 
                btn_huyDatBan.Visible = false;

            if (clickedButton.BackColor != System.Drawing.Color.LightGray)
            {
                setUpForm(true);
            }
            else
            {
                setUpForm(false);
            }
            LoadServicesForTable(maBan);
            time_ban(maBan);
            if (clickedButton != null)
                selectedButton = clickedButton;
        }
        private void LoadServicesForTable(int maBan)
        {
            bangCTDV_theoban.Rows.Clear();
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                SqlCommand cmd = new SqlCommand(@"SELECT DICHVU.TenDichVu, GIADICHVU.DonGia, CHITIETDICHVU.SoLuong
                                                  FROM CHITIETDICHVU
                                                  JOIN DICHVU ON CHITIETDICHVU.MaDichVu = DICHVU.MaDichVu
                                                  LEFT JOIN GIADICHVU ON DICHVU.MaDichVu = GIADICHVU.MaDichVu
                                                  WHERE CHITIETDICHVU.MaBan = @TableID", connsql);
                cmd.Parameters.AddWithValue("@TableID", maBan);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    bangCTDV_theoban.Rows.Add(row[0], row[1], row[2]);
                }
                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }

        }
        private void time_ban(int maBan)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qTime = @"SELECT TGBatDau, TGKetThuc FROM CHITIETDATBAN WHERE MaBan = @MaBan";

                SqlCommand cmd = new SqlCommand(qTime, connsql);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["TGBatDau"] != DBNull.Value)
                    {
                        TimeSpan startTime = (TimeSpan)reader["TGBatDau"];
                        txtStartTime.Text = startTime.ToString(@"hh\:mm\:ss");
                    }
                    else
                    {
                        txtStartTime.Text = "Chưa có";
                    }

                    if (reader["TGKetThuc"] != DBNull.Value)
                    {
                        TimeSpan endTime = (TimeSpan)reader["TGKetThuc"];
                        txtEndTime.Text = endTime.ToString(@"hh\:mm\:ss");
                    }
                    else
                    {
                        txtEndTime.Text = "Chưa kết thúc";
                    }
                }
                else
                {
                    txtStartTime.Text = "Chưa có";
                    txtEndTime.Text = "Chưa có";
                }

                reader.Close();
                connsql.Close();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }
        private void load_comboBox_Ban()
        {
            string querycb_ban = "SELECT MABAN FROM BAN WHERE TRANGTHAI = N'Trống'";
            LoadDataToComboBox(cbChuyenBan, querycb_ban, "MABAN", "MABAN");
        }
        private void loadcombox_dichvu()
        {
            string query = "SELECT MADICHVU, TENDICHVU FROM DICHVU";
            LoadDataToComboBox(cbGoimon, query, "TENDICHVU", "MADICHVU");
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

        private void tấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTableThanhToan();
        }

        private void lầu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoadTable("VIP");
        }

        private void caoCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoadTable("Cao cấp");
        }

        private void thườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoadTable("Thường");
        }

        private void lỗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTable("VIP", "Pool");
        }

        private void cromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTable("VIP", "Crom");
        }

        private void biToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTable("VIP", "Libre");
        }

        private void lỗToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadTable("Cao cấp", "Pool");
        }

        private void cromToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadTable("Cao cấp", "Crom");
        }

        private void libreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTable("Cao cấp", "Libre");
        }

        private void lỗToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadTable("Thường", "Pool");
        }

        private void cromToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadTable("Thường", "Crom");
        }

        private void libreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadTable("Thường", "Libre");

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            ThemBanMoi banMoi = new ThemBanMoi();
            banMoi.ShowDialog();

            LoadTableThanhToan();
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            if (selectedButton != null)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bàn " + selectedButton.Tag.ToString() + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int maBan = (int)selectedButton.Tag;
                    try
                    {
                        DBConnect db = new DBConnect();
                        if(db.checkCondition("select MABAN from BAN where MABAN = " + maBan + " AND TRANGTHAI = N'Đang chơi'"))
                            throw new Exception("Bàn đang có người chơi, không thể xóa!");

                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }
                        string qXoaban = @"DELETE FROM BAN WHERE MABAN = @MABAN";
                        SqlCommand cmdDelBan = new SqlCommand(qXoaban, connsql);

                        cmdDelBan.Parameters.AddWithValue("@MABAN", maBan);
                        int rowsAffected = cmdDelBan.ExecuteNonQuery();
                        if(rowsAffected > 0)
                        {
                            tableLayoutPanel1.Controls.Remove(selectedButton);
                            MessageBox.Show("Xóa bàn mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _autoIncrementHelper.ResetAutoIncrement("BAN", "MABAN");

                        connsql.Close();
                        LoadTableThanhToan();
                        setUpForm(false);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi");
                    }
                }
            }
            else
                MessageBox.Show("Chọn bàn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            if (maBan == 0) 
            {
                MessageBox.Show("Vui lòng chọn một bàn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                SuaBan suaBanForm = new SuaBan(maBan.ToString());
                suaBanForm.ShowDialog();

                LoadTableThanhToan();
                setUpForm(false);
            }    
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string maDatBanStr = GetMaDatBanFromMaBan(maBan);
                if (string.IsNullOrEmpty(maDatBanStr))
                {
                    MessageBox.Show("Bàn đang trống, không thể thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                maDatBan = int.Parse(maDatBanStr);
                if (string.IsNullOrEmpty(maDatBan.ToString()))
                {
                    MessageBox.Show("Bàn đang trống, không thể thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TimeSpan thoiGianKetThuc = DateTime.Now.TimeOfDay;

                //if (kn.getCount("SELECT COUNT(*) FROM CHITIETDATBAN WHERE DATEDIFF(HOUR, TGBATDAU, '" + thoiGianKetThuc + "') <= 1 AND MABAN = " + maBan) > 0)
                //{
                //    throw new Exception("Giờ kết thúc phải cách giờ mở bàn 1h");
                //}

                UpdateThoiGianKetThuc(maBan, thoiGianKetThuc);

                ThanhToan tt = new ThanhToan(maDatBan, maBan);
                tt.ShowDialog();

                LoadTableThanhToan();
                setUpForm(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetMaDatBanFromMaBan(int maBan)
        {
            using (SqlConnection connection = new SqlConnection(kn.strConnect))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MADATBAN FROM CHITIETDATBAN WHERE MABAN = @maBan";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@maBan", SqlDbType.Int).Value = maBan;

                        object result = cmd.ExecuteScalar();
                        connection.Close();
                        return result?.ToString(); // Trả về null nếu không có kết quả
                    }
                    
                }
                catch (SqlException ex)
                {
                    // Log lỗi cụ thể
                    Console.WriteLine($"Lỗi truy vấn SQL: {ex.Message}");
                    return null; // Hoặc tái ném ngoại lệ tùy theo yêu cầu
                }
                catch (Exception ex)
                {
                    // Log lỗi chung
                    Console.WriteLine($"Lỗi hệ thống: {ex.Message}");
                    return null;
                }
            }
        }
        private void UpdateThoiGianKetThuc(int maBan, TimeSpan thoiGianKetThuc)
        {
            using (SqlConnection connection = new SqlConnection(kn.strConnect))
            {
                try
                {
                    if (kn.getCount("SELECT Count(MADATBAN) FROM CHITIETDATBAN C JOIN BAN B ON C.MABAN = B.MABAN WHERE TGKETTHUC = '23:59:00' and C.MABAN = " + maBan) > 0)
                    {
                        connection.Open();

                        

                        string query = "UPDATE CHITIETDATBAN SET TGKETTHUC = @thoiGianKetThuc WHERE MABAN = @MABAN";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                            cmd.Parameters.AddWithValue("@MABAN", maBan);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật thời gian kết thúc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGoiDV_Click(object sender, EventArgs e)
        {
            if (maBan == 0)
            {
                MessageBox.Show("Vui lòng chọn một bàn để gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedService = cbGoimon.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedService))
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string checkStockQuery = @"SELECT SoLuong FROM DICHVU WHERE MaDichVu = @MaDichVu";
                SqlCommand checkStockCmd = new SqlCommand(checkStockQuery, connsql);
                checkStockCmd.Parameters.AddWithValue("@MaDichVu", selectedService);
                int currentStock = (int)checkStockCmd.ExecuteScalar();

                int remainingStock = currentStock - (int)SoluongDV.Value;
                if (remainingStock < 0)
                {
                    MessageBox.Show("Số lượng dịch vụ không đủ để gọi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra dịch vụ đã được gọi cho bàn này chưa
                string checkQuery = @"SELECT COUNT(*) FROM CHITIETDICHVU 
                      WHERE MaBan = @MaBan AND MaDichVu = @MaDichVu";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connsql);
                checkCmd.Parameters.AddWithValue("@MaBan", maBan);
                checkCmd.Parameters.AddWithValue("@MaDichVu", selectedService);
                int exists = (int)checkCmd.ExecuteScalar();

                // Nếu dịch vụ đã tồn tại, cập nhật số lượng
                if (exists > 0)
                {
                    string updateQuery = @"UPDATE CHITIETDICHVU 
                           SET SoLuong = SoLuong + @SoLuong
                           WHERE MaBan = @MaBan AND MaDichVu = @MaDichVu";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connsql);
                    updateCmd.Parameters.AddWithValue("@MaBan", maBan);
                    updateCmd.Parameters.AddWithValue("@MaDichVu", selectedService);
                    updateCmd.Parameters.AddWithValue("@SoLuong", (int)SoluongDV.Value);
                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật số lượng dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Nếu chưa tồn tại, thêm mới
                {
                    string insertQuery = @"INSERT INTO CHITIETDICHVU (MaBan, MaDatBan, MaDichVu, SoLuong) 
                           VALUES (@MaBan, @MaDatBan, @MaDichVu, @SoLuong)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, connsql);
                    insertCmd.Parameters.AddWithValue("@MaBan", maBan);
                    insertCmd.Parameters.AddWithValue("@MaDatBan", GetMaDatBanFromMaBan(maBan));
                    insertCmd.Parameters.AddWithValue("@MaDichVu", selectedService);
                    insertCmd.Parameters.AddWithValue("@SoLuong", (int)SoluongDV.Value);
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Gọi món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Trừ số lượng trong bảng DICHVU


                string deductQuery = @"UPDATE DICHVU 
                       SET SoLuong = @RemainingStock 
                       WHERE MaDichVu = @MaDichVu";
                SqlCommand deductCmd = new SqlCommand(deductQuery, connsql);
                deductCmd.Parameters.AddWithValue("@RemainingStock", remainingStock);
                deductCmd.Parameters.AddWithValue("@MaDichVu", selectedService);
                deductCmd.ExecuteNonQuery();

                // Cập nhật tình trạng của dịch vụ
                DichVu dv = new DichVu();
                string updatedTinhTrang = dv.XacDinhTinhTrang(remainingStock);

                string updateTinhTrangQuery = @"UPDATE DICHVU 
                                SET TINHTRANG = @TINHTRANG 
                                WHERE MaDichVu = @MaDichVu";
                SqlCommand updateTinhTrangCmd = new SqlCommand(updateTinhTrangQuery, connsql);
                updateTinhTrangCmd.Parameters.AddWithValue("@TINHTRANG", updatedTinhTrang);
                updateTinhTrangCmd.Parameters.AddWithValue("@MaDichVu", selectedService);
                updateTinhTrangCmd.ExecuteNonQuery();

                connsql.Close();

                // Tải lại danh sách dịch vụ cho bàn (nếu cần)
                LoadServicesForTable(maBan);
                SoluongDV.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTrangThaiBan(string maBanMoi, int maBanCu)
        {
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = "UPDATE BAN SET TRANGTHAI = N'Trống' WHERE MABAN = @MaBanCu; " +
                               "UPDATE BAN SET TRANGTHAI = N'Đang chơi' WHERE MABAN = @MaBanMoi";
                using (SqlCommand cmd = new SqlCommand(query, connsql))
                {
                    cmd.Parameters.AddWithValue("@MaBanCu", maBanCu);
                    cmd.Parameters.AddWithValue("@MaBanMoi", maBanMoi);
                    cmd.ExecuteNonQuery();
                }

                var nutBanCu = LayNutBanTheoId(maBanCu.ToString());
                if (nutBanCu != null)
                {
                    CapNhatTrangThaiNutBan(nutBanCu, "Trống");
                }

                var nutBanMoi = LayNutBanTheoId(maBanMoi);
                if (nutBanMoi != null)
                {
                    CapNhatTrangThaiNutBan(nutBanMoi, "Đang chơi");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái bàn trong SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }
        // Cập nhật trạng thái hiển thị của nút bàn
        private void CapNhatTrangThaiNutBan(Button nutBan, string trangThai)
        {
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }
            if (trangThai == "Trống")
            {
                nutBan.Text = "Trống";
                nutBan.BackColor = System.Drawing.Color.LightGray;  // Màu xám nhạt để biểu thị bàn trống
            }
            else if (trangThai == "Đang chơi")
            {
                nutBan.Text = "Đang chơi";
                nutBan.BackColor = System.Drawing.Color.LawnGreen;    // Màu xanh để biểu thị bàn đang có người
            }

        }

        private Button LayNutBanTheoId(string maBan)
        {
            return tableLayoutPanel1.Controls.OfType<Button>().FirstOrDefault(btn => btn.Tag?.ToString() == maBan);
        }


        // Lấy thông tin phiên hiện tại của bàn đã chọn
        private dynamic LayThongTinPhien(int maBan)
        {
            // Kiểm tra và mở kết nối nếu chưa mở
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }

            string query = "SELECT MADATBAN, TGBATDAU, TGKETTHUC FROM CHITIETDATBAN WHERE MABAN = @MaBan";
            using (SqlCommand cmd = new SqlCommand(query, connsql))
            {
                cmd.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    // Thực thi câu lệnh SQL và đọc dữ liệu
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new
                            {
                                MADATBAN = reader["MADATBAN"],
                                TGBATDAU = reader["TGBATDAU"],
                                TGKETTHUC = reader["TGKETTHUC"]
                            };
                        }
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    if (connsql.State == ConnectionState.Open)
                    {
                        connsql.Close();
                    }
                }
            }

        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            if (maBan == 0)
            {
                MessageBox.Show("Vui lòng chọn một bàn để chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maBanMoi = cbChuyenBan.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maBanMoi))
            {
                MessageBox.Show("Vui lòng chọn bàn mới để chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra xem bàn mới đã có mã đặt bàn hay chưa
                var thongTinPhienBanMoi = LayThongTinPhien(int.Parse(maBanMoi));
                if (thongTinPhienBanMoi != null)
                {
                    MessageBox.Show("Bàn mới đang có người chơi. Không thể chuyển đến bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var thongTinPhienHienTai = LayThongTinPhien(maBan);
                if (thongTinPhienHienTai == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin phiên cho bàn cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra và mở kết nối nếu chưa mở
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                // Bước 2: Tăng số lượng bàn trong bảng DATBAN
                string query2 = "UPDATE DATBAN SET SOLUONGBAN = SOLUONGBAN + 1 WHERE MADATBAN = @MaDatBan";
                using (SqlCommand cmd2 = new SqlCommand(query2, connsql))
                {
                    cmd2.Parameters.AddWithValue("@MaDatBan", thongTinPhienHienTai.MADATBAN);
                    cmd2.ExecuteNonQuery();
                }

                // Bước 4: Cập nhật CHITIETDATBAN với mã bàn mới
                string query3 = "INSERT INTO CHITIETDATBAN (MADATBAN, MABAN, TGBATDAU, TGKETTHUC) VALUES (@MaDatBan, @MaBanMoi, @ThoiGianBatDau, @ThoiGianKetThuc)";
                using (SqlCommand cmd3 = new SqlCommand(query3, connsql))
                {
                    cmd3.Parameters.AddWithValue("@MaDatBan", thongTinPhienHienTai.MADATBAN);
                    cmd3.Parameters.AddWithValue("@MaBanMoi", maBanMoi);
                    cmd3.Parameters.AddWithValue("@ThoiGianBatDau", DateTime.Now.TimeOfDay);
                    cmd3.Parameters.AddWithValue("@ThoiGianKetThuc", DBNull.Value);
                    cmd3.ExecuteNonQuery();
                }

                ChuyenDichVu(maBanMoi, maBan);
                btnThanhToan_Click(sender, e);

                // Bước 6: Cập nhật trạng thái bàn
                CapNhatTrangThaiBan(maBanMoi, maBan);
                MessageBox.Show("Chuyển bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableThanhToan(); // Làm mới dữ liệu bàn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo kết nối được đóng
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
        }



        // Chuyển dịch vụ từ bàn cũ sang bàn mới
        private void ChuyenDichVu(string maBanMoi, int maBanCu)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string queryDichVu = "SELECT MADICHVU, MABAN, SOLUONG FROM CHITIETDICHVU WHERE MABAN = @MaBanCu";
                using (SqlCommand cmd = new SqlCommand(queryDichVu, connsql))
                {
                    cmd.Parameters.AddWithValue("@MaBanCu", maBanCu);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maDichVu = reader["MADICHVU"].ToString();
                            int soLuong = Convert.ToInt32(reader["SOLUONG"]);

                            ThemDichVuVaoBanMoi(maBanMoi, maDichVu, soLuong);
                        }
                    }
                    XoaTatCaDichVuTuBanCu(maBanCu);
                }
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm dịch vụ vào bàn mới
        private void ThemDichVuVaoBanMoi(string maBanMoi, string maDichVu, int soLuong)
        {
            try
            {
                string query = "SELECT MADATBAN FROM CHITIETDATBAN WHERE MABAN = @MaBanMoi";
                SqlCommand cmd = new SqlCommand(query, connsql);
                cmd.Parameters.AddWithValue("@MaBanMoi", maBanMoi);

                object madatbanObj = cmd.ExecuteScalar();
                if (madatbanObj == null)
                {
                    MessageBox.Show("Không tìm thấy mã đặt bàn cho bàn mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string madatban = madatbanObj.ToString();

                string insertQuery = "INSERT INTO CHITIETDICHVU (MABAN, MADICHVU, SOLUONG, MADATBAN) VALUES (@MaBanMoi, @MaDichVu, @SoLuong, @MaDatBan)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connsql);
                insertCmd.Parameters.AddWithValue("@MaBanMoi", maBanMoi);
                insertCmd.Parameters.AddWithValue("@MaDichVu", maDichVu);
                insertCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                insertCmd.Parameters.AddWithValue("@MaDatBan", madatban);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ vào bàn mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa tất cả dịch vụ khỏi bàn cũ
        private void XoaTatCaDichVuTuBanCu(int maBanCu)
        {
            try
            {
                string deleteQuery = "DELETE FROM CHITIETDICHVU WHERE MABAN = @MaBanCu";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connsql))
                {
                    cmd.Parameters.AddWithValue("@MaBanCu", maBanCu);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dịch vụ khỏi bàn cũ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btn_huyDatBan_Click(object sender,  EventArgs e)
        {
            DBConnect db = new DBConnect();
            db.updateToDataBase("DELETE CHITIETDATBAN WHERE MABAN = " + maBan);
            db.updateToDataBase("UPDATE BAN SET TRANGTHAI = N'Trống' WHERE MABAN = " + maBan);
            LoadTableThanhToan();
        }

        int count = 60 - Convert.ToInt32(DateTime.Now.Second) - 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lab_time.Text = DateTime.Now.ToString();
            if (count == 0)
            {
                count = 60;
                connsql.Open();
                try
                {
                    if (connsql.State == ConnectionState.Closed)
                    {
                        connsql.Open();
                    }


                    SqlCommand cmd = new SqlCommand("AUTO_UPDATE_STATE_DANGCHOI", connsql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("AUTO_UPDATE_STATE_TRONG", connsql);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.ExecuteNonQuery();

                    connsql.Close();    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                LoadTableThanhToan();
            }
            else
            {
                count--;
            }
        }
    }
    
}
