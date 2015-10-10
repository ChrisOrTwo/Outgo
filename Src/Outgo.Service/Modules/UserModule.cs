using Nancy;
using Outgo.Service.Data;

namespace Outgo.Service.Service.Modules
{
	public class UserModule : NancyModule
	{
		public UserModule(IUserRepository userRepository)
		{
			Get["/UsersJson"] = x =>
			{
				var user = userRepository.GetUsersByGroup(1);
				return Response.AsJson(user);
			};
		}
	}
}