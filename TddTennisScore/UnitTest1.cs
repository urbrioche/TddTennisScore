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

        private void ScoreShouldBe(string expected)
        {
            Assert.AreEqual(expected, _tennisGame.ScoreResult(AnyGameId));
        }

        private void GivenGame(Game game)
        {
            _repository.GetGame(AnyGameId).Returns(game);
        }
    }
}
