using Microsoft.EntityFrameworkCore; // el ORM object to relational mapping
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia //similar a un paquete java

{
    public class AppContext:DbContext
    {
        public DbSet<Persona> Personas {get;set;}

        public DbSet<Veterinario> Veterinarios {get;set;}

        public DbSet<Dueno> Duenos {get;set;}

        public DbSet<VisitaPyP> VisitasPyP {get;set;}

        public DbSet<Historia> Historias {get;set;}

        public DbSet<Mascota> Mascotas {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MascotaFelizData");
            }
        }
    }
}