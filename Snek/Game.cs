using System.Numerics;

namespace Snek
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public string NumberOfPlayers { get; set; }
        public int CurrentPlayer { get; set; }
        public bool GameInProgress { get; set; }

        public Game()
        {
            Players = new List<Player>();
            NumberOfPlayers = "";
            CurrentPlayer = 0;
            GameInProgress = false;
        }

        public void CreateGame()
        {
            Console.WriteLine("Welcome to Snek!");
            NumberOfPlayers = NumberOfPlayersInput();

            for (int i = 0; i < int.Parse(NumberOfPlayers); i++)
                PlayersName(i);

            GameInProgress = true;

            while (GameInProgress)
                GameLoop();
            PlayAgain();
        }

        private void PlayersName(int i)
        {
            Console.WriteLine($"Player {i + 1} - What is your name?");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
                name = $"Player {i + 1}";

            Players.Add(new Player(name));
        }

        private string NumberOfPlayersInput()
        {
            while (!int.TryParse(NumberOfPlayers, out int number) || number < 2 || number > 4)
            {
                Console.WriteLine("Please enter the number of players (between 2 and 4)");
                NumberOfPlayers = Console.ReadLine();
            }

            return NumberOfPlayers;
        }

        private void GameLoop()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine($"{player.Name} - Press enter to roll the dice :)");
                Console.ReadLine();
                int dice = new Dice().Roll();
                Console.WriteLine($"You rolled a {dice}");
                player.AddScore(dice);
                player.Thirty();
                player.OverFifty();
                EndGame(player);
                if (GameInProgress == false)
                    break;
            }
        }

        private void EndGame(Player player)
        {
            if (player.Score == 50)
            {
                GameInProgress = false;
                Console.WriteLine("Game over!");
                Console.WriteLine("The winner is:");
                Console.WriteLine(Players.OrderByDescending(p => p.Score).First().Name);
                Console.ReadLine();
                return;
            }
        }

        private void PlayAgain()
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                Players.Clear();
                CreateGame();
            }
            else
                Console.WriteLine("Thanks for playing!");
        }
    }
}