using Humanizer;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoParaDesenvolvedorBackend.Context;
using TesteTecnicoParaDesenvolvedorBackend.Models;

namespace TesteTecnicoParaDesenvolvedorBackend.Services
{
    public class ReservaService
    {
        private HotelContext _dbContext;

        public ReservaService() { }

        public async Task<bool> JaPossuiReserva(string idHospede, string idHotel)
        {
            var reserva = await _dbContext.ReservaModels.Where(r => r.IdHospede == idHospede).SingleOrDefaultAsync();

            if (reserva.Id is not null)
                throw new Exception("O hospede já possui uma reserva.");

            return true;
        }

        public async Task<bool> VerificaSePossuiReservaAtiva(ReservaModel reserva)
        {
            var res = await _dbContext.ReservaModels.Where(r => r.IdHospede == reserva.IdHospede && (r.Entrada >= reserva.Entrada && r.Saida <= reserva.Saida)).SingleOrDefaultAsync();

            if (res.Id is not null)
                throw new Exception("O hóspede já possuia uma reserva ativa neste data.");

            return true;
        }

        public async Task<bool> RealizarCheckIn(string idReserva)
        {
            var res = await _dbContext.ReservaModels.FindAsync(idReserva);

            _dbContext.Entry(res).State = EntityState.Modified;

            res.Entrada = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RealizarCheckOut(string idReserva)
        {
            var res = await _dbContext.ReservaModels.FindAsync(idReserva);

            _dbContext.Entry(res).State = EntityState.Modified;

            res.Saida = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
