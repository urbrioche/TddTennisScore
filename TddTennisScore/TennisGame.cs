using System;

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
            var game = this._repo.GetGame(gameId);
            if (game.FirstPlayerScore == game.SecondPlayerScore && game.FirstPlayerScore == 0)
            {
                return "Love All";
            }
            throw new NotImplementedException();
        }
    }
}