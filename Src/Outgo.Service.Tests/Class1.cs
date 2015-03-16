using NUnit.Framework;
using Outgo.Service.Services;

namespace Outgo.Service.Tests
{
    [TestFixture]
    public class DatabaseHostTest
    {
        private IDatabaseHost _sut;
        private dynamic _databaseConnection;

        [SetUp]
        public void Setup()
        {
            _databaseConnection = new object();
            _sut = new DatabaseHost(_databaseConnection);
        }

        [Test]
        public void DatabaseConnection_should_not_be_empty()
        {
            Assert.IsNotNull(_sut.DatabaseConnection);
        }
    }
}
