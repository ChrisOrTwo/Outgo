using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Data
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		public UserRepository(IDatabaseHost host) : base(host)
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
	}
}