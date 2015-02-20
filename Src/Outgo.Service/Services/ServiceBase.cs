using System;

namespace Outgo.Service.Services
{
    public class ServiceBase
    {
        public ServiceBase(IDatabaseHost host)
        {
            _host = host;
        }

        private IDatabaseHost _host { get; set; }

        public T Call<T>(Func<IDatabaseHost, T> databaseFunction)
        {
            return databaseFunction(_host);
        }
    }
}