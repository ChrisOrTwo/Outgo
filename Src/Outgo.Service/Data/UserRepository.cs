using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Data
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		public UserRepository(IDatabaseHost host)
			: base(host)
		{
		}

		public List<User> GetUsersByGroup(int groupId)
		{
			return Call<List<User>>(db => db.Session.UserGroup.FindAllByGroupId(groupId).User);
		}

		public List<Group> GetGroupsByUser(int userId)
		{
			return Call<List<Group>>(db => db.Session.UserGroup.FindAllByUserId(userId).Group);
		}

		public User RegisterUser(string name, string surname)
		{
			var user = new User { Name = name, Surname = surname };
			return Call<User>(db => db.Session.Users.Insert(user));
		}

		public void AddUserToGroup(int userId, int groupId)
		{
			var userGroup = new UserGroup() { GroupId = groupId, UserId = userId };
			Call(db => db.Session.UserGroups.Insert(userGroup));
		}

		public void RemoveUserFromGroup(int userId, int groupId)
		{
			Call(db => db.Session.UserGroups.DeleteByUserIdAndGroupId(userId, groupId));
		}
	}
}