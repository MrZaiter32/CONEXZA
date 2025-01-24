using Microsoft.AspNetCore.Mvc;
using CONEXA.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CONEXA.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar el formulario de creación de productos
        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Familias = _context.Familias.ToList();
            ViewBag.UnidadesMedida = _context.UnidadesMedida.ToList();
            return View();
        }

        // Acción para procesar el formulario de creación de productos
        [HttpPost]
        public async Task<IActionResult> Crear(Producto producto, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                    var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", nombreArchivo);

                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        await foto.CopyToAsync(stream);
                    }

                    producto.Foto = "images/" + nombreArchivo;
                }

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Familias = _context.Familias.ToList();
            ViewBag.UnidadesMedida = _context.UnidadesMedida.ToList();
            return View(producto);
        }

        // Acción para agregar una familia desde el modal
        [HttpPost]
        public IActionResult CrearFamilia([FromBody] Familia nuevaFamilia)
        {
            if (!string.IsNullOrEmpty(nuevaFamilia.Nombre))
            {
                _context.Familias.Add(nuevaFamilia);
                _context.SaveChanges();

                return Json(new { success = true, id = nuevaFamilia.Id, nombre = nuevaFamilia.Nombre });
            }

            return Json(new { success = false, message = "El nombre de la familia es obligatorio." });
        }

        //
