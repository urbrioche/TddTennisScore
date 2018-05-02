using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TddTennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private TennisGame _tennisGame;
        private const int AnyGameId = 1;

        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }

        [TestMethod]
        public void Love_All()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 0, SecondPlayerScore = 0 });
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 1, SecondPlayerScore = 1 });
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 2, SecondPlayerScore = 2 });
            ScoreShouldBe("Thirty All");
        }

        [TestMethod]
        public void Deuce()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 3, SecondPlayerScore = 3 });
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 1, SecondPlayerScore = 0 });
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Fifteen()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 2, SecondPlayerScore = 1 });
            ScoreShouldBe("Thirty Fifteen");
        }

        [TestMethod]
        public void Forty_Thirty()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 3, SecondPlayerScore = 2 });
            ScoreShouldBe("Forty Thirty");
        }

        [TestMethod]
        public void First_Player_Advantage()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 4, SecondPlayerScore = 3, FirstPlayerName = "Joey" });
            ScoreShouldBe("Joey Adv");
        }

        [TestMethod]
        public void Second_Player_Advantage()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 3, SecondPlayerScore = 4, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });
            ScoreShouldBe("Tom Adv");
        }

        [TestMethod]
        public void First_Player_Win()
        {
            GivenGame(new Game { Id = AnyGameId, FirstPlayerScore = 5, SecondPlayerScore = 3, FirstPlayerName = "Joey", SecondPlayerName = "Tom" });
            ScoreShouldBe("Joey Win");
        }

        private void ScoreShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(AnyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private void GivenGame(Game game)
        {
            _repository.GetGame(AnyGameId).Returns(game);
        }

        
    }
}
