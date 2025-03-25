using Microsoft.AspNetCore.Mvc;

namespace marketnasusAPI.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
