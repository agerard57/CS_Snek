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
        public int CurrentPlayer { get; set; }

        public Game()
        {
            Players = new List<Player>();
            CurrentPlayer = 0;
        }

        public void CreateGame()
        {
            Players.Add(new Player("Player 1"));
            Players.Add(new Player("Player 2"));

            while (true)
            {
                foreach (Player player in Players)
                {
                    Console.WriteLine($"{player.Name} - Press enter to roll the dice :)");
                    Console.ReadLine();
                    int dice = Dice.Roll();
                    Console.WriteLine($"You rolled a {dice}");
                    player.Score += dice;
                    Console.WriteLine($"Your score is {player.Score}");

                    if (player.Score == 50)
                    {
                        Console.WriteLine("You won!");
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
    }
}