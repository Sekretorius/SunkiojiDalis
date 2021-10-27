using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Managers;
using SignalRWebPack.Characters;
using SignalRWebPack.Hubs;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack {
  public class ForestBuilder : IBuilder {
        private int x;
        private int y;
        private ForestArea forest;
        
        public ForestBuilder(int x, int y)
        {
            this.forest = new ForestArea(x, y);
            this.x = x;
            this.y = y;
            this.Reset();
        }
        
        public void Reset()
        {
            this.forest = new ForestArea(this.x, this.y);
        }
        
        public void AddNPCs()
        {
            var npcCreator = new NpcCreator();
            var enemy1 = npcCreator.FactoryMethod(NpcType.Enemy, "", $"{x},{y}");
            enemy1.SetMoveAlgorithm(new Walk());
            this.forest.AddNPC(enemy1);
            var enemy2 = npcCreator.FactoryMethod(NpcType.Enemy, "", $"{x},{y}");
            enemy2.SetMoveAlgorithm(new Stand());
            this.forest.AddNPC(enemy2);
        }
        
        public void AddItems()
        {
            var item1 = ItemsList.GenerateItem();
            item1.AreaId = $"{x},{y}";

            var item2 = ItemsList.GenerateItem();
            item2.AreaId = $"{x},{y}";

            var item3 = ItemsList.GenerateItem();
            item3.AreaId = $"{x},{y}";

            var item4 = ItemsList.GenerateItem();
            item4.AreaId = $"{x},{y}";

            this.forest.AddItem(item1);
            this.forest.AddItem(item2);
            this.forest.AddItem(item3);
            this.forest.AddItem(item4);
        }
        
        public void AddObstacles()
        {   
            var obstacleCreator = new ObstacleCreator();
            for(int i = 0; i <= 20; i++) {
                this.forest.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "tree1", $"{x},{y}"));
            }
            this.forest.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
            this.forest.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
        }

        public ForestArea GetProduct()
        {
            ForestArea result = this.forest;
            this.Reset();
            World.Instance.SwapArea(result);
            return result;
        }
    }
}