using System.Collections.Generic;

namespace TddTennisScore
{
    public class Game
    {
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int Id { get; set; }

        private static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };

        private bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string ScoreResult()
        {
            if (IsSameScore())
            {
                if (FirstPlayerScore >= 3)
                    return "Deuce";
                return _scoreLookup[FirstPlayerScore] + " All";
            }
  
            return "";
        }
    }
}