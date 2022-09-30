using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask
{
    public class Enums
    {
        public enum Menu
        {
            [Description("Balance")]
            Balance = 1,

            [Description("Deposit")]
            Deposit = 2,

            [Description("Withdraw")]
            Withdraw = 3,

            [Description("Transfer")]
            Transfer = 4,

            [Description("Logout")]
            Logout = 5,
        }

        public enum TypeOfTransaction
        {
            [Description("Deposit")]
            Deposit = 1,

            [Description("Withdraw")]
            Withdraw = 1,

            [Description("Transfer")]
            Transfer = 1,
        }
    }
}
