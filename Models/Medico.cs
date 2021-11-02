using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "debe completar este campo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "debe completar este campo")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "debe completar este campo")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "debe completar este campo")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [EmailAddress(ErrorMessage = "email incorrecto")]
        [Required(ErrorMessage = "debe completar este campo")]
        public string Email { get; set; }

        [Display(Name = "Horario desde")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }

        [Display(Name = "Horario hasta")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        public List<Turno> Turno { get; set; }
    }
}