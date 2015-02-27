using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using Outgo.Contracts;
using Outgo.Contracts.Contract;
using Outgo.Service.Services;
using Simple.Data;

namespace Outgo.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            const string connectionString = "Server=127.0.0.1;Port=5432;Database=outgo;Uid=postgres;Pwd=ghostdj10;";

            RawConnectionTest(connectionString);

            Console.ReadKey();

            SharedConnectionTest(connectionString);

            Console.ReadKey();
        }

        private static void RawConnectionTest(string connectionString)
        {
            var session = Database.OpenConnection(connectionString);

            User user = session.User.Get(1);
            Group group = session.Group.Get(1);
            UserGroup userGroup = session.UserGroup.Get(1);
            List<UserGroup> userGroups = session.UserGroup.FindAllByGroupId(1);

            var users2 = session.Group.FindByGroupId(1);
            foreach (var x in users2.UserGroup.User)
            {
                Console.WriteLine(x.Name);
            }

            Debug.WriteLine("----");

            List<User> users3 = session.Group.FindByGroupId(1).UserGroup.User;
            foreach (var x in users3)
            {
                Console.WriteLine(x.Name);
            }

            Debug.WriteLine("----");

            List<User> users4 = session.UserGroup.FindAllByGroupId(1).User;
            foreach (var x in users4)
            {
                Console.WriteLine(x.Name);
            }
            
        }

        private static void SharedConnectionTest(string connectionString)
        {
            var db = Database.OpenConnection(connectionString);
            var host = new DatabaseHost(db);

            var userRepo = new UserRepository(host);

            var users = userRepo.GetUsersByGroup(1);
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }

            Console.ReadKey();

            var users2 = userRepo.GetUsersByGroup(2);
            foreach (var user in users2)
            {
                Console.WriteLine(user.Name);
            }

        }
    }
}
