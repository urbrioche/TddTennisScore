using System;
using System.Collections.Generic;

namespace TddTennisScore
{
    public class Game
    {
        private readonly Dictionary<int, string> _scoreLookup =
            new Dictionary<int, string> {{0, "Love"}, {1, "Fifteen"}, {2, "Thirty"}, {3, "Forty"}};

        private readonly string _Deuce = "Deuce";
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }

        public string ScoreResult()
        {
            return IsSameScore()
                ? (IsDeuce() ? _Deuce : SameScoreLookup())
                : (IsReadyForWin() ? AdvState() : ScoreLookup());
        }

        private bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        private bool IsDeuce()
        {
            return FirstPlayerScore >= 3;
        }

        private bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }

        private bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore ? FirstPlayerName : SecondPlayerName;
        }

        private string AdvState()
        {
            return AdvPlayer() + (IsAdv() ? " Adv" : " Win");
        }

        private string ScoreLookup()
        {
            return _scoreLookup[FirstPlayerScore] + " " + _scoreLookup[SecondPlayerScore];
        }

        private string SameScoreLookup()
        {
            return _scoreLookup[FirstPlayerScore] + " All";
        }
    }
}