using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
