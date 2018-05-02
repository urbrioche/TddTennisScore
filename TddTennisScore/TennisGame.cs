using System;
using System.Collections.Generic;

namespace TddTennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = _repo.GetGame(gameId);
            if (game.IsSameScore())
            {
                if (game.FirstPlayerScore >= 3)
                {
                    return "Deuce";
                }
                return game.SameScoreLookup();
            }


            return string.Empty;
        }
    }
}