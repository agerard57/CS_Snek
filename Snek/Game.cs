using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    internal class Game
    {
        private static void Main(string[] args)
        {
            Player[] players = new Player[2];
            players[0] = new Player();
            players[1] = new Player();

            while (true)
            {
                foreach (Player player in players)
                {
                    Console.WriteLine($"Player {Array.IndexOf(players, player) + 1} - Press enter to roll the dice :)");
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