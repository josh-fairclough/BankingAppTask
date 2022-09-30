using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask
{
    public class Transactions
    {
        public Enums.TypeOfTransaction TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public Int64 AccountTo { get; set; }
        public Int64 AccountFrom { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
