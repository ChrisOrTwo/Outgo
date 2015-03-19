using NUnit.Framework;
using Outgo.Service.Data;

namespace Outgo.Service.Tests
{
	[TestFixture]
	public class DatabaseHostTest
	{
		[SetUp]
		public void Setup()
		{
			_databaseConnection = new object();
			_sut = new DatabaseHost(_databaseConnection);
		}

		private IDatabaseHost _sut;
		private dynamic _databaseConnection;

		[Test]
		public void DatabaseConnection_should_not_be_empty()
		{
			Assert.IsNotNull(_sut.Session);
		}
	}
}