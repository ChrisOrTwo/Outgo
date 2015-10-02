using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Outgo.Contracts.Contract;
using Outgo.Service.Data;

namespace Outgo.Service.Integration.Tests
{
	[TestFixture]
	public class UserRepositoryTests : RepositoryTestsBase
	{
		IUserRepository Sut { get; set; }

		[SetUp]
		public void Setup()
		{
			Sut = new UserRepository(TestingHost);
		}

		[Test]
		public void RegisterUser_add_user()
		{
			string firstName = "Testing";
			string secondName = "Testing";

			User user = Sut.RegisterUser(firstName, secondName);

			Assert.IsNotNull(user);
			Assert.AreEqual(user.Name, firstName);
			Assert.AreEqual(user.Surname, secondName);
		}

		[Test]
		public void GetUser_returns_user()
		{
			string firstName = "Testing";
			string secondName = "Testing";

			User userRegistered = Sut.RegisterUser(firstName, secondName);
			User user = Sut.GetUser(userRegistered.UserId);

			Assert.AreEqual(user.Name, firstName);
			Assert.AreEqual(user.Surname, secondName);
		}

		[Test]
		public void RemoveUser_removes_user()
		{
			string firstName = "Testing";
			string secondName = "Testing";

			User userRegistered = Sut.RegisterUser(firstName, secondName);
			int rows = Sut.RemoveUser(userRegistered.UserId);
			User user = Sut.GetUser(userRegistered.UserId);

			Assert.AreEqual(rows, 1);
			Assert.IsNull(user);
		}

		[Test]
		public void RegisterGroup_adds_group()
		{
			string groupName = "Testing";

			Group group = Sut.RegisterGroup(groupName);

			Assert.IsNotNull(group);
			Assert.AreEqual(group.Name, groupName);
		}

		[Test]
		public void GetGroup_returns_group()
		{
			string groupName = "Testing";
			Group groupRegistered = Sut.RegisterGroup(groupName);

			Group group = Sut.GetGroup(groupRegistered.GroupId);

			Assert.IsNotNull(group);
			Assert.AreEqual(group.Name, groupName);
		}

		[Test]
		public void RemoveGroup_removes_group()
		{
			string groupName = "Testing";
			Group groupRegistered = Sut.RegisterGroup(groupName);

			int row = Sut.RemoveGroup(groupRegistered.GroupId);
			Group group = Sut.GetGroup(groupRegistered.GroupId);

			Assert.AreEqual(row, 1);
			Assert.IsNull(group);
		}

		[Test]
		public void GetUserByGroup_returns_empty_list_when_no_user()
		{
			int notExistingGroupId = 99;

			List<User> users = Sut.GetUsersByGroup(notExistingGroupId);

			Assert.IsEmpty(users);
		}

		[Test]
		public void GetUsersByGroup_get_users_after_AddUserToGroup()
		{
			Group group = Sut.RegisterGroup("group1");
			User user = Sut.RegisterUser("user1", "user1");

			Sut.AddUserToGroup(user.UserId, group.GroupId);

			List<User> users = Sut.GetUsersByGroup(group.GroupId);

			Assert.AreEqual(1, users.Count);
			Assert.AreEqual(user.Name, users.First().Name);
			Assert.AreEqual(user.Surname, users.First().Surname);
			Assert.AreEqual(user.UserId, users.First().UserId);
		}

		[Test]
		public void GetGroupByUser_get_groups_after_AddUserToGroup()
		{
			Group group = Sut.RegisterGroup("group1");
			User user = Sut.RegisterUser("user1", "user1");

			Sut.AddUserToGroup(user.UserId, group.GroupId);

			List<Group> groups = Sut.GetGroupsByUser(user.UserId);

			Assert.AreEqual(1, groups.Count);
			Assert.AreEqual(group.Name, groups.First().Name);
			Assert.AreEqual(group.GroupId, groups.First().GroupId);
		}
	}
}