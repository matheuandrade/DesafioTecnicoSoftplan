using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.IntegrationTest.Test
{
    public class CalculaJurosControllerIntegrationTest: IntegrationTestbase
    {
        public class GetCalculoJuros : CalculaJurosControllerIntegrationTest
        {
            [Trait("Category", "Integration")]
            [Fact(DisplayName = "API - Integration - Smoke - CalculaJurosController - Get - Returns expected response.")]
            public async Task ReturnAsExpectedResult()
            {
                var response = await Client.GetAsync($"api/calculajuros");

                var result = JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());

                Assert.True(response.IsSuccessStatusCode);
                Assert.IsType<decimal>(result);
            }
        }
    }
}
