namespace BankingAppTask.Interfaces
{
    public interface ITransfer
    {
        void SendTransfer(Accounts account, Transfer balanceTransfer);
    }
}
