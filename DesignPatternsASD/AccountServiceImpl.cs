using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DesignPatternsASD.DomainClasses;
using DesignPatternsASD.DataAccess;
using DesignPatternsASD.DataAccess.FactoryOfConnection;

namespace DesignPatternsASD
{
    class AccountServiceImpl : AccountService
    {
        private AccountDAO accountDAO;

        public AccountServiceImpl(DAOFactory factory) //
        {
            accountDAO = factory.createDAO();//
        }

        public Account createAccount(String accountNumber, String customerName, AccountType acctType)
        {
            Account account;
            if (acctType.Equals(AccountType.Savings))
            {
                account = new AccountSavings(accountNumber);
            }
            else
            {
                account = new AccountCheckings(accountNumber);
            }

            Customer customer = new Customer(customerName);
            account.setCustomer(customer);

            accountDAO.saveAccount(account);

            return account;
        }

        public void deposit(String accountNumber, double amount)
        {
            Account account = accountDAO.loadAccount(accountNumber);
            account.deposit(amount);

            accountDAO.updateAccount(account);
        }

        public Account getAccount(String accountNumber)
        {
            Account account = accountDAO.loadAccount(accountNumber);
            return account;
        }

        public Collection<Account> getAllAccounts()
        {
            return accountDAO.getAccounts();
        }

        public void withdraw(String accountNumber, double amount)
        {
            Account account = accountDAO.loadAccount(accountNumber);
            account.withdraw(amount);
            accountDAO.updateAccount(account);
        }

        public void transferFunds(String fromAccountNumber, String toAccountNumber, double amount, String description)
        {
            Account fromAccount = accountDAO.loadAccount(fromAccountNumber);
            Account toAccount = accountDAO.loadAccount(toAccountNumber);
            fromAccount.transferFunds(toAccount, amount, description);
            accountDAO.updateAccount(fromAccount);
            accountDAO.updateAccount(toAccount);
        }
        public void addInterest(String accountNumber)
        {
            Account account = accountDAO.loadAccount(accountNumber);
            account.interest();

            accountDAO.updateAccount(account);
        }
    }
}
