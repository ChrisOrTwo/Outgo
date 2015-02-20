using System.Collections.Generic;
using System.Data;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Services
{
    public interface IUserService
    {
        List<User> GetGroupUsers(int groupId);
        List<Group> GetUserGroups(int groupId);
    }
}