using FluentAssertions;

namespace FootballWorldCupScoreboard.Tests
{
    public class ScoreboardTests
    {
        [Fact]
        public void Start_OnSuccess_ReturnsNotNull()
        {
            // Arrange

            var scoreboard = new Scoreboard();

            // Act

            var result = scoreboard.Start("Barcelona", "Madrid");

            // Assert

            result.Should().NotBeNull();
        }

        [Fact]
        public void Start_Throw_WhenTeamNamesIsNullOrEmpty()
        {
            // Arrange

            var scoreboard = new Scoreboard();

            // Act & Assert

            Assert.Throws<ArgumentException>(() => scoreboard.Start(string.Empty, null));
            Assert.Throws<ArgumentException>(() => scoreboard.Start("Barcelona", null));
            Assert.Throws<ArgumentException>(() => scoreboard.Start(string.Empty, "Manchester"));
        }

        public void Start_OnSuccess_ReturnsNewMatchWithInitScores()
        {
            // Arrange

            var scoreboard = new Scoreboard();
            var match = new Match() { HomeTeam = "Barcelona", AwayTeam = "Madrid" };

            // Act

            var result = scoreboard.Start("Barcelona", "Madrid");

            // Assert
            
            Assert.Equal(match.HomeTeam, result.HomeTeam);
            Assert.Equal(match.AwayTeam, result.AwayTeam);
            Assert.Equal(match.HomeTeamScore, 0);
            Assert.Equal(match.AwayTeamScore, 0);
        }
    }
}