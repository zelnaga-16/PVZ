using Microsoft.AspNetCore.Mvc;

namespace PVZView.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
