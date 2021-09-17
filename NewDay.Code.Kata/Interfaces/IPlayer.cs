namespace NewDay.Code.Kata.Core.Interfaces
{
    public interface IPlayer
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public bool IsWon { get; set; }
    }
}
