using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoParaDesenvolvedorBackend.Context;
using TesteTecnicoParaDesenvolvedorBackend.Models;

namespace TesteTecnicoParaDesenvolvedorBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : ControllerBase
    {
        public HotelContext _dbContext;

        public QuartoController() { }

        [HttpPost]
        public async Task<IActionResult> PostQuarto(QuartoModel Quarto)
        {
            _dbContext.QuartoModels.Add(Quarto);
            var res = await _dbContext.SaveChangesAsync();

            return Ok(res);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetQuarto(string Id)
        {
            var res = await _dbContext.QuartoModels.FindAsync(Id);

            if (res is null)
                throw new Exception("Quarto não encontrado.");

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> PutQuarto(ReservaModel Quarto)
        {
            if (Quarto.Id is null)
                throw new Exception("Quarto não selecionado");

            _dbContext.Entry(Quarto).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteQuarto(string Id)
        {
            var Quarto = await _dbContext.QuartoModels.FindAsync(Id);
            _dbContext.QuartoModels.Remove(Quarto);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
