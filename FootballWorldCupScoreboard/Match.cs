namespace FootballWorldCupScoreboard;

public class Match
{
    public string HomeTeam { get; }

    public string AwayTeam { get; }

    private byte _homeTeamScore;
    private byte _awayTeamScore;

    public byte HomeTeamScore => _homeTeamScore;
    public byte AwayTeamScore => _awayTeamScore;

    public Match(string homeTeam, string awayTeam)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        _homeTeamScore = _awayTeamScore = 0;
    }

    public void UpdateScore(byte homeTeamScore, byte awayTeamScore)
    {
        _homeTeamScore = homeTeamScore;
        _awayTeamScore = awayTeamScore;
    }
}