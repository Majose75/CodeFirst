using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class LibreriaContext: DbContext
    {
        // Creamos las bases de Datos
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        // Se indica dónde se va a guardar/crear las BD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"server=(localdb)\MSSQLLocalDB;database=Libreria;Integrated Security=True");
        }

    }
}
