using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class Tipo
    {
        public string nombre { get; set; } //[Key?]
        public string descTipo { get; set; }
        public int costoTipo { get; set; }
    }
}
