using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameAPI.Models;

namespace GameAPI.Controllers;

public class UsersController : Controller
{
    private readonly GameAPIContext _context;

    public UsersController(GameAPIContext context)
    {
        _context = context;
    }
}
