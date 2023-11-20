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

        [Fact]
        public void Start_OnSuccess_ReturnsNewMatchWithInitScores()
        {
            // Arrange

            var scoreboard = new Scoreboard();
            var match = new Match("Barcelona", "Madrid");

            // Act

            var result = scoreboard.Start("Barcelona", "Madrid");

            // Assert
            
            Assert.Equal(match.HomeTeam, result.HomeTeam);
            Assert.Equal(match.AwayTeam, result.AwayTeam);
            Assert.Equal(0, result.HomeTeamScore);
            Assert.Equal(0, result.AwayTeamScore);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 5)]
        public void Matches_PropertyShouldReturnAllStartedMatches(IEnumerable<(string, string)> enumerable)
        {
            // Arrange

            var scoreboard = new Scoreboard();

            // Act

            foreach (var item in enumerable)
                scoreboard.Start(item.Item1, item.Item2);

            // Assert

            Assert.Equal(enumerable.Count(), scoreboard.Matches.Count);

            foreach (var valueTuple in enumerable)
            {
                var matchExists = scoreboard.Matches.Any(match =>
                    match.HomeTeam == valueTuple.Item1 && match.AwayTeam == valueTuple.Item2);

                Assert.True(matchExists, $"Match not found for teams: {valueTuple.Item1} vs {valueTuple.Item2}");
            }
        }

        [Fact]
        public void Finish_RemovesMatchFromMatchesProperty()
        {
            // Arrange
            var scoreboard = new Scoreboard();
            var match = scoreboard.Start("TeamA", "TeamB");

            // Act
            var matchFinished = scoreboard.Finish(match);

            // Assert
            Assert.True(matchFinished);
            Assert.DoesNotContain(match, scoreboard.Matches);
        }

        public static IEnumerable<object[]> GetData(int count)
        {
            var dataset = new (string, string)[]
            {
                ("Dinamo", "Arsenal"),
                ("Barcelona", "Madrid"),
                ("NYT", "CaliforniaBikers"),
                ("Juventus", "Real Madrid"),
                ("AJAX", "Portu"),
            };

            yield return new object[] { dataset };
        }
    }
}