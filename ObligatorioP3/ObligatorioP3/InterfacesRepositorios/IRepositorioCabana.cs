using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDominio;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioCabana: IRepositorio<Cabana>
    {
        IEnumerable<Cabana> FindCabanaNombre(string nombre);
        IEnumerable<Cabana> FindCabanaMax(int maxPersonas);
        IEnumerable<Cabana> FindCabanaTipo(Tipo tipo);
        IEnumerable<Cabana> FindCabanasHabilitadas(bool habilitadas);

    }
}
