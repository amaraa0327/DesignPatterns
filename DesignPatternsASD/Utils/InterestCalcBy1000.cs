using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsASD.DomainClasses;

namespace DesignPatternsASD.Utils
{
    class InterestCalcBy1000 : InterestType
    {
        private Account account;

        public InterestCalcBy1000(Account pAccount)
        {
            account = pAccount;
        }

        public float getRateInterest()
        {
            if (account.getBalance() < 1000)
            {
                return (float)1.5;
            }
            else
            {
                return (float)2.5;
            }
        }
    }
}
