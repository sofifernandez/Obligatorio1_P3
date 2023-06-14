using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDominio;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioTipo: IRepositorio<Tipo>
    {
        public Tipo FindTipoByNombre(string nombreTipo);
    }
}
