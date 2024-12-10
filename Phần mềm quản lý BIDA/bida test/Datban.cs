using Microsoft.VisualStudio.Text.Tagging;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace bida_test
{
    
    public partial class Datban : Form
    {
        MyLibrary.DBConnect db = new MyLibrary.DBConnect();
        SqlConnection connsql;
        List<int> listDatBan = new List<int>();
        public Datban()
        {
            InitializeComponent();
            connsql = db.conn;
            LoadTable();
            LoadKHComboBox();
            LoadNVLabel();
            txt_ngayThaoTac.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadDatesToComboBox();
            lab_time.Text = DateTime.Now.ToString();
        }

        private void LoadNVLabel()
        {
            lab_nhanVien.Text = Dashboard_backup.nhanVien_Class.tenNhanVien;
        }
        private void LoadKHComboBox()
        {
            string query = "SELECT DISTINCT MAKHACHHANG, TENKHACHHANG FROM KHACHHANG";
            LoadDataToComboBox(cbMakh, query, "TENKHACHHANG", "MAKHACHHANG");
        }

        public void LoadTable(string loaiKhuVuc = "", string loaiBan = "")
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                // Lấy ngày hiện tại
                DateTime ngayHienTai = DateTime.Now.Date;

                // Truy vấn kết hợp với ngày hiện tại
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
                    query += " AND " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@NgayHienTai", ngayHienTai);

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

                    // Đổi màu theo trạng thái
                    if (trangThaiBan == "Trống")
                    {
                        tableButton.BackColor = System.Drawing.Color.LightGray;
                    }
                    else if (trangThaiBan == "Đang chơi")
                    {
                        tableButton.BackColor = System.Drawing.Color.LawnGreen;
                        //tableButton.Enabled = false;
                    }
                    else if (trangThaiBan == "Đã đặt")
                    {
                        tableButton.BackColor = System.Drawing.Color.Yellow;
                    }

                    tableButton.FlatStyle = FlatStyle.Flat;
                    tableButton.FlatAppearance.BorderColor = Color.LightGray;
                    tableButton.FlatAppearance.BorderSize = 3;

                    tableButton.Click += new EventHandler(TableButton_Click);

                    tableLayoutPanel1.Controls.Add(tableButton);
                }

                reader.Close();
                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void TableButton_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            Button clickedButton = (Button)sender;

            try
            {
                int maBan = (int)clickedButton.Tag;
                if (clickedButton != null)
                {
                    if (clickedButton.FlatAppearance.BorderColor == System.Drawing.Color.LightGray && clickedButton.BackColor == System.Drawing.Color.LawnGreen)
                    {
                        listDatBan.Add(maBan);
                        clickedButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
                        DataTable dt = db.GetDataTable("SELECT TGBATDAU, TGKETTHUC FROM CHITIETDATBAN C JOIN DATBAN D ON C.MADATBAN = D.MADATBAN WHERE NGAYDATBAN = CAST(GETDATE() AS DATE) AND TGBATDAU <= CAST(GETDATE() AS TIME) AND TGKETTHUC >= CAST(GETDATE() AS TIME) AND MABAN = " + maBan);
                        DataRow r = dt.Rows[0];
                        if (r != null)
                        {
                            lab_banBD.Text = r["TGBATDAU"].ToString();
                            lab_banKT.Text = r["TGKETTHUC"].ToString();
                        }
                        else
                        {
                            lab_banBD.Text = "Chưa có";
                            lab_banKT.Text = "Chưa có";
                        }
                    }
                    else if (clickedButton.FlatAppearance.BorderColor == System.Drawing.Color.LightGray)
                    {
                        
                        listDatBan.Add(maBan);
                        clickedButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
                    }
                    else if (clickedButton.FlatAppearance.BorderColor == System.Drawing.Color.Blue)
                    {
                        listDatBan.Remove(maBan);
                        clickedButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
                        lab_banBD.Text = "Chưa có";
                        lab_banKT.Text = "Chưa có";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
      

        private void ReloadDatBanTables(object sender, EventArgs e)
        {
            cbNgayDaDatBan.Controls.Clear();
            LoadTable();
        }
        
        
        private void LoadDataToComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            try
            {
                DataTable dt = db.GetDataTable(query);

                comboBox.DataSource = dt;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtSoLuongBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void datBan(DateTime ngayDatBan, string trangThai)
        {
            string query = "INSERT INTO DATBAN (SOLUONGBAN, MANHANVIEN, MAKHACHHANG, NGAYDATBAN, TRANGTHAI) VALUES (" + listDatBan.Count + ", " + Convert.ToInt32(Dashboard_backup.nhanVien_Class.idNhanVien) + ", " + Convert.ToInt32(cbMakh.SelectedValue) + ", '" + (ngayDatBan).ToString("yyyy/MM/dd") + "', N'" + trangThai + "')";
            db.updateToDataBase(query);
        }

        private void btn_MoBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDatBan.Count == 0)
                {
                    throw new Exception("Vui lòng chọn bàn cần mở.");
                }

                if(txt_ngayThaoTac.Text != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    throw new Exception("Chỉ được mở bàn vào thời gian hiện tại.");
                }

                if (txt_ngayThaoTac.Text == "")
                {
                    throw new Exception("Vui lòng chọn ngày đặt bàn.");
                }

                if (Convert.ToDateTime(txt_ngayThaoTac.Text) < DateTime.Now.Date)
                {
                    throw new Exception("Ngày đặt bàn không hợp lệ.");
                }

                foreach (Control item in tableLayoutPanel1.Controls)
                {
                    Button btn = item as Button;
                    if (btn.FlatAppearance.BorderColor == System.Drawing.Color.Blue && btn.BackColor == System.Drawing.Color.Yellow)
                    {
                        throw new Exception("Không thể mở bàn có lịch đặt.");
                    }
                    else if(btn.FlatAppearance.BorderColor == System.Drawing.Color.Blue && btn.BackColor == System.Drawing.Color.LawnGreen)
                    {
                        throw new Exception("Không thể mở bàn đang chơi.");
                    }
                }

                if (listDatBan.Count > 0)
                {
                    datBan(DateTime.Now, "Chưa thanh toán");
                    int idDatBan = db.getCount("SELECT MAX(MADATBAN) FROM DATBAN");
                    foreach (int maBan in listDatBan)
                    {
                        string query2 = "INSERT INTO CHITIETDATBAN values(" + idDatBan + ", " + maBan + ", '" + DateTime.Now.ToString("HH:mm") + "' , '23:59:00')";
                        db.updateToDataBase(query2);
                        db.updateToDataBase("UPDATE BAN SET TRANGTHAI = N'Đang chơi' WHERE MABAN = " + maBan);
                    }
                }
                listDatBan.Clear();
                LoadTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi ");
            }
        }

        private void btn_DatBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDatBan.Count == 0)
                {
                    throw new Exception("Vui lòng chọn bàn cần mở.");
                }

                if (listDatBan.Count > 0)
                {
                    datBan(Convert.ToDateTime(txt_ngayThaoTac.Text), "Chưa thanh toán");
                    int idDatBan = db.getCount("SELECT MAX(MADATBAN) FROM DATBAN");
                    Datban_class dBan = new Datban_class();
                    dBan.maDatBan = idDatBan;
                    dBan.ngayDat = Convert.ToDateTime(txt_ngayThaoTac.Text).ToString("yyyy/MM/dd");
                    foreach (int maBan in listDatBan)
                    {
                        dBan.maBan = maBan;
                        dBan.tenBan = "Bàn " + maBan;
                        XacNhanDatBan xacNhanDatBan = new XacNhanDatBan(dBan);
                        xacNhanDatBan.ShowDialog();
                    }
                    if (db.getCount("SELECT COUNT(*) FROM CHITIETDATBAN WHERE MADATBAN = " + idDatBan) == 0)
                    {
                        db.updateToDataBase("DELETE FROM DATBAN WHERE MADATBAN = " + idDatBan);
                    }
                }
                listDatBan.Clear();
                LoadTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi ");
            }
        }

        private void btnLoadbanDaDat_Click(object sender, EventArgs e)
        {
            string selectedDate = cbNgayDaDatBan.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDate))
            {
                MessageBox.Show("Vui lòng chọn ngày để hiển thị bàn!");
                return;
            }

            LoadTable_theongaydadat(selectedDate);
        }
        public void LoadDatesToComboBox()
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = "SELECT DISTINCT NGAYDATBAN FROM DATBAN ORDER BY NGAYDATBAN";
                SqlCommand cmd = new SqlCommand(query, connsql);
                SqlDataReader reader = cmd.ExecuteReader();

                cbNgayDaDatBan.Items.Clear();

                while (reader.Read())
                {
                    DateTime ngayDat = (DateTime)reader["NGAYDATBAN"];
                    cbNgayDaDatBan.Items.Add(ngayDat.ToString("yyyy-MM-dd")); // Định dạng ngày
                }

                reader.Close();
                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ngày: " + ex.Message);
            }
        }
        public void LoadTable_theongaydadat(string selectedDate, string loaiKhuVuc = "", string loaiBan = "")
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }

                string query = @"
            SELECT BAN.MABAN, BAN.LOAIBAN, BAN.TRANGTHAI AS TRANGTHAI_BAN, 
                   KHUVUC.LOAIKHUVUC, 
                   DATBAN.NGAYDATBAN, 
                   CTDB.MABAN AS CTDB_MABAN, 
                   CTDB.TGBATDAU
            FROM BAN
            LEFT JOIN KHUVUC ON BAN.MAKHUVUC = KHUVUC.MAKHUVUC
            LEFT JOIN CHITIETDATBAN CTDB ON BAN.MABAN = CTDB.MABAN
            LEFT JOIN DATBAN ON CTDB.MADATBAN = DATBAN.MADATBAN
            WHERE DATBAN.NGAYDATBAN = @selectedDate";

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
                    query += " AND " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(query, connsql);
                cmd.Parameters.AddWithValue("@selectedDate", DateTime.Parse(selectedDate));

                SqlDataReader reader = cmd.ExecuteReader();

                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Refresh();

                while (reader.Read())
                {
                    Button tableButton = new Button();
                    int maBan = (int)reader["MABAN"];
                    string trangThaiBan = reader["TRANGTHAI_BAN"].ToString();
                    string loaiBanText = reader["LOAIBAN"].ToString();
                    string tgBatDau = reader["TGBATDAU"]?.ToString();

                    // Kiểm tra trạng thái theo giờ bắt đầu
                    if (!string.IsNullOrEmpty(tgBatDau))
                    {
                        DateTime thoiGianBatDau = DateTime.Parse(tgBatDau);
                        DateTime ngayVaGioBatDau = new DateTime(
                            DateTime.Parse(selectedDate).Year,
                            DateTime.Parse(selectedDate).Month,
                            DateTime.Parse(selectedDate).Day,
                            thoiGianBatDau.Hour,
                            thoiGianBatDau.Minute,
                            0
                        );

                        if (DateTime.Now >= ngayVaGioBatDau)
                        {
                            trangThaiBan = "Đang chơi";
                        }
                        else
                        {
                            trangThaiBan = "Đã đặt trước";
                        }
                    }

                    tableButton.Text = $"Bàn {maBan}\n{loaiBanText}\n{trangThaiBan}";
                    tableButton.Tag = maBan;
                    tableButton.Dock = DockStyle.Fill;

                    // Đổi màu theo trạng thái
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        //private void txt_ngayThaoTac_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string ngayChon = txt_ngayThaoTac.Text;

        //        DateTime parsedDate;
        //        bool isValidDate = DateTime.TryParseExact(ngayChon, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate);

        //        if (isValidDate)
        //        {
        //            LoadTable_theongaychuadat(ngayChon);
        //        }
        //        else
        //        {
        //            tableLayoutPanel1.Controls.Clear();
        //            tableLayoutPanel1.Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //}
        //public void LoadTable_theongaychuadat(string ngayChon, string loaiKhuVuc = "", string loaiBan = "")
        //{
        //    try
        //    {
        //        if (connsql.State == ConnectionState.Closed)
        //        {
        //            connsql.Open();
        //        }

        //        // Kiểm tra định dạng ngày hợp lệ
        //        DateTime ngayChonDate;
        //        if (!DateTime.TryParseExact(ngayChon, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayChonDate))
        //        {
        //            MessageBox.Show("Ngày không hợp lệ");
        //            return;
        //        }

        //        // Sử dụng thủ tục lưu trữ
        //        SqlCommand cmd = new SqlCommand("GetBanByNgayDatBan", connsql);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // Thêm tham số ngày
        //        cmd.Parameters.AddWithValue("@NgayChon", ngayChonDate);

        //        // Thêm điều kiện lọc khu vực và loại bàn nếu có
        //        if (!string.IsNullOrEmpty(loaiBan))
        //        {
        //            cmd.Parameters.AddWithValue("@LoaiBan", loaiBan);
        //        }
        //        else
        //        {
        //            cmd.Parameters.AddWithValue("@LoaiBan", DBNull.Value);
        //        }

        //        if (!string.IsNullOrEmpty(loaiKhuVuc))
        //        {
        //            cmd.Parameters.AddWithValue("@LoaiKhuVuc", loaiKhuVuc);
        //        }
        //        else
        //        {
        //            cmd.Parameters.AddWithValue("@LoaiKhuVuc", DBNull.Value);
        //        }

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        // Làm sạch TableLayoutPanel trước khi tải mới
        //        tableLayoutPanel1.Controls.Clear();
        //        tableLayoutPanel1.Refresh();

        //        while (reader.Read())
        //        {
        //            Button tableButton = new Button();
        //            int maBan = (int)reader["MABAN"];
        //            string loaiBanText = reader["LOAIBAN"].ToString();
        //            string trangThaiBan = "Trống"; // Mặc định là "Trống"
        //            string ngayDatBan = reader["NGAYDATBAN"]?.ToString();
        //            string tgBatDau = reader["TGBATDAU"]?.ToString();

        //            // Kiểm tra nếu có bản ghi phù hợp với ngày chọn
        //            if (!string.IsNullOrEmpty(ngayDatBan))
        //            {
        //                DateTime ngayDat = DateTime.Parse(ngayDatBan);
        //                if (ngayDat == ngayChonDate) // Có ngày đặt
        //                {
        //                    if (!string.IsNullOrEmpty(tgBatDau))
        //                    {
        //                        DateTime thoiGianBatDau = DateTime.Parse(tgBatDau);
        //                        DateTime ngayVaGioBatDau = new DateTime(
        //                            ngayDat.Year, ngayDat.Month, ngayDat.Day,
        //                            thoiGianBatDau.Hour, thoiGianBatDau.Minute, 0
        //                        );

        //                        if (DateTime.Now >= ngayVaGioBatDau)
        //                        {
        //                            trangThaiBan = "Đang chơi";
        //                        }
        //                        else
        //                        {
        //                            trangThaiBan = "Đã đặt";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        trangThaiBan = "Đã đặt";
        //                    }
        //                }
        //            }

        //            // Định nghĩa nút bàn dựa trên trạng thái
        //            tableButton.Text = $"Bàn {maBan}\n{loaiBanText}\n{trangThaiBan}";
        //            tableButton.Tag = maBan;
        //            tableButton.Dock = DockStyle.Fill;

        //            if (trangThaiBan == "Trống")
        //            {
        //                tableButton.BackColor = System.Drawing.Color.LightGray;
        //                tableButton.Enabled = true;
        //            }
        //            else if (trangThaiBan == "Đang chơi")
        //            {
        //                tableButton.BackColor = System.Drawing.Color.LawnGreen;
        //                tableButton.Enabled = false;
        //            }
        //            else if (trangThaiBan == "Đã đặt")
        //            {
        //                tableButton.BackColor = System.Drawing.Color.Yellow;
        //                tableButton.Enabled = false;
        //            }

        //            tableButton.FlatStyle = FlatStyle.Flat;
        //            tableButton.FlatAppearance.BorderColor = Color.LightGray;
        //            tableButton.FlatAppearance.BorderSize = 3;

        //            tableButton.Click += new EventHandler(TableButton_Click);

        //            tableLayoutPanel1.Controls.Add(tableButton);
        //        }

        //        reader.Close();
        //        connsql.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //}

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
                LoadTable();
            }
            else
            {
                count--;
            }
        }



    }
}
