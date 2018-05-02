using System;
using System.Collections.Generic;

namespace TddTennisScore
{
    public class Game
    {
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int Id { get; set; }

        public bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string SameScoreLookup()
        {
            return _scoreLookup[FirstPlayerScore] + " All";
        }

        public static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty"
        };

        public bool IsDeuce()
        {
            return FirstPlayerScore >= 3 && IsSameScore();
        }

        public string ScoreResult()
        {
            if (IsSameScore())
            {
                if (IsDeuce())
                {
                    return "Deuce";
                }

                return SameScoreLookup();
            }

            return _scoreLookup[FirstPlayerScore] + " " + _scoreLookup[SecondPlayerScore];

        }
    }
}