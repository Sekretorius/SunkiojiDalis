using SignalRWebPack.Characters;
using System;

namespace SignalRWebPack.Managers {
  static class RandomNPC {
    public static (NPC, NpcType) GenerateNPC(int x, int y) {
      var npcCreator = new NpcCreator();
      var rand = new Random();
      var NPCTypeIndex = rand.Next(3);
      int NPCSubtypeIndex = rand.Next(2);
      NpcType NPCType;
      string NPCSubtype;
      switch(NPCTypeIndex) {
        case 0: {
          NPCType = NpcType.Friendly;
          break; 
        }
        case 1: {
          NPCType = NpcType.Enemy;
          break;
        }
        default: {
          NPCType = NpcType.Animal;
          break;
        }
      }
      if(NPCType == NpcType.Enemy) {
        if(NPCSubtypeIndex == 0) {
          NPCSubtype = "fast_enemy";
        } else {
          NPCSubtype = "slow_enemy";
        }
      } else {
        NPCSubtype = "";
      }
      var npc = npcCreator.FactoryMethod(NPCType, NPCSubtype, $"{x},{y}");
      return (npc, NPCType);
    }

    public static NPC AssignRandomAlgorithms(NPC npc, NpcType type) {
      var rand = new Random();
      var moveAlgorithmIndex = rand.Next(2);
      switch(moveAlgorithmIndex) {
        case 0: {
          npc.SetMoveAlgorithm(new Stand());
          break; 
        }
        case 1: {
          npc.SetMoveAlgorithm(new Walk());
          break;
        }
        default: {
          npc.SetMoveAlgorithm(new MixedMove(rand.Next(20, 31)));
          break;
        }
      }
      if(type == NpcType.Enemy) {
        var attackAlgorithmIndex = rand.Next(2);
        switch(moveAlgorithmIndex) {
          case 0: {
            npc.SetAttackAlgorithm(new Melee(npc.AreaId, (float)rand.Next(5, 15), (float)rand.Next(10, 15)));
            break; 
          }
          case 1: {
            npc.SetAttackAlgorithm(new Ranged(npc.AreaId, (float)rand.Next(5, 15), (float)rand.Next(5, 15), (float)rand.Next(80, 101)));
            break;
          }
          default: {
            npc.SetAttackAlgorithm(new Mixed(npc.AreaId, (float)rand.Next(5, 15)));
            break;
          }
        }
      }
      return npc;
    }
  }
}

