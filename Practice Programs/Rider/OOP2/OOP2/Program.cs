using System.Net.Security;

namespace OOP2;

class Program
{
    public class Card
    {
        public int rank;
        public int suit;
        public int score;

        private Random rnd = new Random();

        public Card(int NumRank, int NumSuit)
        {
            rank = NumRank;
            suit = NumSuit;
        }

        public int GetScore()
        {
            score = (rank * 4) + score;
            return score;
        }

        public void randomize()
        {
            Random rnd = new Random();

            rank = rnd.Next(1, 14);
            suit = rnd.Next(1, 14);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("MILOS SUPER EPIC CARD GENERATOR!!!! \n");

            Card myCard = new Card(0, 0);

            myCard.randomize();

            Console.WriteLine($"rank is {myCard.rank}");
            Console.WriteLine($"suit is {myCard.suit}");
            Console.WriteLine($"score is {myCard.GetScore()}");
        }
    }
}