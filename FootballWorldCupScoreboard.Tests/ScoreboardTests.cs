using System.Diagnostics;
using FluentAssertions;

namespace FootballWorldCupScoreboard.Tests;

public class ScoreboardTests
{
    public static IEnumerable<object[]> GetData(int count)
    {
        var dataset = new[]
        {
            ("Dinamo", "Arsenal"),
            ("Barcelona", "Madrid"),
            ("NYT", "CaliforniaBikers"),
            ("Juventus", "Real Madrid"),
            ("AJAX", "Portu")
        };

        yield return new object[] { dataset };
    }

    public static IEnumerable<object[]> GetData2(int count)
    {
        var dataset = new[]
        {
            ("Mexico", "Canada", 0, 5),
            ("Spain", "Brazil", 10, 2),
            ("Germany", "France", 2, 2),
            ("Uruguay", "Italy", 6, 6),
            ("Argentine", "Australia", 3, 1)
        };

        yield return new object[] { dataset };
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

    [Fact]
    public void Finish_Throw_WhenArgumentIsNull()
    {
        // Arrange
        var scoreboard = new Scoreboard();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => scoreboard.Finish(null));
    }

    [Theory]
    [MemberData(nameof(GetData2), 5)]
    public void Get_ReturnsMatchesOrderedByTheirScore(IEnumerable<(string, string, int, int)> enumerable)
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var i = 0;
        var count = enumerable.Count();

        foreach (var item in enumerable)
        {
            scoreboard.Start(item.Item1, item.Item2).UpdateScore((byte)(count - i), (byte)(count - i));
            i++;
        }

        // Act
        var sorted = scoreboard.Get().ToList();

        // Assert
        for (var j = 0; j < sorted.Count - 1; j++)
            Assert.True(sorted[j].TotalScore >= sorted[j + 1].TotalScore,
                "Matches are not ordered by their score in descending order.");
    }

    [Theory]
    [MemberData(nameof(GetData2), 5)]
    public void Get_ReturnsMatchesOrderedByTheirScore_ThanByTheirStartTime(
        IEnumerable<(string, string, int, int)> enumerable)
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var list = enumerable.ToList();

        for (var i = 0; i < list.Count; i++)
            scoreboard.Start(list[i].Item1, list[i].Item2).UpdateScore((byte)list[i].Item3, (byte)list[i].Item4);

        // Act
        var sorted = scoreboard.Get().ToList();

        // Assert
        var matches = scoreboard.Matches.ToArray();

        Assert.Equal(list.Count, sorted.Count);

        for (var i = 0; i < sorted.Count - 1; i++)
        {
            Assert.True(sorted[i].TotalScore >= sorted[i + 1].TotalScore);

            if (sorted[i].TotalScore == sorted[i + 1].TotalScore)
                Assert.True(Array.IndexOf(matches, sorted[i])
                            > Array.IndexOf(matches, sorted[i + 1]));
        }
    }

    [Theory]
    [MemberData(nameof(GetData2), 5)]
    public void Get_ReturnsMatchesOrderedByTheirStartTimeDesc(IEnumerable<(string, string, int, int)> enumerable)
    {
        // Arrange
        var scoreboard = new Scoreboard();

        foreach (var item in enumerable)
            scoreboard.Start(item.Item1, item.Item2);

        // Act
        var sorted = scoreboard.Get().ToList();

        // Assert
        for (var i = 0; i < sorted.Count - 1; i++)
            Assert.True(Array.IndexOf(scoreboard.Matches.ToArray(), sorted[i])
                        > Array.IndexOf(scoreboard.Matches.ToArray(), sorted[i + 1]));
    }

    [Theory]
    [MemberData(nameof(GetData), 5)]
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