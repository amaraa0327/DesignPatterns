using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DesignPatternsASD.Observer
{
    class ObservableImpl : IObservable
    {
        //container to store the observer instance (is not synchronized for this example)
        protected Hashtable _observerContainer = new Hashtable();

        public void Register(IObserver anObserver)
        {
            _observerContainer.Add(anObserver, anObserver);
        }

        public void UnRegister(IObserver anObserver)
        {
            _observerContainer.Remove(anObserver);
        }

        public void NotifyObservers(object anObject)
        {
            foreach (IObserver anObserver in _observerContainer.Keys)
            {
                anObserver.Notify(this, anObject);
            }
        }
    }
}
