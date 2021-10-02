namespace SunkiojiDalis {
  public abstract class CommonItemFactory: AbstractItemFactory {
    public override CommonWeapon CreateWeapon() {
      return new CommonWeapon();
    }
    public override CommonArmor CreateArmor() {
      return new CommonArmor();
    }
    public override CommonPotion CreatePotion() {
      return new CommonPotion();
    }
    public override CommonFood CreateFood() {
      return new CommonFood();
    }
  }
}