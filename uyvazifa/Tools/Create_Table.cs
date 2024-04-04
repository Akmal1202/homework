using System;
using System.Data.SqlClient;
public class MigrationsManager
{
    public void CreateTable(string connectionString) 
    {
        string createTableQuery = @"
            CREATE TABLE Students(
                StudentId INT PRIMARY KEY IDENTITY,
                FirstName NVARCHAR(50),
                LastName NVARCHAR(50),
                BirthDate Date
            )
        ";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Table created successfully.");
            }
        }
    }
}
