namespace SunkiojiDalis{
  public class CommonPotion: AbstractPotion {
    public CommonPotion(int id, string sprite, string name, int weight, int quantity, int x, int y, string ability) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.Ability = ability;
    }
  }
}