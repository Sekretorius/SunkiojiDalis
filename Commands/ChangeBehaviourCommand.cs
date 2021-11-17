
using SignalRWebPack.Hubs;
using SignalRWebPack.Facades;

namespace SignalRWebPack
{
    public class ChangeBehaviourCommand : ICommand
    {
        private int frame;
        private Player player;

        private Facade servas;

        public ChangeBehaviourCommand(Player player)
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