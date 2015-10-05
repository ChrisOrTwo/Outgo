using Nancy;

namespace Outgo.Service.Service.Modules
{
	public class HelloViewModule : NancyModule
	{
		public HelloViewModule()
		{
			Get["/HelloView"] = x =>
			{
				return View["HelloView.html", new HelloModel()];
			};
		}

		public class HelloModel
		{
			public HelloModel()
			{
				Name = "Super Duper User";
				Id = 777;
			}

			public string Name { get; set; }

			public int Id { get; set; }
		}
	}
}