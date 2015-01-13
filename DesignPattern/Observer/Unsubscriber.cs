using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// When the class is instantiated in the BaggageHandler.Subscribe method, 
    /// it is passed a reference to the observers collection and a reference to the observer that is added to the collection. 
    /// These references are assigned to local variables. 
    /// When the object's Dispose method is called, 
    /// it checks whether the observer still exists in the observers collection, and, if it does, removes the observer.
    /// </summary>
    /// <typeparam name="BaggageInfo"></typeparam>
    class Unsubscriber<BaggageInfo> : IDisposable
    {
        List<IObserver<BaggageInfo>> _observers;
        IObserver<BaggageInfo> _observer;

        internal Unsubscriber(List<IObserver<BaggageInfo>> observers,IObserver<BaggageInfo> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
