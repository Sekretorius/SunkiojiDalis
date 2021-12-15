using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Managers;
using SignalRWebPack.Characters;
using SignalRWebPack.Hubs;
using SignalRWebPack.Obstacles;
using System;

namespace SignalRWebPack {
  // Builder template with default implementation.
  public class Builder {
    private int x;
    private int y;
    private DesertArea area;
        
    public Builder(int x, int y) {
      this.area = new DesertArea(x, y);
      this.x = x;
      this.y = y;
      this.Reset();
    }

    public virtual void AddNPCs() {
      var rand = new Random();
      var numberOfNPCs = rand.Next(1, 5);
      for(int i = 0; i < numberOfNPCs; i++) {
        var (npc, type) = RandomNPC.GenerateNPC(x, y);
        npc = RandomNPC.AssignRandomAlgorithms(npc, type);
        this.area.AddNPC(npc);
      }
    }

    public virtual void AddItems() {
      var rand = new Random();
      var numberOfNPCs = rand.Next(1, 5);
      for(int i = 0; i < numberOfNPCs; i++) {
        var item = ItemsList.GenerateItem();
        item.AreaId = $"{x},{y}";
        this.area.AddItem(item);
      }
    }

    public virtual void AddObstacles() {
      var rand = new Random();
      var numberOfNPCs = rand.Next(1, 5);
      for(int i = 0; i < numberOfNPCs; i++) {
        var obstacle = RandomObstacle.GenerateObstacle(x, y);
        this.area.AddObstacle(obstacle);
      }
    }

    public virtual void Reset() {
      this.area = new DesertArea(this.x, this.y);
    }

    public virtual Area GetProduct() {
      DesertArea result = this.area;
      this.Reset();
      World.Instance.SwapArea(result);
      return result;
    }
  }
}