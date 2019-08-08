using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AccountsServiceLibrary
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        Account GetAccount(int accountNumber);

        [OperationContract]
        bool Deposit(decimal amount, int accountNumber);

        [OperationContract]
        bool Withdraw(decimal amount, int accountNumber);
    }
}
