namespace GameAPI.Models;

public class OpponentBot
{
    public Model.General.Game game { get; set; }
    public OpponentBot(Model.General.Game game)
    {
        this.game = game;
    }

}
