using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoParaDesenvolvedorBackend.Context;
using TesteTecnicoParaDesenvolvedorBackend.Models;
using TesteTecnicoParaDesenvolvedorBackend.Services;

namespace TesteTecnicoParaDesenvolvedorBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private ReservaService _reservaService;
        private HotelContext _dbContext;

        public ReservaController(ReservaService reservaService)
        {
            this._reservaService = reservaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostReserva(ReservaModel reserva)
        {
            _dbContext.ReservaModels.Add(reserva);
            var res = await _dbContext.SaveChangesAsync();

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserva(string id)
        {
            var res = await _dbContext.ReservaModels.FindAsync(id);

            if (res is null)
                throw new Exception("Reserva não encontrada.");

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> PutReserva(ReservaModel reserva)
        {
            if (reserva.Id is null)
                throw new Exception("Reserva não selecionada.");

            _dbContext.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(string id)
        {
            var reserva = await _dbContext.ReservaModels.FindAsync(id);
            _dbContext.ReservaModels.Remove(reserva);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("checkin/{id}")]
        public async Task<IActionResult> RealizarCheckIn(string id)
        {
            var res = await _reservaService.RealizarCheckIn(id);

            return Ok(res);
        }

        [HttpPut("checkout/{id}")]
        public async Task<IActionResult> RealizarCheckOut(string id)
        {
            var res = await _reservaService.RealizarCheckOut(id);

            return Ok(res);
        }

        [HttpPut("verificaReservaAtiva")]
        public async Task<IActionResult> VerificaSePossuiReservaAtiva(ReservaModel reserva)
        {
            var res = await _reservaService.VerificaSePossuiReservaAtiva(reserva);

            return Ok(res);
        }
    }
}
