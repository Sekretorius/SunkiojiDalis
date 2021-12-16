using System;
using SignalRWebPack.Managers;

namespace SignalRWebPack.Hubs.Worlds
{
  public class ForestArea: Area {
    public ForestArea(int x, int y): base(x, y) {
      this.background = "resources/backgrounds/forest.png";
    }

    public int CreateFire() {
      Random rnd = new Random();
      return rnd.Next(0, 20);
    }

    public override void Accept(IVisitor visitor) {
      visitor.VisitForestArea(this);
    }
  }
}