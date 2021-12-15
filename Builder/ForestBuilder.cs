using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Managers;
using SignalRWebPack.Characters;
using SignalRWebPack.Hubs;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack {
  public class ForestBuilder : Builder {
        private int x;
        private int y;
        private ForestArea area;
        
        public ForestBuilder(int x, int y): base(x, y)
        {
            this.area = new ForestArea(x, y);
            this.x = x;
            this.y = y;
            this.Reset();
        }
        
        public override void Reset()
        {
            this.area = new ForestArea(this.x, this.y);
        }
        
        public override void AddItems()
        {
            var item1 = ItemsList.GenerateItem();
            item1.AreaId = $"{x},{y}";

            var item2 = ItemsList.GenerateItem();
            item2.AreaId = $"{x},{y}";

            var item3 = ItemsList.GenerateItem();
            item3.AreaId = $"{x},{y}";

            var item4 = ItemsList.GenerateItem();
            item4.AreaId = $"{x},{y}";

            this.area.AddItem(item1);
            this.area.AddItem(item2);
            this.area.AddItem(item3);
            this.area.AddItem(item4);
        }
        
        public override void AddObstacles()
        {   
            var obstacleCreator = new ObstacleCreator();
            for(int i = 0; i <= 20; i++) {
                this.area.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "tree1", $"{x},{y}"));
            }
            this.area.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
            this.area.AddObstacle(obstacleCreator.FactoryMethod(ObstacleType.Impassable, "rocks1", $"{x},{y}"));
        }

        public override Area GetProduct()
        {
            ForestArea result = this.area;
            this.Reset();
            World.Instance.SwapArea(result);
            return result;
        }
    }
}