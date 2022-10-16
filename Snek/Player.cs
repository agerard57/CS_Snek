namespace Snek
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void AddScore(int dice)
        {
            Score += dice;
            Console.WriteLine($"Your score is {Score}");
        }

        public void OverFifty()
        {
            if (Score > 50)
            {
                Console.WriteLine("You did more than 50 points, go back to 25!");
                Score = 25;
            }
        }

        public void Thirty()
        {
            if (Score == 30)
                Console.WriteLine("Too bad, 30 makes you loose a turn :(");
        }
    }
}