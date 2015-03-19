namespace Outgo.Service.Bootstrap
{
	public interface IConfigurationProvider
	{
		string ConnectionString { get; set; }
	}

	public class ConfigurationProvider : IConfigurationProvider
	{
		public string ConnectionString { get; set; }
	}
}