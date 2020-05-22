using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;

namespace TaxaJuros.IntegrationTest
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
                BaseAddress = new Uri(Config.GetValue<string>("TAXA_JUROS_API"))
            };
        }

        protected IConfigurationRoot Config { get; private set;  }
        protected HttpClient Client { get; private set; }

        private string GetSettings() => "integrationtest.settings.json";
    }
}
