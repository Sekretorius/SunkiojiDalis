using System.Collections.Generic;

namespace SignalRWebPack
{
    public class Subject
    {
        private List<IObserver> observers = new List<IObserver>();
        private ListIterator<IObserver> iteratedObservers;
        private string msg;

        public Subject()
        {
            iteratedObservers = new ListIterator<IObserver>(observers);
        }
        public void Attatch(IObserver observer) 
        {
            observers.Add(observer);
        }
        public void Deattach(IObserver observer) 
        {
            observers.Remove(observer);
        }
        public void NotifyAll() 
        {
            while(iteratedObservers.Current() != null)
            {
                iteratedObservers.Current().Update();
                iteratedObservers.Next();
            }
            iteratedObservers.Reset();
        }
        public virtual void ReceiveFromClient(string msg) 
        {
            this.msg = msg;
            NotifyAll();
        }
    }
}
