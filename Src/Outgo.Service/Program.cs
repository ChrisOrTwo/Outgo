using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Outgo.Contracts;
using Simple.Data;

namespace Outgo.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");

            const string connectionString = "Server=127.0.0.1;Port=5432;Database=outgo;Uid=postgres;Pwd=ghostdj10;";
            var session = Database.OpenConnection(connectionString);

            var x = session.User.All();
            List<User> users = session.User.All();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
            Console.ReadKey();
        }
    }
}
