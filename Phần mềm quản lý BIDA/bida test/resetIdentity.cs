using System;
using System.Data.SqlClient;

public class resetIdentity
{
    private string _connectionString;

    public resetIdentity(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Phương thức để lấy ID lớn nhất
    public int GetMaxId(string tableName, string idColumn)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            int maxId = 0;
            using (SqlCommand maxIdCommand = new SqlCommand($"SELECT ISNULL(MAX({idColumn}), 0) FROM {tableName}", connection))
            {
                maxId = Convert.ToInt32(maxIdCommand.ExecuteScalar());
            }
            return maxId;
        }
    }

    // Phương thức để reset giá trị tự động tăng
    public void ResetAutoIncrement(string tableName, string idColumn)
    {
        int maxId = GetMaxId(tableName, idColumn);
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand resetCommand = new SqlCommand($"DBCC CHECKIDENT ('{tableName}', RESEED, @NewId)", connection))
            {
                resetCommand.Parameters.AddWithValue("@NewId", maxId);
                resetCommand.ExecuteNonQuery();
            }
        }
    }
}

