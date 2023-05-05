using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Dominio.EntidadesDominio
{
    [Index(nameof(Nombre), IsUnique=true)]
    public class Tipo
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string DescTipo { get; set; } //TIENE PARAMETROS VARIABLES (ENTR 10 Y 200)
        public int CostoTipo { get; set; }

        //VALIDAR EL NOMBRE--> CARACTERES ALFABETICOS Y ESPACIOS EMBEBIDOS (NO AL INICIO NI AL FINAL)
    }
}
