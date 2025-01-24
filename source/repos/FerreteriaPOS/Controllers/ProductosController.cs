using FerreteriaPOS.Data;
using FerreteriaPOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaPOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        public IActionResult CreateProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public IActionResult UpdateProducto(int id, [FromBody] Producto producto)
        {
            if (producto == null || producto.Id != id)
            {
                return BadRequest();
            }

            var existingProducto = _context.Productos.Find(id);
            if (existingProducto == null)
            {
                return NotFound();
            }

            var updatedProducto = existingProducto with
            {
                Nombre = producto.Nombre,
                Categoria = producto.Categoria,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            _context.Entry(existingProducto).CurrentValues.SetValues(updatedProducto);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
