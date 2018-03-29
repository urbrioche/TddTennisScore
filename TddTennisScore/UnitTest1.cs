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
            var repository = Substitute.For<IRepository<Game>>();
            var gameId = 1;
            repository.GetGame(gameId).Returns(new Game { Id = 1, FirstPlayerScore = 0, SecondPlayerScore = 0 });
            var tennisGame = new TennisGame(repository);
            Assert.AreEqual("Love All", tennisGame.ScoreResult(gameId));
        }
    }
}
