using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.InterfacesCU.IUsuario
{
    public interface ILogin
    {
        UsuarioDTO Login(string mail, string password);
    }
}
