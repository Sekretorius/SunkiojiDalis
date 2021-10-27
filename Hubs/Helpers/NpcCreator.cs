using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Characters;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack.Managers
{
    public class NpcCreator : Creator<NPC, NpcType>
    {
        public NPC FactoryMethod(NpcType npcType, string subtype, string area)
        {
            switch (npcType)
            {
                case NpcType.Friendly:
                    return new FriendlyNpc("Friendly", areaId: area, position: new Vector2D(50, 50), width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 30);
                case NpcType.Enemy:
                    if(subtype == "lion") {
                        return new EnemyNpc("Lion", areaId: area, position: new Vector2D(150, 100), width: 48, height: 48, sprite: "resources/characters/lion.png", speed: 50);
                    }
                    return new EnemyNpc("Enemy", areaId: area, position: new Vector2D(100, 100), width: 32, height: 48, sprite: "resources/characters/player-blue.png", speed: 30);
                default:
                    return null;
            }
        }
    }
}