using System.Data.SqlClient;
using Autofac;
using Outgo.Service.Services;
using Simple.Data;

namespace Outgo.Service.Bootstrap
{
    public class ServiceBootstrap
    {
        private dynamic _db;
        private SqlConnection _connection;
        private ContainerBuilder _builder;

        public void InitializeBuilder()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterType<DatabaseHost>().As<IDatabaseHost>();

        }

        public void InitializeSharedConnection(string connectionString)
        {
            
             

            _db = Database.OpenConnection(connectionString);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _db.UseSharedConnection(_connection);

            InitializeServices(new DatabaseHost(_db));
        }

        public void InitializeServices(IDatabaseHost host)
        {
            
        }

        public void Close()
        {
            _db.StopUsingSharedConnection();
            _connection.Close();
        }

    }
}