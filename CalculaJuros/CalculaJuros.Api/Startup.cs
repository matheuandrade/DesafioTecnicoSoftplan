using CalculaJuros.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace CalculaJuros.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(httpClientHandler)
            {
                Timeout = new TimeSpan(0, 2, 0)
            };
        }

        private HttpClient _httpClient;

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureTaxaJurosService(services);
            ConfigureCalculaJurosService(services);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected virtual void ConfigureTaxaJurosService(IServiceCollection services)
        {
            var endpoint = new Uri(Environment.GetEnvironmentVariable("TAXA_JUROS_API"));

            services.AddSingleton<ITaxaJurosService>(provider => new TaxaJurosService(endpoint, _httpClient));
        }

        protected virtual void ConfigureCalculaJurosService(IServiceCollection services)
        {
            services.AddSingleton<ICalculaJurosService, CalculaJurosService>();
        }
    }
}
