using CalculaJuros.Api;
using CalculaJuros.Api.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculaJuros.FunctionalTest.Test
{
    public class FakeStartup : Startup
    {
        public FakeStartup(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment) { }

        protected override void ConfigureTaxaJurosService(IServiceCollection services)
        {
            services.AddSingleton<ITaxaJurosService, FakeTaxaJurosService>();
        }

        protected override void ConfigureCalculaJurosService(IServiceCollection services)
        {
            services.AddSingleton<ICalculaJurosService, FakeCalculaJurosService>();
        }
    }
}
