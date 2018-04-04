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
        public string SecondPlayerName { get; set; }

        public bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string ScoreResult()
        {
            return IsSameScore()
                ? (IsDeuce() ? Deuce : SameScoreLookup())
                : (IsReadyForWin() ? AdvState() : ScoreLookup());
        }

        private string ScoreLookup()
        {
            return $"{_scoreLookup[FirstPlayerScore]} {_scoreLookup[SecondPlayerScore]}";
        }

        private string SameScoreLookup()
        {
            return $"{_scoreLookup[FirstPlayerScore]} All";
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
            var b = FirstPlayerScore >= 3 && SecondPlayerScore >= 3;
            return b;
        }

        private bool IsDeuce()
        {
            return FirstPlayerScore >= 3;
        }
    }
}