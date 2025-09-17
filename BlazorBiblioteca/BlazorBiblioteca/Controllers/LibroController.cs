using BlazorBiblioteca.Context;
using BlazorBiblioteca.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroDBContext _context;

        public LibroController(LibroDBContext context)
        {
            _context = context;
        }

        [HttpGet("ConexionLibros")]
        public async Task<ActionResult<string>> GetConexionLibros()
        {
            try
            {
                var respuesta = await _context.Libros.ToListAsync();
                return "Conectado a la base de datos y a la tabla LIBROS";
            }
            catch (Exception)
            {
                return "Error de conexión con LIBROS";
            }
        }
        [HttpGet("ConexionServidor")]
        public ActionResult<string> Conexion()
        {
            return Ok("Conectado con el servidor");
        }

        [HttpGet("LibrosListar")]
        public async Task<ActionResult<List<Libro>>> ListarLibros()
        {
            var res = await _context.Libros.ToListAsync();
            return res;
        }
        [HttpPost("LibroAgregar")]
        public async Task<ActionResult<string>> HandleCreateLibro([FromBody] Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            var res = await _context.SaveChangesAsync();

            if (res == 1) return Created();
            else return BadRequest();
        }
        [HttpPut("libro/{id}")]
        public async Task<ActionResult<string>> ActualizarLibro(int id, Libro libro)
        {
            var find = await _context.Libros.FindAsync(id);

            if (find == null) return NotFound();

            var res = await _context.Libros
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.NombreLibro, libro.NombreLibro)
                    .SetProperty(p => p.Autor, libro.Autor)
                    .SetProperty(p => p.NumPaginas, libro.NumPaginas)
                    .SetProperty(p => p.FechaPublicacion, libro.FechaPublicacion));

            if (res == 1) return Ok();
            else return BadRequest();
        }
        [HttpDelete("libro/{id}")]
        public async Task<ActionResult<string>> HandleDeleteLibro([FromRoute] int id)
        {
            var find = await _context.Libros.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (find == 1) return Ok();
            else return BadRequest();
        }

    }
}
