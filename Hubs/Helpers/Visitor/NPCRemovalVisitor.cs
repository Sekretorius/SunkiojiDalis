using System;
using System.Collections.Generic;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Characters;

namespace SignalRWebPack.Managers
{
    class NPCRemovalVisitor : IVisitor
    {
        public void VisitDesertArea(DesertArea element)
        {
            var npcs = World.Instance.GetNPCs(element.x, element.y);
            var badNPCs = new List<NPC>();
            foreach(var npc in npcs) {
                if(npc.name.Contains("Friendly")) {
                    badNPCs.Add(npc);
                }
            }
            foreach(var npc in badNPCs) {
                World.Instance.RemoveNPC(npc);
                Console.WriteLine("Removed friendly NPC from the desert!");
            }
        }

        public void VisitForestArea(ForestArea element)
        {
            var npcs = World.Instance.GetNPCs(element.x, element.y);
            var badNPCs = new List<NPC>();
            foreach(var npc in npcs) {
                if(npc.name.Contains("animal")) {
                    badNPCs.Add(npc);
                }
            }
            
            foreach(var npc in badNPCs) {
                World.Instance.RemoveNPC(npc);
                Console.WriteLine("Removed lion from the forest!");
            }
        }
    }
}