using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsASD.Observer;

namespace DesignPatternsASD.DomainClasses.EventsOfNotification
{
    class EmailSender : IObserver
    {
        public EmailSender(IObservable pObservable)
        {
            pObservable.Register(this);
        }

        public void Notify(IObservable o, object arg)
        {
            String output = "";
            if (arg is ChangedSender)
            {
                if (((ChangedSender)arg).changedAttribute.Equals("created"))
                {
                    output = "   Account created. AccountNumber is '" + ((ChangedSender)arg).oldValue + "'";
                    // output = ((Account) arg).changedAttribute + " changed from '" + ((Account)
                    // arg).oldValue + "' to '"
                    // + ((Account) arg).newValue + "'";
                    sendEmail(output);
                }
            }

        }

        private void sendEmail(String pContent)
        {
            Console.WriteLine("Email sent: ");
            Console.WriteLine(pContent);
        }
    }
}
