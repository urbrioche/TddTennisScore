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
            if (game.FirstPlayerScore == game.SecondPlayerScore)
            {
                if (game.FirstPlayerScore == 0)
                {
                    return "Love All";
                }

                if (game.FirstPlayerScore == 1)
                {
                    return "Fifteen All";
                }

                if (game.FirstPlayerScore == 2)
                {
                    return "Thirty All";
                }
            
            }

            return string.Empty;
        }
    }
}