
using SignalRWebPack.Hubs;
using SignalRWebPack.Facades;

namespace SignalRWebPack
{
    public class ChekInvCommand : ICommand
    {
        private int frame;
        private Player player;
        private Facade servas;

        public ChekInvCommand(Player player)
        {
            this.player = player;
            frame = player.frameY;
            servas = new Facade();
        }

        public void Execute()
        {
            servas.CheckInventory(this.player);
            
        }

        public void Undo()
        {
        }
    }
}