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

            Task.Run(() => UpdateGame(game));

        }
        else
        {
            return BadRequest("Please send your API key");
        }
        return Ok("your key is: "+gameKey);
    }
    [HttpGet]
    public IActionResult Progress(string apiKey, string gameKey) 
    {
        Models.Game gameFromDb = _context.Game.Where((g) => g.User.APIKey == apiKey && g.GameKey == gameKey).FirstOrDefault();
        if (gameFromDb == null)
        {
            return NotFound("Can't find your game session. Are you sure you created it?");
        }
        Model.General.Game MainGame = _games[gameFromDb.GameKey];
        return Ok();

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
        PlantsFabric plantsFabric = new PlantsFabric(MainGame);

        GameEntity plant = ChoosePlant(plantsFabric, new Vector2(X, Y),plantName);


        GameEntity gameEntity = EntityCheck<Plant>(MainGame,plant.Transform);
        if (gameEntity != null)
        {
            return BadRequest("You tried to place a plant where another plant is. Please remove previous plant if you realy want to place your here.");
        }
        MainGame.ToAddList.Add(plant);


        return Ok("Great, you planted successfully.");
    }
    private GameEntity ChoosePlant(PlantsFabric fabric,Vector2 pos,string plantName) 
    {
        switch (plantName.ToLower()) 
        {
            case "peashooter":
                return fabric.CreatePeashooter(pos);
            case "sunflower":
                return fabric.CreateSunFlower(pos);
        }

        return null;
    }
    private void UpdateGame(Model.General.Game game,bool IsOpponentBot) 
    {
        OpponentBot opponentBot = new OpponentBot(game);
        if (IsOpponentBot == false)
        {
            while (true)
            {
                game.GameTick(DateTime.Now);
                Console.WriteLine("Yahoo");
            }
        }
        else 
        {
            while (true)
            {
                game.GameTick(DateTime.Now);
                Console.WriteLine("Yahoo");
                
            }
        }
    }
    private GameEntity EntityCheck<T>(Model.General.Game game, Transform hitbox) where T : GameEntity
    {
        foreach (T entity in game.GameEntities)
        {
            if (hitbox.isInside(entity.Transform))
            {
                return entity;
            }
        }
        return null;
    }
    
}
