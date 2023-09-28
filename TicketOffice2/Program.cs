using System;

namespace TicketOffice2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Ticket Office App!");

            int age = GetCustomerAge();
            string place = GetCustomerPlacePreference();

            int price = PriceSetter(age, place);
            decimal tax = TaxCalculator(price);
            int ticketNumber = TicketNumberGenerator();

            Console.WriteLine($"Ticket Price: {price} SEK");
            Console.WriteLine($"Tax: {tax} SEK");
            Console.WriteLine($"Ticket Number: {ticketNumber}");
        }

        static int GetCustomerAge()
        {
            while (true)
            {
                Console.Write("Please enter your age: ");
                string input = Console.ReadLine();
                if (input.Length >= 1 && input.Length <= 3 && IsNumeric(input))
                {
                    return int.Parse(input); // to convert the string (input) into an integer 
                }
                else
                {
                    Console.WriteLine("Invalid age format or range. Please enter a valid age between 1 and 3 characters.");
                }
            }
        }

        static bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        static string GetCustomerPlacePreference()
        {
            while (true)
            {
                Console.Write("Do you want a standing or seated ticket (S for seated, anything else for standing): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "s" || input == "seated")
                {
                    return "Seated";
                }
                else if (input == "standing")
                {
                    return "Standing";
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 'S' for seated or any other key for standing.");
                }
            }
        }

        static int PriceSetter(int age, string place)
        {
            int seatedPrice = 0;
            int standingPrice = 0;

            if (age < 11)
            {
                seatedPrice = 50;
                standingPrice = 25;
            }
            else if (age >= 12 && age <= 64)
            {
                seatedPrice = 170;
                standingPrice = 110;
            }
            else if (age > 65)
            {
                seatedPrice = 100;
                standingPrice = 60;
            }

            return place == "Seated" ? seatedPrice : standingPrice;
        }

        static decimal TaxCalculator(int price)
        {
            decimal tax = (1 - 1 / 1.06m) * price;
            return Math.Round(tax, 2);
        }

        static int TicketNumberGenerator()
        {
            Random random = new Random();
            return random.Next(1, 8000);
        }
    }
}
