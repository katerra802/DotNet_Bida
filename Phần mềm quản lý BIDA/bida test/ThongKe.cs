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
using System.Windows.Forms.DataVisualization.Charting;
using MyLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bida_test
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
            loadTK();
        }

        private DataTable setDataForDataTable(string query)
        {
            DBConnect db = new DBConnect();
            DataTable dt = new DataTable();
            dt.Columns.Add("TONGDONVI", typeof(double));
            dt.Columns.Add("TENTHANHPHAN", typeof(string));

            DataTable data = db.GetDataTable(query);

            foreach (DataRow dthu in data.Rows)
            {
                DataRow row = dt.NewRow();
                if (dthu != null)
                {
                    row["TONGDONVI"] = Convert.ToDouble(dthu["TONGDONVI"]);
                    row["TENTHANHPHAN"] = dthu["TENTHANHPHAN"].ToString();
                    dt.Rows.Add(row);
                }
                else
                {
                    row["TONGDONVI"] = 0;
                    row["TENTHANHPHAN"] = dthu["TENTHANHPHAN"].ToString();
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        void chartBindDing(Chart chart, DataTable datatable, string s)
        {
            chart.DataSource = datatable;
            chart.Series[s].XValueMember = "TENTHANHPHAN";
            chart.Series[s].YValueMembers = "TONGDONVI";
            chart.Series[s].IsValueShownAsLabel = true;
            chart.DataBind();
        }

        private void loadTK()
        {
            try
            {
                DataTable doanhThu = setDataForDataTable("SELECT SUM(TONGTIEN) AS TONGDONVI, NGAYXUAT AS TENTHANHPHAN FROM BIENLAI WHERE NGAYXUAT BETWEEN CAST( '" + Convert.ToDateTime(dtpStart.Text).ToString("yyyy/MM/dd") + "' as DATE) AND Cast( '" + Convert.ToDateTime(dtpEnd.Text).ToString("yyyy/MM/dd") + "' as DATE) GROUP BY NGAYXUAT");
                DataTable khachHang = setDataForDataTable("SELECT COUNT(MAKHACHHANG) AS TONGDONVI, NGAYDATBAN AS TENTHANHPHAN FROM DATBAN WHERE NGAYDATBAN BETWEEN CAST('" + Convert.ToDateTime(dtpStart.Text).ToString("yyyy/MM/dd") + "' as DATE) AND Cast('" + Convert.ToDateTime(dtpEnd.Text).ToString("yyyy/MM/dd") + "' as DATE) GROUP BY NGAYDATBAN");

                if(doanhThu != null && khachHang != null)
                {
                    chartBindDing(chart_doanhThu, doanhThu, "Doanh thu");
                    chartBindDing(chart_khachHang, khachHang, "Khách hàng");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.Message);
            }
        }

        private void comboBox_ValueChanged(object sender, EventArgs e)
        {
            comboBox_Validating(sender, new CancelEventArgs());
        }

        private void comboBox_Validating(object sender, CancelEventArgs e)
        {
            loadTK();
        }

        private void btnLoadformHoaDon_Click(object sender, EventArgs e)
        {
            frmLichSu frm = new frmLichSu();
            frm.Show();
        }
    }
    
}
