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
using static System.Net.Mime.MediaTypeNames;

namespace bida_test
{
    public partial class XacNhanDatBan : Form
    {
        Datban_class datBan = new Datban_class();   
        public XacNhanDatBan(Datban_class datBan)
        {
            InitializeComponent();
            this.datBan = datBan;
            CenterToScreen();
        }

        private void XacNhanDatBan_Load(object sender, EventArgs e)
        {
            lab_tenBan.Text = datBan.tenBan;
        }

        void setUp()
        {
            txt_gioBatDau.Text = DateTime.Now.ToString("HH:mm:ss");
            txt_gioKetThuc.Text = DateTime.Now.AddHours(1).ToString("HH:mm:ss");
        }

        private void checkMashTxtTime(object sender, int gioBatDau, int gioKetThuc)
        {
            try
            {
                MaskedTextBox txt = sender as MaskedTextBox;
                if (txt == null)
                {
                    throw new Exception("text marker no invalue.");
                }
                string inputTime = txt.Text;

                // Tách giờ và phút
                string[] timeParts = inputTime.Split(':');
                if (timeParts.Length == 2 &&
                    int.TryParse(timeParts[0], out int hour) &&
                    int.TryParse(timeParts[1], out int minute))
                {
                    // Kiểm tra tính hợp lệ của giờ và phút
                    if (hour >= gioBatDau && hour <= gioKetThuc)
                    {
                        txt.Text = $"{21:D2}:{minute:D2}";
                        throw new Exception($"Giờ không hợp lệ: {inputTime}");
                    }

                    if (minute >= 0 && minute <= 59)
                    {
                        txt.Text = $"{21:D2}:{59:D2}";
                        throw new Exception($"Phút không hợp lệ: {inputTime}");
                    }
                    else
                    {
                        MessageBox.Show("Giờ hoặc phút không hợp lệ. Hãy nhập trong khoảng 08:00 đến 21:59.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void txt_gioKetThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskedTextBox txt = sender as MaskedTextBox;
            if (txt == null)
            {
                throw new Exception("text marker no invalue.");
            }
            string inputTime = txt.Text;

            if(!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
            else
            {
                string[] timeParts = inputTime.Split(':');
                if (int.TryParse(timeParts[0], out int hour))
                {
                    // Kiểm tra tính hợp lệ của giờ và phút
                    if (hour == 2 && (e.KeyChar < '0' || e.KeyChar > '4'))
                    {
                        e.Handled = true;
                        return;
                    }
                    else if (hour == 1 && (e.KeyChar < '0' || e.KeyChar > '9'))
                    {
                        e.Handled = true;
                        return;
                    }

                }
                int.TryParse(timeParts[1], out int minute);
                if (minute == 0 && (e.KeyChar > '0' && e.KeyChar <= '9'))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void btn_xacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect db = new DBConnect();
                if(db.getCount("SELECT COUNT(TGBATDAU) FROM CHITIETDATBAN C JOIN DATBAN D ON C.MADATBAN = D.MADATBAN WHERE TGKETTHUC >= '"+txt_gioBatDau.Text+"' and MABAN = "+datBan.maBan+" AND D.NGAYDATBAN = '"+datBan.ngayDat+"'") > 0)
                {
                    throw new Exception("Opp! Bị trùng giờ rồi.");
                }

                //if (Convert.ToDateTime(txt_gioBatDau.Text) < Convert.ToDateTime(DateTime.Now.ToString("HH:mm")))
                //{
                //    throw new Exception("Giờ bắt đàu ko được nhỏ hơn giờ hiện tại");
                //}

                if (Convert.ToDateTime(txt_gioBatDau.Text).AddHours(1) > Convert.ToDateTime(txt_gioKetThuc.Text))
                {
                    throw new Exception("Giờ bắt đầu phải cách giờ kết thúc 1 giờ.");
                }
                //if (Convert.ToDateTime(txt_gioKetThuc.Text) >= Convert.ToDateTime("22:00"))
                //{
                //    throw new Exception("Giờ kết thúc không được lớn hơn 22:00.");
                //}
                //if (Convert.ToDateTime(txt_gioBatDau.Text) < Convert.ToDateTime("08:00"))
                //{
                //    throw new Exception("Giờ bắt đầu không được nhỏ hơn 08:00.");
                //}


                string query2 = "INSERT INTO CHITIETDATBAN values(" + datBan.maDatBan + ", " + datBan.maBan + ", '" + txt_gioBatDau.Text + "' , '" + txt_gioKetThuc.Text + "')";
                db.updateToDataBase(query2);
                db.updateToDataBase("UPDATE BAN SET TRANGTHAI = N'Đã đặt' WHERE MABAN = " + datBan.maBan + " AND TRANGTHAI = N'Trống'");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

    }
}
