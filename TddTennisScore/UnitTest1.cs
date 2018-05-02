using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TddTennisScore
{
    [TestClass]
    public class UnitTest1
    {        
        [TestMethod]
        public void Love_All()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 0, SecondPlayerScore = 0 });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Love All", scoreResult);
        }

        [TestMethod]
        public void Fifteen_All()
        {
            var gameId = 1;

            IRepository<Game> repo = Substitute.For<IRepository<Game>>();
            repo.GetGame(gameId).Returns(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 1 });

            TennisGame tennisGame = new TennisGame(repo);

            var scoreResult = tennisGame.ScoreResult(gameId);
            Assert.AreEqual("Fifteen All", scoreResult);
        }
    }
}
