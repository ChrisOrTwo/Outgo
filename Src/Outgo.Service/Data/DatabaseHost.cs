using System;
using Npgsql;
using Outgo.Service.Bootstrap;
using Simple.Data;

namespace Outgo.Service.Data
{
	public class DatabaseHost : IDatabaseHost, IDisposable
	{
		private readonly NpgsqlConnection _connection;
		private readonly dynamic _session;

		public DatabaseHost(IConfigurationProvider provider)
		{
			_session = Database.OpenConnection(provider.ConnectionString);
			_connection = new NpgsqlConnection(provider.ConnectionString);
			_connection.Open();
			_session.UseSharedConnection(_connection);
		}

		public dynamic Session
		{
			get { return _session; }
		}

		public void Dispose()
		{
			_session.StopUsingSharedConnection();
			_connection.Close();
		}
	}
}