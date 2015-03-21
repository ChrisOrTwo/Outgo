using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Data
{
	public interface IUserRepository
	{
		List<User> GetUsersByGroup(int groupId);

		List<Group> GetGroupsByUser(int userId);

		User RegisterUser(string name, string surname);

		void AddUserToGroup(int userId, int groupId);

		void RemoveUserFromGroup(int userId, int groupId);
	}
}