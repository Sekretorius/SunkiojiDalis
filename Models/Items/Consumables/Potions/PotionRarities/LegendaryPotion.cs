using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack{
  public class LegendaryPotion: AbstractPotion {
    public LegendaryPotion(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, string ability) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.BelongsTo = -1;
      this.AreaId = AreaId;
      this.Ability = ability;
    }

    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> legendaryPotionData = base.OnClientSideCreation();
      legendaryPotionData["ability"] = this.Ability;
      legendaryPotionData["objectType"] = nameof(ServerObjectType.LegendaryPotion);
      return legendaryPotionData;
    }
  }
}