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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cabana>().OwnsOne(c => c.NombreCabana)
                .HasIndex(nc => nc.Value).IsUnique();

            modelBuilder.Entity<Cabana>().OwnsOne(c => c.DescripCabana);

            modelBuilder.Entity<Tipo>().OwnsOne(t => t.NombreTipo)
               .HasIndex(nt => nt.Value).IsUnique();

            modelBuilder.Entity<Tipo>().OwnsOne(t => t.DescTipo);

            base.OnModelCreating(modelBuilder);
        }
    }
}
