using Snek;

namespace Snek_Tests
{
    [TestClass]
    public class GameUnitTests
    {
        private Game _game;

        [TestInitialize]
        public void GameUnitTestsInitializer()
        {
            _game = new();

        }

        [TestMethod]
        [DataRow("2")]
        [DataRow("3")]
        [DataRow("4")]
        public void NumberOfPlayersInputTest(String FedInput)
        {
            using StringReader reader = new(FedInput);
            Console.SetIn(reader);

            Assert.AreEqual(FedInput, _game.NumberOfPlayersInput());
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void PlayersNamesTest(int NumberOfPlayers)
        {
            // Depending on numberOfPlayers, create FedInput with this format
            // "numberOfPlayers\r\nPlayer1Name\r\nPlayer2Name\r\nPlayer3Name\r\nPlayer4Name"
            string FedInput = string.Format("{0}\r\n", NumberOfPlayers);
            for (int i = 0; i < NumberOfPlayers; i++)
                FedInput += string.Format("TestPlayer{0}\r\n", i + 1);

            StringReader stringReader = new(FedInput);
            Console.SetIn(stringReader);
            _game.PlayersInitializer();

            // Loop through all players and check if their name is correct
            for (int i = 0; i < NumberOfPlayers; i++)
                Assert.AreEqual(string.Format("TestPlayer{0}", i + 1), _game.Players[i].Name);
        }

        [TestMethod]
        [DataRow("10\r\n2")]
        [DataRow("IncorrectStringInputFormat\r\n2")]
        [DataRow("-1\r\n2")]
        public void IncorrectNumberOfPlayersInputTest(String FedInput)
        {
            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            using StringReader reader = new(FedInput);
            Console.SetIn(reader);
            _game.NumberOfPlayersInput();

            // Check that "Please enter the number of players (between 2 and 4)" appears twice.
            // If the incorrect input is handled, then the message should appear again
            String Message = "Please enter the number of players (between 2 and 4)";
            Assert.AreEqual(string.Format("{0}\r\n{0}\r\n", Message), stringWriter.ToString());
        }

        [TestMethod]
        [DataRow("2\r\nTestPlayer1\r\nTestPlayer2\r\n")]
        public void EndGameTest(string FedInput)
        {
            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            using StringReader reader = new(FedInput);
            Console.SetIn(reader);
            _game.PlayersInitializer();
            _game.GameInProgress = true;

            _game.Players[0].AddScore(50);
            _game.EndGame(_game.Players[0]);

            // Check that the message "Game over!" appears
            Assert.IsTrue(stringWriter.ToString().Contains("TestPlayer1"));
            Assert.IsFalse(_game.GameInProgress);
        }

        [TestMethod]
        [DataRow("2\r\nTestPlayer1\r\nTestPlayer2\r\n")]
        public void GameNotEndedTest(string FedInput)
        {
            using StringReader reader = new(FedInput);
            Console.SetIn(reader);
            _game.PlayersInitializer();
            _game.GameInProgress = true;

            _game.EndGame(_game.Players[0]);

            Assert.IsTrue(_game.GameInProgress);
        }
    }
}
