using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyche.DDD.Application
{
    public class Subscription<T> : IDisposable
    {
        private readonly IObservable<T> observable;
        private readonly IObserver<T> observer;
        private readonly List<IObserver<T>> observers;
        public bool IsExpired { get; private set; }
        public Subscription(IObservable<T> observable, IObserver<T> observer, List<IObserver<T>> observerList)
        {
            this.observable = observable;
            this.observer = observer;
            observers = observerList;
            IsExpired = false;
        }

        public void Dispose()
        {
            if (observer != null && observers.Contains(observer))
                observers.Remove(observer);
        }

        public void CloseSubscription()
        {
            IsExpired = true;
            observer.OnCompleted();
            Dispose();
        }
    }
}
