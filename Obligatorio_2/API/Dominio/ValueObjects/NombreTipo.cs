using Dominio.ExcepcionesPropias;
using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.ValueObjects
{
    public class NombreTipo : IValidable
    {
        public string Value { get; private set; }
        private static Regex alphabetRegex = new("^[a-zA-Z áéíóúÁÉÍÓÚ]+$");

        public NombreTipo(string nombre)
        {
            Value = nombre;
            Validar();
        }

        private NombreTipo() { }


        public void Validar()
        {
            if (!alphabetRegex.IsMatch(Value)) { throw new Exception("El nombre puede contener solo letras y espacios"); }
            if (Value[0].ToString() == " ") { throw new Exception("No puede haber un espacio al comienzo del nombre"); }
            if (Value[Value.Length - 1].ToString() == " ") { throw new Exception("No puede haber un espacio al final del nombre"); }

        }
    }
}
