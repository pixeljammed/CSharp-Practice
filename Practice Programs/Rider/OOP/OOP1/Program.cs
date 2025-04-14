namespace OOP1;

class Program
{
    public class Dice
    {
        public int value;
        public int sides;
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