using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Avion
    {
        public int AvionID { get; set; }
        public int Numero { get; set; }
        public string Modelo { get; set; }
        public int Peso { get; set; }
        public int Capacidad { get; set; }
        public int HangarID { get; set; }
    }

}