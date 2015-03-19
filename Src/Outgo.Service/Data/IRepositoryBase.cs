using System;

namespace Outgo.Service.Data
{
	public interface IRepositoryBase
	{
		T Call<T>(Func<IDatabaseHost, T> databaseFunction);
	}
}