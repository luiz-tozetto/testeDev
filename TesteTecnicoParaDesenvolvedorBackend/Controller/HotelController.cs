using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using TesteTecnicoParaDesenvolvedorBackend.Context;
using TesteTecnicoParaDesenvolvedorBackend.Models;
using TesteTecnicoParaDesenvolvedorBackend.Services;

namespace TesteTecnicoParaDesenvolvedorBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private HotelService _hotelService;
        private HotelContext _dbContext;

        public HotelController(HotelService hotelService)
        {
            this._hotelService = hotelService;
        }

        [HttpPost]
        public async Task<IActionResult> PostHotel(HotelModel hotel)
        {
            _dbContext.HotelModels.Add(hotel);
            var res = await _dbContext.SaveChangesAsync();

            return Ok(res);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHotel(string Id)
        {
            var res = await _dbContext.HotelModels.FindAsync(Id);

            if (res is null)
                throw new Exception("Hotel não encontrado.");

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> PutHotel(ReservaModel hotel)
        {
            if (hotel.Id is null)
                throw new Exception("Hotel não selecionado");

            _dbContext.Entry(hotel).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteHotel(string Id)
        {
            var hotel = await _dbContext.HotelModels.FindAsync(Id);
            _dbContext.HotelModels.Remove(hotel);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
