using System;
using Nancy.Hosting.Self;

namespace Outgo.Service.Service
{
	public class ServiceHost : IServiceHost
	{
		private NancyHost _host;

		public void Start()
		{
			const string connectionString = "http://localhost:8888/nancy/";

			_host = new NancyHost(new Uri(connectionString));
			_host.Start();
			Console.WriteLine("Nancy is now listening on: {0}", connectionString);
		}

		public void Stop()
		{
			_host.Stop();
			_host.Dispose();
			Console.WriteLine("Stopped. Good bye!");
		}
	}
}