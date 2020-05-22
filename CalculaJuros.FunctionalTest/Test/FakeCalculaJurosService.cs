using CalculaJuros.Api.Infrastructure;
using System.Threading.Tasks;

namespace CalculaJuros.FunctionalTest.Test
{
    public class FakeCalculaJurosService: ICalculaJurosService
    {
        public async Task<decimal> calculaJuros(decimal valorInicial, int tempo)
        {
            return await Task.Run(() => 1.0M);
        }
    }
}
