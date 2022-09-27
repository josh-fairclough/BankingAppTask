using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask.App
{
    public  enum TypeOfTransaction
    {
        Deposit = 1,
        Withdrawal = 2,
        Transfer = 3
    }

    public enum StatusOfTransaction
    {
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
    }
}
