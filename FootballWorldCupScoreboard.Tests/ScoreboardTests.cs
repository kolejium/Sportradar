namespace FootballWorldCupScoreboard.Tests
{
    public class ScoreboardTests
    {
        [Fact]
        public void StartNewMatch_OnSuccess_ReturnsNotNull()
        {
            // Arrange

            var scoreboard = new Scoreboard();

            // Act

            var result = scoreboard.Start("Barcelona", "Madrid");

            // Assert

            result.Should().NotBeNull();
        }
    }
}