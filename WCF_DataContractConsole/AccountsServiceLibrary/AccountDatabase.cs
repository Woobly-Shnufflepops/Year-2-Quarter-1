using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsServiceLibrary
{
    public static class AccountDatabase
    {
        internal static List<Account> accounts = new List<Account>() { 
                                                       
                    new Account{AccountNumber=1234567, Balance=1200, Bank="Bank of America"},
                    new Account{AccountNumber=2345678, Balance=9870.95m, Bank="Chase Bank"},
                    new Account{AccountNumber=1245987, Balance=5872.47m, Bank="Columbia Bank"},
                    new Account{AccountNumber=2473644, Balance=3624.87m, Bank="HomeStreet Bank"},
                    new Account{AccountNumber=3214578, Balance=984.49m, Bank="Credit Union Bank"}
                     };

       
    }
}
