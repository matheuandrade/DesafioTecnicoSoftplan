using CalculaJuros.Api.Controllers;
using CalculaJuros.Api.Infrastructure;
using Moq;
using Xunit;

namespace CalculaJuros.UnitTest.Controllers
{
    public class CalculaJurosControllerUnitTest
    {
        private Mock<ICalculaJurosService> _mockCalculaJurosService;
        private CalculaJurosController _controller;

        public CalculaJurosControllerUnitTest()
        {
            _mockCalculaJurosService = new Mock<ICalculaJurosService>();
            _controller = new CalculaJurosController(_mockCalculaJurosService.Object);
        }

        public class CalculaJurosShould: CalculaJurosControllerUnitTest
        {
            [Trait("Category", "Unit")]
            [Fact(DisplayName = "Api - CalculaJurosController - Should call calculaJuros service properly")]
            public async void GetCalculaJuros()
            {
                decimal valorInicial = 1;
                int tempo = 2;

                _mockCalculaJurosService.Setup(mock => mock.calculaJuros(It.IsAny<decimal>(), It.IsAny<int>()));

                var response = await _controller.Get(valorInicial, tempo);

                _mockCalculaJurosService.Verify(
                    mock => mock.calculaJuros(It.Is<decimal>(req => req == valorInicial), It.Is<int>(req => req == tempo)), 
                    Times.Once, 
                    "Calcula juros should be called properly");
            }
        }
    }
}
