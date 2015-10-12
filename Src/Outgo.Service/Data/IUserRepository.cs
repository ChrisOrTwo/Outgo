using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Data
{
	public interface IUserRepository : IRepositoryBase
	{
		User RegisterUser(string name, string surname);

		User GetUser(int userId);

		int RemoveUser(int userId);

		Group RegisterGroup(string groupName);

		Group GetGroup(int groupId);

		int RemoveGroup(int groupId);

		List<User> GetUsersByGroup(int groupId);

		List<Group> GetGroupsByUser(int userId);

		List<Group> GetAllGroups();

		List<User> GetAllUsers();
		
		void AddUserToGroup(int userId, int groupId);

		void RemoveUserFromGroup(int userId, int groupId);
	}
}