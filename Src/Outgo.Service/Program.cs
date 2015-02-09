using System;
using System.Globalization;
using System.Threading;
using Simple.Data;

namespace Outgo.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");

            const string connectionString = "Server=127.0.0.1;Port=5432;Database=outgo;Uid=postgres;Pwd=ghostdj10;";
            var session = Database.Open();
            var users = session.User.FirstOrDefault();
            Console.WriteLine(users.Count);
            Console.ReadKey();
        }
    }
}
