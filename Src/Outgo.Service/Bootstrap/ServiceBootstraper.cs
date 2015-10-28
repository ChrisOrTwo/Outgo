using System.Linq;
using Nancy;
using Nancy.Bootstrapper;
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
				ConnectionString = "Server=127.0.0.1;Port=5432;Database=outgo;Uid=postgres;Pwd=postgres;"
			};
		}

		protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
		{
			//CORS Enabled
			pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
			{
				ctx.Response
					.WithHeader("Access-Control-Allow-Origin", "*")
					.WithHeader("Access-Control-Allow-Methods", "POST,GET")
					.WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
			});
		}

		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			var configuration = FetchConfiguration();

			container.Register(configuration);
			container.Register<IDatabaseHost, DatabaseHost>().AsSingleton();

			container.Register<IUserRepository, UserRepository>();
			container.Register<IPaymentRepository, PaymentRepository>();

			container.Register<INancyModule, UserModule>().AsSingleton();
			container.Register<INancyModule, HelloViewModule>().AsSingleton();
			container.Register<INancyModule, UsersModule>().AsSingleton();

			var x = container.ResolveAll<INancyModule>().ToList();
		}
	}
}