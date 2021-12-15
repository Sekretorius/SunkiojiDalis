using SignalRWebPack.Hubs.Worlds;

namespace SignalRWebPack {
  public class Director
    {
        private Builder _builder;
        
        public Builder Builder
        {
            set { _builder = value; } 
        }
        
        public void BuildArea()
        {
            this._builder.AddNPCs();
            this._builder.AddItems();
            this._builder.AddObstacles();
            var area = this._builder.GetProduct();
            World.Instance.SwapArea(area);
        }
    }
}