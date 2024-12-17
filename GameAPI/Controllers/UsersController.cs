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

namespace GameAPI.Controllers;

public class UsersController : Controller
{
    private readonly GameAPIContext _context;
    public UsersController(GameAPIContext context)
    {
        _context = context;

    }
    [HttpGet]
    public string GameStart(string apiKey) 
    {
        if(_context.User.Select((user) => user.APIKey == apiKey ).FirstOrDefault() != null) 
        {
        
        }
        return "Big Cat";
    }
}
