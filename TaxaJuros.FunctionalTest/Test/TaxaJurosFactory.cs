using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using TaxaJuros.Api;

namespace TaxaJuros.FunctionalTest.Test
{
    public class TaxaJurosFactory : WebApplicationFactory<FakeStartup>
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
