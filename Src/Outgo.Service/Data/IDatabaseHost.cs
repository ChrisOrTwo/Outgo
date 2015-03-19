namespace Outgo.Service.Data
{
	public interface IDatabaseHost
	{
		dynamic Session { get; }
	}
}