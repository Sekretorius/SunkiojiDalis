using System;
using SignalRWebPack.Managers;

namespace SignalRWebPack.Hubs.Worlds
{
  public class DesertArea: Area {
    public DesertArea(int x, int y): base(x, y) {
      this.background = "resources/backgrounds/desert.png";
    }

    public int CreateSandstorm() {
      Random rnd = new Random();
      return rnd.Next(0, 10);
    }

    public override void Accept(IVisitor visitor) {
      visitor.VisitDesertArea(this);
    }
  }
}