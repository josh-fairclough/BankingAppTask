using System;

namespace BankingAppTask.Managers
{
    public static class MenuManager
    {
        internal static string gbp = "GBP";

        public static Transfer TransferInput()
        {
            var transfer = new Transfer();

            Console.WriteLine("\nEnter Account number to transfer to ");
            transfer.AccountReceiving = Convert.ToInt32(Console.ReadLine());
            transfer.AccountReceiving = InputManager.ValidateInput("Account number receiving transfer");

            Console.WriteLine($"\nTransfer amount {gbp}");
            transfer.TransferAmount = InputManager.ValidateDecimal("amount");

            return transfer;
        }

        public static void Login()
        {
            //Console.Clear();
            Console.WriteLine(" Main Menu ");
            Console.WriteLine(" ");
            Console.WriteLine(" 1. Enter Login Details ");
            Console.WriteLine(" 2. Create Account");
            Console.WriteLine(" 3. Shut Down ");
            Console.WriteLine(" ");
        }

        public static void AccountMenu()
        {
            Console.Clear();
            Console.WriteLine(" Account Menu ");
            Console.WriteLine(" ");
            Console.WriteLine(" 1. Balance ");
            Console.WriteLine(" 2. Deposit ");
            Console.WriteLine(" 3. Withdraw ");
            Console.WriteLine(" 4. Transfer ");
            Console.WriteLine(" 5. Logout ");
            Console.WriteLine(" ");
        }
    }
}
