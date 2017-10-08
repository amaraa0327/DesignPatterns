using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DesignPatternsASD.DomainClasses;

namespace DesignPatternsASD.DataAccess
{
    interface AccountDAO
    {
        void saveAccount(Account account);
        void updateAccount(Account account);
        Account loadAccount(String accountnumber);
        Collection<Account> getAccounts();
    }
}
