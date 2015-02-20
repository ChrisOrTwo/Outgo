using System.Data.SqlClient;
using Simple.Data;

namespace Outgo.Service.Services
{
    public class ServiceBootstrap
    {
        private dynamic _db;
        private SqlConnection _connection;

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