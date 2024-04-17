using Microsoft.AspNetCore.Mvc;

namespace day5.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
