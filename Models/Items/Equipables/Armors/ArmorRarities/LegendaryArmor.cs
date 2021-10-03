namespace SunkiojiDalis{
  public class LegendaryArmor: AbstractArmor {
    public LegendaryArmor(int id, string sprite, string name, int weight, int quantity, int x, int y, int defense) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.Defense = defense;
    }
  }
}