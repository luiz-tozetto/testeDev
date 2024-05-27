using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoParaDesenvolvedorBackend.Context;
using TesteTecnicoParaDesenvolvedorBackend.Models;

namespace TesteTecnicoParaDesenvolvedorBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedeController : ControllerBase
    {
        public HotelContext _dbContext;
        public HospedeController(HotelContext hotelContext) 
        {
            _dbContext = hotelContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostHospede(HospedeModel Hospede)
        {
            _dbContext.HospedeModels.Add(Hospede);
            var res = await _dbContext.SaveChangesAsync();

            return Ok(res);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHospede(string Id)
        {
            var res = await _dbContext.HospedeModels.FindAsync(Id);

            if (res is null)
                throw new Exception("Hospede não encontrada.");

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> PutHospede(HospedeModel Hospede)
        {
            if (Hospede.Id is null)
                throw new Exception("Hospede não selecionada.");

            _dbContext.Entry(Hospede).State = EntityState.Modified;

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

        [HttpDelete]
        public async Task<IActionResult> DeleteHospede(string Id)
        {
            var Hospede = await _dbContext.HospedeModels.FindAsync(Id);
            _dbContext.HospedeModels.Remove(Hospede);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
