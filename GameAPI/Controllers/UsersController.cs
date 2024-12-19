using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Model;
using Model.General.Entity;
using Azure.Core;
using Model.Plants.Units;
using Model.General;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using NuGet.Common;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace GameAPI.Controllers;

public class UsersController : Controller
{
    private readonly GameAPIContext _context;
    public UsersController(GameAPIContext context)
    {
        _context = context;
        

    }
    [HttpPost]
    public IActionResult Registrate(string? login,string? password,string? email)
    {
        if(_context.User.Select((u) => u.Email == email || u.Login == login).FirstOrDefault()) 
        {
            return BadRequest("Your Login or Email already in use on our site");
        }

        password = password.ToSHA256String();


        if (!IsValidEmail(email))
        {
            return BadRequest("Your email is impossible");
        }
        var key = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
            generator.GetBytes(key);
        User user = new User
        {
            Email = email,
            Password = password,
            Login = login,
            APIKey = Convert.ToBase64String(key).Replace("/", "").Replace("+", "").Replace("=","")
        };
        _context.User.Add(user);
        _context.SaveChanges();
        return Ok();
    }
    [HttpPost]
    public IActionResult Login(string LoginOrEmail, string Password)
    {
        Password = Password.ToSHA256String();

        if (_context.User.Where(x => (x.Login == LoginOrEmail || x.Email == LoginOrEmail) && x.Password == Password).FirstOrDefault() == null) return BadRequest("Your login or password is wrong.");
        return Ok();
    }
    private bool IsValidEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false; 
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }
}
