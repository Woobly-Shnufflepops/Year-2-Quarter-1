using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AccountsServiceLibrary
{
    public class AccountsService : IAccountService
    {
        public bool Deposit(decimal amount, int accountNumber)
        {
            //Get account with the given accountNumber
            Account account = AccountDatabase.accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null) return false;
            else
            {
                account.Balance += amount;
                return true;
            }
        }

        public bool Withdraw(decimal amount, int accountNumber)
        {
            //Get account with the given accountNumber
            Account account = AccountDatabase.accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null) return false;
            else
            {
                if (account.Balance >= amount)
                {
                    account.Balance -= amount;
                    return true;
                }
                else return false;
            }
        }
        public Account GetAccount(int accountNumber)
        {
            //Get the account with the specified accountNumber
            Account account = AccountDatabase.accounts.Find(a => a.AccountNumber == accountNumber);
            return account;
        }
    }
}
