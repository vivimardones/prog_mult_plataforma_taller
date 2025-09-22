
using BlazorBiblioteca.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorBiblioteca.Context
{
    public class LibroDBContext : DbContext
    {
        public LibroDBContext(DbContextOptions<LibroDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .Property(l => l.FechaPublicacion)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();

        }

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
            { }
        }

        public class DateOnlyComparer : ValueComparer<DateOnly>
        {
            public DateOnlyComparer() : base(
                (d1, d2) => d1 == d2,
                d => d.GetHashCode(),
                d => d)
            { }
        }


        public DbSet<Libro> Libros { get; set; }

    }
}
