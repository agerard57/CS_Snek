namespace Snek
{
    public class Dice
    {
        public static int Roll()
        {
            Random random = new();
            return random.Next(1, 7);
        }
    }
}