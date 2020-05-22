using CalculaJuros.Api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace CalculaJuros.FunctionalTest.Test
{
    public class CalculaJurosFactory : WebApplicationFactory<FakeStartup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .ConfigureTestServices(services =>
                {
                    services.AddControllers()
                    .AddApplicationPart(typeof(Startup).Assembly);
                })
                .UseStartup<FakeStartup>();
        }
    }
}
