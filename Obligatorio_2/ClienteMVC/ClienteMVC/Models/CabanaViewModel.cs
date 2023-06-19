using ClienteMVC.DTOs;

namespace ClienteMVC.Models
{
    public class CabanaViewModel
    {
        
        CabanaDTO Cabana { get; set; }
        public IEnumerable<TipoViewModel> Tipos { get; set; }
        public IFormFile Foto { get; set; }
        public int IdTipoSeleccionado { get; set; }
    }
}
