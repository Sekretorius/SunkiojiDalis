
using SignalRWebPack.Hubs;
using SignalRWebPack.Facades;

namespace SignalRWebPack
{
    public class ChangeNPCCommand : ICommand
    {
        private int frame;
        private Player player;

        private Facade servas;

        public ChangeNPCCommand(Player player)
        {
            this.player = player;
            frame = player.frameY;
            servas = new Facade();
        }

        public void Execute()
        {
            servas.Prototype();
        }

        public void Undo()
        {
            servas.UndoPrototype();
        }
    }
}