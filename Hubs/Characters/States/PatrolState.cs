using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRWebPack.Characters;

namespace SignalRWebPack.States
{
    public class PatrolState : State
    {
        public void Handle(NPC npc){
            npc.SetMoveAlgorithm(new Walk());
        }
    }
}