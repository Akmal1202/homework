using Microsoft.EntityFrameworkCore;
using System;
using uyvazifa.Context;
using uyvazifa.Model;
using uyvazifa.Tools;

namespace uyvazifa
{
    class Program
    {
        static void Main()
        {
            string connectionString = "server = localhost; database = Training; TrustServerCertificate=True; Integrated Security = true";
            string tableName = "Students";

            var students = new List<Student>();
            CheckConnection check = new CheckConnection();
            if (check.Info(tableName, connectionString))
            {
                Console.WriteLine("Table exists.");
                string answer = "";
                while (answer != "YES" && answer != "NO")
                {
                    Console.WriteLine("Do you want to add new information to the table (Yes or No): ");
                    answer = Console.ReadLine().ToUpper();
                    if (answer == "YES")
                    {
                        Console.WriteLine("FirstName: ");
                        string first = Console.ReadLine();
                        Console.WriteLine("LastName: ");
                        string last = Console.ReadLine();
                        Console.WriteLine("Date(yyyy-mm-dd): ");
                        DateOnly date = DateOnly.Parse(Console.ReadLine());
                        using (var context = new MyDbContext())
                        {
                            var student = new Student { FirstName = first, LastName = last, BirthDate = date };
                            context.Students.Add(student);
                            context.SaveChanges();
                        }
                        break;
                    }
                    else if (answer == "NO")
                    {
                        Console.WriteLine("OK");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your answer was not Yes or No");
                    }
                }
            }
            else
            {
                Console.WriteLine("Table does not exist.");
                string answer = "";
                while (answer != "YES" && answer != "NO")
                {
                    Console.WriteLine("Do you want to create table (Yes or No): ");
                    answer = Console.ReadLine().ToUpper();
                    if (answer == "YES")
                    {
                        MigrationsManager create = new MigrationsManager();
                        create.CreateTable(connectionString);
                        break;
                    }
                    else if (answer == "NO")
                    {
                        Console.WriteLine("OK");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your answer was not Yes or No");
                    }
                }
            }
        }
    }
}
