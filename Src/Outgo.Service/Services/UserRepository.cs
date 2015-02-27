using System;
using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Services
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public List<User> GetUsersByGroup(int groupId)
        {
            return Call<List<User>>(db => db.DatabaseConnection.UserGroup.FindAllByGroupId(groupId).User);
        }

        public List<Group> GetGroupsByUser(int userId)
        {
            return Call<List<Group>>(db => db.DatabaseConnection.UserGroup.FindAllByUserId(userId).Group);
        }

        public UserRepository(IDatabaseHost host) : base(host)
        {
        }
    }
}