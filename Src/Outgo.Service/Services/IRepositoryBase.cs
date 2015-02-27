using System;

namespace Outgo.Service.Services
{
    public interface IRepositoryBase
    {
        IDatabaseHost Host { get; }

        T Call<T>(Func<IDatabaseHost, T> databaseFunction);
    }
}