using System;

namespace Outgo.Service.Services
{
    public interface IRepositoryBase
    {
        T Call<T>(Func<IDatabaseHost, T> databaseFunction);
    }
}