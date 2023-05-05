using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesAuxiliares;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioParametro : IRepositorio<Parametro>
    {
        string ValorParametro(string nombre);
    }
}
