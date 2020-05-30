using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPersonas.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }

        [Phone(ErrorMessage = "Debe introducir un número de teléfono válido")]
        [StringLength(15, ErrorMessage ="Debe introducir un número de teléfono válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obigatorio introducir su cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage ="Es obligatorio introducir su dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir su fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public double Balance { get; set; }

    }
}
