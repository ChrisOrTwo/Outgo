using System;
using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public List<User> GetGroupUsers(int groupId)
        {
            return Call<List<User>>(db =>
            {
                throw new NotImplementedException();
            });
        }

        public List<Group> GetUserGroups(int groupId)
        {
            throw new System.NotImplementedException();
        }

        public UserService(IDatabaseHost host) : base(host)
        {
        }
    }
}