using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AdoNetConfigFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Console.WriteLine("Connection String 'docker-mssql:'");
            // Console.WriteLine(ConfigurationManager.ConnectionStrings["docker-mssql"].ConnectionString);
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["docker-mssql-wo-credentials"].ConnectionString);
            builder.UserID = ConfigurationManager.AppSettings["user-name"];
            builder.Password = ConfigurationManager.AppSettings["password"];
            Console.WriteLine(builder.ConnectionString);
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                SqlCommand testSelectCommand = connection.CreateCommand();
                testSelectCommand.CommandText = "SELECT COUNT(*) FROM [TotalStat]";
                Console.WriteLine(testSelectCommand.ExecuteScalar());
            }
        }
    }
}