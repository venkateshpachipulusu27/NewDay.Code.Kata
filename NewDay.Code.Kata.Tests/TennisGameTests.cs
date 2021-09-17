using FluentAssertions;
using NewDay.Code.Kata.Core;
using NewDay.Code.Kata.Core.Enums;
using Xunit;

namespace NewDay.Code.Kata.Tests
{
    public class TennisGameTests
    {
        [Theory]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Love, "player1", "Fifteen-Love")]
        [InlineData(TennisGamePoint.Fifteen, TennisGamePoint.Love, "player1", "Thirty-Love")]
        [InlineData(TennisGamePoint.Thirty, TennisGamePoint.Love, "player1", "Forty-Love")]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Love, "player1", "player1 Won")]

        [InlineData(TennisGamePoint.Love, TennisGamePoint.Love, "player2", "Love-Fifteen")]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Fifteen, "player2", "Love-Thirty")]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Thirty, "player2", "Love-Forty")]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Forty, "player2", "player2 Won")]

        [InlineData(TennisGamePoint.Fifteen, TennisGamePoint.Fifteen, "player1", "Thirty-Fifteen")]
        [InlineData(TennisGamePoint.Thirty, TennisGamePoint.Fifteen, "player2", "Thirty-Thirty")]
        [InlineData(TennisGamePoint.Thirty, TennisGamePoint.Thirty, "player1", "Forty-Thirty")]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Thirty, "player2", "Deuce")]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Forty, "player1", "player1 Advance")]
        [InlineData(TennisGamePoint.Advance, TennisGamePoint.Forty, "player1", "player1 Won")]
        [InlineData(TennisGamePoint.Advance, TennisGamePoint.Forty, "player2", "Deuce")]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Forty, "player2", "player2 Advance")]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Advance, "player1", "Deuce")]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Advance, "player2", "player2 Won")]
        public void TennisGameTest_WhoHasScored(TennisGamePoint player1Score, TennisGamePoint player2Score, string whoHasScored, string expected)
        {
            // Arrange
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            TennisGame game = new TennisGame(player1, player2);

            player1.Score = (int)player1Score;
            player2.Score = (int)player2Score;

            // Act
            game.WhoHasScored(whoHasScored);
            string score = game.GetScore();

            //Assert
            score.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Love, "player1", true)]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Forty, "player2", true)]
        [InlineData(TennisGamePoint.Advance, TennisGamePoint.Forty, "player1", true)]
        [InlineData(TennisGamePoint.Forty, TennisGamePoint.Advance, "player2", true)]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Love, "player1", false)]
        [InlineData(TennisGamePoint.Thirty, TennisGamePoint.Love, "player1", false)]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Love, "player2", false)]
        [InlineData(TennisGamePoint.Love, TennisGamePoint.Thirty, "player2", false)]
        public void TennisGameTest_IsGameOver(TennisGamePoint player1Score, TennisGamePoint player2Score, string whoHasScored, bool expected)
        {
            // Arrange
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            TennisGame game = new TennisGame(player1, player2);

            player1.Score = (int)player1Score;
            player2.Score = (int)player2Score;

            // Act
            game.WhoHasScored(whoHasScored);
            bool isGameOver = game.IsGameOver();

            //Assert
            isGameOver.Should().Be(expected);
        }
    }
}
