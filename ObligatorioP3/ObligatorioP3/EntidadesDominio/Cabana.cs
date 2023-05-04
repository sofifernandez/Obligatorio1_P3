using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Dominio.EntidadesDominio
{
    [ForeignKey("tipoNombre")]
    public class Cabana
    {
        private static int UltHab = 1;
        public string NombreCabana { get; set; }

        [MinLength(10), MaxLength(500)] //Estos hay que hacerlos variables
        public string DescripCabana { get; set;}
        public bool Jacuzzi { get; set; }
        public bool Habilitado { get; set; }
        [Key]
        public int NumHabitacion { get; set; }
        public int MaxPersonas { get; set; }
        public string FotoCabana { get; set; }
        public Tipo Tipo { get; set; }
        public string TipoNombre { get; set; }

        //public string tipoCabananombre { get; set; } --> para la foreignkey (así po convención quedaría automático)
        // si quiero ponerlo con Data Annotations se pone arriba: [ForeignKey("Tipo")]

        public Cabana()
        {
            numHabitacion = ultHab++;
        }



    }
}
