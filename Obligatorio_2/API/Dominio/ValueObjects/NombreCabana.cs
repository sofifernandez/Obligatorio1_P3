using Dominio.ExcepcionesPropias;
using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    public class NombreCabana : IValidable
    {
        public string Value { get; private set; }
        private static Regex alphabetRegex = new("^[a-zA-Z áéíóúÁÉÍÓÚ]+$");

        public NombreCabana(string nombre)
        {
            Value = nombre;
            Validar();
        }

        private NombreCabana() { }


        public void Validar()
        {
            if (!alphabetRegex.IsMatch(Value)) { throw new AltaCabanaException("El nombre puede contener solo letras y espacios"); }
            if (Value[0].ToString() == " ") { throw new AltaCabanaException("No puede haber un espacio al comienzo del nombre"); }
            if (Value[Value.Length - 1].ToString() == " ") { throw new AltaCabanaException("No puede haber un espacio al final del nombre"); }

        }
    }
}
