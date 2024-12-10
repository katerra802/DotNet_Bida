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
    public partial class ThemUD : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        public ThemUD()
        {
            InitializeComponent();
            connsql = kn.conn;
        }

        private void btnThemUD_Click(object sender, EventArgs e)
        {
            if (Kiemtra_textboxRong())
            {
                
                    try
                    {
                        if (connsql.State == ConnectionState.Closed)
                        {
                            connsql.Open();
                        }

                       

                        string queryKH = @"INSERT INTO UUDAIHOIVIEN (TENUUDAI, DIEUKIENUUDAI, UUDAI) VALUES (@TENUUDAI, @DIEUKIENUUDAI, @UUDAI)";
                        SqlCommand cmdTHEM = new SqlCommand(queryKH, connsql);

                        cmdTHEM.Parameters.AddWithValue("@TENUUDAI", txtTenUD.Text);
                        cmdTHEM.Parameters.AddWithValue("@DIEUKIENUUDAI", int.Parse(txtDieukienUD.Text.ToString()));
                        cmdTHEM.Parameters.AddWithValue("@UUDAI", (float.Parse(txtUudai.Text.ToString()) / 100));

                        cmdTHEM.ExecuteNonQuery();

                        

                        MessageBox.Show("Thêm ưu đãi mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        connsql.Close();
                        this.Close();


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
        private bool Kiemtra_textboxRong()
        {
            Guna.UI2.WinForms.Guna2TextBox[] textBoxes = { txtTenUD, txtDieukienUD, txtUudai };

            foreach (Guna.UI2.WinForms.Guna2TextBox tb in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    return false;
                }
            }
            return true;
        }
        

        private void txtDieukienUD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void txtUudai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                MessageBox.Show("Chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;

            }
            else if(char.IsDigit(e.KeyChar))
            {
                if (Convert.ToInt32(txtUudai.Text + e.KeyChar) > 50)
                {
                    MessageBox.Show("Ưu đãi chỉ được phép 50%", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;
                }
            }    

            
        }

        
    }
}
