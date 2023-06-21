using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class AltaMantenimientoException:Exception
    {
        public AltaMantenimientoException() : base()
        {
        }

        public AltaMantenimientoException(string mensaje) : base(mensaje)
        {
        }

        public AltaMantenimientoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
