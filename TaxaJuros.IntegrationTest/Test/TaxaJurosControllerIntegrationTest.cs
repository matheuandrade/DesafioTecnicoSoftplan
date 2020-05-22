using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TaxaJuros.IntegrationTest
{
    public class TaxaJurosControllerIntegrationTest : IntegrationTestbase
    {
        public class GetTaxaJuros : TaxaJurosControllerIntegrationTest
        {
            [Trait("Category", "Integration")]
            [Fact(DisplayName = "API - Integration - Smoke - TaxaJurosController - Get - Returns expected response.")]
            public async Task ReturnAsExpectedResult()
            {
                var response = await Client.GetAsync($"api/taxajuros");

                var result = JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());

                Assert.True(response.IsSuccessStatusCode);
                Assert.IsType<double>(result);            
            }
        }
    }
}
