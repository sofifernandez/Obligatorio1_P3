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
        public int Id { get; set; }
        public string NombreCabana { get; set; }   
        public string? DescripCabana { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }      
        public int? MaxPersonas { get; set; }
        public string? FotoCabana { get; set; }
        public TipoDTO? Tipo { get; set; }
        public int TipoId { get; set; }
    }
}
