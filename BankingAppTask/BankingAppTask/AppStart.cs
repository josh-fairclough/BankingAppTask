using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BankingApptests")]
namespace BankingAppTask
{
    internal class AppStart
    {
        public static void Main(string[] args)
        {
            BankingAppManager initialise = new BankingAppManager();
            initialise.MockAccounts();
            initialise.StartUp();
        }
    }
}
