using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
    public class CabanaDTO
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string NombreCabana { get; set; }   
        /// <summary>
        /// Descripcion
        /// </summary>
        public string? DescripCabana { get; set; }
        /// <summary>
        /// Si contiene jacuzzi
        /// </summary>
        public bool Jacuzzi { get; set; }
        /// <summary>
        /// Si está habilitado
        /// </summary>
        public bool Habilitado { get; set; }    
        /// <summary>
        /// Máximo de huéspedes
        /// </summary>
        public int? MaxPersonas { get; set; }
        /// <summary>
        /// string que identifica la imagen
        /// </summary>
        public string? FotoCabana { get; set; }
        /// <summary>
        /// Información del tipo
        /// </summary>
        public TipoDTO? Tipo { get; set; }
        /// <summary>
        /// Identificador del tipo
        /// </summary>
        public int TipoId { get; set; }
    }
}
