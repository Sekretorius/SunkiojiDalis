using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRWebPack.Characters;

namespace SignalRWebPack.States
{
    public class AttackState : State
    {
        public void Handle(NPC npc){
            npc.health -=10;
        }
    }
}