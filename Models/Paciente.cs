using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Complete este campo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Complete este campo")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Complete este campo")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Complete este campo")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Complete este campo")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; }

        public List<Turno> Turno { get; set; }
    }
}