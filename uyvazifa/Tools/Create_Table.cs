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
            // Open the connection
            connection.Open();

            // Create a SqlCommand object with the query and connection
            using (SqlCommand command = new SqlCommand(createTableQuery, connection))
            {
                // Execute the query
                command.ExecuteNonQuery();
                Console.WriteLine("Table created successfully.");
            }
        }
    }
}
