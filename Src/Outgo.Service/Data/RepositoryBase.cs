using System;

namespace Outgo.Service.Data
{
	public class RepositoryBase : IRepositoryBase
	{
		private readonly IDatabaseHost _host;

		public RepositoryBase(IDatabaseHost host)
		{
			_host = host;
		}

		public T Call<T>(Func<IDatabaseHost, T> databaseFunction)
		{
			return databaseFunction(_host);
		}
	}
}