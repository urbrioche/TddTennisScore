using System;
using System.Collections.Generic;

namespace TddTennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;
        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" }
        };

        private string _Deuce;

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
            _Deuce = "Deuce";
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);
            if (IsSameScore(game))
            {
                if (IsDeuce(game))
                {
                    return _Deuce;
                }
                return _scoreLookup[game.FirstPlayerScore] + " All";
            }
            
            throw new NotImplementedException();
        }

        private static bool IsDeuce(Game game)
        {
            return game.FirstPlayerScore >= 3;
        }

        private static bool IsSameScore(Game game)
        {
            return game.FirstPlayerScore == game.SecondPlayerScore;
        }
    }
}