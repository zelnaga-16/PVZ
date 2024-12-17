namespace GameAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? OpponentId { get; set; }
        public string GameKey { get; set; }
        public int Score { get; set; }
        public bool IsWin { get; set; } = false;
        public bool IsInProgress { get; set; } = true;
        public virtual User User { get; set; } = default!;
        public virtual User Opponent { get; set; } = default;


    }
}
