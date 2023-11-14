namespace FootballWorldCupScoreboard
{
    public class Scoreboard
    {
        public object Start(string homeTeamName, string awayTeamName)
        {
            if (string.IsNullOrEmpty(homeTeamName))
                throw new ArgumentException("The team name can't be empty or null", nameof(homeTeamName));

            if (string.IsNullOrEmpty(awayTeamName))
                throw new ArgumentException("The team name can't be empty or null", nameof(awayTeamName));

            return new { homeTeamName, awayTeamName };
        }
    }
}