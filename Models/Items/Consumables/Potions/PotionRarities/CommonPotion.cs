using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack{
  public class CommonPotion: AbstractPotion {
    public CommonPotion(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, string ability) {
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
      Dictionary<string, string> commonPotionData = base.OnClientSideCreation();
      commonPotionData["ability"] = this.Ability;
      commonPotionData["objectType"] = nameof(ServerObjectType.CommonPotion);
      return commonPotionData;
    }
  }
}