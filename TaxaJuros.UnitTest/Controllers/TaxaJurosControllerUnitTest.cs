using Moq;
using TaxaJuros.Api.Controllers;
using TaxaJuros.Api.Infrastructure;
using Xunit;

namespace TaxaJuros.UnitTest.Controllers
{
    public class TaxaJurosControllerUnitTest
    {
        private Mock<IJurosService> _mockJurosService;
        private TaxaJurosController _controller;

        public TaxaJurosControllerUnitTest()
        {
            _mockJurosService = new Mock<IJurosService>();
            _controller = new TaxaJurosController(_mockJurosService.Object);
        }

        public class TaxaJurosShould : TaxaJurosControllerUnitTest
        {
            [Trait("Category", "Unit")]
            [Fact(DisplayName = "Api - TaxaJurosController - Should call taxaJuros service properly")]
            public void GetCalculaJuros()
            {
                _mockJurosService.Setup(mock => mock.getJuros());

                var response = _controller.Get();

                _mockJurosService.Verify(mock => mock.getJuros(),
                    Times.Once,
                    "Taxa juros should be called properly");
            }
        }
    }
}
