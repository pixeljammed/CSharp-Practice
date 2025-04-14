using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class Card
    {
        public int Rank { private set; get; }
        public int Suit { private set; get; }

        // constructor
        public Card(int r, int s)
        {
            Rank = r;
            Suit = s;
        }


        public string GetRankAsString()
        {
            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            return ranks[Rank - 1];
        }

        public string GetSuitAsString()
        {
            string[] suits = { "♣", "♦", "♥", "♠" };
            return suits[Suit];
        }


        public string GetName()
        {
            return GetSuitAsString() + GetRankAsString();
        }

        public int GetRank()
        {
            return Rank;
        }
    }
}