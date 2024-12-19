using Microsoft.AspNetCore.Mvc;

namespace PVZView.Controllers;

public class ViewController : Controller
{
    private string frame = @"";

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("{game_key}")]
    public IActionResult Game()
    {
        ViewBag.Frame = frame;
        return View();
    }
}
