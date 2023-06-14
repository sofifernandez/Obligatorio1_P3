using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesAuxiliares;
using Dominio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;


namespace Datos.ContextoEF
{
    public class HotelContext:DbContext
    {
        public DbSet<Cabana> Cabanas { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Parametro> Parametros { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options):base(options) { }
    }
}
