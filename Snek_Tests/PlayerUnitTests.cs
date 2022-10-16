using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Snek;

namespace Snek_Tests
{
    [TestClass]
    public class PlayerUnitTests
    {
        private Player _player;

        [TestInitialize]
        public void PlayerUnitTestsInit()
        {
            _player = new("TestPlayer");
        }

        [TestMethod]
        [DataRow(5)]
        public void AddScoreTest(int Score)
        {
            _player.AddScore(Score);
            Assert.AreEqual(Score, _player.Score);
        }

        [TestMethod]
        [DataRow(51, 25)]
        public void OverFiftyTest(int Score, int ExpectedScore)
        {
            _player.AddScore(Score);
            _player.OverFifty();
            Assert.AreEqual(ExpectedScore, _player.Score);
        }

        [TestMethod]
        [DataRow(30)]
        public void ThirtyTest(int Score)
        {
            _player.AddScore(Score);
            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            _player.Thirty();
            Assert.AreEqual(string.Format("Too bad, {0} makes you loose a turn :(\r\n", Score), stringWriter.ToString());
        }

        [TestMethod]
        public void AllScoresTest()
        {
            for (int i = 0; i < 50; i++)
            {
                _player.AddScore(1);
                Assert.AreEqual(i + 1, _player.Score);
            }
        }
    }
}