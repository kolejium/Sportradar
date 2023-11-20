namespace FootballWorldCupScoreboard;

public class Match
{
    public string HomeTeam { get; }

    public string AwayTeam { get; }

    private byte _homeTeamScore;
    private byte _awayTeamScore;

    public int HomeTeamScore => _homeTeamScore;
    public int AwayTeamScore => _awayTeamScore;

    public int TotalScore => _homeTeamScore + _awayTeamScore;

    public Match(string homeTeam, string awayTeam)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        _homeTeamScore = _awayTeamScore = 0;
    }

    public void UpdateScore(int homeTeamScore, int awayTeamScore)
    {
        if (homeTeamScore is < 0 or > byte.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(homeTeamScore),
                "The score should be positive and less than 255");

        if (awayTeamScore is < 0 or > byte.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(awayTeamScore),
                "The score should be positive and less than 255");

        _homeTeamScore = (byte)homeTeamScore;
        _awayTeamScore = (byte)awayTeamScore;
    }
}