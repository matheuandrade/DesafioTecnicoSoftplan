using CalculaJuros.Api.Infrastructure;
using System.Threading.Tasks;

namespace CalculaJuros.FunctionalTest.Test
{
    public class FakeTaxaJurosService: ITaxaJurosService
    {
        public async Task<double> getTaxaJuros()
        {
            return await Task.Run(() => 1.0);
        }
    }
}
