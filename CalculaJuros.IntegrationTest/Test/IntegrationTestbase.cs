using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace CalculaJuros.IntegrationTest.Test
{
    public class IntegrationTestbase
    {
        public IntegrationTestbase()
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile(GetSettings())
                .Build();

            Client = new HttpClient()
            {
                BaseAddress = new Uri(Config.GetValue<string>("CALCULA_JUROS_API"))
            };
        }

        protected IConfigurationRoot Config { get; private set; }
        protected HttpClient Client { get; private set; }

        private string GetSettings() => "integrationtest.settings.json";
    }
}
