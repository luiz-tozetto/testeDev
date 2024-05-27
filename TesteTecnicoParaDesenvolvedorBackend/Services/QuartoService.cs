using Microsoft.EntityFrameworkCore;
using TesteTecnicoParaDesenvolvedorBackend.Context;
using TesteTecnicoParaDesenvolvedorBackend.Models;

namespace TesteTecnicoParaDesenvolvedorBackend.Services
{
    public class QuartoService
    {
        private HotelContext _dbContext;

        public QuartoService() { }

        public async Task<bool> EstaOcupado(string idQuarto)
        {
            var quarto = await _dbContext.FindAsync<QuartoModel>(idQuarto);

            if (quarto.Ocupado)
                throw new Exception("O quarto encontra-se ocupado.");

            return true;
        }
    }
}
