using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyLibrary
{
    public class DBConnect
    {
        private SqlConnection _conn;
        private string _strConnect, _strServerName, _strDBName, _strUserID, _strPassword;
        public SqlConnection conn
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public string strConnect
        {
            get { return _strConnect; }
            set { _strConnect = value; }
        }
        public string strServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }
        public string strDBName
        {
            get { return _strDBName; }
            set { _strDBName = value; }
        }
        public string strUserID
        {
            get { return _strUserID; }
            set { _strUserID = value; }
        }
        public string strPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }
        public DBConnect()
        {
            strServerName = @"LAPTOP-TEK92DJC";
            strDBName = "database_BIDA";
            //Dùng với quyền của của Windows
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
            ";Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
            //Dùng với quyền của SQL Server
            //strUserID = "";
            //strPassword = "";
            //strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
            //";User ID=" + strUserID + ";Password=" + strPassword;
            conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
        }
        public void openConnect()
        { //Mở kết nối
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void closeConnect()
        { //Đóng kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public void disposeConnect()
        { //Hủy đối tượng kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Dispose(); //Giải phóng vùng nhớ đã cấp phát cho conn
        }
        public void updateToDataBase(string strSQL)
        { //Cho phép cập nhật CSDL với các thao tác gồm: Thêm, Xóa, Sửa
            openConnect(); //Mở kết nối
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL; //Câu truy vấn đưa vào
            cmd.ExecuteNonQuery(); //Thực thi
            closeConnect(); //Đóng kết nối
        }
        public int getCount(string strSQL)
        {
            openConnect(); //Mở kết nối
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL; //Câu truy vấn đưa vào
            int count = (int)cmd.ExecuteScalar(); //Thực thi
            closeConnect(); //Đóng kết nối
            return count;
        }
        public bool checkExist(string tableName, string fieldName, string fieldValue)
        {
            string strSQL = "SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName + "='"
            + fieldValue + "'";
            return getCount(strSQL) > 0 ? true : false;
        }

        public SqlDataReader GetDataReader(string strSQL)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            SqlDataReader r = cmd.ExecuteReader();
            return r;
        }

        public SqlDataReader showAllforOneTable(string nameTable)
        {
            string querry = "Select * from " + nameTable;
            return GetDataReader(querry);
        }

        public SqlDataReader showOneTable(string nameRows, string nameTable)
        {
            string querry = "Select " + nameRows + " from " + nameTable;
            return GetDataReader(querry);
        }

        public SqlDataReader showOneTable(string nameRows, string nameTable, string nameConditions)
        {
            string querry = "Select " + nameRows + " from " + nameTable + " where " + nameConditions;
            return GetDataReader(querry);
        }

        public SqlDataReader showOneTable(string querry)
        {
            return GetDataReader(querry);
        }


        public SqlDataReader getAllFromTable(string strSQL)
        {
            return GetDataReader(strSQL);
        }

        public SqlDataAdapter GetDataAdapter(string strSQL)
        {
            openConnect();
            SqlDataAdapter adp = new SqlDataAdapter(strSQL, conn);
            return adp;
        }

        public DataTable GetDataTable(string strSQL)
        {
            SqlDataAdapter adapter = GetDataAdapter(strSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public bool checkCondition(string strSQL)
        {
            SqlDataReader r = GetDataReader(strSQL);
            bool result = r.HasRows;
            closeConnect();
            return result;
        }
    }
}