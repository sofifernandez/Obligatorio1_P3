using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesPropias
{
    public class AltaCabanaException: Exception
    {
        public AltaCabanaException() : base()
        {
        }

        public AltaCabanaException(string mensaje) : base(mensaje)
        {
        }

        public AltaCabanaException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
