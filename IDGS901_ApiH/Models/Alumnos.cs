using System.ComponentModel.DataAnnotations;

namespace IDGS901_ApiH.Models
{
    public class Alumnos
    {
        [Key]
        public int Id { get; set; }
        public string? nombre { get; set; }
        public int edad { get; set; }

        public string? correo { get; set; }


    }
}
