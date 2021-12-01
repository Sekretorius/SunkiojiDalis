using SignalRWebPack.Hubs.Worlds;

namespace SignalRWebPack {
  // Builder template with default implementation.
  public class Builder {
    private int x;
    private int y;
    private TemporaryArea temporaryArea;
        
    public Builder(int x, int y)
    {
      this.temporaryArea = new TemporaryArea(x, y);
      this.x = x;
      this.y = y;
      this.Reset();
    }

    public virtual void AddNPCs() {}
    public virtual void AddItems() {}
    public virtual void AddObstacles() {}

    public virtual void Reset() {
      this.temporaryArea = new TemporaryArea(this.x, this.y);
    }

    public virtual Area GetProduct() {
      TemporaryArea result = this.temporaryArea;
      this.Reset();
      World.Instance.SwapArea(result);
      return result;
    }
  }
}