using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;

namespace Datos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public HotelContext Contexto { get; set; }

        public RepositorioUsuario(HotelContext contexto)
        {
            Contexto = contexto;    
        }
        public void Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Login(string email, string password)
        {
            Usuario? usuario = Contexto.Usuarios
                                            .Where(usuario => usuario.Email == email)
                                            .Where(usuario => usuario.Password == password)
                                            .SingleOrDefault();
            //CÓMO SIGUE ESTO?
            
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
