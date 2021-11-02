using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [StringLength(200, ErrorMessage = "El campo debe tener como max 200")]
        [Display(Name = "Descripcción", Prompt = "Ingrese una descripcción")]
        [Required(ErrorMessage = "Debe ingresar una descripccion")]
        public string Descripccion { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}