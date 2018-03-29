using System;
using System.Collections.Generic;

namespace TddTennisScore
{
    public class Game
    {
        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty"
        };

        public int Id { get; set; }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }

        public bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string ScoreResult()
        {
            if (IsSameScore())
            {
                return $"{_scoreLookup[FirstPlayerScore]} All";
            }

            throw new NotImplementedException();
        }
    }
}