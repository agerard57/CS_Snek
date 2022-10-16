using Snek;

namespace Snek_Tests
{
    [TestClass]
    public class GameUnitTests
    {
        private Game _game;

        [TestInitialize]
        public void GameUnitTestsInit()
        {
            _game = new();
        }

        /*        [TestMethod]
                [DataRow(2)]
                public void CreateGameTest()
                {
                    _game.CreateGame();
                    // Input 2 to cli

                    Assert.AreEqual(2, _game.Players.Count);
                }*/
    }
}