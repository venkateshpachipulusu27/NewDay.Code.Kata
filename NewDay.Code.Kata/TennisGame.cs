using NewDay.Code.Kata.Core.Enums;
using NewDay.Code.Kata.Core.Interfaces;

namespace NewDay.Code.Kata.Core
{
    public class TennisGame : ITennisGame
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public bool IsAdvantagePlay { get; set; }


        public TennisGame(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;

            _player1.Score = 0;
            _player2.Score = 0;
        }

        public string GetScore()
        {
            if (_player1.IsWon)
                return $"{_player1.Name} Won";

            if (_player2.IsWon)
                return $"{_player2.Name} Won";

            if (IsAdvantagePlay)
            {
                if (_player1.Score == (int)TennisGamePoint.Advance)
                    return $"{_player1.Name} Advance";

                if (_player2.Score == (int)TennisGamePoint.Advance)
                    return $"{_player2.Name} Advance";
            }

            if (_player1.Score == (int)TennisGamePoint.Forty && _player2.Score == (int)TennisGamePoint.Forty)
                return "Deuce";

            return $"{(TennisGamePoint)_player1.Score}-{(TennisGamePoint)_player2.Score}";
        }

        public void WhoHasScored(string playerName)
        {
            if (playerName == _player1.Name.ToLower())
                UpdatePlayerScore(_player1, _player2);

            if (playerName == _player2.Name.ToLower())
                UpdatePlayerScore(_player2, _player1);
        }

        private void UpdatePlayerScore(IPlayer playerWonThePoint, IPlayer playerLostThePoint)
        {
            if (IsAdvantagePlay == false)
            {
                if (playerWonThePoint.Score == (int)TennisGamePoint.Forty && playerLostThePoint.Score == (int)TennisGamePoint.Forty)
                    IsAdvantagePlay = true;

                if (playerWonThePoint.Score == (int)TennisGamePoint.Advance || playerLostThePoint.Score == (int)TennisGamePoint.Advance)
                    IsAdvantagePlay = true;
            }

            if (IsAdvantagePlay)
            {
                if (playerWonThePoint.Score == (int)TennisGamePoint.Advance)
                    playerWonThePoint.IsWon = true;
                else
                {
                    if (playerLostThePoint.Score == (int)TennisGamePoint.Advance)
                    {
                        playerLostThePoint.Score = (int)TennisGamePoint.Forty;
                    }
                    else
                    {
                        playerWonThePoint.Score = (int)TennisGamePoint.Advance;
                    }
                }
            }
            else
            {
                playerWonThePoint.Score++;
                playerWonThePoint.IsWon = (playerWonThePoint.Score > (int)TennisGamePoint.Forty);
            }
        }

        public bool IsGameOver()
        {
            return _player1.IsWon || _player2.IsWon;
        }
    }
}
