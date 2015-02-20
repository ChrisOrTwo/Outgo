namespace Outgo.Service.Services
{
    public class DatabaseHost : IDatabaseHost
    {
        public DatabaseHost(dynamic databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        public dynamic DatabaseConnection { get; set; }
    }
}