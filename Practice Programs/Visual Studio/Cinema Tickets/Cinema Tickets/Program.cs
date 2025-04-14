using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialise the variables
            double price = 11.50;
            string ticketType;
            string extras = "None";
            Boolean member = false;

            // Ask user for the ticket type
            Console.WriteLine("Enter the ticket type: ");
            ticketType = Console.ReadLine();

            // Ask user if the ticket holder is a member
            Console.WriteLine("Is the ticket holder a member? (true or false) ");
            member = Convert.ToBoolean(Console.ReadLine());
            if (member == true)
            {
                price = price * 0.9;
                Console.WriteLine("10% discount has been applied.");
                extras = "Premier Seats";
                Console.WriteLine("Premier seats have been assigned.");
            }

            // Calculate the price depending on the ticket type and membership
            if (ticketType == "Infant")
            {
                // Infants go free
                price = 0.0;
            }
            else if (ticketType == "Student" || ticketType == "Senior")
            {
                price = price * 0.8;
                Console.WriteLine("20% discount has been applied.");

                if (member == true)
                {
                    extras = "Popcorn";
                    Console.WriteLine("Popcorn has been assigned.");
                }
            }

            else
            {
                // Set the ticket type to Adult
                ticketType = "Adult";
            }

            // Output the ticket details
            Console.WriteLine("Ticket type: " + ticketType);
            Console.WriteLine("Membership: " + member);
            Console.WriteLine("Ticket cost: £" + price);
            Console.WriteLine("Extras: " + extras);

            Console.ReadKey();
        }
    }
}


