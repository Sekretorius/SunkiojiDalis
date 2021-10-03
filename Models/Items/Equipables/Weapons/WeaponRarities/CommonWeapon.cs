namespace SunkiojiDalis{
  public class CommonWeapon: AbstractWeapon {
    public CommonWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int damage) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.Damage = damage;
    }
  }
}