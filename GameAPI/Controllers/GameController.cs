using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.General.Entity;
using Model.General;
using Model.Plants.Units;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using GameAPI.Models;

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
    public IActionResult GameStart(string apiKey,string? opponentKey)
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

            Model.General.Game game = new Model.General.Game();

            _games.Add(gameKey, game);

            User opponent = _context.User.Where((user) => user.APIKey == opponentKey).FirstOrDefault();
            if (opponentKey != "0" && opponent != null)
            {
                GameToDB.OpponentId = opponent.Id;
            }

            _context.Game.Add(GameToDB);
            _context.SaveChanges();

            Task.Run(() => UpdateGames(game));

        }
        else
        {
            return BadRequest("Please send your API key");
        }
        return Ok("your key is: "+gameKey);
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

        MainGame.GameEntities.Add(new Peashooter(MainGame, new Vector2(X, Y)));

        return Ok("");
        
        
        if (X > 10 || X <= 0)
        {
            return BadRequest("Your X coordinate is eather smaller than 1 or bigger than 10.");
        }
        if (Y > 4 || Y <= 0)
        {
            return BadRequest("Your Y coordinate is eather smaller than 1 or bigger than 4.");
        }
        Transform transform = new Transform();
        transform.Position = new Vector2(X, Y);


        GameEntity gameEntity = EntityCheck<Plant>(transform);
        if (gameEntity == null)
        {
            return BadRequest("You tried to place a plant where another plant is. Please remove previous plant if you realy want to place your here.");
        }


        return Ok($"{apiKey}");
    }
    private void UpdateGames(Model.General.Game game) 
    {
        while (true)
        {
            game.GameTick();
            Console.WriteLine("Yahoo");
            
        }
    }
    private GameEntity EntityCheck<T>(Transform hitbox) where T : GameEntity
    {
        return null;
    }
    private bool HitBoxCheck(Transform hitbox1, Transform hitbox2)
    {

        if (hitbox1.Position.Y != hitbox2.Position.Y) return false;

        if (hitbox1.Position.X == hitbox2.Position.X)
        {
            return true;
        }

        if (hitbox1.Position.X < hitbox2.Position.X && (hitbox1.Position.X + hitbox1.Size.X / 2) >= (hitbox2.Position.X - hitbox2.Size.X / 2))
        {
            return true;
        }

        if (hitbox1.Position.X > hitbox2.Position.X && (hitbox2.Position.X + hitbox2.Size.X / 2) >= (hitbox1.Position.X - hitbox1.Size.X / 2))
        {
            return true;
        }
        return false;
    }
}
