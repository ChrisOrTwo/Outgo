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

		public List<Group> GetAllGroups()
		{
			return Call<List<Group>>(db => db.Session.Group.All());
		}

		public List<User> GetAllUsers()
		{
			return Call<List<User>>(db => db.Session.User.All());
		}

		public User RegisterUser(string name, string surname)
		{
			var user = new User { Name = name, Surname = surname };
			return Call<User>(db => db.Session.Users.Insert(user));
		}

		public User GetUser(int userId)
		{
			return Call<User>(db => db.Session.Users.Get(userId));
		}

		public int RemoveUser(int userId)
		{
			return Call<int>(db => db.Session.Users.DeleteByUserId(userId));
		}

		public Group RegisterGroup(string groupName)
		{
			var group = new Group {Name = groupName};
			return Call<Group>(db => db.Session.Groups.Insert(group));
		}

		public Group GetGroup(int groupId)
		{
			return Call<Group>(db => db.Session.Groups.Get(groupId));
		}

		public int RemoveGroup(int groupId)
		{
			return Call<int>(db => db.Session.Groups.DeleteByGroupId(groupId));
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