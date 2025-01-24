using CONEXA.Data;
using Microsoft.AspNetCore.Mvc;

namespace CONEXA.Controllers
{
    public interface IProductosController
    {
        IActionResult Crear();
        Task<IActionResult> Crear(Producto producto, IFormFile foto);
    }
}