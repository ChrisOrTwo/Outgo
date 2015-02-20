namespace Outgo.Service.Services
{
    public interface IDatabaseHost
    {
        dynamic DatabaseConnection { get; set; }
    }
}