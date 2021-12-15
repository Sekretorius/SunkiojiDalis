using System;

namespace SignalRWebPack
{
    public interface Handler
    {
        public void SetNext(Handler handler);

        public void Handle(string text);
    }
}