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
    public IActionResult Game(string game_key)
    {
        ViewBag.game_key = game_key;
        Console.WriteLine(game_key);
        return View();
    }
}
