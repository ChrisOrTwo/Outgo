using Outgo.Contracts.Contract;
using System.Collections.Generic;

namespace Outgo.Service.Services
{
    public interface IUserRepository
    {
        List<User> GetUsersByGroup(int groupId);
 
        List<Group> GetGroupsByUser(int userId);
    }
}