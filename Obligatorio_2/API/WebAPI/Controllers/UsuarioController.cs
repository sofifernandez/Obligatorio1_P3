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
        /// <summary>
        /// Ingreso al sistema mediante usuario y contraseña
        /// </summary>
        /// <param name="usuario">Información del usuario</param>
        /// <returns>Devuelve un OK.200 y genera un Token asociado</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] UsuarioDTO usuario)
        {
            UsuarioDTO logueado = CULogin.Login(usuario.Email, usuario.Password);
            if (logueado == null) return Unauthorized("El usuario o la contraseña no son correctos");
            //return Ok(new DTOLogin() { Rol = logueado.Rol, TokenJWT = ManejadorJWT.GenerarToken(logueado) });
            return Ok(new LoginDTO() { TokenJWT = ManejadorJWT.GenerarToken(logueado) });
        }
    }
}
