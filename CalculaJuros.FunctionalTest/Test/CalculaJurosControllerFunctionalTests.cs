using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace CalculaJuros.FunctionalTest.Test
{
    public class CalculaJurosControllerFunctionalTests : IClassFixture<CalculaJurosFactory>
    {
        protected readonly HttpClient _client;

        public CalculaJurosControllerFunctionalTests(CalculaJurosFactory factory) => _client = factory.CreateClient();

        public class TaxaJurosShould : CalculaJurosControllerFunctionalTests
        {
            public TaxaJurosShould(CalculaJurosFactory factory) : base(factory)
            {

            }

            [Trait("Category", "Functional")]
            [Fact(DisplayName = "Api - Integration - Functional - CalculaJurosController - Returns Ok as result from Get method")]
            public async void ReturnOkfromGet()
            {
                int valorInicial = 0;
                int tempo = 0;

                var response = await _client.GetAsync($"api/calculajuros?valorinicial={valorInicial}&tempo={tempo}");
                Assert.True(response.IsSuccessStatusCode);
            }
        }

    }
}
