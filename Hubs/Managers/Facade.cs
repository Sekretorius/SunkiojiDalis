using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SignalRWebPack.Characters;
using SignalRWebPack.Managers;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Hubs;
using SignalRWebPack.Network;
using System.Diagnostics;

namespace SignalRWebPack.Facades
{
    public class Facade
    {
        public Facade(){
            Console.WriteLine("Facade started");
        }
        protected NPC test1;
        protected NPC test2;

        public void Builder(){
            var director = new Director();
            var builder = new DesertBuilder(2, 3);
            director.Builder = builder;
            director.BuildArea();
            var desert = builder.GetProduct();
            World.Instance.SwapArea(desert);
        }
        public void Factory(){
            NpcCreator npcCreator = new NpcCreator();
            NPC friendly = npcCreator.FactoryMethod(NpcType.Friendly, "", $"{3},{3}");
            NPC enemy = npcCreator.FactoryMethod(NpcType.Enemy, "", $"{2},{3}");
            friendly.SetMoveAlgorithm(new Stand());
            enemy.SetMoveAlgorithm(new Walk());
            friendly.SetAttackAlgorithm(new Melee(0));
            enemy.SetAttackAlgorithm(new Melee(50));
            World.Instance.AddNPC(friendly);
            World.Instance.AddNPC(enemy);
        }

        public void CreateTestUnits(){
            Console.WriteLine("---------------Factory--------------");
            test1 = new FriendlyNpc("Testavimas1", areaId: $"{2},{3}", position: new Vector2D(50, 50), width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 30);
            Console.WriteLine(test1.name + ", " + test1.AreaId);
            test2 = new EnemyNpc("Testavimas2", areaId: $"{2},{3}", position: new Vector2D(50, 50), width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 30);
            Console.WriteLine(test2.name + ", " + test2.AreaId);
        }
        public void TestPrototype()
        {
            Console.WriteLine("-------------Prototype test--------------");
            Console.WriteLine("Pgr pries keitimus:" + test2.name + ", " + test2.areaId + ", " + test2.Position.X+ ", " +test2.Position.Y+ ", " + test2.MoveAlgorithm+ ", " + test2.GetHashCode());

            NPC nig = (NPC)test2.ShallowCopy();
            nig.name = "bebras";
            nig.Position.X = 150;
            nig.Position.Y = 101;
            Console.WriteLine("Pgr po shallow keitimo:" + test2.name + ", " + test2.areaId + ", " + test2.Position.X+ ", " +test2.Position.Y + ", " + test2.MoveAlgorithm+ ", " + test2.GetHashCode());
            Console.WriteLine("Shallow kopijavimas:" + nig.name + ", " + nig.areaId + ", " + nig.Position.X+ ", " +nig.Position.Y+ ", " + nig.MoveAlgorithm+ ", " + nig.GetHashCode());


            NPC asd = (NPC)test2.DeepCopy();
            asd.name = "arabas";
            asd.Position.X = 200;
            asd.Position.Y = 300;
            Console.WriteLine("Pgr po shallow keitimo, po to po deep keitimo:" +test2.name + ", " + test2.areaId + ", " + test2.Position.X+ ", " +test2.Position.Y+ ", " + test2.MoveAlgorithm+ ", " + test2.GetHashCode());
            Console.WriteLine("Deep kopijavimas:" + asd.name + ", " + asd.areaId + ", " + asd.Position.X+ ", " +asd.Position.Y+ ", " + asd.MoveAlgorithm+ ", " + asd.GetHashCode());
        }
        public void TestStrategy(){
            test2.SetMoveAlgorithm(new Stand());
            test1.SetMoveAlgorithm(new Walk());
            Console.WriteLine("-------------Strategy test--------------");
            Console.WriteLine("Test1: " + test1.MoveAlgorithm);
            Console.WriteLine("Test2: " + test2.MoveAlgorithm);
        }
        public void TestDecorator(){
            SpearAttackDecorator s = new SpearAttackDecorator(test1);
            SwordAttackDecorator ss = new SwordAttackDecorator(s);
            Console.WriteLine("-------------Decorator test--------------");
            Console.WriteLine("Decorated test1: ");
            ss.Attack();
        }
    }
}