using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Hangar
    {
        public int HangarID { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Localizacion { get; set; }
    }

}