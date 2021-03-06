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
        }
        protected NPC test1;
        protected NPC test2;

        public void Builder(){
            var director = new Director();
            var desertBuilder = new DesertBuilder(2, 3);
            director.Builder = desertBuilder;
            director.BuildArea();
            // Template - a forest-builder using the default AddNPCs() implementation
            //            and a template builder.
            var forestBuilder = new ForestBuilder(4, 3);
            director.Builder = forestBuilder;
            director.BuildArea();
            var defaultBuilder = new Builder(1, 3);
            director.Builder = defaultBuilder;
            director.BuildArea();
        }

        public void Visitor() {
            List<Area> components = new List<Area>
            {
                World.Instance.GetArea(2, 3), // Forest area.
                World.Instance.GetArea(1, 3)  // Randomly generated area.
            };

            var areaEventVisitor = new AreaEventVisitor();
            var obstacleRemovalVisitor = new ObstacleRemovalVisitor();
            var npcRemovalVisitor = new NPCRemovalVisitor();
            Console.WriteLine("-------------Visitor--------------");
            foreach (var component in components)
            {
                component.Accept(areaEventVisitor);
                component.Accept(obstacleRemovalVisitor);
                component.Accept(npcRemovalVisitor);
            }
        }

        public void Factory(){
            NpcCreator npcCreator = new NpcCreator();
            NPC friendly = npcCreator.FactoryMethod(NpcType.Friendly, "", $"{3},{3}");
            NPC enemy = npcCreator.FactoryMethod(NpcType.Enemy, "", $"{2},{3}");
            friendly.SetMoveAlgorithm(new Stand());
            enemy.SetMoveAlgorithm(new Walk());
            friendly.SetAttackAlgorithm(new Melee(friendly.AreaId, 0, 0));
            enemy.SetAttackAlgorithm(new Melee(enemy.AreaId, 10, 50));
            World.Instance.AddNPC(friendly);
            World.Instance.AddNPC(enemy);
        }

        public void Prototype(){
            List<NPC> asd = World.Instance.GetNPCs(2, 3);
            Console.WriteLine("Prototype real time");
            Console.WriteLine("Before change:");
            Console.WriteLine("name: " + asd[0].name + ", Position x: " + asd[0].Position.X + ", Position y: " + asd[0].Position.Y);
            Character a = (Character)asd[0];
            a.Position.X = 400;
            a.Position.Y = 400;
            Console.WriteLine("After change: ");
            Console.WriteLine("name: " + a.name + ", Position x: " + a.Position.X + ", Position y: " + a.Position.Y);
            World.Instance.UpdateNPC((NPC)a);
            List<NPC> acc = World.Instance.GetNPCs(2, 3);
            Console.WriteLine("Test if change worked: ");
            Console.WriteLine("name: " +acc[0].name + ", Position x: " + acc[0].Position.X + ", Position y: " + acc[0].Position.Y);
        }
        public void testState(){
            NpcCreator npcCreator = new NpcCreator();
            NPC enemy = npcCreator.FactoryMethod(NpcType.Enemy, "", $"{2},{3}");

            enemy.StateChange();
            enemy.StateChange();
            enemy.StateChange();
            enemy.StateChange();
            enemy.StateChange();
            enemy.StateChange();
            enemy.StateChange();
        }
        public void UndoPrototype(){
            //List<NPC> asd = World.Instance.GetNPCs(2, 3);
            //Character a = (Character)asd[2].ShallowCopy();
            //a.SetMoveAlgorithm(new Walk());
        }

        public void CheckInventory(Player ps){
            Console.WriteLine("Mano inventorius: ");
            SpearAttackDecorator s = new SpearAttackDecorator(ps);
            HelmetDecorator s1 = new HelmetDecorator(s);
            BodyArmorDecorator s2 = new BodyArmorDecorator(s1);
            LegArmorDecorator s3 = new LegArmorDecorator(s2);
            s3.Equip();     
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
            Console.WriteLine("Pgr pries keitimus:" + test2.name + ", " + test2.areaId + ", " + test2.Position.X+ ", " +test2.Position.Y+ ", " + test2.GetMoveAlgorithm() + ", " + test2.GetHashCode());

            NPC nig = (NPC)test2.ShallowCopy();
            nig.name = "bebras";
            nig.Position.X = 150;
            nig.Position.Y = 101;
            Console.WriteLine("Pgr po shallow keitimo:" + test2.name + ", " + test2.areaId + ", " + test2.Position.X+ ", " +test2.Position.Y + ", " + test2.GetMoveAlgorithm()+ ", " + test2.GetHashCode());
            Console.WriteLine("Shallow kopijavimas:" + nig.name + ", " + nig.areaId + ", " + nig.Position.X+ ", " +nig.Position.Y+ ", " + nig.GetMoveAlgorithm()+ ", " + nig.GetHashCode());


            NPC asd = (NPC)test2.DeepCopy();
            asd.name = "arabas";
            asd.Position.X = 200;
            asd.Position.Y = 300;
            Console.WriteLine("Pgr po shallow keitimo, po to po deep keitimo:" +test2.name + ", " + test2.areaId + ", " + test2.Position.X+ ", " +test2.Position.Y+ ", " + test2.GetMoveAlgorithm()+ ", " + test2.GetHashCode());
            Console.WriteLine("Deep kopijavimas:" + asd.name + ", " + asd.areaId + ", " + asd.Position.X+ ", " +asd.Position.Y+ ", " + asd.GetMoveAlgorithm()+ ", " + asd.GetHashCode());
        }
        public void TestStrategy(){
            test2.SetMoveAlgorithm(new Stand());
            test1.SetMoveAlgorithm(new Walk());
            Console.WriteLine("-------------Strategy test--------------");
            Console.WriteLine("Test1: " + test1.GetMoveAlgorithm());
            Console.WriteLine("Test2: " + test2.GetMoveAlgorithm());
        }
        public void TestDecorator(){
            SpearAttackDecorator s = new SpearAttackDecorator(test1);
            SwordAttackDecorator ss = new SwordAttackDecorator(s);
            Console.WriteLine("-------------Decorator test--------------");
            Console.WriteLine("Decorated test1: ");
            ss.Attack();
        }

        public void TestAdapter()
        {
            
            Console.WriteLine("-------------Adapter test--------------");
            Console.WriteLine("Adapter test1: ");

            ISaveFileAdapter xmlAdapter = new XMLAdapter(new XMLWritter());
            ISaveFileAdapter txtAdapter = new TXTAdapter(new TXTWritter());

            List<Player> players = new List<Player>()
            {
                new Player(0, 0, 0, 0, 0, 0, 0, 0, false, null, 0, 0, null),
                new Player(1, 1, 1, 1, 1, 1, 1, 1, true, "test", 1, 1, "test"),
                new Player(2, 2, 2, 2, 2, 2, 2, 2, true, "test", 1, 1, "test"),
            };

            txtAdapter.Save(players);
            xmlAdapter.Save(players);

            List<string> data1 = xmlAdapter.Read();
            List<string> data2 = txtAdapter.Read();

            foreach(string p1 in data1)
            {
                Console.WriteLine("XML DATA: " + p1);
            }

            foreach(string p2 in data2)
            {
                Console.WriteLine("TXT DATA: " + p2);
            }

        }
    }
}