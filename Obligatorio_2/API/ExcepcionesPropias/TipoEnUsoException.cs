using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class TipoEnUsoException:Exception
    {
        public TipoEnUsoException() : base()
        {
        }

        public TipoEnUsoException(string mensaje) : base(mensaje)
        {
        }

        public TipoEnUsoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
