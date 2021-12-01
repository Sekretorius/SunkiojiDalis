using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Managers;
using SignalRWebPack.Characters;
using SignalRWebPack.Hubs;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack {
  public class DesertBuilder : Builder {
        private int x;
        private int y;
        private DesertArea desert;
        
        public DesertBuilder(int x, int y): base(x, y)
        {
            this.desert = new DesertArea(x, y);
            this.x = x;
            this.y = y;
            this.Reset();
        }
        
        public override void Reset()
        {
            this.desert = new DesertArea(this.x, this.y);
        }
        
        public override void AddNPCs()
        {
            var npcCreator = new NpcCreator();
            var enemy = npcCreator.FactoryMethod(NpcType.Animal, null, $"{x},{y}");

            var randomEnemy_1 = npcCreator.FactoryMethod(NpcType.Enemy, "slow_enemy", $"{x},{y}");
            var randomEnemy_2 = npcCreator.FactoryMethod(NpcType.Enemy, "slow_enemy", $"{x},{y}");

            enemy.SetMoveAlgorithm(new Stand());

            randomEnemy_1.SetMoveAlgorithm(new Walk());
            randomEnemy_2.SetMoveAlgorithm(new Walk());

            randomEnemy_1.SetAttackAlgorithm(new Melee(randomEnemy_1.AreaId, 5f, 10f));
            randomEnemy_2.SetAttackAlgorithm(new Melee(randomEnemy_2.AreaId, 10f, 10f));

            this.desert.AddNPC(enemy);
            this.desert.AddNPC(randomEnemy_1);
            this.desert.AddNPC(randomEnemy_2);
        }
        
        public override void AddItems()
        {
            var item = ItemsList.GenerateItem();
            item.AreaId = $"{x},{y}";
            this.desert.AddItem(item);
        }
        
        public override void AddObstacles()
        {   
            var obstacleCreator = new ObstacleCreator();
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Passable, "cactus", $"{x},{y}"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Passable, "cactus", $"{x},{y}"));
        }

        public override Area GetProduct()
        {
            DesertArea result = this.desert;
            this.Reset();
            World.Instance.SwapArea(result);
            return result;
        }
    }
}