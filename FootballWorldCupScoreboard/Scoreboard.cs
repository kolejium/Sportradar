namespace FootballWorldCupScoreboard;

public class Scoreboard
{
    #region [ Variables ]

    private readonly List<Match> _matches;

    #endregion

    #region [ Properties ]

    public IReadOnlyList<Match> Matches => _matches;

    #endregion

    public Scoreboard()
    {
        _matches = new List<Match>();
    }

    public Match Start(string homeTeamName, string awayTeamName)
    {
        if (string.IsNullOrEmpty(homeTeamName))
            throw new ArgumentException("The team name can't be empty or null", nameof(homeTeamName));

        if (string.IsNullOrEmpty(awayTeamName))
            throw new ArgumentException("The team name can't be empty or null", nameof(awayTeamName));

        var result = new Match(homeTeamName, awayTeamName);

        _matches.Add(result);

        return result;
    }

    public bool Finish(Match match)
    {
        if (match == null)
            throw new ArgumentNullException(nameof(match), "Match can't be null");

        return _matches.Remove(match);
    }

    public IEnumerable<Match> Get()
    {
        return _matches.OrderByDescending(match => match.TotalScore);
    }
}