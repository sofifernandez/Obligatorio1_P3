using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.InterfacesCU.IUsuario;
using Dominio.EntidadesDominio;
using Dominio.InterfacesRepositorios;
using DTOs;

namespace Aplicacion.CU.UsuarioCU
{
    public class Login : ILogin
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }

        public Login(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }

        UsuarioDTO ILogin.Login(string mail, string password)
        {
            UsuarioDTO dto = null;
            Usuario usu = RepoUsuarios.Login(mail, password);

            if (usu != null)
            {
                dto = new UsuarioDTO()
                {
                    Id = usu.Id,
                    Email = usu.Email,
                    Password = usu.Password
                };
            }

            return dto;
        }
    }
}
