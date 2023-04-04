using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class Mantenimiento
    {
        public Cabana cabana { get; set; }
        public DateTime fechaMant { get; set; }
        public string descMant { get; set; }
        public int costoMant { get; set; }
        public string personal { get; set; }
    }
}
