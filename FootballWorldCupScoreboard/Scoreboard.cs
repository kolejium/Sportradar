namespace FootballWorldCupScoreboard
{
    public class Scoreboard
    {
        public object Start(string homeTeamName, string awayTeamName)
        {
            return new { homeTeamName, awayTeamName };
        }
    }
}