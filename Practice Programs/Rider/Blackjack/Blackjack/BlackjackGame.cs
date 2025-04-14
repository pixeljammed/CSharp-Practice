namespace Blackjack;

using static Globals;

public class BlackjackGame : Game
{
    public void Play()
    {
        BlackjackHand playerHand = new BlackjackHand();
        BlackjackHand houseHand = new BlackjackHand();

        string choice;

        while (balance > 100)
        {
            AsciiArt();

            choice = "HIT";

            Pack pack1 = new Pack(); //new pack every round cos why not?
            pack1.Shuffle();

            playerHand.Clear();
            houseHand.Clear();

            games += 1; // increment total number of games played

            bet = BetMoney();

            Console.Clear();

            playerHand.AddCard(pack1.DealCard());
            playerHand.AddCard(pack1.DealCard());
            // two cards dealt to player

            houseHand.AddCard(pack1.DealCard());
            houseHand.AddCard(pack1.DealCard());
            // two cards dealt to house

            while (choice == "HIT" && playerHand.GetScore() <= 21)
            {
                DisplayScores(playerHand, houseHand);

                Console.WriteLine("Would you like to HIT or STAND?");
                choice = Console.ReadLine().ToUpper();
                if (choice == "HIT")
                {
                    playerHand.AddCard(pack1.DealCard());
                }

                Console.Clear();
            }

            CheckResult(playerHand.GetScore(), houseHand.GetScore());

            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadLine();
            Console.Clear();
        }
    }

    // ----- ----- ----- ----- ----- ///

    private static int BetMoney()
    {
        Console.WriteLine($"   \n   YOUR BALANCE: {balance}\n");
        Console.WriteLine("How much would you like to bet?");

        int bet;
        while ((!int.TryParse(Console.ReadLine(), out bet) || bet > balance || bet < 100))
        {
            Console.WriteLine(
                $"Invalid Bet - Must be minimum 100 coins + must have enough money. \n Your current balance is: {balance}");
        }

        return bet;
    }

    // I SHOULD HAVE USED A SWITCH CASE BUT IDC
    private static void CheckResult(int playerScore, int houseScore)
    {
        if (playerScore > 21)
        {
            Console.WriteLine(
                $"YOU WENT BUST! \n Your card's values were above 21... \n [You: {playerScore} > 21 | House: {houseScore}] \n");
            balance -= bet; // deduct bet
        }

        if (playerScore == 21 && playerScore != houseScore)
        {
            Console.WriteLine(
                $"YOU GOT A NATURAL 21! \n You've been given 3x (Triple) your bet back! \n [You: {playerScore} = 21 | House: {houseScore}] \n");
            balance = balance + (Convert.ToInt32(bet * 2)); // triple bet and give back
            wins += 1;
        }

        if (playerScore > houseScore && playerScore < 21)
        {
            Console.WriteLine(
                $"YOU WIN! \n You had a higher score than the house! \n [You: {playerScore} > House: {houseScore}] \n");
            balance = balance + bet; // double bet + give back: bet isn't taken away until loss so just adds
            wins += 1;
        }

        if (playerScore < houseScore && playerScore < 21)
        {
            Console.WriteLine(
                $"YOU LOSE! \n The house had a higher score than you... \n [You: {playerScore} < House: {houseScore}] \n");
            balance -= bet; // deduct bet
        }

        if (playerScore == houseScore && playerScore <= 21)
        {
            Console.WriteLine(
                $"YOU TIED! \n You and the house had equal scores. \n [You: {playerScore} = House: {houseScore}] \n");
            // don't do shit
        }
    }

    public override void DisplayScores(BlackjackHand player, BlackjackHand house)
    {
        string cards = $"║ {player.GetHandAsString()}                 │ {house.First().GetName()} ?             ║";
        cards = cards.Remove((player.Size * 3) + 2, player.Size * 3);


        string scores = $"║ SCORE: {player.GetScore()}          │ SCORE: ??        ║";
        scores = scores.Remove(11, player.GetScore().ToString().Length);

        Console.WriteLine("╔═════════════════════════════════════╗");
        Console.WriteLine("║ Blackjack                           ║");
        Console.WriteLine("║━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━║");
        Console.WriteLine("║ Your cards:      │ House's cards:   ║");
        Console.WriteLine(cards);
        Console.WriteLine("║                  │                  ║");
        Console.WriteLine(scores);
        Console.WriteLine("╚═════════════════════════════════════╝");
    }

    private static void AsciiArt()
    {
        // BLACKJACK ASCII ART
        Console.WriteLine(
            "\n\u2588\u2588\u2588\u2588\u2588\u2588\u2591  \u2588\u2588\u2591       \u2588\u2588\u2588\u2588\u2588\u2591   \u2588\u2588\u2588\u2588\u2588\u2588\u2591 \u2588\u2588\u2591  \u2588\u2588\u2591      \u2591\u2588\u2588   \u2591\u2588\u2588\u2588\u2588\u2588    \u2591\u2588\u2588\u2588\u2588\u2588\u2588  \u2591\u2588\u2588   \u2588\u2588 \n\u2588\u2588\u2591  \u2588\u2588\u2591 \u2588\u2588\u2591      \u2588\u2588\u2591  \u2588\u2588\u2591 \u2588\u2588\u2591      \u2588\u2588\u2591 \u2588\u2588\u2591       \u2591\u2588\u2588  \u2591\u2588\u2588   \u2588\u2588  \u2591\u2588\u2588       \u2591\u2588\u2588  \u2588\u2588  \n\u2588\u2588\u2588\u2588\u2588\u2588\u2591  \u2588\u2588\u2591      \u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2591 \u2588\u2588\u2591      \u2588\u2588\u2588\u2588\u2588\u2591        \u2591\u2588\u2588  \u2591\u2588\u2588\u2588\u2588\u2588\u2588\u2588  \u2591\u2588\u2588       \u2591\u2588\u2588\u2588\u2588\u2588   \n\u2588\u2588\u2591  \u2588\u2588\u2591 \u2588\u2588\u2591      \u2588\u2588   \u2588\u2588\u2591 \u2588\u2588\u2591      \u2588\u2588\u2591 \u2588\u2588\u2591  \u2591\u2588\u2588  \u2591\u2588\u2588  \u2591\u2588\u2588   \u2588\u2588  \u2591\u2588\u2588       \u2591\u2588\u2588  \u2588\u2588  \n\u2588\u2588\u2588\u2588\u2588\u2588\u2591  \u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2591 \u2588\u2588   \u2588\u2588\u2591  \u2588\u2588\u2588\u2588\u2588\u2588\u2591 \u2588\u2588\u2591  \u2588\u2588\u2591  \u2591\u2588\u2588\u2588\u2588\u2588   \u2591\u2588\u2588   \u2588\u2588   \u2591\u2588\u2588\u2588\u2588\u2588\u2588  \u2591\u2588\u2588   \u2588\u2588 ");
    }
}