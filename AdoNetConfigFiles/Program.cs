using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace AdoNetConfigFiles
{
    /* public static class Ext
    {
        public static string ExtMethod(this IData obj, string data)
        {
            if (obj is Person)
            {
                return ((Person)obj).name + " " + ((Person)obj).lastName + " " + data;
            }
            if (obj is Product)
            {
                return ((Product)obj).title + " " + ((Product)obj).price;
            }
            return "";
        }
    }

    public interface IData
    {
        
    }

    public class Person : IData
    {
        public string name;
        public string lastName;
    }
    
    class Product : IData
    {
        public string title;
        public Decimal price;
    } */

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Console.WriteLine("Connection String 'docker-mssql:'");
            // Console.WriteLine(ConfigurationManager.ConnectionStrings["docker-mssql"].ConnectionString);
            
            // Console.WriteLine(readConnectionStringOld());
            // using (SqlConnection connection = new SqlConnection(readConnectionStringOld()))
            
            /* Console.WriteLine(readConnectionStringNew());
            using (SqlConnection connection = new SqlConnection(readConnectionStringNew()))
            {
                connection.Open();
                SqlCommand testSelectCommand = connection.CreateCommand();
                testSelectCommand.CommandText = "SELECT COUNT(*) FROM [TotalStat]";
                Console.WriteLine(testSelectCommand.ExecuteScalar());
            } */

            /* var person = new Person() { name = "Noname", lastName = "Last"};
            var product = new Product() { title = "PC", price = 40000};
            Console.WriteLine(person.ExtMethod("demo data 1"));
            Console.WriteLine(product.ExtMethod("demo data 2")); */
            
            Console.WriteLine(ReadConnectionStringNew());
        }

        private static string ReadConnectionStringOld()
        {
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["docker-mssql-wo-credentials"].ConnectionString);
            builder.UserID = ConfigurationManager.AppSettings["user-name"];
            builder.Password = ConfigurationManager.AppSettings["password"];
            return builder.ConnectionString;
        }

        private static string ReadConnectionStringNew()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();
            return config.GetSection("Data").GetSection("password").Value;
        }
    }
}