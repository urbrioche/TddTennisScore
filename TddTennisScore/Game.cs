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
            [2] = "Thirty",
            [3] = "Forty"
        };

        private const string Deuce = "Deuce";

        public int Id { get; set; }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public string FirstPlayerName { get; set; }

        public bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string ScoreResult()
        {
            if (IsSameScore())
            {
                if (IsDeuce())
                {
                    return Deuce;
                }

                return $"{_scoreLookup[FirstPlayerScore]} All";
            }

            if ( FirstPlayerScore >=3 && SecondPlayerScore >=3 &&  (FirstPlayerScore - SecondPlayerScore) == 1)
            {
                return FirstPlayerName + " Adv";
            }

            return $"{_scoreLookup[FirstPlayerScore]} {_scoreLookup[SecondPlayerScore]}";
        }

        private bool IsDeuce()
        {
            return FirstPlayerScore >= 3;
        }
    }
}