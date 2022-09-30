using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask.Interfaces
{
    public interface IWithdraw
    {
        void Withdraw(Accounts account);
    }
}
