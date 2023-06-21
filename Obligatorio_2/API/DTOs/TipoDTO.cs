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
        public int Id { get; set; }
       
        public string NombreTipo { get; set; }
       
        public string? DescTipo { get; set; }
       
        public int? CostoTipo { get; set; }
    }
}
