namespace SunkiojiDalis{
  public class CommonFood: AbstractFood {
    public CommonFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int health) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.Health = health;
    }
  }
}