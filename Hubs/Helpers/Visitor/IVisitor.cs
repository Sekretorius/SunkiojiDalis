using System.Collections.Generic;
using SignalRWebPack.Hubs.Worlds;

namespace SignalRWebPack.Managers
{

    public interface IVisitor
    {
        void VisitForestArea(ForestArea element);

        void VisitDesertArea(DesertArea element);
    }
}