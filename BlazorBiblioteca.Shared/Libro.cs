using System.ComponentModel.DataAnnotations;

namespace BlazorBiblioteca.Shared
{
    public class Libro
    {
        public int Id { get; set; }
        public string? NombreLibro { get; set; }
        public string? Autor { get; set; }
        public int NumPaginas { get; set; }
        public DateOnly FechaPublicacion { get; set; }


    }
}
