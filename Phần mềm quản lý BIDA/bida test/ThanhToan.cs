using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace bida_test
{
    public partial class ThanhToan : Form
    {
        int maDatBan;
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        int maBan;
        double calculatedTotalCost;
        DataTable dt_service;

        public ThanhToan(int maDatBan, int maBan)
        {
            InitializeComponent();
            connsql = kn.conn;
            this.maDatBan = maDatBan;
            this.maBan = maBan;
            ReadOnlytxt();
            LoadThanhToanDetails();
            LoadServicesForTable(maBan);
            CalculateTotal();
            CenterToScreen();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadThanhToanDetails()
        {
            using (SqlConnection connection = new SqlConnection(kn.strConnect))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT db.MANHANVIEN ,db.MAKHACHHANG, ctdb.TGBATDAU, ctdb.TGKETTHUC, db.NGAYDATBAN FROM CHITIETDATBAN ctdb JOIN DATBAN db ON ctdb.MADATBAN = db.MADATBAN WHERE ctdb.MABAN = @maBan"; 
                    using (SqlCommand cmdDatBan = new SqlCommand(query, connection))
                    {
                        cmdDatBan.Parameters.AddWithValue("@maBan", maBan);
                        using (SqlDataReader reader = cmdDatBan.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMaDatBan.Text = maDatBan.ToString();
                                txtMaBan.Text = maBan.ToString();

                                TimeSpan tgBatDau = (TimeSpan)reader["TGBATDAU"];
                                TimeSpan tgKetThuc = (TimeSpan)reader["TGKETTHUC"];

                                txtTGBatDau.Text = tgBatDau.ToString(@"hh\:mm");
                                txtTGKetThuc.Text = tgKetThuc.ToString(@"hh\:mm");

                                DateTime ngayDB = Convert.ToDateTime(reader["NGAYDATBAN"]);

                                txtNgaydatban.Text = ngayDB.ToString("dd/MM/yyyy");

                                string maNhanVien = reader["MANHANVIEN"].ToString();
                                string maKhachHang = reader["MAKHACHHANG"].ToString();


                                LoadNhanVienDetails(maNhanVien, connection);
                                LoadKhachHangDetails(maKhachHang, connection);
                            }
                        }
                    }
                    //LoadServiceDetails(connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadNhanVienDetails(string maNhanVien, SqlConnection connection)
        {
            string queryNhanVien = "SELECT HOTEN FROM NHANVIEN WHERE MANHANVIEN = @maNhanVien";
            using (SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, connection))
            {
                cmdNhanVien.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                string hoTenNhanVien = cmdNhanVien.ExecuteScalar()?.ToString();
                txtNhanvien.Text = hoTenNhanVien; 
            }
        }

        private void LoadKhachHangDetails(string maKhachHang, SqlConnection connection)
        {
            string queryKhachHang = "SELECT TENKHACHHANG FROM KHACHHANG WHERE MAKHACHHANG = @maKhachHang";
            using (SqlCommand cmdKhachHang = new SqlCommand(queryKhachHang, connection))
            {
                cmdKhachHang.Parameters.AddWithValue("@maKhachHang", maKhachHang);
                string tenKhachHang = cmdKhachHang.ExecuteScalar()?.ToString();
                txtKhachHang.Text = tenKhachHang; 
            }
        }

        DataTable setDataService(DataTable dtable)
        {
            DataTable tmp = new DataTable();
            tmp.Columns.Add("stt", typeof(string));
            tmp.Columns.Add("tenDichVu", typeof(string));
            tmp.Columns.Add("donGia", typeof(string));
            tmp.Columns.Add("soLuong", typeof(string));
            tmp.Columns.Add("thanhTien", typeof(string));

            int i = 1;
            foreach(DataRow row in dtable.Rows)
            {
                tmp.Rows.Add(i.ToString(), row[0].ToString(), row[1].ToString(), row[2].ToString(), (Convert.ToInt32(row[1]) * Convert.ToInt32(row[2])).ToString());
                i++;
            }

            return tmp;
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

                dt_service = setDataService(dt);
                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }

        }

        private void CalculateTotal()
        {
            try
            {
                string customerName = txtKhachHang.Text;
                string tableId = txtMaBan.Text;
                DateTime startTime = DateTime.Parse(txtTGBatDau.Text);
                DateTime endTime = DateTime.Parse(txtTGKetThuc.Text);
                double discount = 0, areaSurcharge = 0, tablePrice = 0, servicesTotal = 0;
                string customerId = "";

                using (SqlConnection conn = new SqlConnection(kn.strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MAKHACHHANG FROM KHACHHANG WHERE TENKHACHHANG = @CustomerName", conn);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    var idResult = cmd.ExecuteScalar();
                    if (idResult != null)
                        customerId = idResult.ToString();
                    else
                    {
                        MessageBox.Show("Customer not found.");
                        return;
                    }
                }

                using (SqlConnection conn = new SqlConnection(kn.strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT UUDAI FROM UUDAIHOIVIEN WHERE MAUUDai = (SELECT MAUUDai FROM KHACHHANG WHERE MAKHACHHANG = @CustomerId)", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    var discountResult = cmd.ExecuteScalar();
                    if (discountResult != null)
                        discount = Convert.ToDouble(discountResult);
                }

                using (SqlConnection conn = new SqlConnection(kn.strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT PHIKHUVUC FROM KHUVUC WHERE MAKHUVUC = (SELECT MAKHUVUC FROM BAN WHERE MABAN = @TableId)", conn);
                    cmd.Parameters.AddWithValue("@TableId", tableId);
                    var surchargeResult = cmd.ExecuteScalar();
                    if (surchargeResult != null)
                        areaSurcharge = Convert.ToDouble(surchargeResult);
                }

                using (SqlConnection conn = new SqlConnection(kn.strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DONGIA FROM GIABAN WHERE MAGIABAN = (SELECT MAGIABAN FROM BAN WHERE MABAN = @TableId)", conn);
                    cmd.Parameters.AddWithValue("@TableId", tableId);
                    var priceResult = cmd.ExecuteScalar();
                    if (priceResult != null)
                        tablePrice = Convert.ToDouble(priceResult);
                }

                foreach (DataGridViewRow row in bangCTDV_theoban.Rows)
                {
                    if (row.Cells["DGia"].Value != null && row.Cells["SLuong"].Value != null)
                    {
                        double servicePrice = Convert.ToDouble(row.Cells["DGia"].Value);
                        int quantity = Convert.ToInt32(row.Cells["SLuong"].Value);
                        servicesTotal += (servicePrice * quantity);
                    }

                }
                if (endTime < startTime)
                {
                    endTime = endTime.AddDays(1);
                }

                TimeSpan playTime = endTime - startTime;
                double hoursPlayed = playTime.TotalHours;

                double baseCost = tablePrice * hoursPlayed;
                double totalCost;
                if(discount != 1)
                {
                    totalCost = (baseCost + areaSurcharge + servicesTotal) * (1 - discount);
                }
                else
                {
                    totalCost = baseCost + areaSurcharge + servicesTotal;
                }

                txtTongTien.Text = totalCost.ToString("N2") + " VND";
                calculatedTotalCost = totalCost;
                setUpBank(totalCost);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total: " + ex.Message);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(kn.strConnect))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Thêm hóa đơn vào bảng BIENLAI
                    string insertBienlaiQuery = @"INSERT INTO BIENLAI (MADATBAN, TONGTIEN, NGAYXUAT, MANHANVIEN) VALUES (@MADATBAN, @TONGTIEN, @NGAYXUAT, " + Dashboard_backup.nhanVien_Class.idNhanVien + " )";
                    using (SqlCommand cmd = new SqlCommand(insertBienlaiQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MADATBAN", txtMaDatBan.Text);
                        cmd.Parameters.AddWithValue("@TONGTIEN", calculatedTotalCost);
                        cmd.Parameters.AddWithValue("@NGAYXUAT", Convert.ToDateTime(DateTime.Now.Date).ToString("yyyy/MM/dd"));

                        cmd.ExecuteNonQuery();
                    }

                    // Xóa bàn khỏi CHITIETDATBAN sau khi thanh toán
                    string deleteCTDB = "DELETE FROM CHITIETDATBAN WHERE MABAN = @MABAN AND MADATBAN = " + txtMaDatBan.Text;
                    using (SqlCommand cmd = new SqlCommand(deleteCTDB, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MABAN", txtMaBan.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Kiểm tra xem còn bàn nào chưa thanh toán (TGKETTHUC vẫn là NULL) trong CHITIETDATBAN
                    string checkRemainingTablesQuery = @"SELECT COUNT(*) FROM CHITIETDATBAN WHERE MADATBAN = @MADATBAN AND TGKETTHUC IS NULL";
                    using (SqlCommand cmd = new SqlCommand(checkRemainingTablesQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MADATBAN", txtMaDatBan.Text);
                        int unpaidTables = (int)cmd.ExecuteScalar();

                        // Nếu không còn bàn nào chưa thanh toán, cập nhật trạng thái DATBAN là "Đã thanh toán"
                        if (unpaidTables == 0)
                        {
                            string updateDatbanStatusQuery = "UPDATE DATBAN SET TRANGTHAI = N'Đã thanh toán' WHERE MADATBAN = @MADATBAN";
                            using (SqlCommand updateCmd = new SqlCommand(updateDatbanStatusQuery, connection, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@MADATBAN", txtMaDatBan.Text);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Cập nhật trạng thái bàn hiện tại về "Trống" trong bảng BAN
                    string updateBanQuery = "UPDATE BAN SET TRANGTHAI = N'Trống' WHERE MABAN = @MABAN";
                    using (SqlCommand cmd = new SqlCommand(updateBanQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MABAN", txtMaBan.Text);
                        cmd.ExecuteNonQuery();
                    }
                    string deleteQuery = "DELETE FROM CHITIETDICHVU WHERE MABAN = @MaBan";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaBan", txtMaBan.Text);
                        cmd.ExecuteNonQuery();
                    }
                    // Cập nhật số lần chơi cho khách hàng
                    if(txtKhachHang.Text != "Khách vãng lai")
                    {
                        string updateKhachhangQuery = "UPDATE KHACHHANG SET SOLANCHOI = SOLANCHOI + 1 WHERE MAKHACHHANG = (SELECT MAKHACHHANG FROM KHACHHANG WHERE TENKHACHHANG = @TENKHACHHANG)";
                        using (SqlCommand cmd = new SqlCommand(updateKhachhangQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TENKHACHHANG", txtKhachHang.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    

                    transaction.Commit();

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        setUPinHoaDon();
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }

        void setUpBank(double soTien)
        {
            Bank bank = new Bank();
            APIRequest APIrequest = new APIRequest();
            APIrequest.acqId = Convert.ToInt32(bank.data.bin);
            APIrequest.accountNo = 1029832127;
            APIrequest.accountName = "BiDa nhóm 6";
            APIrequest.amount = (int)soTien;
            APIrequest.format = "text";
            APIrequest.template = "print";
            var json = JsonConvert.SerializeObject(APIrequest);

            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", json, RestSharp.ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content; // raw content as string  
            var dataResult = JsonConvert.DeserializeObject<APIResponse>(content);

            var image = Base64ToImage(dataResult.data.qrDataURL);
            pcbMaQR.Image = image;
        }

        public System.Drawing.Image Base64ToImage(string base64String)
        {
            // Remove the prefix if it exists
            if (base64String.Contains(","))
            {
                base64String = base64String.Split(',')[1];
            }

            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        void setUPinHoaDon()
        {
            CRP_HoaDon hd = new CRP_HoaDon();
            (hd.ReportDefinition.ReportObjects["maHoaDon"] as TextObject).Text = txtMaDatBan.Text;
            (hd.ReportDefinition.ReportObjects["tenKhachHang"] as TextObject).Text = txtKhachHang.Text;
            (hd.ReportDefinition.ReportObjects["tenNhanVien"] as TextObject).Text = txtNhanvien.Text;
            (hd.ReportDefinition.ReportObjects["tenBan"] as TextObject).Text = txtMaBan.Text;
            (hd.ReportDefinition.ReportObjects["tongThanhTien"] as TextObject).Text = txtTongTien.Text;

            hd.SetDataSource(dt_service);

            inHoaDon inHD = new inHoaDon();
            inHD.crystalReportViewer1.ReportSource = hd;
            inHD.ShowDialog();
        }

        private void btn_inHoaDon_Click(object sender, EventArgs e)
        {
            setUPinHoaDon();
        }
        private void ReadOnlytxt()
        {
            txtKhachHang.ReadOnly = true;
            txtNhanvien.ReadOnly = true;
            txtMaDatBan.ReadOnly = true;
            txtMaBan.ReadOnly = true;
            txtTGBatDau.ReadOnly = true;
            txtTGKetThuc.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtNgaydatban.ReadOnly = true;
        }
        
    }
}

