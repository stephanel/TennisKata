using Xunit;

namespace Tennis
{
    public class TennisScoreCalculatorTests
    {
        [Theory]
        // player 1 won at least 4 points in total and at least 2 points more than the opponent
        [InlineData(4, 0, "player one wins!")]
        [InlineData(5, 0, "player one wins!")]
        [InlineData(4, 1, "player one wins!")]
        [InlineData(5, 1, "player one wins!")]
        [InlineData(5, 3, "player one wins!")]
        // player 2 won at least 4 points in total and at least 2 points more than the opponent
        [InlineData(0, 4, "player two wins!")]
        [InlineData(0, 5, "player two wins!")]
        [InlineData(1, 4, "player two wins!")]
        [InlineData(1, 5, "player two wins!")]
        [InlineData(3, 5, "player two wins!")]
        // each players won at least 3 points and scores are equal
        [InlineData(3, 3, "deuce")]
        [InlineData(4, 4, "deuce")]
        [InlineData(5, 5, "deuce")]
        // each players won at least 3 points and one player won 1 more point than the opponent
        [InlineData(3, 4, "advantage")]
        [InlineData(4, 5, "advantage")]
        [InlineData(4, 3, "advantage")]
        [InlineData(6, 5, "advantage")]
        // convert 0 to love
        [InlineData(0, 0, "love love")]
        // convert 1 to fifteen
        // convert 2 to thirty
        // convert 3 to forty
        [InlineData(0, 1, "love fifteen")]
        [InlineData(1, 1, "fifteen fifteen")]
        [InlineData(2, 1, "thirty fifteen")]
        [InlineData(1, 0, "fifteen love")]
        [InlineData(1, 2, "fifteen thirty")]
        [InlineData(2, 2, "thirty thirty")]
        [InlineData(2, 0, "thirty love")]
        [InlineData(0, 3, "love forty")]
        [InlineData(3, 0, "forty love")]
        public void Convert_Points_To_Score(
            int player1Points, int player2Points, string expected)
        {
            // Giwen
            var game = new TennisGame(player1Points, player2Points);

            // When
            var score = game.GetScore();

            // Then
            Assert.Equal(expected, score);
        }
    }
}
