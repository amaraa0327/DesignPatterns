using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsASD.DomainClasses;

namespace DesignPatternsASD.Utils
{
    class InterestCalcBy5000 : InterestType
    {
        private Account account;

        public InterestCalcBy5000(Account pAccount)
        {
            account = pAccount;
        }
        public float getRateInterest()
        {
            if (account.getBalance() < 1000)
            {
                return 1;
            }
            else if (account.getBalance() > 1000 && account.getBalance() < 5000)
            {
                return 2;
            }
            else
            {
                return 4;
            }
        }
    }
}
