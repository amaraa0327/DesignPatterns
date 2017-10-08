using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsASD.Utils;
using DesignPatternsASD.Observer;

namespace DesignPatternsASD.DomainClasses
{
    enum AccountType { Savings, Checkings };
    abstract class Account : ObservableImpl
    {
        private Customer customer;
        private string accountNumber;
        private InterestType interestType;

        private List<AccountEntry> entryList = new List<AccountEntry>();

        public Account(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        public InterestType getInterestType()
        {
            return interestType;
        }

        public void setInterestType(InterestType interestType)
        {
            this.interestType = interestType;
        }
        public double calcInterest()
        {
            return this.getBalance() * this.getInterestType().getRateInterest() / 100;
        }
        public void interest()
        {
            String oldValue = this.getBalance().ToString();

            AccountEntry entry = new AccountEntry(this.calcInterest(), "interest", "", "");
            entryList.Add(entry);

            String newValue = this.getBalance().ToString();
            //this.setChanged();
            this.NotifyObservers(new ChangedSender("Balance", oldValue, newValue));
        }

        public void withdraw(double amount)
        {
            String oldValue = this.getBalance().ToString();

            AccountEntry entry = new AccountEntry(-amount, "withdraw", "", "");
            entryList.Add(entry);

            String newValue = this.getBalance().ToString();
            //this.setChanged();
            this.NotifyObservers(new ChangedSender("Balance", oldValue, newValue));
        }

        private void addEntry(AccountEntry entry)
        {
            entryList.Add(entry);
        }

        public void transferFunds(Account toAccount, double amount, String description)
        {
            String oldValue = this.getBalance().ToString();

            AccountEntry fromEntry = new AccountEntry(-amount, description, toAccount.getAccountNumber(),
                    toAccount.getCustomer().getName());
            AccountEntry toEntry = new AccountEntry(amount, description, toAccount.getAccountNumber(),
                    toAccount.getCustomer().getName());

            entryList.Add(fromEntry);

            toAccount.addEntry(toEntry);

            String newValue = this.getBalance().ToString();
            //this.setChanged();
            this.NotifyObservers(new ChangedSender("Balance", oldValue, newValue));
        }

        public void deposit(double amount)
        {
            String oldValue = this.getBalance().ToString();

            AccountEntry entry = new AccountEntry(amount, "deposit", "", "");
            entryList.Add(entry);

            String newValue = this.getBalance().ToString();
            //this.setChanged();
            this.NotifyObservers(new ChangedSender("Balance", oldValue, newValue));
        }

        public double getBalance()
        {
            double balance = 0;
            foreach (AccountEntry entry in entryList)
            {
                balance += entry.getAmount();
            }
            return balance;
        }

        #region [getter setter]
        public Customer getCustomer()
        {
            return this.customer;
        }

        public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }

        public string getAccountNumber()
        {
            return this.accountNumber;
        }

        public void setAccountNumber(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        public List<AccountEntry> getAccountEntryList()
        {
            return this.entryList;
        }
        #endregion
    }
}
