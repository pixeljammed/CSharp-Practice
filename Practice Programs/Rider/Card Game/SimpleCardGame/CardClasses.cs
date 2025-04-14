using System;

namespace SimpleCardGame
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
            // Calculate the score based on rank
            score = (rank + 1) * 4;
        }

        public int getScore()
        {
            // Removed unnecessary 'score = (rank * 4) + score;' line
            return score;
        }

        public void randomize()
        {
            rank = rnd.Next(0, 14);
            suit = rnd.Next(0, 5);
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
}