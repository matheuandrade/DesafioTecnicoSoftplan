using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxaJuros.Api;
using TaxaJuros.Api.Infrastructure;

namespace TaxaJuros.FunctionalTest.Test
{
    public class FakeStartup : Startup
    {
        public FakeStartup(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment) { }

        protected override void ConfigureJurosService(IServiceCollection services)
        {
            services.AddSingleton<IJurosService, FakeJurosService>();
        }
    }
}
