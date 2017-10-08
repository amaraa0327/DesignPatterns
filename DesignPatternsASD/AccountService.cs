using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DesignPatternsASD.DomainClasses;

namespace DesignPatternsASD
{
    interface AccountService
    {
        Account createAccount(String accountNumber, String customerName, AccountType acctType);
        Account getAccount(String accountNumber);
        Collection<Account> getAllAccounts();
        void deposit(String accountNumber, double amount);
        void addInterest(String accountNumber);
        void withdraw(String accountNumber, double amount);
        void transferFunds(String fromAccountNumber, String toAccountNumber, double amount, String description);
    }
}
