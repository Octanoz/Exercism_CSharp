public static class Tournament
{
    public static void Tally(string inputFilePath, string outputFilePath)
    {
        using (StreamReader reader = new(inputFilePath))
        using (StreamWriter writer = new(outputFilePath))
        {
            Dictionary<string, TeamStats> teams = new();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(';');

                string teamA = parts[0];
                string teamB = parts[1];
                string outcome = parts[2];

                teams.TryAdd(teamA, new TeamStats());
                teams.TryAdd(teamB, new TeamStats());

                teams[teamA].MatchesPlayed++;
                teams[teamB].MatchesPlayed++;

                switch (outcome)
                {
                    case "win":
                        teams[teamA].MatchesWon++;
                        teams[teamA].Points += 3;
                        teams[teamB].MatchesLost++;
                        break;
                    case "draw":
                        teams[teamA].MatchesDrawn++;
                        teams[teamA].Points++;
                        teams[teamB].MatchesDrawn++;
                        teams[teamB].Points++;
                        break;
                    case "loss":
                        teams[teamA].MatchesLost++;
                        teams[teamB].MatchesWon++;
                        teams[teamB].Points += 3;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid outcome in source file, please review.");
                        break;
                }
            }

            IEnumerable<KeyValuePair<string, TeamStats>> sortedTeams = teams
                    .OrderByDescending(st => st.Value.Points)
                    .ThenBy(st => st.Key);

            writer.Write($"Team                          |  MP | W | D | L | P");

            foreach (var team in sortedTeams)
            {
                string teamName = team.Key.PadRight(30);
                string matchesPlayed = team.Value.MatchesPlayed.ToString().PadLeft(2);
                string matchesWon = team.Value.MatchesWon.ToString().PadLeft(1);
                string matchesDrawn = team.Value.MatchesDrawn.ToString().PadLeft(1);
                string matchesLost = team.Value.MatchesLost.ToString().PadLeft(1);
                string points = team.Value.Points.ToString().PadLeft(1);

                string outputLine = $"{teamName}| {matchesPlayed}  | {matchesWon} | {matchesDrawn} | {matchesLost} | {points}";

                writer.Write($"\n{outputLine}");
            }
        }
    }

    private class TeamStats
    {
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }
        public int Points { get; set; }
    }
}