using System;
using System.Collections.Generic;

namespace TddTennisScore
{
    public class Game
    {
        private const string Deuce = "Deuce";
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }

        public bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public static readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };

        public string LookupSameScore()
        {
            return _scoreLookup[FirstPlayerScore] + " All";
        }

        public string ScoreResult()
        {
            return IsSameScore()
                ? (IsDeuce() ? Deuce : LookupSameScore())
                : (IsReadyForWin() ? AdvState() : LookupScore());
        }

        private string AdvState()
        {
            return AdvPlayer() + (IsAdv() ? " Adv" : " Win");
        }

        private string AdvPlayer()
        {
            return (FirstPlayerScore > SecondPlayerScore ? FirstPlayerName : SecondPlayerName);
        }

        private bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }

        private string LookupScore()
        {
            return _scoreLookup[FirstPlayerScore] + " " + _scoreLookup[SecondPlayerScore];
        }

        private bool IsDeuce()
        {
            return FirstPlayerScore >= 3;
        }
    }
}