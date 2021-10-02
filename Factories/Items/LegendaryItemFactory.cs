namespace SunkiojiDalis {
  public abstract class LegendaryItemFactory: AbstractItemFactory {
    public override LegendaryWeapon CreateWeapon() {
      return new LegendaryWeapon();
    }
    public override LegendaryArmor CreateArmor() {
      return new LegendaryArmor();
    }
    public override LegendaryPotion CreatePotion() {
      return new LegendaryPotion();
    }
    public override LegendaryFood CreateFood() {
      return new LegendaryFood();
    }
  }
}