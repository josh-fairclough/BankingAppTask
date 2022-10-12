using System;
using System.Collections.Generic;
using System.Linq;
using BankingAppTask.Interfaces;
using BankingAppTask.Managers;

namespace BankingAppTask
{
    public class BankingAppManager : IBalance, IDeposit, ILogin, ITransfer, IWithdraw
    {
        private static List<Accounts> listOfAccounts;
        private static Accounts accountSelected;
        private static Accounts enterAccount;

        private static List<Transactions> listOfTransactions;
        private static decimal transactionAmount;

        private static int attempts;
        private const int maxAttempts = 3;

        public void StartUp()
        {
            MenuManager.Login();

            while (true)
            {
                switch (InputManager.ValidateInput("option"))
                {
                    case 1:
                        CheckPin();
                        listOfTransactions = new List<Transactions>();

                        while (true)
                        {
                            MenuManager.AccountMenu();

                            switch (InputManager.ValidateInput("option"))
                            {
                                case (int)Enums.Menu.Balance:
                                    Balance(accountSelected);
                                    break;

                                case (int)Enums.Menu.Deposit:
                                    Deposit(accountSelected);
                                    break;

                                case (int)Enums.Menu.Withdraw:
                                    Withdraw(accountSelected);
                                    break;

                                case (int)Enums.Menu.Transfer:
                                    var balanceTransfer = new Transfer();
                                    balanceTransfer = MenuManager.TransferInput();

                                    SendTransfer(accountSelected, balanceTransfer);
                                    break;

                                case (int)Enums.Menu.Logout:
                                    InputManager.Output("Thank you for using our services. Logout success.");
                                    StartUp();
                                    break;

                                default:
                                    InputManager.Output("Option entered is invalid. Please try again");
                                    break;
                            }
                        }
                    case 2:
                        var newAccount = new Accounts();
                        Console.WriteLine("\n Create Account");
                        Console.WriteLine("Please enter your Forename");
                        newAccount.Forename = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Please enter your Surname");
                        newAccount.Surname = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Please enter a valid account number");
                        newAccount.AccountNumber = Convert.ToInt32(Console.ReadLine());

                        var existing = (from a in listOfAccounts
                            where a.AccountNumber == newAccount.AccountNumber
                            select a).FirstOrDefault();
                        if (existing != null)
                            Console.WriteLine("Please try another AccountNumber");

                        Console.WriteLine("Please enter your pin");
                        newAccount.Pin = Convert.ToInt32(Console.ReadLine());

                        listOfAccounts.Insert(0, newAccount);

                        InputManager.Output("Account creation successful.");
                        StartUp();
                        break;

                    case 3:
                        Console.WriteLine("\n Shutting Down");
                        System.Environment.Exit(1);
                        break;

                    default:
                        InputManager.Output("Option entered is invalid. Please try again");
                        break;
                }
            }
        }

        public void MockAccounts()
        {
            transactionAmount = 0;
            listOfAccounts = new List<Accounts>
            {
                new Accounts()
                    { Forename = "Jish", Surname = "Clough", AccountNumber = 111111, Pin = 1111, Balance = 100.00m },
                new Accounts()
                    { Forename = "Bill", Surname = "Preston", AccountNumber = 222222, Pin = 2222, Balance = 200.00m },
                new Accounts()
                    { Forename = "Ted", Surname = "Logan", AccountNumber = 333333, Pin = 3333, Balance = 300.00m }
            };
        }

        public void CheckPin()
        {
            bool success = false;

            while (!success)
            {
                enterAccount = new Accounts();

                Console.WriteLine("Enter Account Number");
                enterAccount.AccountNumber = InputManager.ValidateInput("Account Number");

                Console.WriteLine("Enter PIN");
                enterAccount.Pin = Convert.ToInt32(InputManager.GetConsoleInput());

                foreach (Accounts account in listOfAccounts)
                {
                    if (enterAccount.AccountNumber.Equals(account.AccountNumber))
                    {
                        accountSelected = account;

                        if (enterAccount.Pin.Equals(account.Pin))
                        {
                            success = true;
                        }

                        else
                        {
                            success = false;
                            attempts++;

                            if (attempts >= maxAttempts)
                            {
                                // Leaves the potential to put a limit on attempts
                            }
                        }
                    }
                }

                if (!success)
                    InputManager.Output("The details entered are incorrect.");
                Console.Clear();
            }
        }

        public void Balance(Accounts bankAccount)
        {
            InputManager.Output($"The balance in the account is {InputManager.Amount(bankAccount.Balance)}");
        }

        public void Deposit(Accounts account)
        {
            Console.WriteLine("Enter deposit amount " + MenuManager.gbp);

            transactionAmount = InputManager.ValidateDecimal("amount");

            if (transactionAmount <= 0)
                InputManager.Output("Please try again with an amount larger than zero");
            else
            {
                var transaction = new Transactions()
                {
                    AccountTo = account.AccountNumber,
                    AccountFrom = account.AccountNumber,
                    TransactionType = Enums.TypeOfTransaction.Deposit,
                    TransactionAmount = transactionAmount,
                    TransactionDate = DateTime.Now
                };
                account.Balance = account.Balance + transactionAmount;
                InputManager.Output($"Deposit successful {InputManager.Amount(transactionAmount)}");
            }
        }

        public void Withdraw(Accounts account)
        {
            Console.WriteLine("Enter amount for withdrawal " + MenuManager.gbp);
            transactionAmount = InputManager.ValidateDecimal("amount");

            if (transactionAmount <= 0)
                InputManager.Output("Please try again with an amount larger than zero");
            else if (transactionAmount > account.Balance)
                InputManager.Output($"Failed to withdraw. Not enough funds {InputManager.Amount(transactionAmount)}");
            else
            {
                var transaction = new Transactions()
                {
                    AccountTo = account.AccountNumber,
                    AccountFrom = account.AccountNumber,
                    TransactionType = Enums.TypeOfTransaction.Withdraw,
                    TransactionAmount = transactionAmount,
                    TransactionDate = DateTime.Now
                };
                account.Balance = account.Balance - transactionAmount;
                InputManager.Output($"Withdraw successful {InputManager.Amount(transactionAmount)}");
            }
        }

        public void SendTransfer(Accounts account, Transfer balanceTransfer)
        {
            if (balanceTransfer.TransferAmount <= 0)
                InputManager.Output("Please try again with an amount larger than zero");
            else if (balanceTransfer.TransferAmount > account.Balance)
                InputManager.Output(
                    $"Please try again, you cannot transfer below your balance {InputManager.Amount(transactionAmount)}");
            else
            {
                var transferAccount = (from a in listOfAccounts
                    where a.AccountNumber == balanceTransfer.AccountReceiving
                                       select a).FirstOrDefault();
                if (transferAccount == null)
                    InputManager.Output($"Transfer failed. Receiving account invalid");
                else
                {
                    Transactions transaction = new Transactions()
                    {
                        AccountFrom = account.AccountNumber,
                        AccountTo = balanceTransfer.AccountReceiving,
                        TransactionType = Enums.TypeOfTransaction.Transfer,
                        TransactionAmount = transactionAmount,
                        TransactionDate = DateTime.Now
                    };
                    listOfTransactions.Add(transaction);
                    InputManager.Output(
                        $"Transfer successful of {InputManager.Amount(balanceTransfer.TransferAmount)} to {balanceTransfer.AccountReceiving}");
                    account.Balance = account.Balance - balanceTransfer.TransferAmount;
                    transferAccount.Balance = transferAccount.Balance + balanceTransfer.TransferAmount;
                }
            }
        }
    }
}
