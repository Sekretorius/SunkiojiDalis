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

                    Random random = new Random();
                    if(subtype == "fast_enemy"){
                         return new EnemyNpc("fast_enemy", areaId: area, position: new Vector2D(random.Next(50, 750), random.Next(50, 450)), width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 60);
                    }

                    if(subtype == "slow_enemy"){
                         return new EnemyNpc("slow_enemy", areaId: area, position: new Vector2D(random.Next(50, 750), random.Next(50, 450)), width: 32, height: 48, sprite: "resources/characters/player-brown.png", speed: 15);
                    }

                    return new EnemyNpc("normal_enemy", areaId: area, position: new Vector2D(random.Next(50, 750), random.Next(50, 450)), width: 32, height: 48, sprite: "resources/characters/player-blue.png", speed: 30);
                   
                default:
                    return null;
            }
        }
    }
}