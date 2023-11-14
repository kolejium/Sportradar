namespace FootballWorldCupScoreboard;

public class Match
{
    public string HomeTeam { get; }

    public string AwayTeam { get; }

    public byte HomeTeamScore { get; }
    public byte AwayTeamScore { get; }

    public Match(string homeTeam, string awayTeam)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeTeamScore = AwayTeamScore = 0;
    }
}