using System.Threading.Tasks;

namespace CalculaJuros.Api.Infrastructure
{
    public interface ITaxaJurosService
    {
        public Task<double> getTaxaJuros();
    }
}
