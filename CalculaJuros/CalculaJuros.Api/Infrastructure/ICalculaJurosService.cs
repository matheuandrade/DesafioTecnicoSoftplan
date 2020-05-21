using System.Threading.Tasks;

namespace CalculaJuros.Api.Infrastructure
{
    public interface ICalculaJurosService
    {
        public Task<decimal> calculaJuros(decimal valorInicial, int tempo);
    }
}
