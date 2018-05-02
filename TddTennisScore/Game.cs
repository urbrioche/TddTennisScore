using System;
using System.Collections.Generic;

namespace TddTennisScore
{
    public class Game
    {
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }

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
            [2] = "Thirty",
            [3] = "Forty"
        };

        public bool IsDeuce()
        {
            return FirstPlayerScore >= 3 && IsSameScore();
        }

        public string ScoreResult()
        {
            return IsSameScore()
                ? (IsDeuce() ? "Deuce" : SameScoreLookup())
                : (IsReadyForWin() ? AdvState() : LookupScore());
        }

        private string LookupScore()
        {
            return _scoreLookup[FirstPlayerScore] + " " + _scoreLookup[SecondPlayerScore];
        }

        private string AdvState()
        {
            return IsAdv() ? AdvPlayer() + " Adv" : AdvPlayer() + " Win";
        }

        private string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore ? FirstPlayerName : SecondPlayerName;
        }

        private bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }
    }
}