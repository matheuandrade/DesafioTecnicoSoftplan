using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Net.Http;
using Xunit;

namespace TaxaJuros.FunctionalTest.Test
{
    public class TaxaJurosControllerFunctionalTests: IClassFixture<TaxaJurosFactory>
    {
        protected readonly HttpClient _client;

        public TaxaJurosControllerFunctionalTests(TaxaJurosFactory factory) => _client = factory.CreateClient();

        public class TaxaJurosShould : TaxaJurosControllerFunctionalTests
        {
            public TaxaJurosShould(TaxaJurosFactory factory) : base(factory)
            {

            }

            [Trait("Category", "Functional")]
            [Fact(DisplayName = "Api - Integration - Functional - TaxaJurosController - Returns Ok as result from Get method")]
            public async void ReturnOkfromGet()
            {
                var response = await _client.GetAsync($"api/taxajuros");
                Assert.True(response.IsSuccessStatusCode);
            }
        }
    }
}
