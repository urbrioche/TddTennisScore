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

        private const string Deuce = "Deuce";

        private bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string ScoreResult()
        {
            if (IsSameScore())
            {
                if (IsDeuce())
                    return Deuce;
                return _scoreLookup[FirstPlayerScore] + " All";
            }
  
            return "";
        }

        private bool IsDeuce()
        {
            return FirstPlayerScore >= 3;
        }
    }
}