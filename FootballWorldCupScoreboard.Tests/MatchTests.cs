using FluentAssertions;

namespace FootballWorldCupScoreboard.Tests;

public class MatchTests
{
    [Theory, MemberData(nameof(Scores))]
    public void UpdateScore_OnSuccess_ShouldChangeValuesOfProperties(int newHomeTeamScore, int newAwayTeamScore)
    {
        var match = new Match("NYFC", "Arcenal");

        match.UpdateScore(3, 5);
        
        Assert.True(match.HomeTeamScore == 3);
        Assert.True(match.AwayTeamScore == 5);
    }


    public static IEnumerable<object[]> Scores =>
        new List<object[]>
        {
            new object[] { 1, 1 },
            new object[] { 3, 8 },
            new object[] { 0, 9 }
        };
}