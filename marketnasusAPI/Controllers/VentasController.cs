using Microsoft.AspNetCore.Mvc;

namespace marketnasusAPI.Controllers
{
    public class Ventascontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
