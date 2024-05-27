using TesteTecnicoParaDesenvolvedorBackend.Models.Base;

namespace TesteTecnicoParaDesenvolvedorBackend.Models
{
    public class QuartoModel : ModelBase
    {
        public int Numero { get; set; }

        public string IdHotel { get; set; }
        public bool Ocupado { get; set; }
    }
}
