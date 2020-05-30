using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPersonas.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        [Required(ErrorMessage ="Es necesario introducir la Fecha")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="Es Necesario seleccionar la Persona")]
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "Es necesario introducir el concepto")]
        public string Concepto { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un monto")]
        public double Monto { get; set; }
        public double Balance { get; set; }

    }
}
