using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRWebPack.Characters;

namespace SignalRWebPack.States
{
    public class IdleState : State
    {
        public void Handle(NPC npc){
            npc.SetMoveAlgorithm(new Stand());
            npc.health = 200;
        }
    }
}