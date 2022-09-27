using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask.App.Transaction
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionReference { get; set; }
        public string TransactionNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionInitiatedAccount { get; set; }
        public string TransactionReceivingAccount { get; set; }
        public TypeOfTransaction TransactionType { get; set; }
        public StatusOfTransaction TransactionStatus { get; set; }
        public bool TransactionConfirmed { get; set; }
        public DateTime TransactionDate { get; set; }


        public Transaction()
        {
            TransactionReference = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 20)}";
        }

    }
}
