using System;

namespace OOP3
{
    class Program
    {
        public class Card
        {
            private int rank;
            private int suit;
            private int score;

            private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            private string[] ranks =
            {
                "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"
            };

            private Random rnd = new Random();

            public Card(int NumRank, int NumSuit)
            {
                rank = NumRank;
                suit = NumSuit;
            }

            public int getScore()
            {
                // Removed unnecessary 'score = (rank * 4) + score;' line
                return score;
            }

            public void randomize()
            {
                rank = rnd.Next(0, 13); // Changed range to include all ranks
                suit = rnd.Next(0, 4);
            }

            public int getRank()
            {
                return rank;
            }

            public string getRankString()
            {
                return ranks[rank];
            }

            public int getSuit()
            {
                return suit;
            }

            public string getSuitString()
            {
                return suits[suit];
            }

            public string getCardName()
            {
                return $"{getRankString()} of {getSuitString()}";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("MILOS SUPER EPIC CARD GENERATOR!!!! \n");

            /// GENERATE DECK ///
            Card[,] deck = new Card[4, 13];

            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 0; rank < 13; rank++)
                {
                    deck[suit, rank] = new Card(rank, suit);
                }
            }

            /// DISPLAY DECK ///
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 0; rank < 13; rank++)
                {
                    Console.WriteLine($"Card: {deck[suit, rank].getCardName()}");
                }
            }

            /// GENERATE RANDOM CARD ///

            // Card myCard = new Card(0, 0); 
            //
            // myCard.randomize();
            //
            // Console.WriteLine($"rank is {myCard.getRank()}");
            // Console.WriteLine($"suit is {myCard.getSuit()}");
            // Console.WriteLine($"score is {myCard.getScore()}");
            //
            // Console.Write("\n");

            Card[] cards = new Card[52];

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = new Card(i % 13 + 1, i / 13);
            }
        }
    }
}