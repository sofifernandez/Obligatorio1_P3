using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.EntidadesDominio
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public DateTime FechaMant { get; set; }
        [MinLength(10), MaxLength(200)]
        public string DescMant { get; set; } 
        public int CostoMant { get; set; }
        public string Personal { get; set; }
        public Cabana Cabana { get; set; }
        public int CabanaId { get; set; }
    }
}
