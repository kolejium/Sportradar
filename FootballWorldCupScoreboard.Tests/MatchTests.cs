using FluentAssertions;

namespace FootballWorldCupScoreboard.Tests;

public class MatchTests
{
    [Theory, MemberData(nameof(Scores))]
    public void UpdateScore_OnSuccess_ShouldChangeValuesOfProperties(int newHomeTeamScore, int newAwayTeamScore)
    {
        // Arrange
        var match = new Match("NYFC", "Arcenal");

        // Act
        match.UpdateScore((byte) newHomeTeamScore, (byte) newAwayTeamScore);
        
        // Assert
        Assert.True(match.HomeTeamScore == newHomeTeamScore);
        Assert.True(match.AwayTeamScore == newAwayTeamScore);
    }

    [Theory, MemberData(nameof(InvalidScores))]
    public void UpdateScore_Throw_ArgumentOutOfRangeException(int newHomeTeamScore, int newAwayTeamScore)
    {
        // Arrange
        var match = new Match("NYFC", "Arcenal");

        // Act && Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => match.UpdateScore(newHomeTeamScore, newAwayTeamScore));
    }


    public static IEnumerable<object[]> Scores =>
        new List<object[]>
        {
            new object[] { 1, 1 },
            new object[] { 3, 8 },
            new object[] { 0, 9 }
        };

    public static IEnumerable<object[]> InvalidScores =>
        new List<object[]>
        {
            new object[] { -10, 0 },
            new object[] { 0, 2000 },
            new object[] { 2000, -10 },
        };
}