using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Data
{
	public interface IUserRepository
	{
		List<User> GetUsersByGroup(int groupId);
		List<Group> GetGroupsByUser(int userId);
	}
}