using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsASD.Observer;


namespace DesignPatternsASD.DomainClasses.EventsOfNotification
{
    class Logger : IObserver
    {
        public Logger(IObservable pObservable)
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
                }
                else
                {
                    output = "   " + ((ChangedSender)arg).changedAttribute + " attribute changed from '"
                            + ((ChangedSender)arg).oldValue + "' to '" + ((ChangedSender)arg).newValue + "'. AccountNumber = '"
                            + ((Account)o).getAccountNumber() + "'";
                }
                writeLogger(output);
            }
        }

        private void writeLogger(String pContent)
        {
            Console.WriteLine("Wrote Log:");
            Console.WriteLine(pContent);
        }
    }
}
