using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Api.Infrastructure
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ITaxaJurosService _taxaJurosService;
        public CalculaJurosService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<decimal> calculaJuros(decimal valorInicial, int tempo)
        {
            var juros = await _taxaJurosService.getTaxaJuros();

            juros =+ 1;

            var valorFinal = Math.Round((valorInicial * (decimal)Math.Pow(juros, tempo)), 2);

            return valorFinal;
        }
    }
}
