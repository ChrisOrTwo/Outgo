using NUnit.Framework;
using Outgo.Service.Bootstrap;

namespace Outgo.Service.Integration.Tests
{
	[SetUpFixture]
	public class RepositoryTestsBase
	{
		protected TestingDatabaseHost TestingHost { get; set; }

		[SetUp]
		public void SetupFixture()
		{
			const string connectionString = "Server=127.0.0.1;Port=5432;Database=outgo;Uid=postgres;Pwd=postgres;";
			var config = new ConfigurationProvider { ConnectionString = connectionString };
			TestingHost = new TestingDatabaseHost(config);
		}

		[TearDown]
		public void TearDownFixture()
		{
			TestingHost.Dispose();
		}
	}
}