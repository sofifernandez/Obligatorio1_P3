using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class Cabana
    {
        private static int ultHab = 1;
        public string nombreCabana { get; set; }
        public string descripCabana { get; set;}
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        public int numHabitacion { get; set; }
        public int maxPersonas { get; set; }
        public string fotoCabana { get; set; }
        public Tipo tipoCabana { get; set; }
     

        public Cabana()
        {
            numHabitacion = ultHab++;
        }



    }
}
