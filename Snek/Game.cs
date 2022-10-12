using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CurrentPlayer = 0;
            GameInProgress = false;
        }

        public void CreateGame()
        {
            Console.WriteLine("Welcome to Snek!");
            NumberOfPlayers = NumberOfPlayersInput();

            // User input must be a valid number, must also be between 2 and 4 players
            while (!int.TryParse(NumberOfPlayers, out int n) || n < 2 || n > 4)
                NumberOfPlayers = NumberOfPlayersInput();

            for (int i = 0; i < int.Parse(NumberOfPlayers); i++)
            {
                Console.WriteLine($"Player {i + 1} - What is your name?");
                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                    name = $"Player {i + 1}";

                Players.Add(new Player(name));
            }
            GameInProgress = true;

            while (GameInProgress)
                GameLoop();
        }

        private string NumberOfPlayersInput()
        {
            Console.WriteLine("Please enter the number of players (between 2 and 4)");
            return Console.ReadLine();
        }

        private void GameLoop()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine($"{player.Name} - Press enter to roll the dice :)");
                Console.ReadLine();
                int dice = Dice.Roll();
                Console.WriteLine($"You rolled a {dice}");

                if (player.Score + dice == 30)
                    Console.WriteLine("Too bad, 30 makes you loose a turn :(");
                else
                {
                    player.Score += dice;
                    Console.WriteLine($"Your score is {player.Score}");

                    if (player.Score == 50)
                    {
                        GameInProgress = false;
                        EndGame();
                        return;
                    }
                    else if (player.Score > 50)
                    {
                        Console.WriteLine("You did more than 50 points, go back to 25!");
                        player.Score = 25;
                    }
                }
            }
        }

        private void EndGame()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine("The winner is:");
            Console.WriteLine(Players.OrderByDescending(p => p.Score).First().Name);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}