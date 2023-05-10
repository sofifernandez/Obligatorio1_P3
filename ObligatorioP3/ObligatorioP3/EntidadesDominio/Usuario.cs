using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Dominio.InterfacesDominio;

namespace Dominio.EntidadesDominio
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario: IValidable
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage ="El campo ingresado no tiene formato de email")]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage ="La contraseña debe tener más de 6 caracteres")]
        public string Password { get; set; }


        public void Validar() 
        {
            bool tieneMinuscula =false;
            bool tieneMayuscula =false;
            bool tieneNumero = false;

            foreach (char c in Password)
            {
                if (char.IsLower(c))
                {
                    tieneMinuscula = true;
                }
                else if (char.IsUpper(c))
                {
                    tieneMayuscula = true;
                }
                else if (char.IsDigit(c))
                {
                    tieneNumero = true;
                }
            }

            if (!tieneMinuscula || !tieneMayuscula || !tieneNumero) 
            {
                throw new Exception("La contraseña debe tener al menos una mayúscula, una miníscula y un número");
            }

        }
    }
}
