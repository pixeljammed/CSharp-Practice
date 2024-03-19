using System;
using Blackjack;

namespace Blackjack
{
    public class BlackjackHand : ScoringHand
    {
        public override int GetScore()
        {
            int Score = 0;
            int Aces = 0;
            
            foreach (Card card in cards)
            {
                int rank = card.GetRank();

                // NUMBER CARDS
                if (rank >= 2 && rank <= 10)
                {
                    Score += rank;
                }
                
                // PICTURE CARDS
                else if (rank >= 11 && rank <= 13)
                {
                    Score += 10;
                }
                
                // ACES
                else if (rank == 1)
                {
                    Score += 11;
                    Aces++;
                }
                
                // ERROR
                else
                {
                    Console.WriteLine("invalid rank");
                }
            }
            
            // ACE >21 RULE
            if (Score > 21 && Aces >= 1)
            {
                Score = Score - (10 * Aces);
            }

            return Score;
        }
    }
}