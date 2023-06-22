using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TipoDTO
    {
        /// <summary>
        /// Identificador del tipo
        /// </summary>
        public int Id { get; set; }
       /// <summary>
       /// Nombre
       /// </summary>
        public string NombreTipo { get; set; }
       /// <summary>
       /// Descripcion
       /// </summary>
        public string? DescTipo { get; set; }
       /// <summary>
       /// Costo diario
       /// </summary>
        public int? CostoTipo { get; set; }
    }
}
