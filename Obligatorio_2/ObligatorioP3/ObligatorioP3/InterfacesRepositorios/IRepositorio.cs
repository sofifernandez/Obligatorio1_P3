using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        void Add(T obj);
        IEnumerable<T> FindAll();
        void Remove(int id);
        void Update(T obj);
        T FindById(int id);

    }
}
