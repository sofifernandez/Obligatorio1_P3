using Aplicacion.InterfacesCU.IUsuario;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       
        public ILogin CULogin { get; set; }

        public UsuarioController(ILogin cuLogin)
        {
            CULogin = cuLogin;
        }

        //api/usuarios/login POST
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuario)
        {
            UsuarioDTO logueado = CULogin.Login(usuario.Email, usuario.Password);
            if (logueado == null) return Unauthorized("El usuario o la contraseña no son correctos");
            //return Ok(new DTOLogin() { Rol = logueado.Rol, TokenJWT = ManejadorJWT.GenerarToken(logueado) });
            return Ok(new LoginDTO() { TokenJWT = ManejadorJWT.GenerarToken(logueado) });
        }
    }
}
