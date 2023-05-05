using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.EntidadesDominio
{
    public class Usuario
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage ="El campo ingresado no tiene formato de email")]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage ="La contraseña debe tener más de 6 caracteres")]
        public string Password { get; set; }

        //VALIDAR QUE LA PASSWORD TENGA MAYUSCULAS Y MINUSCULAS Y NUMEROS
    }
}
