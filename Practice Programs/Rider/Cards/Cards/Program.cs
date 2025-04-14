namespace Cards;

class Program
{
    public class Dice
    {
        private int value;
        private int sides;
        Random rnd = new Random();

        public Dice(int numSides)
        {
            sides = numSides;
        }

        public int GetValue()
        {
            return value;
        }

        // public int  Roll()
        // {
        //     value = rnd.Next(sides + 1);
        // }
    }
}