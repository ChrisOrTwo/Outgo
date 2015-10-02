using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Outgo.Service.Bootstrap;
using Outgo.Service.Data;
using Simple.Data;

namespace Outgo.Service.Integration.Tests
{
	public class TestingDatabaseHost : IDatabaseHost, IDisposable
	{
		private readonly dynamic _pgTransaction;

		public TestingDatabaseHost(IConfigurationProvider provider)
		{
			var db = Database.OpenConnection(provider.ConnectionString);
			_pgTransaction = db.BeginTransaction(IsolationLevel.ReadUncommitted);
		}

		public dynamic Session
		{
			get { return _pgTransaction; }
		}

		public void Dispose()
		{
			_pgTransaction.Dispose();
		}

	}
}
