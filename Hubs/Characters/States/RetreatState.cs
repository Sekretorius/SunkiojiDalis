using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRWebPack.Characters;

namespace SignalRWebPack.States
{
    public class RetreatState : State
    {
        public void Handle(NPC npc){
            Console.WriteLine("Im retreating");
        }
    }
}