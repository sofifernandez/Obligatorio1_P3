﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.EntidadesDominio
{
    public class Cabana
    {
        private static int ultHab = 1;
        [MaxLength(100)]
        public string nombreCabana { get; set; }
        public string descripCabana { get; set;}
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        public int numHabitacion { get; set; }
        public int maxPersonas { get; set; }
        public string fotoCabana { get; set; }
        public Tipo tipoCabana { get; set; }

        //public string tipoCabananombre { get; set; } --> para la foreignkey (así po convención quedaría automático)
        // si quiero ponerlo con Data Annotations se pone arriba: [ForeignKey("Tipo")]

        public Cabana()
        {
            numHabitacion = ultHab++;
        }



    }
}
