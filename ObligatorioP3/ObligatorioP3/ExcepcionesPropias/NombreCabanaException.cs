using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesPropias
{
    public class NombreCabanaException: Exception
    {
        public NombreCabanaException() : base()
        {
        }

        public NombreCabanaException(string mensaje) : base(mensaje)
        {
        }

        public NombreCabanaException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
