using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsASD.Utils;
using DesignPatternsASD.Observer;
using DesignPatternsASD.DomainClasses.EventsOfNotification;

namespace DesignPatternsASD.DomainClasses
{
    class AccountSavings : Account
    {
        public AccountSavings(string accountNumber) : base(accountNumber)
        {
            this.setAccountNumber(accountNumber);
            this.setInterestType(new InterestCalcBy5000(this));

            Logger log = new Logger(this);
            SMSSender sms = new SMSSender(this);
            EmailSender email = new EmailSender(this);

            String oldValue = accountNumber;
            //this.setChanged();
            this.NotifyObservers(new ChangedSender("created", oldValue, ""));
        }
    }
}
