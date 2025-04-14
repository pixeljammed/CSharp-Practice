using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCardGame
{
    class Program
    {
        static Card[] pack = new Card[52];

        // declare two arrays for player1 hand and player2 hand
        private static Card[] hand1 = new Card[26];
        private static Card[] hand2 = new Card[26];


        static void CreateAndShuffle()
        {
            Random rnd = new Random();

            for (int i = 0; i < pack.Length; i++)
            {
                pack[i] = new Card(i % 13 + 1, i / 13);
            }

            //Fisher-Yates shuffle
            for (int i = 0; i < pack.Length - 1; i += 2)
            {
                int r = rnd.Next(i + 1, 52);
                Card temp = pack[i];
                pack[i] = pack[r];
                pack[r] = temp;
            }
        }

        static void Deal()
        {
            for (int i = 0; i < 26; i++)
            {
                // assign card from pack to player1 hand
                hand1[i] = pack[i];
                //Console.WriteLine(pack[i].getScore());
                //Console.WriteLine($"PLAYER GOT: {hand1[i].getCardName()}");

                // assign card from pack to player2 hand
                hand2[i] = pack[i + 26];
                //Console.WriteLine(pack[i].getScore());
                //Console.WriteLine($"OPPONENT GOT: {hand1[i].getCardName()}");
            }
        }

        static void Play()
        {
            Console.Clear();

            int score1 = 0;
            int score2 = 0;
            for (int i = 0; i < 26; i++)
            {
                //write the card names
                Console.WriteLine($"YOUR CARD: {hand1[i].getCardName()}");
                Console.WriteLine($"OPPONENT'S CARD: {hand2[i].getCardName()}");

                // player 1 wins
                if (hand1[i].getScore() > hand2[i].getScore())
                {
                    score1 += 1;
                    Console.WriteLine("YOU WIN!");
                }

                //player 2 wins
                if (hand1[i].getScore() < hand2[i].getScore())
                {
                    score2 += 1;
                    Console.WriteLine("OPPONENT WINS!");
                }

                //tie or error
                else
                {
                    Console.WriteLine("TIE! (or error. idk)");
                }

                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            CreateAndShuffle();
            Deal();
            Play();
        }
    }
}