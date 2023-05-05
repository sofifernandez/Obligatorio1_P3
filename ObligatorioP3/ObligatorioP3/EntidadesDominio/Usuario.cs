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
        [EmailAddress]
        public string Emai { get; set; }
        [MinLength(6)]
        public string Password { get; set; }

        //VALIDAR QUE LA PASSWORD TENGA MAYUSCULAS Y MINUSCULAS Y NUMEROS
    }
}
