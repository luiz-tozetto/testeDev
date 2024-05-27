using System.Diagnostics.Contracts;
using TesteTecnicoParaDesenvolvedorBackend.Models.Base;

namespace TesteTecnicoParaDesenvolvedorBackend.Models
{
    public class ReservaModel : ModelBase
    {
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public string IdQuarto { get; set; }
        public string IdHospede { get; set; }
        public string IdHotel { get; set; }
    }
}
