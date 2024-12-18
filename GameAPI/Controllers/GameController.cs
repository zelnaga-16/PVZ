using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.General.Entity;
using Model.General;
using Model.Plants.Units;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using GameAPI.Models;
using Model.Plants;
using System.Xml.Linq;
using Model.Zombies.Units;
using Model.Plants.Fabrics;
using System.Net;
using System.Net.Http.Headers;

namespace GameAPI.Controllers;

public class GameController : Controller
{
    private readonly GameAPIContext _context;
    private static Dictionary<string,Model.General.Game> _games = new Dictionary<string, Model.General.Game>();

    public GameController(GameAPIContext context)
    {
        _context = context;
        
        
    }

    [HttpGet]
    public IActionResult GameStart(string apiKey,string? opponentKey,string plantNames)
    {
        string gameKey = null;
        opponentKey = opponentKey.IsNullOrEmpty()?"0":opponentKey;


        User master = _context.User.Where((user) => user.APIKey == apiKey).FirstOrDefault();
        if (master != null)
        {
            Models.Game GameToDB = new Models.Game();

            GameToDB.UserId = master.Id;
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            gameKey = Convert.ToBase64String(key).Replace("/", "").Replace("+", "");
            GameToDB.GameKey = gameKey;

            Model.General.Game game = new Model.General.Game(plantNames.Split(',').ToList());

            _games.Add(gameKey, game);

            User opponent = _context.User.Where((user) => user.APIKey == opponentKey).FirstOrDefault();
            if (opponentKey != "0" && opponent != null)
            {
                GameToDB.OpponentId = opponent.Id;
            }

            _context.Game.Add(GameToDB);
            _context.SaveChanges();

            Task.Run(() => UpdateGame(game));

        }
        else
        {
            return BadRequest("Please send your API key");
        }
        return Ok("your key is: "+gameKey);
    }
    [HttpGet]
    public IActionResult Progress(string gameKey)
    {
        Models.Game gameFromDb = _context.Game.Where((g) => g.GameKey == gameKey).FirstOrDefault();
        if (gameFromDb == null)
        {
            //return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        Model.General.Game MainGame = _games[gameFromDb.GameKey];

        string JsonString = "{ ";

        foreach (GameEntity entity in MainGame.GameEntities)
        {
            JsonString += "{\"name\":\"" + entity.ToString() + "\",\"x\":\"" + entity.Transform.Position.X + "\",\"y\":\"" + entity.Transform.Position.Y + "\"},";
        }
        JsonString += " }";
        var content = new StringContent(JsonString);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
        

        return Ok(JsonString);

    }

    [HttpGet]
    public IActionResult Plant(string apiKey, string gameKey, double X, int Y, string plantName)
    {
        Models.Game gameFromDb = _context.Game.Where((g) => g.User.APIKey == apiKey && g.GameKey == gameKey).FirstOrDefault();
        if (gameFromDb == null)
        {
            return NotFound("Can't find your game session. Are you sure you created it?");
        }
        Model.General.Game MainGame = _games[gameFromDb.GameKey];
        
        if (X > 10 || X <= 0)
        {
            return BadRequest("Your X coordinate is eather smaller than 1 or bigger than 10.");
        }
        if (Y > 4 || Y <= 0)
        {
            return BadRequest("Your Y coordinate is eather smaller than 1 or bigger than 4.");
        }
        PlantFabric plantFabric = MainGame.PlantFabrics[plantName.ToLower()];

        Transform transform = new Transform();
        transform.Position = new Vector2(X, Y);
        transform.Size = new Vector2(1,1);

        if (!IsPositionFree<Plant>(MainGame, transform))
        {
            return BadRequest("You tried to place a plant where another plant is. Please remove previous plant if you realy want to place your here.");
        }
        GameEntity plant = plantFabric.TryCreate(transform.Position);

        return Ok("Great, you planted successfully.");
    }

    private void UpdateGame(Model.General.Game game) 
    {
        while (!game.IsGameEnded)
        {
            game.GameTick();
            Thread.Sleep(50);
        }
        Console.WriteLine(game.IsGameWinned);
    }
    private bool IsPositionFree<T>(Model.General.Game game, Transform hitbox) where T : GameEntity
    {
        foreach (GameEntity entity in game.GameEntities)
        {
            if (entity is not T)
                continue;
            if (hitbox.isInside(entity.Transform))
            {
                return false;
            }
        }
        return true;
    }
    
}
