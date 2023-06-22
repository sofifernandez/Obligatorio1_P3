using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UsuarioDTO
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Contrasena
        /// </summary>
        public string Password { get; set; }
    }
}
