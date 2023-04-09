using Microsoft.Extensions.Configuration;

namespace Manager.Infrastructure.Connection
{
    public class GetConnection
    {
        private static readonly string _path = @"\..\..\..\..\bar_manager\Manager.Infrastructure\Connection\appSettings.json";
        private static readonly string _path2 = @"C:\Users\HP\Source\Repos\BarManager\Manager.Infrastructure\Connection\appSettings.json";
        private static readonly string _elyorbek = @"D:\C# darslar\Bar_Manager\bar_manager\Manager.Infrastructure\Connection\appSettings.json";
        //D:\C# darslar\Bar_Manager\bar_manager\Manager.Infrastructure\Connection\appSettings.json
        public static string Connection()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(_elyorbek, true, true);
            
            IConfiguration configuration = builder.Build();
            return  configuration.GetConnectionString("MyConnectionString");


        }
    }
}
