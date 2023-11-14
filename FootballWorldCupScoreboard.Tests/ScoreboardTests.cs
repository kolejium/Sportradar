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
    }
}