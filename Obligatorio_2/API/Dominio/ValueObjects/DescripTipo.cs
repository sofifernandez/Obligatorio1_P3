using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    public class DescripTipo
    {
        public static int MinDescripTipo { get; set; }
        public static int MaxDescripTipo { get; set; }

        public string Value { get; private set; }

        public DescripTipo(string descripcion)
        {
            Value = descripcion;
            Validar();
        }

        private DescripTipo()
        {
        }

        public void Validar()
        {
            if (Value.Length < MinDescripTipo) { throw new Exception("La descripción del tipo no puede tener menos de " + MinDescripTipo); }
            if (Value.Length > MaxDescripTipo) { throw new Exception("La descripción del tipo no puede tener más de " + MaxDescripTipo); }
        }
    }
}
