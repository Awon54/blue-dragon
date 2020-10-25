using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace blue_dragon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO remove this
            //EmployeeDummy test = new EmployeeDummy();
            //test.EmployeeDummyTest();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
