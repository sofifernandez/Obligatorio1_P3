using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.InterfacesCU.ICabana
{
    public interface IBuscarPorID
    {
        CabanaDTO Buscar(int id);
    }
}
