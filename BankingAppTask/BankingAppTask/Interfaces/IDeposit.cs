using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask.Interfaces
{
    public interface IDeposit
    {
        void Deposit(Accounts account);
    }
}
