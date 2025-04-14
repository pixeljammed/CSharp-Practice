using System;

namespace PCardGameIncomplete

{

    public class PCardGame

    {

        public static void Main(string[] args)

        {

            int i, number, ranknum, suitnum;

            string rank = "";

            string suit = "";

            // "seeds" (initialises) the random number generator

            Random random = new Random();

            //selects a random number between 0 and 51,

            //adds one to it and assigns the result to number

            number = random.Next(52) + 1;

            // ??? complete this using the method you came up with in your triangles

            ranknum = (number - 1) % 13 + 1;

            suitnum = (number - 1) / 13;

            // ??? complete this case statement for the other ranks

            switch (ranknum)

            {
                case 1:
                    rank = "Ace";
                    break;

                case 2:
                    rank = "Two";
                    break;

                case 3:
                    rank = "Three";
                    break;

                case 4:
                    rank = "Four";
                    break;

                case 5:
                    rank = "Five";
                    break;

                case 6:
                    rank = "Six";
                    break;

                case 7:
                    rank = "Seven";
                    break;

                case 8:
                    rank = "Eight";
                    break;

                case 9:
                    rank = "Nine";
                    break;

                case 10:
                    rank = "Ten";
                    break;

                case 11:
                    rank = "Jack";
                    break;

                case 12:
                    rank = "Queen";
                    break;

                case 13:
                    rank = "King";
                    break;

                default:
                    rank = "DEFAULT CASE";
                    break;
            }

            // add if statements for the other suits

            if (suitnum == 0)

            {

                suit = "Clubs";

            }

            if (suitnum == 1)

            {

                suit = "Spades";

            }

            if (suitnum == 2)

            {

                suit = "Diamonds";

            }

            if (suitnum == 3)

            {

                suit = "Hearts";

            }

            // output using an interpolated string

            Console.WriteLine($"Your card is the {rank} of {suit}");

            Console.ReadLine();

        }

    }

}