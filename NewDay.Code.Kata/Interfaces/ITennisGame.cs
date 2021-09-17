namespace NewDay.Code.Kata.Core.Interfaces
{
    public interface ITennisGame
    {
        public string GetScore();

        public void WhoHasScored(string playerName);

        bool IsAdvantagePlay { get; set; }

        public bool IsGameOver();
    }
}
