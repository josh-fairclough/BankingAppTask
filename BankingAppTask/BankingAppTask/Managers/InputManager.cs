using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BankingAppTask.Managers
{
    public static class InputManager
    {
        private static CultureInfo country = new CultureInfo("en-GB");
        public static decimal ValidateDecimal(string input)
        {
            decimal amount = 0;
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = GetUserInput(input);
                valid = decimal.TryParse(userInput, out amount);
                if (!valid)
                    Output("Please try again. Input invalid");
            }

            return amount;
        }

        public static int ValidateInput(string input)
        {
            int amount = 0;
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = GetUserInput(input);
                valid = Int32.TryParse(userInput, out amount);
                if (!valid)
                    Output("Please try again. Input invalid");
            }

            return amount;
        }

        public static string GetUserInput(string note)
        {
            Console.WriteLine($"Write {note} here");
            return Console.ReadLine();
        }

        public static string GetConsoleInput()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                var keyPress = Console.ReadKey(true);
                if (keyPress.Key == ConsoleKey.Enter) break;
                if (keyPress.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (keyPress.Key != ConsoleKey.Backspace) input.Append(keyPress.KeyChar);
            }

            return input.ToString();
        }

        public static string Amount(decimal amount)
        {
            return String.Format(country, "{0:C2}", amount);
        }

        public static void Output(string output)
        {
            Console.WriteLine(output);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
