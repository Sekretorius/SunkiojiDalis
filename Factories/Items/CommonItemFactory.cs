namespace SunkiojiDalis {
  public class CommonItemFactory: AbstractItemFactory {
    public override CommonWeapon CreateWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int damage) {
      return new CommonWeapon(id, sprite, name, weight, quantity, x, y, damage);
    }
    public override CommonArmor CreateArmor(int id, string sprite, string name, int weight, int quantity, int x, int y, int defense) {
      return new CommonArmor(id, sprite, name, weight, quantity, x, y, defense);
    }
    public override CommonPotion CreatePotion(int id, string sprite, string name, int weight, int quantity, int x, int y, string ability) {
      return new CommonPotion(id, sprite, name, weight, quantity, x, y, ability);
    }
    public override CommonFood CreateFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int health) {
      return new CommonFood(id, sprite, name, weight, quantity, x, y, health);
    }
  }
}