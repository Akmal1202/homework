using System.Data.SqlClient;

namespace uyvazifa.Tools
{
    internal class CheckConnection
    {
        public bool Info(string tableName, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_name = @TableName", connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);
                    int tableCount = (int)command.ExecuteScalar();

                    if (tableCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}