namespace FootballWorldCupScoreboard;

public class Match
{
    #region [ Variables ]

    private byte _awayTeamScore;

    private byte _homeTeamScore;

    #endregion

    #region [ Properties ]

    public string AwayTeam { get; }
    public int AwayTeamScore => _awayTeamScore;
    public string HomeTeam { get; }

    public int HomeTeamScore => _homeTeamScore;

    public int TotalScore => _homeTeamScore + _awayTeamScore;

    #endregion

    #region [ Constructors ]

    public Match(string homeTeam, string awayTeam)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        _homeTeamScore = _awayTeamScore = 0;
    }

    #endregion

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