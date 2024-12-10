using System.Data.SqlClient;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace bida_test
{
    public class facilities
    {
        public void closingForm(FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát", "thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public DataGridView FilldataView(DBConnect dBConnect, string query, string tenbang)
        {
            DataGridView dvg = new DataGridView();
            DataSet ds = new DataSet();
            using (SqlDataAdapter da = new SqlDataAdapter(query, dBConnect.conn))
            {
                da.Fill(ds, tenbang);
            }
            dvg.DataSource = ds.Tables[tenbang];
            return dvg;
        }
                
    }
}
