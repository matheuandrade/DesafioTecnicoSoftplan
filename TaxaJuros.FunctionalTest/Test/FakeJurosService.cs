using TaxaJuros.Api.Infrastructure;

namespace TaxaJuros.FunctionalTest.Test
{
    public class FakeJurosService: IJurosService
    {
        public double getJuros()
        {
            return 0.0;
        }
    }
}
