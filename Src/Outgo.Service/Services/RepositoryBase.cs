using System;

namespace Outgo.Service.Services
{
    public class RepositoryBase : IRepositoryBase
    {
        public RepositoryBase(IDatabaseHost host)
        {
            _host = host;
        }

        private readonly IDatabaseHost _host;

        public IDatabaseHost Host
        {
            get { return _host; }
        }

        public T Call<T>(Func<IDatabaseHost, T> databaseFunction)
        {
            return databaseFunction(_host);
        }
    }
}