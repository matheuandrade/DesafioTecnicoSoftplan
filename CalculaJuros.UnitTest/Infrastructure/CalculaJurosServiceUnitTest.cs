using CalculaJuros.Api.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculaJuros.UnitTest.Infrastructure
{
    public class CalculaJurosServiceUnitTest
    {
        private Mock<ITaxaJurosService> _mockTaxaJurosService;
        private CalculaJurosService _service;

        public CalculaJurosServiceUnitTest()
        {
            _mockTaxaJurosService = new Mock<ITaxaJurosService>();
            _service = new CalculaJurosService(_mockTaxaJurosService.Object);
        }

        public class CalculaJurosServiceShould : CalculaJurosServiceUnitTest
        {
            [Trait("Category", "Unit")]
            [Fact(DisplayName = "Api - CalculaJurosService - Should call calculaJuros service properly")]
            public async void CalculaJuros()
            {
                decimal valorInicial = 10;
                int tempo = 20;

                double taxa = 0.1;

                _mockTaxaJurosService.Setup(mock => mock.getTaxaJuros()).ReturnsAsync(taxa);

                var response = await _service.calculaJuros(valorInicial, tempo);

                _mockTaxaJurosService.Verify(
                    mock => mock.getTaxaJuros(),
                    Times.Once,
                    "Get taxa juros should be called properly");

                Assert.Equal((double)67.27, (double)response);
            }
        }
    }
}
