using System;

namespace SignalRWebPack
{
    public abstract class BaseHandler : Handler
    {
        protected Handler next;

        public BaseHandler() { }

        public abstract void Handle(string text);

        public void SetNext(Handler handler)
        {
            next = handler;
        }
    }
}