using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsASD.DomainClasses;
using DesignPatternsASD.DataAccess.FactoryOfConnection;

namespace DesignPatternsASD
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountService accountService = new AccountServiceImpl(new FactoryRealDAO());//new FactoryMockDAO()

            // create 2 accounts;
            accountService.createAccount("1263862", "Frank Brown", AccountType.Checkings);
            accountService.createAccount("4253892", "John Doe", AccountType.Savings);
            // use account 1;
            accountService.deposit("1263862", 240);
            accountService.deposit("1263862", 529);
            accountService.withdraw("1263862", 230);
            // use account 2;
            accountService.deposit("4253892", 12450);
            accountService.transferFunds("4253892", "1263862", 100, "payment of invoice 10232");

            accountService.addInterest("1263862");
            accountService.addInterest("4253892");
            // show balances

            foreach (Account account in accountService.getAllAccounts())
            {
                Customer customer = account.getCustomer();
                Console.WriteLine("Statement for Account: " + account.getAccountNumber());
                Console.WriteLine("Account Holder: " + customer.getName());

                Console.WriteLine("-Date-------------------------"
                        + "-Description------------------"
                        + "-Amount-------------");

                foreach (AccountEntry entry in account.getAccountEntryList())
                {
                    Console.WriteLine(String.Format("{0, 30}{1, 30}{2, 20:F2}", entry.getDate().ToString(),
                            entry.getDescription(),
                            entry.getAmount()));
                }

                Console.WriteLine("----------------------------------------" + "----------------------------------------");
                Console.WriteLine(String.Format("{0, 30}{1, 30}{2, 20:F2}", " ", "Current Balance:", account.getBalance()));
                Console.ReadLine();
            }
        }
    }
}
