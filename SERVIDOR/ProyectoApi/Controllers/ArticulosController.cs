using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data;
using ProyectoAPI.Models;

namespace ProyectoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArticulosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string? busqueda, string? orden = "ASC")
        {
            var query = _context.Articulos.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
                query = query.Where(a => a.Nombre.ToLower().Contains(busqueda.ToLower()));

            query = orden == "DESC"
                ? query.OrderByDescending(a => a.Nombre)
                : query.OrderBy(a => a.Nombre);

            return Ok(query.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var art = _context.Articulos.Find(id);
            return art == null ? NotFound() : Ok(art);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string nombre, [FromForm] int stock, [FromForm] IFormFile imagen)
        {
            string rutaImagen = await GuardarImagen(imagen);

            var articulo = new Articulo
            {
                Nombre = nombre,
                Stock = stock,
                Imagen = rutaImagen
            };

            _context.Articulos.Add(articulo);
            _context.SaveChanges();

            return Ok(articulo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] string nombre, [FromForm] int stock, [FromForm] IFormFile? imagen)
        {
            var art = _context.Articulos.Find(id);
            if (art == null) return NotFound();

            art.Nombre = nombre;
            art.Stock = stock;

            if (imagen != null)
                art.Imagen = await GuardarImagen(imagen);

            _context.SaveChanges();
            return Ok(art);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var art = _context.Articulos.Find(id);
            if (art == null) return NotFound();

            _context.Articulos.Remove(art);
            _context.SaveChanges();

            return Ok();
        }

        private async Task<string> GuardarImagen(IFormFile archivo)
        {
            var carpeta = Path.Combine("wwwroot", "imagenes");
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(archivo.FileName);
            var ruta = Path.Combine(carpeta, nombreArchivo);

            using (var stream = new FileStream(ruta, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }

            return "/imagenes/" + nombreArchivo;
        }
    }
}
