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
    public partial class frmLichSu : Form
    {
        MyLibrary.DBConnect kn = new MyLibrary.DBConnect();
        SqlConnection connsql;
        public frmLichSu()
        {
            InitializeComponent();
            connsql = kn.conn;
            load_dv();
        }
        private void load_dv()
        {
            bangHoaDon.Rows.Clear();
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string qDV = @"SELECT * FROM BIENLAI";

                SqlCommand cmd = new SqlCommand(qDV, connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    bangHoaDon.Rows.Add(row[0], row[1], row[2], row[3]);
                }
                bangHoaDon.ClearSelection();

                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void bangHoaDon_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
