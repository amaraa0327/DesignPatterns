using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DesignPatternsASD.DomainClasses;

namespace DesignPatternsASD.DataAccess
{
    class AccountDAOImpl : AccountDAO
    {
        Collection<Account> accountlist = new Collection<Account>();

        public void saveAccount(Account account)
        {
            accountlist.Add(account); // add the new
        }

        public void updateAccount(Account account)
        {
            Account accountexist = loadAccount(account.getAccountNumber());
            if (accountexist != null)
            {
                accountlist.Remove(accountexist); // remove the old
                accountlist.Add(account); // add the new
            }

        }

        public Account loadAccount(String accountNumber)
        {
            foreach (Account account in accountlist)
            {
                if (account.getAccountNumber() == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public Collection<Account> getAccounts()
        {
            return accountlist;
        }
    }
}
