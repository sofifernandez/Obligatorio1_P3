
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MantenimientoDTO
    {
        /// <summary>
        /// Identificador del mantenimientos
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime FechaMant { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string? DescMant { get; set; }
        /// <summary>
        /// Costo asociado
        /// </summary>
        public int? CostoMant { get; set; }
        /// <summary>
        /// Personal que lo realizó
        /// </summary>
        public string? Personal { get; set; }
        /// <summary>
        /// Toda la información de la cabaña
        /// </summary>
        public CabanaDTO? Cabana { get; set; }
        /// <summary>
        /// Identificador de la cabaña
        /// </summary>
        public int CabanaId { get; set; }
    }
}
