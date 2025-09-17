
using BlazorBiblioteca.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorBiblioteca.Context
{
    public class LibroDBContext : DbContext
    {
        public LibroDBContext(DbContextOptions<LibroDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Libro> Libros { get; set; }

    }
}
