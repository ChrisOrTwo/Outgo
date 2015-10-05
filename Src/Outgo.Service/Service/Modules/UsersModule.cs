using Nancy;
using Outgo.Service.Data;

namespace Outgo.Service.Service.Modules
{
	public class UsersModule : NancyModule
	{
		public UsersModule(IUserRepository repository)
		{
			Get["/Users"] = x =>
			{
				var users = repository.GetUsersByGroup(1);
				return View["Users.html", users];
			};
		}
	}
}