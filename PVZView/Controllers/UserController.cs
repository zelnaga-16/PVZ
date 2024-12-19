using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace PVZView.Controllers;

public class UserController : Controller
{
    private static readonly string _url = @"http://127.0.0.1:5236/user/";
    private readonly HttpClient _client = new HttpClient();

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Registrate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string login, string password)
    {
        Dictionary<string, string> body = new Dictionary<string, string>
        {
            { "Login", login },
            { "Password", password },
        };

        FormUrlEncodedContent contentBody = new FormUrlEncodedContent(body);
        HttpResponseMessage response = await _client.PostAsync(_url+@"/Login", contentBody);
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        return RedirectPermanent("/");
    }

    [HttpPost]
    public async Task<IActionResult> Registrate(string login, string password, string email)
    {
        Dictionary<string, string> body = new Dictionary<string, string>
        {
            { "Login", login },
            { "Password", password },
            { "Email", email},
        };

        FormUrlEncodedContent contentBody = new FormUrlEncodedContent(body);
        HttpResponseMessage response = await _client.PostAsync(_url+ @"Registrate", contentBody);
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        return RedirectPermanent("/");
    }
}
