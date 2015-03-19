using System;
using Topshelf;
using Topshelf.HostConfigurators;
using Topshelf.ServiceConfigurators;

namespace Outgo.Service.Service
{
	public class ServiceTopShelf
	{
		public void Run()
		{
			HostFactory.Run(FactoryConfiguration());
		}

		private static Action<HostConfigurator> FactoryConfiguration()
		{
			return c =>
			{
				c.Service(ServiceConfiguration());
				c.RunAsLocalSystem();
				c.SetDescription("Outgo Service Host");
				c.SetDisplayName("OutgoNancySelfHost");
				c.SetServiceName("OutgoNancySelfHost");
			};
		}

		private static Action<ServiceConfigurator<IServiceHost>> ServiceConfiguration()
		{
			return s =>
			{
				s.ConstructUsing(name => new ServiceHost());
				s.WhenStarted(x => x.Start());
				s.WhenStopped(x => x.Stop());
			};
		}
	}
}