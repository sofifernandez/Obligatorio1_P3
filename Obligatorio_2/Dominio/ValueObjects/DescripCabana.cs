using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    public class DescripCabana: IValidable
    {
        //Constraints variables de la descripción: Min=10 y Max=500
        public static int MinDescripCabana { get; set; }
        public static int MaxDescripCabana { get; set; }

        public string Value { get; private set; }

        public DescripCabana(string descripcion)
        {
            Value = descripcion;
            Validar();
        }

        private DescripCabana()
        {
        }

        public void Validar()
        {
            if (Value.Length < MinDescripCabana) { throw new Exception("La descripción de la cabaña no puede tener menos de " + MinDescripCabana); }
            if (Value.Length > MaxDescripCabana) { throw new Exception("La descripción de la cabaña no puede tener más de " + MaxDescripCabana); }
        }
    }
}
