using System.Linq;
using Nancy;
using Nancy.Responses;

namespace Outgo.Service.Service.Modules
{
	public class HelloModule : NancyModule
	{
		public HelloModule()
		{
			Get["/Hello"] = x => "Hello World";
		}
	}
}