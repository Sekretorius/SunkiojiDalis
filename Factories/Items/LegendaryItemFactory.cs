namespace SunkiojiDalis {
  public class LegendaryItemFactory: AbstractItemFactory {
    public override LegendaryWeapon CreateWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int damage) {
      return new LegendaryWeapon(id, sprite, name, weight, quantity, x, y, damage);
    }
    public override LegendaryArmor CreateArmor(int id, string sprite, string name, int weight, int quantity, int x, int y, int defense) {
      return new LegendaryArmor(id, sprite, name, weight, quantity, x, y, defense);
    }
    public override LegendaryPotion CreatePotion(int id, string sprite, string name, int weight, int quantity, int x, int y, string ability) {
      return new LegendaryPotion(id, sprite, name, weight, quantity, x, y, ability);
    }
    public override LegendaryFood CreateFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int health) {
      return new LegendaryFood(id, sprite, name, weight, quantity, x, y, health);
    }
  }
}