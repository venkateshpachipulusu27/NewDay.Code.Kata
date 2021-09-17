using NewDay.Code.Kata.Core.Interfaces;

namespace NewDay.Code.Kata.Core
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsWon { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
