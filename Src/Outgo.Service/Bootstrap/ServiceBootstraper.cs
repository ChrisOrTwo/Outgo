using System.Linq;
using Nancy;
using Nancy.TinyIoc;
using Outgo.Service.Data;
using Outgo.Service.Service.Modules;

namespace Outgo.Service.Bootstrap
{
	public class ServiceBootstraper : DefaultNancyBootstrapper
	{
		private IConfigurationProvider FetchConfiguration()
		{
			return new ConfigurationProvider
			{
				ConnectionString = "Server=127.0.0.1;Port=5432;Database=outgo;Uid=postgres;Pwd=ghostdj10;"
			};
		}

		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			var configuration = FetchConfiguration();

			container.Register(configuration);
			container.Register<IDatabaseHost, DatabaseHost>().AsSingleton();

			container.Register<IUserRepository, UserRepository>();
			container.Register<IPaymentRepository, PaymentRepository>();

			container.Register<INancyModule, HelloModule>().AsSingleton();
			container.Register<INancyModule, UserModule>().AsSingleton();

			var x = container.ResolveAll<INancyModule>().ToList();
		}
	}
}