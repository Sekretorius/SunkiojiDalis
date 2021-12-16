using System;
using SignalRWebPack.Hubs.Worlds;

namespace SignalRWebPack.Managers
{
    class AreaEventVisitor : IVisitor
    {
        public void VisitDesertArea(DesertArea element)
        {
            Console.WriteLine("A sandstorm has hit area (" + element.x + ", " + element.y + "). All players have taken " + element.CreateSandstorm() + " damage!");
        }

        public void VisitForestArea(ForestArea element)
        {
            Console.WriteLine("A forest fire has hit area (" + element.x + ", " + element.y + "). All players have taken " + element.CreateFire() + " damage!");
        }
    }
}