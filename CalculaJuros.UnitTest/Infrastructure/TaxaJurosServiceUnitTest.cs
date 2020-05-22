using CalculaJuros.Api.Infrastructure;
using Moq;
using Moq.Protected;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.UnitTest.Infrastructure
{
    public class TaxaJurosServiceUnitTest
    {
        protected readonly Mock<HttpMessageHandler> _mockHtppHandler;
        protected readonly TaxaJurosService _service;
        protected readonly string _baseEndpoint = "http://www.test.com";

        public TaxaJurosServiceUnitTest()
        {
            _mockHtppHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHtppHandler.Object);

            _service = new TaxaJurosService(new Uri(_baseEndpoint), httpClient);
        }

        public class TaxaJurosServiceShould : TaxaJurosServiceUnitTest
        {
            [Trait("Category", "Unit")]
            [Fact(DisplayName = "Api - TaxaJurosService - Should call taxa juros service")]
            public async void TaxaJuros()
            {
                double taxa = 0.1;
                var expectedEndopintToBeCalled = new Uri(new Uri(_baseEndpoint), $"/api/taxajuros");

                _mockHtppHandler.Protected()
                            .Setup<Task<HttpResponseMessage>>(
                            "GetAsync",
                            ItExpr.IsAny<HttpResponseMessage>())
                            .ReturnsAsync(
                        new HttpResponseMessage()
                        {
                            StatusCode = System.Net.HttpStatusCode.OK,
                            Content = new StringContent(taxa.ToString())
                        }
                    ).Verifiable();

                var response = await _service.getTaxaJuros();

                _mockHtppHandler.Protected().Verify(
                    "GetAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri == expectedEndopintToBeCalled
                    ));

                Assert.Equal(response, taxa);
            }
        }
    }
}
