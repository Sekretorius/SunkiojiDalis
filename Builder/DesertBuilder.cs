using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Managers;
using SignalRWebPack.Character;
using SignalRWebPack.Hubs;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack {
  public class DesertBuilder : IBuilder {
        private int x;
        private int y;
        private Area desert;
        
        public DesertBuilder(int x, int y)
        {
            this.desert = new Area(x, y);
            this.x = x;
            this.y = y;
            this.Reset();
        }
        
        public void Reset()
        {
            this.desert = new Area(this.x, this.y);
        }
        
        // All production steps work with the same product instance.
        public void AddNPCs()
        {
            var npcCreator = new NpcCreator();
            var enemy = npcCreator.FactoryMethod(NpcType.Enemy, "lion", $"{x},{y}");
            enemy.SetMoveAlgorithm(new Walk());
            this.desert.AddNPC(enemy);
        }
        
        public void AddItems()
        {
            var item = ItemsList.GenerateItem();
            item.AreaId = $"{x},{y}";
            this.desert.AddItem(item);
        }
        
        public void AddObstacles()
        {   
            var obstacleCreator = new ObstacleCreator();
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
        }

        public Area GetProduct()
        {
            Area result = this.desert;
            this.Reset();
            World.Instance.SwapArea(result);
            return result;
        }
    }
}