using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask.App.Account
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal AccountBalance { get; set; }
        public Guid UniqueAccountNumber { get; set; }
        public byte[] Pin { get; set; }
        public string AccountName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountHolderSurname { get; set; }


        public Account()
        {
            UniqueAccountNumber = Guid.NewGuid();
            AccountName = $"{AccountHolderName} {AccountHolderSurname}";
        }
    }
}
