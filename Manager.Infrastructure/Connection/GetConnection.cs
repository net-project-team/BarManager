using Microsoft.Extensions.Configuration;

namespace Manager.Infrastructure.Connection
{
    public class GetConnection
    {
        private static readonly string _path = @"\..\..\..\..\..\BarManager\Manager.Infrastructure\Connection\appSettings.json";
        public static string Connection()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(_path, true, true);
            
            IConfiguration configuration = builder.Build();
            return  configuration.GetConnectionString("MyConnectionString");

        }
    }
}
