using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Piloto
    {
        public int PilotoID { get; set; }
        public int NumeroLicencia { get; set; }
        public string Restricciones { get; set; }
        public decimal Salario { get; set; }
        public string Turno { get; set; }
    }

}