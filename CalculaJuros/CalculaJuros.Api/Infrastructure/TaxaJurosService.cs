using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var jsonMessage = await response.Content.ReadAsStringAsync();

            taxaJuros = JObject.Parse(jsonMessage).ToObject<double>();

            return taxaJuros;
        }
    }
}
