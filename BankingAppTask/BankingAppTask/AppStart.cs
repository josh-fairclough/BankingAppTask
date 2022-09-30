namespace BankingAppTask
{
    class AppStart
    {
        static void Main(string[] args)
        {
            BankingAppManager initialise = new BankingAppManager();
            initialise.MockAccounts();
            initialise.StartUp();
        }
    }
}
