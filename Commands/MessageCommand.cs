using SignalRWebPack.Hubs;
using SignalRWebPack.Hubs.Worlds;

namespace SignalRWebPack
{
    public class MessageCommand : ICommand
    {
        private Message message;
        public MessageCommand(Message message)
        {
            this.message = message;
        }

        public void Execute()
        {
            World.Instance.Messages.Add(message);
            World.Instance.NotifyAll();
        }

        public void Undo()
        {
            World.Instance.Messages.Remove(message);
            World.Instance.NotifyAll();
            message = null;
        }
    }
}