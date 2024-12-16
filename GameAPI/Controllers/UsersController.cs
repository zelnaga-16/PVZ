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

namespace GameAPI.Controllers;

public class UsersController : Controller
{
    private readonly GameAPIContext _context;
    private EntityList _entityList;

    public UsersController(GameAPIContext context)
    {
        _context = context;

    }
    [HttpGet]
    public string MainGet(string apiKey,string command) 
    {
        return "Big Cat";
    }
    public IActionResult Plant(string apiKey,int X,int Y,string plantName) 
    {
        if (X > 100 || X <= 0)
        {
            return BadRequest("Your X coordinate is eather smaller than 1 or bigger than 10.");
        }
        if(Y > 4 || Y <= 0) 
        {
            return BadRequest("Your Y coordinate is eather smaller than 1 or bigger than 4.");
        }

        Vector2 position = new Vector2(X*10-5,Y);
        foreach (var entity in _entityList) 
        {
            if(entity.Position == position) 
            {
                return BadRequest("You tried to place a plant where another plant is. Please remove previous plant if you realy want to place your here.");
            }
        }

        return Ok($"{apiKey}");
    }
}
