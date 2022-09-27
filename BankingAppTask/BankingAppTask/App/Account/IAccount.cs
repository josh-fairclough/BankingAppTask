using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTask.App.Account
{
    public interface IAccount
    {
        IEnumerable<Account> FetchAccounts();
        Account FetchWithId(int AccountId);
        Account FetchWithAccountNumber(Guid UniqueAccountNumber);
        Account Create(Account account, string Pin);
        void Delete(int AccountId);
    }
}
