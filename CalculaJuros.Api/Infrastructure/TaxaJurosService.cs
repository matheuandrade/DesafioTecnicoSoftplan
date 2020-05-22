using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Api.Infrastructure
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _endpoint;

        public TaxaJurosService(Uri endpoint, HttpClient httpClient)
        {
            _endpoint = endpoint;
            _httpClient = httpClient;
        }

        public async Task<double> getTaxaJuros()
        {
            double taxaJuros = 0;

            var uriToBecalled = new Uri(_endpoint, $"/api/taxajuros");

            var response = await _httpClient.GetAsync(uriToBecalled);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                taxaJuros = JsonConvert.DeserializeObject<double>(jsonResult);
            }

            return taxaJuros;
        }
    }
}
