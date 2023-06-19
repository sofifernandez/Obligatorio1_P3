using Dominio.EntidadesDominio;
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
        public int Id { get; set; }
        public DateTime FechaMant { get; set; }
        public string? DescMant { get; set; }
        public int? CostoMant { get; set; }
        public string? Personal { get; set; }
        public Cabana? Cabana { get; set; }
        public int CabanaId { get; set; }
    }
}
