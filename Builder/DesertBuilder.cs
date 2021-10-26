using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Managers;
using SignalRWebPack.Character;
using SignalRWebPack.Hubs;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack {
  public class ConcreteBuilder : IBuilder {
        private int x;
        private int y;
        private Area desert = new Area(-1, -1);
        
        public ConcreteBuilder(int x, int y)
        {
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
            var enemy = npcCreator.FactoryMethod(NpcType.Enemy, "lion");
            this.desert.AddNPC(enemy);
        }
        
        public void AddItems()
        {
            this.desert.AddItem(ItemsList.GenerateItem());
        }
        
        public void AddObstacles()
        {   
            var obstacleCreator = new ObstacleCreator();
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1"));
            this.desert.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1"));
        }

        public Area GetProduct()
        {
            Area result = this.desert;
            this.Reset();
            return result;
        }
    }
}