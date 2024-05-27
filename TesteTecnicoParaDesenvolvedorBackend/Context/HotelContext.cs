using Microsoft.EntityFrameworkCore;
using TesteTecnicoParaDesenvolvedorBackend.Models;

namespace TesteTecnicoParaDesenvolvedorBackend.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> dbContextOp)
            :base (dbContextOp) { }

        public DbSet<HotelModel> HotelModels { get; set; }
        public DbSet<ReservaModel> ReservaModels { get; set; }
        public DbSet<HospedeModel> HospedeModels { get; set; }
        public DbSet<QuartoModel> QuartoModels { get; set; }


    }
}
